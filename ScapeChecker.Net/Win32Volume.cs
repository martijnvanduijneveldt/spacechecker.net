using System;
using System.Management;

namespace ScapeChecker.Net
{
    public class Win32Volume
    {
        public Win32Volume(ManagementBaseObject baseObject)
        {
            if (baseObject.ClassPath.ClassName != "Win32_Volume")
            {
                throw new Exception("Wrong type");
            }

            foreach (var item in baseObject.Properties)
            {
                typeof(Win32Volume).GetProperty(item.Name)
                    .SetValue(this, item.Value, null);
            }
        }

        // ReSharper disable InconsistentNaming
        public ushort Access { get; private set; }
        public bool Automount { get; private set; }
        public ushort Availability { get; private set; }
        public ulong BlockSize { get; private set; }
        public bool BootVolume { get; private set; }
        public ulong Capacity { get; private set; }
        public string Caption { get; private set; }
        public bool Compressed { get; private set; }
        public uint ConfigManagerErrorCode { get; private set; }
        public bool ConfigManagerUserConfig { get; private set; }
        public string CreationClassName { get; private set; }
        public string Description { get; private set; }
        public string DeviceID { get; private set; }
        public bool DirtyBitSet { get; private set; }
        public string DriveLetter { get; private set; }
        public uint DriveType { get; private set; }
        public bool ErrorCleared { get; private set; }
        public string ErrorDescription { get; private set; }
        public string ErrorMethodology { get; private set; }
        public string FileSystem { get; private set; }
        public ulong FreeSpace { get; private set; }
        public bool IndexingEnabled { get; private set; }
        public DateTime InstallDate { get; private set; }
        public string Label { get; private set; }
        public uint LastErrorCode { get; private set; }
        public uint MaximumFileNameLength { get; private set; }
        public string Name { get; private set; }
        public ulong NumberOfBlocks { get; private set; }
        public bool PageFilePresent { get; private set; }
        public string PNPDeviceID { get; private set; }
        public ushort PowerManagementCapabilities { get; private set; }
        public bool PowerManagementSupported { get; private set; }
        public string Purpose { get; private set; }
        public bool QuotasEnabled { get; private set; }
        public bool QuotasIncomplete { get; private set; }
        public bool QuotasRebuilding { get; private set; }
        public uint SerialNumber { get; private set; }
        public string Status { get; private set; }
        public ushort StatusInfo { get; private set; }
        public bool SupportsDiskQuotas { get; private set; }
        public bool SupportsFileBasedCompression { get; private set; }
        public string SystemCreationClassName { get; private set; }
        public string SystemName { get; private set; }
        public bool SystemVolume { get; private set; }
        // ReSharper restore InconsistentNaming
    }
}