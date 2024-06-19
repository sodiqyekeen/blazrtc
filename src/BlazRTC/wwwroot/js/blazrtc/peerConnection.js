export class BlazRtcPeerConnection {
    constructor(configuration, dotNetReference, mediaStreams) {
        this.peerConnection = new RTCPeerConnection(configuration);
        this.dotNetReference = dotNetReference;
        this.localStreamId = null;
        this.remoteStreamId = null;
        this.mediaStreams = mediaStreams;

        this.peerConnection.onicecandidate = (event) => {
            if (event.candidate) {
                console.log("Ice Candidate: ", event.candidate);
                dotNetReference.invokeMethodAsync('RaiseOnIceCandidate', event.candidate);
            }
        };

        this.peerConnection.oniceconnectionstatechange = (event) => {
            console.log("Ice Connection State: ", this.peerConnection.iceConnectionState);
            dotNetReference.invokeMethodAsync('RaiseOnIceConnectionStateChange', this.peerConnection.iceConnectionState);
        };

        // this.peerConnection.onnegotiationneeded = this.createOffer;

        this.peerConnection.ontrack = (event) => {
            console.log("Track: ", event);
            this.remoteStreamId = event.streams[0].id;
            dotNetReference.invokeMethodAsync('RaiseOnRemoteStreamAvailable', this.remoteStreamId);
        };

        this.peerConnection.onconnectionstatechange = (event) => {
            console.log("Connection State: ", this.peerConnection.connectionState);
            dotNetReference.invokeMethodAsync('RaiseOnConnectionStateChange', this.peerConnection.connectionState);
        };
    }

    async createOffer(localStreamId) {
        if (!this.peerConnection) {
            console.debug("Peer Connection is not available");
            return;
        }
        if (localStreamId) {
            this.addstream(localStreamId);
        }
        const offer = await this.peerConnection.createOffer();
        await this.peerConnection.setLocalDescription(offer);
        console.log("Offer: ", offer);
        return offer;
    }

    async createAnswer(offer) {
        if (!this.peerConnection || !offer) {
            console.debug("Peer Connection or Offer is not available");
            return;
        }
        await this.peerConnection.setRemoteDescription(offer);
        const answer = await this.peerConnection.createAnswer();
        await this.peerConnection.setLocalDescription(answer);
        this.dotNetReference.invokeMethodAsync('RaiseOnAnswerAvailable', answer);
    }

    async addIceCandidate(candidate) {
        if (candidate) {
            await this.peerConnection.addIceCandidate(candidate);
        }
    }

    getStreamById(streamId) {
        return this.mediaStreams.getStream(streamId).source;
    }

    addstream(streamId) {
        const stream = this.getStreamById(streamId);
        if (stream) {
            stream.getTracks().forEach(track => {
                this.peerConnection.addTrack(track, stream);
            });
            this.localStreamId = streamId;
        }
    }

    dispose() {
        if (this.peerConnection) {
            this.peerConnection.close();
            this.peerConnection = null;
        }
        this.localStreamId = null;
        this.remoteStreamId = null;
        this.dotNetReference = null;
    }

}