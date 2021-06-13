using System.Windows.Controls;

namespace BlankCoreApp1.Views
{
    /// <summary>
    /// Interaction logic for ViewC
    /// </summary>
    public partial class ViewC : UserControl
    {
        public ViewC()
        {
            InitializeComponent();

            ViewModels.ViewCViewModel vm = this.DataContext as ViewModels.ViewCViewModel;
            vm.Initialize(
                msgQuestionFunc: () => System.Windows.MessageBox.Show("保存しますか？", "確認", System.Windows.MessageBoxButton.OKCancel, System.Windows.MessageBoxImage.Question),
                msgShowFunc: () => System.Windows.MessageBox.Show("保存しました"));
        }
    }
}
