using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.LocalStorage;
using Crypto2k16;
using Crypto2k16.Sections;
using Crypto2k16.ViewModels;

namespace Crypto2k16.Views
{
    public sealed partial class AboutListPage : PageBase
    {
        public ListViewModel<LocalStorageDataConfig, About1Schema> ViewModel { get; set; }

        public AboutListPage()
        {
            this.ViewModel = new ListViewModel<LocalStorageDataConfig, About1Schema>(new AboutConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
