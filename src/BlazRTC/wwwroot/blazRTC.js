class BlazMediaDevice {
    async getConnectedDevices() {
        await navigator.mediaDevices.getUserMedia({ audio: true, video: true });
        const devices = await navigator.mediaDevices.enumerateDevices();
        const connectedDevices = devices
            .filter(device => device.kind !== "other")
            .map(device => {
                console.log("device", device);
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

    async getMediaStream(options) {
        console.info("options", options);
        //build constraints object from the options for all the possible values
        const constraints = {
            video: {
                frameRate: options.frameRate,
                width: { min: 480, ideal: 720, max: 1280 },
                aspectRatio: options.aspectRatio,
            }, audio: true
        };
        const stream = await navigator.mediaDevices.getUserMedia(constraints);
        if (stream && options.previewStreamIn) {
            const videoElement = document.getElementById(options.previewStreamIn);
            videoElement.srcObject = stream;
            videoElement.muted = options.muted;
        }
    }

    stopMediaStream(streamElementId) {
        if (!streamElementId) return;
        const videoElement = document.getElementById(streamElementId);
        console.info("videoElement", videoElement);
        if (videoElement.srcObject) {
            const stream = videoElement.srcObject;
            const tracks = stream.getTracks();
            tracks.forEach(track => track.stop());
        }
        //videoElement.removeAttribute("src");
        //videoElement.removeAttribute("srcObject");
    }
}

window.blazMediaDevice = new BlazMediaDevice();