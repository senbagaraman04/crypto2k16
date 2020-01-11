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
    public class AboutConfig : SectionConfigBase<LocalStorageDataConfig, About1Schema>
    {
        public override DataProviderBase<LocalStorageDataConfig, About1Schema> DataProvider
        {
            get
            {
                return new LocalStorageDataProvider<About1Schema>();
            }
        }

        public override LocalStorageDataConfig Config
        {
            get
            {
                return new LocalStorageDataConfig
                {
                    FilePath = "/Assets/Data/About.json"
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("AboutListPage");
            }
        }

        public override ListPageConfig<About1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<About1Schema>
                {
                    Title = "About",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title.ToSafeString();
                        viewModel.SubTitle = item.Description.ToSafeString();
                        viewModel.Description = item.Description.ToSafeString();
                        viewModel.Image = "";

                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("AboutDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<About1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, About1Schema>>();

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = "Detail";
                    viewModel.Title = item.Title.ToSafeString();
                    viewModel.Description = item.Description.ToSafeString();
                    viewModel.Image = "";
                    viewModel.Content = null;
                });

				var actions = new List<ActionConfig<About1Schema>>
				{
				};

                return new DetailPageConfig<About1Schema>
                {
                    Title = "About",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "About"; }
        }

    }
}
