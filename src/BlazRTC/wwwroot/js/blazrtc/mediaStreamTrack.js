
export class BlazMediaStreamTrack {
    constructor(track) {
        this.track = track;
        //track properties to expose to C# class
        this.id = track.id;
        this.kind = track.kind;
        this.label = track.label;

    }

    getCapabilities() {
        return this.track.getCapabilities();
    }

    getConstraints() {
        return this.track.getConstraints();
    }

    getSettings() {
        return this.track.getSettings();
    }

    applyConstraints(constraints) {
        return this.track.applyConstraints(constraints);
    }

    stop() {
        this.track.stop();
    }

    registerEventHandlers(dotNetReference) {
        this.track.onmute = (event) => {
            console.log("Track Muted: ", event);
            dotNetReference.invokeMethodAsync('RaiseOnTrackMuted', event);
        };

        this.track.onunmute = (event) => {
            console.log("Track Unmuted: ", event);
            dotNetReference.invokeMethodAsync('RaiseOnTrackUnmuted', event);
        };

        this.track.onended = (event) => {
            console.log("Track Ended: ", event);
            dotNetReference.invokeMethodAsync('RaiseOnTrackEnded', event);
        };
    }
}