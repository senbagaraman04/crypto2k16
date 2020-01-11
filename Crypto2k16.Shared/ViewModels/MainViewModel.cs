using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppStudio.Common;
using AppStudio.Common.Actions;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Html;
using AppStudio.DataProviders.Menu;
using AppStudio.DataProviders.LocalStorage;
using Crypto2k16.Sections;


namespace Crypto2k16.ViewModels
{
    public class MainViewModel : ObservableBase
    {
        public MainViewModel(int visibleItems)
        {
            PageTitle = "Crypto2k16";
            ThankYou = new ListViewModel<LocalStorageDataConfig, HtmlSchema>(new ThankYouConfig(), visibleItems);
            CRYPTO2K16 = new ListViewModel<LocalStorageDataConfig, HtmlSchema>(new CRYPTO2K16Config(), visibleItems);
            Hospitality = new ListViewModel<LocalStorageDataConfig, Hospitality1Schema>(new HospitalityConfig(), visibleItems);
            About = new ListViewModel<LocalStorageDataConfig, About1Schema>(new AboutConfig(), visibleItems);
            Techie = new ListViewModel<LocalStorageDataConfig, Techie1Schema>(new TechieConfig(), visibleItems);
            NonTechie = new ListViewModel<LocalStorageDataConfig, NonTechie1Schema>(new NonTechieConfig(), visibleItems);
            ContactUs = new ListViewModel<LocalStorageDataConfig, MenuSchema>(new ContactUsConfig());
            AboutOrganizers = new ListViewModel<LocalStorageDataConfig, HtmlSchema>(new AboutOrganizersConfig(), visibleItems);
            AboutDevelopers = new ListViewModel<LocalStorageDataConfig, HtmlSchema>(new AboutDevelopersConfig(), visibleItems);
            Registration = new ListViewModel<LocalStorageDataConfig, HtmlSchema>(new RegistrationConfig(), visibleItems);
            Actions = new List<ActionInfo>();

            if (GetViewModels().Any(vm => !vm.HasLocalData))
            {
                Actions.Add(new ActionInfo
                {
                    Command = new RelayCommand(Refresh),
                    Style = ActionKnownStyles.Refresh,
                    Name = "RefreshButton",
                    ActionType = ActionType.Primary
                });
            }
        }

        public string PageTitle { get; set; }
        public ListViewModel<LocalStorageDataConfig, HtmlSchema> ThankYou { get; private set; }
        public ListViewModel<LocalStorageDataConfig, HtmlSchema> CRYPTO2K16 { get; private set; }
        public ListViewModel<LocalStorageDataConfig, Hospitality1Schema> Hospitality { get; private set; }
        public ListViewModel<LocalStorageDataConfig, About1Schema> About { get; private set; }
        public ListViewModel<LocalStorageDataConfig, Techie1Schema> Techie { get; private set; }
        public ListViewModel<LocalStorageDataConfig, NonTechie1Schema> NonTechie { get; private set; }
        public ListViewModel<LocalStorageDataConfig, MenuSchema> ContactUs { get; private set; }
        public ListViewModel<LocalStorageDataConfig, HtmlSchema> AboutOrganizers { get; private set; }
        public ListViewModel<LocalStorageDataConfig, HtmlSchema> AboutDevelopers { get; private set; }
        public ListViewModel<LocalStorageDataConfig, HtmlSchema> Registration { get; private set; }

        public RelayCommand<INavigable> SectionHeaderClickCommand
        {
            get
            {
                return new RelayCommand<INavigable>(item =>
                    {
                        NavigationService.NavigateTo(item);
                    });
            }
        }

        public DateTime? LastUpdated
        {
            get
            {
                return GetViewModels().Select(vm => vm.LastUpdated)
                            .OrderByDescending(d => d).FirstOrDefault();
            }
        }

        public List<ActionInfo> Actions { get; private set; }

        public bool HasActions
        {
            get
            {
                return Actions != null && Actions.Count > 0;
            }
        }

        public async Task LoadDataAsync()
        {
            var loadDataTasks = GetViewModels().Select(vm => vm.LoadDataAsync());

            await Task.WhenAll(loadDataTasks);

            OnPropertyChanged("LastUpdated");
        }

        private async void Refresh()
        {
            var refreshDataTasks = GetViewModels()
                                        .Where(vm => !vm.HasLocalData)
                                        .Select(vm => vm.LoadDataAsync(true));

            await Task.WhenAll(refreshDataTasks);

            OnPropertyChanged("LastUpdated");
        }

        private IEnumerable<DataViewModelBase> GetViewModels()
        {
            yield return ThankYou;
            yield return CRYPTO2K16;
            yield return Hospitality;
            yield return About;
            yield return Techie;
            yield return NonTechie;
            yield return ContactUs;
            yield return AboutOrganizers;
            yield return AboutDevelopers;
            yield return Registration;
        }
    }
}
