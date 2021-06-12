using BlankCoreApp1.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlankCoreApp1.ViewModels
{
    public class ViewBViewModel : BindableBase, IConfirmNavigationRequest
    {
        IMessageService _messageService;

        public ReactiveProperty<string> MyLabel { get; } = new ReactiveProperty<string>(string.Empty);

        public ViewBViewModel() : this(new MessageService())
        {

        }

        public ViewBViewModel(IMessageService messageService)
        {
            _messageService = messageService;
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
            if (_messageService.Question("保存せず閉じますか？") == System.Windows.MessageBoxResult.OK)
            {
                continuationCallback(true);
            }
        }
    }
}
