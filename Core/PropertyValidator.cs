using System.ComponentModel.DataAnnotations;
using System.Reflection;
#nullable disable

namespace AllAboutGames.Core
{
    public class PropertyValidator
    {
        public static CheckResult Validate(object @object)
        {
            var check = new CheckResult();

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
                    check.AddError(validation.Attribute.FormatErrorMessage(string.Empty));
                }
            }

            return check;
        }
    }//end class

    public class ValidationClass
    {
        public PropertyInfo Property { get; set; }

        public ValidationAttribute Attribute { get; set; }
    }
}
