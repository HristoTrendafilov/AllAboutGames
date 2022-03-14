using System.ComponentModel.DataAnnotations;
using System.Reflection;
#nullable disable

namespace AllAboutGames.Core
{
    public class PropertyValidator
    {
        public static (bool isValid, List<string> errors) Validate(object @object)
        {
            if (@object == null)
            {
                throw new ArgumentNullException(nameof(@object));
            }

            var errors = new List<string>();

            var attributes = from prop in @object.GetType().GetProperties()
                             from attribute in prop.GetCustomAttributes(typeof(ValidationAttribute), true).Cast<ValidationAttribute>()
                             select new Tuple<PropertyInfo, ValidationAttribute>(prop, attribute);

            foreach (var item in attributes)
            {
                if (!item.Item2.IsValid(item.Item1.GetValue(@object, null)))
                {
                    errors.Add(item.Item2.FormatErrorMessage(string.Empty));
                }
            }

            return errors.Count > 0 ? (false, null) : (true, errors);
        }
    }//end class
}
