using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using System;
using System.Windows;

namespace BlankCoreApp1.ViewModels
{
    public class ViewCViewModel : BindableBase, IDialogAware
    {
        public event Action<IDialogResult> RequestClose;

        public string Title => "ViewCのタイトル";

        private Func<System.Windows.MessageBoxResult> MsgQuestionFunc = () => System.Windows.MessageBoxResult.OK;
        private Func<System.Windows.MessageBoxResult> MsgShowFunc = () => System.Windows.MessageBoxResult.OK;

        public ReactiveProperty<string> ViewCTextBox { get; } = new ReactiveProperty<string>("XXX");

        public ReactiveCommand OKButton { get; } = new ReactiveCommand();

        private void OKButtonExecute()
        {
            if (MsgQuestionFunc() == MessageBoxResult.OK)
            {
                MsgShowFunc();

                var p = new DialogParameters();
                p.Add(nameof(ViewCTextBox.Value), ViewCTextBox.Value);
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK, p));
            }
        }

        public ViewCViewModel()
        {
            OKButton.WithSubscribe(OKButtonExecute);
        }

        public void Initialize(Func<MessageBoxResult> msgQuestionFunc, Func<MessageBoxResult> msgShowFunc)
        {
            MsgQuestionFunc = msgQuestionFunc;
            MsgShowFunc = msgShowFunc;
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
            ViewCTextBox.Value = parameters.GetValue<string>(nameof(ViewCTextBox.Value));
        }
    }
}
