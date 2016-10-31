using System;
using System.Windows;

namespace OptiKey.Models
{
    public class ThemeResourceDictionary : ResourceDictionary
    {
        public ThemeResourceDictionary() 
            :base()
        {
            Source = new Uri("/OptiKey;component/Resources/Themes/Android_Dark.xaml", UriKind.Relative);
        }
            
    }
}
