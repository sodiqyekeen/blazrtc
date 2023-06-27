export async function getMediaDevices() {
    try {
        const devices = await navigator.mediaDevices.enumerateDevices();
        console.info("devices", devices);
        const connectedDevices = devices
            .filter(device => device.kind !== "other")
            .map(device => {
                return {
                    deviceId: device.deviceId,
                    kind: device.kind,
                    label: device.label
                };
            })
        console.info("connectedDevices", connectedDevices);

        //Set random device id and label where empty
        connectedDevices.forEach(device => {
            if (device.deviceId === "") {
                device.deviceId = Math.random().toString(36).substring(2, 11);
            }
            if (device.label === "") {
                device.label = device.kind + "-" + device.deviceId;
            }
        });

        return {
            succeeded: true,
            data: connectedDevices
        };;
    } catch (error) {
        console.error("error:", error);
        return {
            succeeded: false,
            data: [],
            error: error
        };
    }
}
