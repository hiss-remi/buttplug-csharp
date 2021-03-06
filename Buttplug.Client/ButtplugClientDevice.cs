using System.Collections.Generic;
using Buttplug.Core;
using Buttplug.Core.Messages;
using JetBrains.Annotations;

namespace Buttplug.Client
{
    /// <summary>
    /// The Buttplug Client representation of a Buttplug Device connected to a server.
    /// </summary>
    public class ButtplugClientDevice
    {
        /// <summary>
        /// The device index, which uniquely identifies the device on the server.
        /// </summary>
        /// <remarks>
        /// If a device is removed, this may be the only populated field. If the same device
        /// reconnects, the index should be reused.
        /// </remarks>
        public readonly uint Index;

        /// <summary>
        /// The device name, which usually contains the device brand and model.
        /// </summary>
        [NotNull]
        public readonly string Name;

        /// <summary>
        /// The Buttplug Protocol messages supported by this device, with additional attributes.
        /// </summary>
        [NotNull]
        public readonly Dictionary<string, MessageAttributes> AllowedMessages;

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtplugClientDevice"/> class, using
        /// information received via a DeviceList, DeviceAdded, or DeviceRemoved message from the server.
        /// </summary>
        /// <param name="aDevInfo">
        /// A Buttplug protocol message implementing the IButtplugDeviceInfoMessage interface.
        /// </param>
        public ButtplugClientDevice(IButtplugDeviceInfoMessage aDevInfo)
           : this(aDevInfo.DeviceIndex, aDevInfo.DeviceName, aDevInfo.DeviceMessages)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtplugClientDevice"/> class, using
        /// discrete parameters.
        /// </summary>
        /// <param name="aIndex">The device index.</param>
        /// <param name="aName">The device name.</param>
        /// <param name="aMessages">The device allowed message list, with corresponding attributes.</param>
        public ButtplugClientDevice(uint aIndex, string aName, Dictionary<string, MessageAttributes> aMessages)
        {
            Index = aIndex;
            Name = aName;
            AllowedMessages = aMessages;
        }
    }
}
