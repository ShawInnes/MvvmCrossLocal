using Cirrious.CrossCore;
using Cirrious.MvvmCross.Localization;
using Cirrious.MvvmCross.ViewModels;
using System.Globalization;
using System.Threading;

namespace MvvmCrossLocal.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        public IMvxCommandCollection Commands { get; private set; }

        public void Init()
        {
            Commands = new MvxCommandCollectionBuilder().BuildCollectionFor(this);
        }

        public IMvxLanguageBinder TextSource
        {
            get { return new MvxLanguageBinder(Constants.GeneralNamespace, GetType().Name); }
        }

        public IMvxLanguageBinder SharedTextSource
        {
            get { return new MvxLanguageBinder(Constants.GeneralNamespace, Constants.Shared); }
        }
    }
}