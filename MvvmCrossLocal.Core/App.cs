using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.Localization;
using Cirrious.MvvmCross.Plugins.JsonLocalisation;
using MvvmCrossLocal.Core.Services;

namespace MvvmCrossLocal.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            InitializeServices();
            InitializeText();

            RegisterAppStart<ViewModels.FirstViewModel>();
        }

        void InitializeServices()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
        }

        private void InitializeText()
        {
            var builder = new TextProviderBuilder();

            Mvx.RegisterSingleton<IMvxTextProviderBuilder>(builder);
            Mvx.RegisterSingleton<IMvxTextProvider>(builder.TextProvider);
        }
    }
}