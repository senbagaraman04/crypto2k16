using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.LocalStorage;
using Crypto2k16;
using Crypto2k16.Sections;
using Crypto2k16.ViewModels;

namespace Crypto2k16.Views
{
    public sealed partial class TechieListPage : PageBase
    {
        public ListViewModel<LocalStorageDataConfig, Techie1Schema> ViewModel { get; set; }

        public TechieListPage()
        {
            this.ViewModel = new ListViewModel<LocalStorageDataConfig, Techie1Schema>(new TechieConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
