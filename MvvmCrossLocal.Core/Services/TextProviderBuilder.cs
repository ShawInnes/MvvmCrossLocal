using Cirrious.MvvmCross.Plugins.JsonLocalisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmCrossLocal.Core.Services
{
    public class TextProviderBuilder
          : MvxTextProviderBuilder
    {
        public TextProviderBuilder()
            : base(Constants.GeneralNamespace, Constants.RootFolderForResources)
        {

        }

        protected override IDictionary<string, string> ResourceFiles
        {
            get
            {
                var dictionary = this.GetType()
                    .Assembly
                    .GetTypes()
                    .Where(t => t.Name.EndsWith("ViewModel"))
                    .Where(t => !t.Name.StartsWith("Base"))
                    .ToDictionary(t => t.Name, t => t.Name);

                dictionary[Constants.Shared] = Constants.Shared;
                return dictionary;
            }
        }
    }
}
