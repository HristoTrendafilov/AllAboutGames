using System.ComponentModel.DataAnnotations;
using System.Reflection;
#nullable disable

namespace AllAboutGames.Core
{
    public class PropertyValidator
    {
        public static (bool isValid, List<string> errors) Validate(object @object)
        {
            var errors = new List<string>();

            var validations = from property in @object.GetType().GetProperties()
                             from attribute in property.GetCustomAttributes(typeof(ValidationAttribute), true).Cast<ValidationAttribute>()
                             select new ValidationClass
                             {
                                 Property = property,
                                 Attribute = attribute
                             };

            foreach (var validation in validations)
            {
                if (!validation.Attribute.IsValid(validation.Property.GetValue(@object, null)))
                {
                    errors.Add(validation.Attribute.FormatErrorMessage(string.Empty));
                }
            }

            return errors.Count > 0 ? (false, null) : (true, errors);
        }
    }//end class

    public class ValidationClass
    {
        public PropertyInfo Property { get; set; }

        public ValidationAttribute Attribute { get; set; }
    }
}
