using BlankCoreApp1.Services;
using BlankCoreApp1.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace BlankCoreApp1.ViewModels
{
    public class ViewCViewModel : BindableBase, IDialogAware
    {
        public event Action<IDialogResult> RequestClose;

        public string Title => "ViewCのタイトル";

        IDialogService _dialogService;
        IMessageService _messageService;

        private string _viewCTextBox = "XXX";

        public string ViewCTextBox
        {
            get { return _viewCTextBox; }
            set { SetProperty<string>(ref _viewCTextBox, value); }
        }

        public DelegateCommand OKButton { get; }

        private void OKButtonExecute()
        {
            //            MessageBox.Show("Saveします");
            //var message = new DialogParameters();
            //message.Add(nameof(MessageBoxViewViewModel.Message), "Saveします");
            //_dialogService.ShowDialog(nameof(MessageBoxView), message, null);

            if (_messageService.Question("保存しますか？") == MessageBoxResult.OK)
            {
                _messageService.ShowDialog("Saveしました。");
            }

            var p = new DialogParameters();
            p.Add(nameof(ViewCTextBox), ViewCTextBox);
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, p));
        }

        public ViewCViewModel(IDialogService dialogService)
            : this(dialogService, new MessageService())
        {
        }

        public ViewCViewModel(IDialogService dialogService, IMessageService messageService)
        {
            _dialogService = dialogService;
            _messageService = messageService;

            OKButton = new DelegateCommand(OKButtonExecute);
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            ViewCTextBox = parameters.GetValue<string>(nameof(ViewCTextBox));
        }
    }
}
