using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using XPlaneConnector;

namespace SR22gcu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PanelViewModel viewModel = new PanelViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        bool TransparentButtons { get; set; } = true;

        private void btnHighlight_Click(object sender, RoutedEventArgs e)
        {
            TransparentButtons = !TransparentButtons;
            var buttonStyle = mainGrid.FindResource(TransparentButtons ? "TransparentButton" : "HighlightedButton");
            mainGrid.Resources.Remove("PanelButton");
            mainGrid.Resources.Add("PanelButton", buttonStyle);
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            var window = new ConnectWindow();
            if (!window.ShowDialog().GetValueOrDefault()) return;

            viewModel.connector = new Connector(window.txtIp.Text, int.Parse(window.txtPort.Text));
            viewModel.Subscribe("afm/sr/gcuLight/xpdr", (d, v) => viewModel.XpdrLed = viewModel.LedValue(v));
            viewModel.Subscribe("afm/sr/gcuLight/fms", (d, v) => viewModel.FmsLed = viewModel.LedValue(v));
            viewModel.Subscribe("afm/sr/gcuLight/com", (d, v) => viewModel.ComLed = viewModel.LedValue(v));
            viewModel.Subscribe("afm/sr/gcuLight/nav", (d, v) => viewModel.NavLed = viewModel.LedValue(v));

            viewModel.Subscribe("afm/sr/apLight/lvl", (d, v) => viewModel.AutopilotLvlLed = viewModel.LedValue(v));
            viewModel.Subscribe("afm/sr/apLight/hdg", (d, v) => viewModel.AutopilotHdgLed = viewModel.LedValue(v));
            viewModel.Subscribe("afm/sr/apLight/nav", (d, v) => viewModel.AutopilotNavLed = viewModel.LedValue(v));
            viewModel.Subscribe("afm/sr/apLight/apr", (d, v) => viewModel.AutopilotAprLed = viewModel.LedValue(v));
            viewModel.Subscribe("afm/sr/apLight/ap", (d, v) => viewModel.AutopilotApLed = viewModel.LedValue(v));
            viewModel.Subscribe("afm/sr/apLight/fd", (d, v) => viewModel.AutopilotFdLed = viewModel.LedValue(v));
            viewModel.Subscribe("afm/sr/apLight/ias", (d, v) => viewModel.AutopilotIasLed = viewModel.LedValue(v));
            viewModel.Subscribe("afm/sr/apLight/yd", (d, v) => viewModel.AutopilotYdLed = viewModel.LedValue(v));
            viewModel.Subscribe("afm/sr/apLight/alt", (d, v) => viewModel.AutopilotAltLed = viewModel.LedValue(v));
            viewModel.Subscribe("afm/sr/apLight/vs", (d, v) => viewModel.AutopilotVsLed = viewModel.LedValue(v));
            viewModel.Subscribe("afm/sr/apLight/vnv", (d, v) => viewModel.AutopilotVnvLed = viewModel.LedValue(v));

            viewModel.Subscribe("afm/sr/lights/g1000COM1", (d, v) => viewModel.Com1Led = viewModel.LedValue(v));
            viewModel.Subscribe("afm/sr/lights/g1000COM1M", (d, v) => viewModel.Mic1Led = viewModel.LedValue(v));
            viewModel.Subscribe("afm/sr/lights/g1000COM2", (d, v) => viewModel.Com2Led = viewModel.LedValue(v));
            viewModel.Subscribe("afm/sr/lights/g1000COM2M", (d, v) => viewModel.Mic2Led = viewModel.LedValue(v));
            viewModel.Subscribe("afm/sr/lights/g1000NAV1", (d, v) => viewModel.Nav1Led = viewModel.LedValue(v));
            viewModel.Subscribe("afm/sr/lights/g1000NAV2", (d, v) => viewModel.Nav2Led = viewModel.LedValue(v));

            viewModel.connector.Start();
        }
    }
}
