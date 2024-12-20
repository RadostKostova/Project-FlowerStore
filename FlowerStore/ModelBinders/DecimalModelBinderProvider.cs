﻿using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FlowerStore.ModelBinders
{
    public class DecimalModelBinderProvider : IModelBinderProvider
    {
        /// <summary>
        /// Register the ModelBinder for formatting numbers to CultureInfo.
        /// </summary>

        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(decimal)
                || context.Metadata.ModelType == typeof(decimal?))
            {
                return new DecimalModelBinder();
            }

            return null;
        }
    }
}
