using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using System;

namespace BlankCoreApp1.ViewModels
{
    public class ViewBViewModel : BindableBase, IConfirmNavigationRequest
    {
        public ReactiveProperty<string> MyLabel { get; } = new ReactiveProperty<string>(string.Empty);

        private Func<System.Windows.MessageBoxResult> MsgFunc = () => System.Windows.MessageBoxResult.OK;

        public ViewBViewModel()
        {

        }

        public void Initialize(Func<System.Windows.MessageBoxResult> msg_func)
        {
            MsgFunc = msg_func;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            MyLabel.Value = navigationContext.Parameters.GetValue<string>(nameof(MyLabel.Value));
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            if (MsgFunc() == System.Windows.MessageBoxResult.OK)
            {
                continuationCallback(true);
            }
        }
    }
}
