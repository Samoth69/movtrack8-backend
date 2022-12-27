using System.ComponentModel.DataAnnotations;

namespace movtrack8_backend.Utils
{
    /// <summary>
    /// TODO
    /// </summary>
    sealed public class RequiredIfFalse : ValidationAttribute
    {
        private readonly string _propertyName;
        public RequiredIfFalse(string propertyName)
        {
            _propertyName = propertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_propertyName);
            if (property == null)
            {
                return new ValidationResult($"Unknown property: {_propertyName}");
            }

            var propertyValue = property.GetValue(validationContext.ObjectInstance, null);
            if (propertyValue == null)
            {
                return new ValidationResult($"Property {_propertyName} is null");
            }

            if (propertyValue is bool val)
            {
                // si _propertyName est vrai, on effectue les vérifications de base
                // sinon, on ne fait rien
                if (val)
                {
                    return base.IsValid(value, validationContext);
                }
            }
            else
            {
                return new ValidationResult($"Property {_propertyName} is not a boolean");
            }

            return null;
        }
    }
}
