// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Microsoft.AspNet.Mvc.ModelBinding.Validation
{
    public class ModelValidationContext
    {
        public ModelValidationContext(
            ModelBindingContext bindingContext,
            ModelExplorer modelExplorer)
            : this(
                  bindingContext.BindingSource,
                  bindingContext.OperationBindingContext.ValidatorProvider,
                  bindingContext.ModelState,
                  modelExplorer)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            if (modelExplorer == null)
            {
                throw new ArgumentNullException(nameof(modelExplorer));
            }
        }

        public ModelValidationContext(
            BindingSource bindingSource,
            IModelValidatorProvider validatorProvider,
            ModelStateDictionary modelState,
            ModelExplorer modelExplorer)
        {
            if (validatorProvider == null)
            {
                throw new ArgumentNullException(nameof(validatorProvider));
            }

            if (modelState == null)
            {
                throw new ArgumentNullException(nameof(modelState));
            }

            if (modelExplorer == null)
            {
                throw new ArgumentNullException(nameof(modelExplorer));
            }

            ModelState = modelState;
            ValidatorProvider = validatorProvider;
            ModelExplorer = modelExplorer;
            BindingSource = bindingSource;
        }

        /// <summary>
        /// Constructs a new instance of the <see cref="ModelValidationContext"/> class using the
        /// <paramref name="parentContext" /> and <paramref name="modelExplorer"/>.
        /// </summary>
        /// <param name="parentContext">Existing <see cref="ModelValidationContext"/>.</param>
        /// <param name="modelExplorer">
        /// <see cref="ModelExplorer"/> associated with the new <see cref="ModelValidationContext"/>.
        /// </param>
        /// <returns>
        /// A new instance of the <see cref="ModelValidationContext"/> class using the
        /// <paramref name="parentContext" /> and <paramref name="modelExplorer"/>.
        /// </returns>
        public static ModelValidationContext GetChildValidationContext(
            ModelValidationContext parentContext,
            ModelExplorer modelExplorer)
        {
            if (parentContext == null)
            {
                throw new ArgumentNullException(nameof(parentContext));
            }

            if (modelExplorer == null)
            {
                throw new ArgumentNullException(nameof(modelExplorer));
            }

            return new ModelValidationContext(
                modelExplorer.Metadata.BindingSource,
                parentContext.ValidatorProvider,
                parentContext.ModelState,
                modelExplorer);
        }

        public ModelExplorer ModelExplorer { get; }

        public ModelStateDictionary ModelState { get; }

        public BindingSource BindingSource { get; set; }

        public IModelValidatorProvider ValidatorProvider { get; }
    }
}
