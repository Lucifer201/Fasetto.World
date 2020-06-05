using Fasetto.World.Core;
using System.Windows.Controls;

namespace Fasetto.World
{
    /// <summary>
    /// Interaction logic for SettingControl.xaml
    /// </summary>
    public partial class SettingControl : UserControl
    {
        public SettingControl()
        {
            InitializeComponent();

            //Set datacontext to setting view model
            DataContext = IoC.Settings;
        }
    }
}
