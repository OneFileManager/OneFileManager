using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFileManager.Security
{
   public class HexUtil
    {
        public  static  string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            foreach(byte b in data)
            {
                sb.Append(((int)b).ToString("X2"));
            }
            return sb.ToString().ToUpper();
        }
        public  static  byte[] HexStrTobyte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Trim(), 16);
            return returnBytes;
        }
    }
}
