using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.JsonLocalisation;
using Cirrious.MvvmCross.ViewModels;
using System.Globalization;
using System.Threading;
using System.ComponentModel;
using System.Linq;

namespace MvvmCrossLocal.Core.ViewModels
{
    public class FirstViewModel 
		: BaseViewModel
    {
        private int dollar;
        private readonly IMvxTextProviderBuilder _builder;

        public FirstViewModel(IMvxTextProviderBuilder builder)
        {
            _builder = builder;
            _builder.LoadResources(Constants.DefaultLanguage);

            Dollar = 1;
        }

        public void SetCultureCommand()
        {
            string[] cultures = new string[] { "en-AU", "ja", "es-ES", "es-BO" };

            CultureInfo culture;

            int index = cultures.ToList().IndexOf(Thread.CurrentThread.CurrentCulture.CompareInfo.Name);
            int newIndex = index + 1;

            if (newIndex > cultures.Length - 1)
                newIndex = 0;

            culture = new CultureInfo(cultures[newIndex]);
            
            Thread.CurrentThread.CurrentCulture = culture;
            _builder.LoadResources(culture.TwoLetterISOLanguageName);

            Culture = Thread.CurrentThread.CurrentCulture.EnglishName + " (" + Thread.CurrentThread.CurrentCulture.NativeName + ")";

            RaiseAllPropertiesChanged();
        }

        public int Dollar
        {
            get { return dollar; }
            set
            {
                if (dollar == value)
                    return;
                dollar = value;

                RaisePropertyChanged(() => Dollar);
                RaisePropertyChanged(() => Display);
            }
        }

        public string Culture { get; private set; }

        public string Display
        {
            get { 
                return string.Format(TextSource.GetText("FormattedText"), Dollar); 
            }
        }        
    }
}
