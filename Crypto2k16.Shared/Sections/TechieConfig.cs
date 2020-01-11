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
    public class TechieConfig : SectionConfigBase<LocalStorageDataConfig, Techie1Schema>
    {
        public override DataProviderBase<LocalStorageDataConfig, Techie1Schema> DataProvider
        {
            get
            {
                return new LocalStorageDataProvider<Techie1Schema>();
            }
        }

        public override LocalStorageDataConfig Config
        {
            get
            {
                return new LocalStorageDataConfig
                {
                    FilePath = "/Assets/Data/Techie.json"
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("TechieListPage");
            }
        }

        public override ListPageConfig<Techie1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<Techie1Schema>
                {
                    Title = "Techie",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title.ToSafeString();
                        viewModel.SubTitle = item.Subtitle.ToSafeString();
                        viewModel.Description = item.Description.ToSafeString();
                        viewModel.Image = item.ImageUrl.ToSafeString();

                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("TechieDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<Techie1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, Techie1Schema>>();

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Title.ToSafeString();
                    viewModel.Title = item.Title.ToSafeString();
                    viewModel.Description = item.Description.ToSafeString();
                    viewModel.Image = item.ImageUrl.ToSafeString();
                    viewModel.Content = null;
                });

				var actions = new List<ActionConfig<Techie1Schema>>
				{
				};

                return new DetailPageConfig<Techie1Schema>
                {
                    Title = "Techie",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "Techie"; }
        }

    }
}
