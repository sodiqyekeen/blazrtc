import { BlazMediaStreamTrack } from './mediaStreamTrack.js';

export class BlazMediaStream {
    constructor(stream) {
        this.source = stream;
        this.id = stream.id;
        this.tracks = [];

        this.source.getTracks().forEach(track => {
            this.tracks.push(new BlazMediaStreamTrack(track));
        });
    }

    registerEventHandlers(dotNetReference) {
        this.source.onaddtrack = (event) => {
            console.log("Track Added: ", event);
            dotNetReference.invokeMethodAsync('RaiseOnTrackAdded', event);
        };

        this.source.onremovetrack = (event) => {
            console.log("Track Removed: ", event);
            dotNetReference.invokeMethodAsync('RaiseOnTrackRemoved', event);
        };
    }

    getAudioTracks() {
        return this.tracks.filter(track => track.kind === 'audio');
    }

    getVideoTracks() {
        return this.tracks.filter(track => track.kind === 'video');
    }

    getTrackById(trackId) {
        return this.tracks.find(track => track.id === trackId);
    }

    getTracks() {
        return this.tracks;
    }
}