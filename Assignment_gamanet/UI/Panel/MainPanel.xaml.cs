using Assignment_gamanet.Model;
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

namespace Assignment_gamanet.UI.Panel
{
    /// <summary>
    /// Interaction logic for MainPanel.xaml
    /// </summary>
    public partial class MainPanel : UserControl
    {
        private _MainPanelContext _mpContext { get; }
        MainPanelViewModel _model { get; set; }
        public MainPanel()
        {
            InitializeComponent();
            _mpContext = new _MainPanelContext();
            RootContainer.DataContext = _model = new MainPanelViewModel(_mpContext);
            this.DataContextChanged += MainPanel_DataContextChanged;
        }

        private void MainPanel_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            RootContainer.DataContext = _model = new MainPanelViewModel(_mpContext);
        }
    }
}
