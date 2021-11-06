using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vanara.PInvoke;
using static Vanara.PInvoke.NetApi32;

namespace OneFileManager.FileSystem
{
    public class GetNetShares
    {
   

      
        public SHARE_INFO_502[] EnumNetShares(string server)
        {
            List<SHARE_INFO_502> ShareInfos = new List<SHARE_INFO_502>();
            uint entriesread = 0;
            uint totalentries = 0;
            uint resume_handle = 0;
            uint prefmaxlen=5;
            int nStructSize = Marshal.SizeOf(typeof(SHARE_INFO_502));
          
            SafeNetApiBuffer bufptr=new SafeNetApiBuffer(IntPtr.Zero);
          
            Win32Error ret = NetShareEnum(server, 502,out bufptr, MAX_PREFERRED_LENGTH,out entriesread,out totalentries,ref resume_handle);
            if (ret == Win32Error.ERROR_SUCCESS)
            {
                IntPtr currentPtr = bufptr.DangerousGetHandle();
                for (int i = 0; i < entriesread; i++)
                {
                    SHARE_INFO_502 shi502 = (SHARE_INFO_502)Marshal.PtrToStructure(currentPtr, typeof(SHARE_INFO_502));
                    ShareInfos.Add(shi502);
                    currentPtr += nStructSize;
                }
                NetApiBufferFree(bufptr.DangerousGetHandle());
                return ShareInfos.ToArray();
            }
            else
            {
              
                return ShareInfos.ToArray();
            }
        }
    }
}