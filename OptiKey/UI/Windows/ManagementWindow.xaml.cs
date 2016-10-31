using System.Windows;
using OptiKey.Properties;
using OptiKey.Services;
using OptiKey.UI.ViewModels;
using MahApps.Metro.Controls;

namespace OptiKey.UI.Windows
{
    /// <summary>
    /// Interaction logic for ManagementWindow.xaml
    /// </summary>
    public partial class ManagementWindow : MetroWindow
    {
        public ManagementWindow(
            IAudioService audioService,
            IDictionaryService dictionaryService)
        {
            InitializeComponent();

            //Instantiate ManagementViewModel and set as DataContext of ManagementView
            var managementViewModel = new ManagementViewModel(audioService, dictionaryService);
            this.ManagementView.DataContext = managementViewModel;
        }
    }
}
