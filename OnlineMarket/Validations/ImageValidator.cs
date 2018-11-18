using System;
using System.Collections.Generic;
using System.Linq;
using OnlineMarket.Models;
using System.Web;
using System.IO;

namespace OnlineMarket.Validations
{
    public class ImageValidator
    {
        static List<string>supportedExtensions;
        static long maxImageSizeInBytes;
        static ImageValidator()
        {
            supportedExtensions = new List<string>
            {
                ".jpeg",
                ".png",
                ".jpg"
            };
            maxImageSizeInBytes = 5242880;//5MB
        }

        HttpPostedFileBase image;
        public ImageValidator(HttpPostedFileBase image)
        {
            this.image = image;
        }
        public static ValidationResult Validate(HttpPostedFileBase image)
        {
            ValidationResult result = new ValidationResult();
            result.isSuccess = true;

            if (!isExtensionSupported(Path.GetExtension(image.FileName)))
            {
                result.isSuccess = false;
                result.message = "unsupported file format";
            }
            
            if(!isImageSizeInAcceptedRange(image.ContentLength))
            {
                result.isSuccess = false;
                result.message = "image shouldn't be more than 5MB";
            }
            return result;
        }
        private static bool isExtensionSupported(string extension)
        {
           return supportedExtensions.Any(x => x == extension.ToLower());

        }
        private  static bool isImageSizeInAcceptedRange(long imageSizeInBytes)
        {

            return imageSizeInBytes <= maxImageSizeInBytes;

        }

    }
}