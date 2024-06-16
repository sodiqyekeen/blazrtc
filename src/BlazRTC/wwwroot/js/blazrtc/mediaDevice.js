import { BlazMediaStream } from "./mediaStream";
export class BlazMediaDevice {
    constructor() {
        this.localStreamId = null;
        this.mediaStreams = [];
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

    async getUserMedia(constraints, previewStreamIn, dotNetReference) {
        try {
            const stream = await navigator.mediaDevices.getUserMedia(constraints);
            if (!stream) {
                console.error("No stream found");
                return;
            }
            const blazMediaStream = new BlazMediaStream(stream);
            window.blazRTC.mediaStreams.addStream({ id: stream.id, stream: blazMediaStream });
            if (previewStreamIn) {
                this.localStreamId = previewStreamIn;
                this.showMediaStream(stream, previewStreamIn, true);
            }

            return blazMediaStream;

        } catch (error) {
            console.error("Error occurred while accessing media devices", error);
        }
    }

    showMediaStream(stream, streamElementId, muted) {
        if (!stream || !streamElementId) return;
        const videoElement = document.getElementById(streamElementId);
        if (!videoElement) return;
        videoElement.srcObject = stream;
        videoElement.muted = muted;
        videoElement.style.transform = "scaleX(-1)";
    }

    stopMediaStream(streamElementId) {
        if (!streamElementId) return;
        const videoElement = document.getElementById(streamElementId);
        if (videoElement.srcObject) {
            const stream = videoElement.srcObject;
            const tracks = stream.getTracks();
            tracks.forEach(track => track.stop());
            videoElement.src = null;
        }
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

