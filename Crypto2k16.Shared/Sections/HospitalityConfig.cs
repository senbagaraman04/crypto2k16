using System;
using System.Collections.Generic;
using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.LocalStorage;
using Crypto2k16.Config;
using Crypto2k16.ViewModels;

namespace Crypto2k16.Sections
{
    public class HospitalityConfig : SectionConfigBase<LocalStorageDataConfig, Hospitality1Schema>
    {
        public override DataProviderBase<LocalStorageDataConfig, Hospitality1Schema> DataProvider
        {
            get
            {
                return new LocalStorageDataProvider<Hospitality1Schema>();
            }
        }

        public override LocalStorageDataConfig Config
        {
            get
            {
                return new LocalStorageDataConfig
                {
                    FilePath = "/Assets/Data/Hospitality.json"
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("HospitalityListPage");
            }
        }

        public override ListPageConfig<Hospitality1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<Hospitality1Schema>
                {
                    Title = "Hospitality",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title.ToSafeString();
                        viewModel.SubTitle = item.Description.ToSafeString();
                        viewModel.Description = "";
                        viewModel.Image = "";

                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("HospitalityDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<Hospitality1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, Hospitality1Schema>>();

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Title.ToSafeString();
                    viewModel.Title = "";
                    viewModel.Description = item.Description.ToSafeString();
                    viewModel.Image = "";
                    viewModel.Content = null;
                });

				var actions = new List<ActionConfig<Hospitality1Schema>>
				{
				};

                return new DetailPageConfig<Hospitality1Schema>
                {
                    Title = "Hospitality",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "Hospitality"; }
        }

    }
}
