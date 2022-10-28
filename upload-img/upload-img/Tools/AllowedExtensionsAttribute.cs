using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace upload_img.Tools
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;
        public new string ErrorMessage { get; set; } = "The file \"{}\" is not allowed!";
        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            if (value is IEnumerable<IFormFile>)
            {
                var files = value as IEnumerable<IFormFile>;
                List<string> errors = new List<string>();
                foreach (var file in files)
                {
                    bool isFileValid = ValidateFileExtension(file);
                    if (!isFileValid)
                    {
                        errors.Add(file.FileName);
                    }
                }

                if (errors.Count > 0)
                    return new ValidationResult(ErrorMessage.Replace("{}", string.Join(", ", errors)));

            }
            else if (value is IFormFile)
            {
                var file = value as IFormFile;
                bool isFileValid = ValidateFileExtension(file);
                if (!isFileValid)
                    return new ValidationResult(ErrorMessage.Replace("{}", file.FileName));
            }

            return ValidationResult.Success;
        }

        protected bool ValidateFileExtension(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            if (_extensions.Contains(extension.ToLower()))
                return true;
            else
                return false;
        }
    }
}
