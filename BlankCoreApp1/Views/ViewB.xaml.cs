using System.Windows;
using System.Windows.Controls;

namespace BlankCoreApp1.Views
{
    /// <summary>
    /// Interaction logic for ViewB
    /// </summary>
    public partial class ViewB : UserControl
    {
        private ViewModels.ViewBViewModel Vm
        {
            get {return this.DataContext as ViewModels.ViewBViewModel;}
        }

        public ViewB()
        {
            InitializeComponent();

            Vm.Initialize(() => MessageBox.Show("保存して閉じますか？", "確認", MessageBoxButton.OKCancel, MessageBoxImage.Question));
        }
    }
}
