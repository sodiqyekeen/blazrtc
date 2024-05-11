class BlazMediaDevice {
    constructor() {
        this.mediaStream = null;
        this.localStreamId = null;
    }

    async ensureMediaPermissions() {
        const hasCameraPermission = await navigator.permissions.query({ name: 'camera' });
        const hasMicrophonePermission = await navigator.permissions.query({ name: 'microphone' });

        if (hasCameraPermission.state !== 'granted' || hasMicrophonePermission.state !== 'granted') {
            await navigator.mediaDevices.getUserMedia({ audio: true, video: true });
        }
    }

    async getConnectedDevices() {
        await this.ensureMediaPermissions();
        const devices = await navigator.mediaDevices.enumerateDevices();
        const connectedDevices = devices
            .filter(device => device.kind !== "other")
            .map(device => {
                return {
                    deviceId: device.deviceId || "",
                    kind: device.kind || "",
                    label: device.label || "",
                    groupId: device.groupId || ""
                };
            });
        return connectedDevices;
    }

    async handleDeviceChange(dotNetReference) {
        const devices = await this.getConnectedDevices();
        dotNetReference.invokeMethodAsync('RaiseOnDeviceChange', devices);
    }

    listenForDeviceChanges(dotNetReference) {
        navigator.mediaDevices.addEventListener('devicechange', () => {
            this.handleDeviceChange(dotNetReference);
        });
    }

    cancelDeviceChangeListener() {
        navigator.mediaDevices.removeEventListener('devicechange');
    }

    async getMediaStream(constraints, previewStreamIn, dotNetReference) {
        navigator.mediaDevices.getUserMedia(constraints)
            .then(stream => {
                if (!stream) {
                    console.error("No stream found");
                    return;
                }
                this.mediaStream = stream;
                if (previewStreamIn) {
                    this.localStreamId = previewStreamIn;
                    this.showMediaStream(stream, previewStreamIn, true);
                }
                dotNetReference.invokeMethodAsync('RaiseOnMediaStreamAvailable', stream.id);
            })
            .catch(err => {
                console.error("Error occurred while accessing media devices", err);
            });
    }

    showMediaStream(stream, streamElementId, muted) {
        if (!stream || !streamElementId) return;
        const videoElement = document.getElementById(streamElementId);
        if (!videoElement) return;
        videoElement.srcObject = stream;
        videoElement.muted = muted;
    }

    stopMediaStream(streamElementId) {
        if (!streamElementId) return;
        const videoElement = document.getElementById(streamElementId);
        if (videoElement.srcObject) {
            const stream = videoElement.srcObject;
            const tracks = stream.getTracks();
            tracks.forEach(track => track.stop());
            videoElement.srcObject = null;
            videoElement.removeAttribute("src");
        }
        //videoElement.removeAttribute("src");
        //videoElement.removeAttribute("srcObject");
    }

    toggleVideoTrack() {
        if (!this.mediaStream) return;
        this.mediaStream.getVideoTracks().forEach(track => {
            track.enabled = !track.enabled;
        });
    }

    toggleAudioTrack() {
        if (!this.mediaStream) return;
        this.mediaStream.getAudioTracks().forEach(track => {
            track.enabled = !track.enabled;
        });
    }

    dispose() {
        if (this.mediaStream) {
            this.mediaStream.getTracks().forEach(track => track.stop());
            this.mediaStream = null;
        }
        this.localStreamId = null;
    }
}

window.blazMediaDevice = new BlazMediaDevice();