using System.ComponentModel.DataAnnotations;
using ExpressiveAnnotations.Attributes;

namespace ExpressiveAnnotations.MvcWebSample.Inheritance
{
    public class CustomRequiredIfAttribute: ExpressiveAttribute
    {
        public bool AllowEmptyStrings { get; set; }

        public CustomRequiredIfAttribute(string expression)
            : base(expression, "The {0} field is conditionally required.") // this default message will be overriden by resources
        {
            AllowEmptyStrings = false;
            ErrorMessageResourceType = typeof(Resources);
            ErrorMessageResourceName = "CustomizedRequiredIfDefaultError";
        }

        protected override ValidationResult IsValidInternal(object value, ValidationContext validationContext)
        {
            if ((PropertyType != null) && (PropertyType.Name == "String") && AllowEmptyStrings) {
                return ValidationResult.Success;
            } 
            else if (value == null) 
            {
                Compile(validationContext.ObjectType);
                if (CachedValidationFuncs[validationContext.ObjectType](validationContext.ObjectInstance)) // check if the requirement condition is satisfied
                    return new ValidationResult( // requirement confirmed => notify
                        FormatErrorMessage(validationContext.DisplayName, Expression, validationContext.ObjectInstance),
                        new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }
}
