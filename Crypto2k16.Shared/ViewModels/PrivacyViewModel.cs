using System;
using AppStudio.Common;

namespace Crypto2k16.ViewModels
{
    public class PrivacyViewModel : ObservableBase
    {
        public Uri Url
        {
            get
            {
                return new Uri(UrlText, UriKind.RelativeOrAbsolute);
            }
        }
        public string UrlText
        {
            get
            {
                return "https://appstudio.windows.com/home/appprivacyterms";
            }
        }
    }
}

