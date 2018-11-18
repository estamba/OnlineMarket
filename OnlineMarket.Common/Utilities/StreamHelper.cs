using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Common.Utilities
{
    public static class StreamHelper
    {
        public static byte[] ToByteArray(this Stream stream)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                stream.CopyTo(memory);
                return memory.ToArray();
            }
        }
        public static async Task<byte[]> ToByteArrayAsync(this Stream stream)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                await stream.CopyToAsync(memory);
                return memory.ToArray();
            }
        }
    }
}
