using System;

namespace ScapeChecker.Net.Models
{
    public enum SizeUnit
    {
        // ReSharper disable InconsistentNaming
        B,
        KB,
        MB,
        GB,
        TB,
        // ReSharper restore InconsistentNaming
    }

    public static class SizeUnitHelper
    {
        private const ulong OneKb = 1024;
        private const ulong OneMb = OneKb * 1024;
        private const ulong OneGb = OneMb * 1024;
        private const ulong OneTb = OneGb * 1024;

        public static ulong AsBytes(SizeUnit unit, uint size)
        {
            switch (unit)
            {
                case SizeUnit.B:
                    return size;
                case SizeUnit.KB:
                    return OneKb* size;
                case SizeUnit.MB:
                    return size * OneMb;
                case SizeUnit.GB:
                    return size * OneGb;
                case SizeUnit.TB:
                    return size * OneTb;
            }

            return 0;
        }

        public static string ToPrettySize(this ulong value)
        {
            var asTb = Math.Round((decimal) value / OneTb, 2);
            if (asTb >= 1)
            {
                return $"{asTb}TB";
            }

            var asGb = Math.Round((decimal) value / OneGb, 2);
            if (asGb >= 1)
            {
                return $"{asGb}GB";
            }

            var asMb = Math.Round((decimal) value / OneMb, 2);
            if (asMb >= 1)
            {
                return $"{asMb}MB";
            }

            var asKb = Math.Round((decimal) value / OneKb, 2);
            if (asKb >= 1)
            {
                return $"{asKb}KB";
            }

            return $"{value}B";
        }
    }
}