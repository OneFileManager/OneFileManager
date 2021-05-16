using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneFileManager.Utils
{
    class DiskUtil
    {
        public static bool CheckBitLockerIsOn(string disk)
        {
            IShellProperty prop = ShellObject.FromParsingName(disk).Properties.GetProperty("System.Volume.BitLockerProtection");
            int? bitLockerProtectionStatus = (prop as ShellProperty<int?>).Value;

            if (bitLockerProtectionStatus.HasValue && (bitLockerProtectionStatus == 1 || bitLockerProtectionStatus == 3 || bitLockerProtectionStatus == 5))
                return true;
            else
                return false;
        }
    }
}
