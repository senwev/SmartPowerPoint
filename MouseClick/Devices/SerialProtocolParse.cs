using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace MouseClick.Devices
{
    public class SerialProtocolParseHelper
    {
        public static long[] Parse(byte[] payload)
        {
            int cursor = 0;
            string prefix1 = Encoding.Default.GetString(payload, cursor, 2);
            if (prefix1 != "mc")
            {
                return null;
            }
            cursor += 2;
            var num = payload.Skip(cursor).Take(3);
            cursor += 3;
            var datas = new long[4];
            for (int i = 0; i < 4; i++)
            {
                cursor += 1;
                var slice = Encoding.Default.GetString(payload.Skip(cursor).Take(8).ToArray());
                var arr = strToToHexByte(slice);//BitConverter.ToUInt32(slice.ToArray(), 0);//BitConverter.ToUInt64(slice.Reverse().ToArray(), 0);
                var x = BitConverter.ToUInt32(arr.Reverse().ToArray(), 0);
                if ((x & 0xfffff000) == 0xfffff000)
                {
                    datas[i] = 0L - (0xffffffffU - x + 1);//ConvertToUInt(slice.ToArray());
                }
                else
                {
                    datas[i] = x;
                }
                cursor += 8;
            }
            return datas;
        }

        private static ulong StringToULong(byte[] data)
        {
            ulong result = 0;
            var list = new List<byte>();
            foreach (var x in data)
            {
                if (x > 57)
                {
                    list.Add((byte)(x - 'a' + 10));
                }
                else
                {
                    list.Add((byte)(x - '0'));
                }
            }
            var l = new List<byte>();
            for (int i = 0; i < list.Count;)
            {
                var temp = list[i] * 16 + list[i + 1];
                l.Add((byte)temp);
                i += 2;
            }
            l.Reverse();
            result = BitConverter.ToUInt32(l.ToArray(), 0);
            return result;
        }

        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        public static string ToHexString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            if (bytes != null || bytes.Length < 0)
            {
                foreach (var item in bytes)
                {
                    sb.Append(string.Format("{0:X2} ", item));
                }
            }
            return sb.ToString();
        }

    }
}
