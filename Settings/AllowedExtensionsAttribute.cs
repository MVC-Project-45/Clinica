<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;

namespace MVC_Final.Attributes;

public class AllowedExtensionsAttribute : ValidationAttribute
{
    private readonly string _allowedExtensions;

    public AllowedExtensionsAttribute(string allowedExtensions)
    {
        _allowedExtensions = allowedExtensions;
    }

    protected override ValidationResult? IsValid
        (object? value, ValidationContext validationContext)
    {
        var file = value as IFormFile;
        
        if(file is not null)
        {
            var extension = Path.GetExtension(file.FileName);

            var isAllowed = _allowedExtensions.Split(',').Contains(extension, StringComparer.OrdinalIgnoreCase);

            if (!isAllowed)
            {
                return new ValidationResult($"Only {_allowedExtensions} are allowed!");
            }
        }

        return ValidationResult.Success;
    }
=======
﻿using System.ComponentModel.DataAnnotations;

namespace MVC_Final.Attributes;

public class AllowedExtensionsAttribute : ValidationAttribute
{
    private readonly string _allowedExtensions;

    public AllowedExtensionsAttribute(string allowedExtensions)
    {
        _allowedExtensions = allowedExtensions;
    }

    protected override ValidationResult? IsValid
        (object? value, ValidationContext validationContext)
    {
        var file = value as IFormFile;
        
        if(file is not null)
        {
            var extension = Path.GetExtension(file.FileName);

            var isAllowed = _allowedExtensions.Split(',').Contains(extension, StringComparer.OrdinalIgnoreCase);

            if (!isAllowed)
            {
                return new ValidationResult($"Only {_allowedExtensions} are allowed!");
            }
        }

        return ValidationResult.Success;
    }
>>>>>>> b905b14e014d082ee4d3e4a1db7d5c994c74a9c2
}