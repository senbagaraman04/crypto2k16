using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.DataProviders.Html;
using Crypto2k16;
using Crypto2k16.Sections;
using Crypto2k16.ViewModels;

namespace Crypto2k16.Views
{
    public sealed partial class CRYPTO2K16ListPage : PageBase
    {
        private DataTransferManager _dataTransferManager;

        public ListViewModel<LocalStorageDataConfig, HtmlSchema> ViewModel { get; set; }

        public CRYPTO2K16ListPage()
        {
            this.ViewModel = new ListViewModel<LocalStorageDataConfig, HtmlSchema>(new CRYPTO2K16Config());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _dataTransferManager.DataRequested -= OnDataRequested;

            base.OnNavigatedFrom(e);
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            bool supportsHtml = true;
#if WINDOWS_PHONE_APP
            supportsHtml = false;
#endif
            ViewModel.ShareContent(args.Request, supportsHtml);
        }
    }
}
