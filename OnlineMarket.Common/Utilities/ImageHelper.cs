using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OnlineMarket.Common.Utilities
{
    public class ImageHelper
    {

        public static byte[] GetImageBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes;
            using (var binaryReader = new BinaryReader(image.InputStream))
            {
                imageBytes = binaryReader.ReadBytes(image.ContentLength);
            }
            return imageBytes;
        }

    }
}

