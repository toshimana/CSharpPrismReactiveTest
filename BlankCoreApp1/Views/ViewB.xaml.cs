using System.Windows;
using System.Windows.Controls;

namespace BlankCoreApp1.Views
{
    /// <summary>
    /// Interaction logic for ViewB
    /// </summary>
    public partial class ViewB : UserControl
    {
        public ViewB()
        {
            InitializeComponent();

            var vm = this.DataContext as ViewModels.ViewBViewModel;
            vm.Initialize(() => MessageBox.Show("保存して閉じますか？", "確認", MessageBoxButton.OKCancel, MessageBoxImage.Question));
        }
    }
}
