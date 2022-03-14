using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AllAboutGames.Core
{
    public class PropertyValidator
    {
        public static bool Validate(object @object, Action<List<string>> onError)
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

            if (errors.Count > 0)
            {
                onError?.Invoke(errors);
                return false;
            }

            return true;
        }
    }//end class
}
