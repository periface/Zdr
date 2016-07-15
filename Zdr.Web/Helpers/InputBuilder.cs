using System;
using System.Web;

namespace Zdr.Web.Helpers
{
    public static class InputBuilder
    {
        public static T BuildInputByRequest<T>(HttpRequestBase request, string prefix = "")
        {
            //Get type
            var obj = typeof(T);
            //Create a new instance of type
            var instance = (T)Activator.CreateInstance(typeof(T));
            //Look for all properties in the type
            foreach (var props in obj.GetProperties())
            {
                //Get the name of the property
                var prop = props.Name;

                var propertyInfo = obj.GetProperty(props.Name);
                //Create a new property info
                string stringValue;
                if (string.IsNullOrEmpty(prefix))
                {
                    stringValue = request.Params.Get(prop);
                }
                else
                {
                    var propertyName = prefix + "[" + props.Name + "]";
                    stringValue = request.Params.Get(propertyName);
                }

                //Gets the string value from the request params based on the property name


                //If its empty just ignore it
                if (stringValue == null) continue;

                //Gets the first value
                var value = stringValue;
                try
                {
                    if (propertyInfo.PropertyType == typeof(Guid))
                    {
                        var convertedGuid = Guid.Parse(value);
                        //Tries to convert the value type to the required value type for the generic object
                        propertyInfo.SetValue(instance, convertedGuid, null);
                    }
                    else
                    {
                        var convertedValue = Convert.ChangeType(value, propertyInfo.PropertyType);
                        //Tries to convert the value type to the required value type for the generic object
                        propertyInfo.SetValue(instance, convertedValue, null);
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            return instance;
        }
    }
}
