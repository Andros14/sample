using System;
using System.ComponentModel;

namespace GeneralExtensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Indicates whether the specified object is null.
        /// </summary>
        /// <param name="value">The object to check.</param>
        /// <returns>true if the value parameter is null; otherwise, false.</returns>
        public static bool IsNull(this object value)
        {
            return value == null;
        }

        /// <summary>
        /// Indicates whether the specified object is not null.
        /// </summary>
        /// <param name="value">The object to check.</param>
        /// <returns>true if the value parameter is not null; otherwise, false.</returns>
        public static bool IsNotNull(this object value)
        {
            return !value.IsNull();
        }

        /// <summary>
        /// Converts the object to the type T.
        /// </summary>
        /// <typeparam name="T">The result type of the conversion.</typeparam>
        /// <param name="value">The object to convert.</param>
        /// <returns>An object that represents the converted value.</returns>
        public static T ConvertTo<T>(this object value)
        {
            if (value is T)
                return (T)value;

            if (value.IsNull())
                return default(T);

            try
            {
                var sourceType = value.GetType();
                var targetType = typeof(T);
                
                var sourceConverter = TypeDescriptor.GetConverter(sourceType);
                if (sourceConverter.CanConvertTo(targetType))
                    return (T)sourceConverter.ConvertTo(value, targetType);

                var targetConverter = TypeDescriptor.GetConverter(targetType);
                return targetConverter.CanConvertFrom(sourceType)
                    ? (T)targetConverter.ConvertFrom(value)
                    : default(T);
            }
            catch (InvalidCastException)
            {
                return default(T);
            }
        }
    }
}
