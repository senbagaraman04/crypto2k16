using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.LocalStorage;
using Crypto2k16;
using Crypto2k16.Sections;
using Crypto2k16.ViewModels;

namespace Crypto2k16.Views
{
    public sealed partial class NonTechieListPage : PageBase
    {
        public ListViewModel<LocalStorageDataConfig, NonTechie1Schema> ViewModel { get; set; }

        public NonTechieListPage()
        {
            this.ViewModel = new ListViewModel<LocalStorageDataConfig, NonTechie1Schema>(new NonTechieConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
