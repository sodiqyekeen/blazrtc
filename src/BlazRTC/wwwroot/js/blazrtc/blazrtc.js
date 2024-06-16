import { BlazMediaDevice } from "./mediaDevice";
import { BlazRtcPeerConnection } from "./peerConnection";

class BlazRTC {
    constructor() {
        this.mediaDevices = new BlazMediaDevice();
        this.peerConnection = {};
        this.mediaStreams = {
            streams: [],

            addStream: function (blazMediaStream) {
                if (blazMediaStream) {
                    this.streams.push(blazMediaStream);
                }
            },
            getStream: function (streamId) {
                return this.streams.find(stream => stream.id === streamId);
            },

            registerEvents: (streamId, dotNetReference) => {
                const mediaStream = this.getStream(streamId);
                if (mediaStream) {
                    mediaStream.stream.registerEventHandlers(dotNetReference);
                }
            },

            getAudioTracks: function (streamId) {
                const mediaStream = this.getStream(streamId);
                if (mediaStream) {
                    return mediaStream.stream.getAudioTracks();
                }
            },

            getVideoTracks: function (streamId) {
                const mediaStream = this.getStream(streamId);
                if (mediaStream) {
                    return mediaStream.stream.getVideoTracks();
                }
            },

            getTrackById: function (streamId, trackId) {
                const mediaStream = this.getStream(streamId);
                if (mediaStream) {
                    return mediaStream.stream.getTrackById(trackId);
                }
            },

            getTracks: function (streamId) {
                const mediaStream = this.getStream(streamId);
                if (mediaStream) {
                    return mediaStream.stream.getTracks();
                }
            },

            registerTrackEvents: function (streamId, trackId, dotNetReference) {
                const mediaStream = this.getStream(streamId);
                if (!mediaStream) return;
                const track = mediaStream.stream.getTrackById(trackId);
                if (track) {
                    track.registerEventHandlers(dotNetReference);
                }

            }

        };
    }

    initialisePeerConnection(configuration, dotNetReference) {
        this.peerConnection = new BlazRtcPeerConnection(configuration, dotNetReference);
    }
}

window.blazRTC = new BlazRTC();