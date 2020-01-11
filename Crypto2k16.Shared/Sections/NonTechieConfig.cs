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
    public class NonTechieConfig : SectionConfigBase<LocalStorageDataConfig, NonTechie1Schema>
    {
        public override DataProviderBase<LocalStorageDataConfig, NonTechie1Schema> DataProvider
        {
            get
            {
                return new LocalStorageDataProvider<NonTechie1Schema>();
            }
        }

        public override LocalStorageDataConfig Config
        {
            get
            {
                return new LocalStorageDataConfig
                {
                    FilePath = "/Assets/Data/NonTechie.json"
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("NonTechieListPage");
            }
        }

        public override ListPageConfig<NonTechie1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<NonTechie1Schema>
                {
                    Title = "Non Techie",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title.ToSafeString();
                        viewModel.SubTitle = item.Subtitle.ToSafeString();
                        viewModel.Description = item.Description.ToSafeString();
                        viewModel.Image = item.ImageUrl.ToSafeString();

                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("NonTechieDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<NonTechie1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, NonTechie1Schema>>();

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Title.ToSafeString();
                    viewModel.Title = item.Title.ToSafeString();
                    viewModel.Description = item.Description.ToSafeString();
                    viewModel.Image = item.ImageUrl.ToSafeString();
                    viewModel.Content = null;
                });

				var actions = new List<ActionConfig<NonTechie1Schema>>
				{
				};

                return new DetailPageConfig<NonTechie1Schema>
                {
                    Title = "Non Techie",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "Non Techie"; }
        }

    }
}
