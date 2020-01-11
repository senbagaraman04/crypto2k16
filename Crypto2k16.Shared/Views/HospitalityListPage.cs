using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.LocalStorage;
using Crypto2k16;
using Crypto2k16.Sections;
using Crypto2k16.ViewModels;

namespace Crypto2k16.Views
{
    public sealed partial class HospitalityListPage : PageBase
    {
        public ListViewModel<LocalStorageDataConfig, Hospitality1Schema> ViewModel { get; set; }

        public HospitalityListPage()
        {
            this.ViewModel = new ListViewModel<LocalStorageDataConfig, Hospitality1Schema>(new HospitalityConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
