using BlankCoreApp1.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using System;

namespace BlankCoreApp1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private readonly IDialogService _dialogService;

        public ReactiveProperty<string> Title { get; } = new ReactiveProperty<string>("Prism Sample");

        public ReactiveProperty<string> SystemDateLabel { get; } =
            new ReactiveProperty<string>(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

        public ReactiveCommand SystemDateUpdateButton { get; } = new ReactiveCommand();
        public ReactiveCommand ShowViewAButton { get; } = new ReactiveCommand();
        public ReactiveProperty<bool> ShowAEnabled { get; } = new ReactiveProperty<bool>(false);
        public ReactiveCommand ShowViewBButton { get; } = new ReactiveCommand();
        public ReactiveCommand ShowViewCButton { get; } = new ReactiveCommand();
        public ReactiveCommand ShowViewDButton { get; } = new ReactiveCommand();


        public void SystemDateUpdateButtonExecute()
        {
            ShowAEnabled.Value = true;
            SystemDateLabel.Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        public void ShowViewAButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(ViewA));
        }


        public void ShowViewBButtonExecute()
        {
            var p = new NavigationParameters();
            p.Add(nameof(ViewBViewModel.MyLabel.Value), SystemDateLabel.Value);
            _regionManager.RequestNavigate("ContentRegion", nameof(ViewB), p);
        }

        public void ShowViewCButtonExecute()
        {
            var p = new DialogParameters();
            p.Add(nameof(ViewCViewModel.ViewCTextBox.Value), SystemDateLabel.Value);
            _dialogService.ShowDialog(nameof(ViewC), p, ViewCClose);
        }


        public void ShowViewDButtonExecute()
        {
            var p = new NavigationParameters();
            Action<string> set_title = title => Title.Value = title;
            p.Add(nameof(ViewDViewModel.SelectedText.Subscribe), set_title);
            _regionManager.RequestNavigate("ContentRegion", nameof(ViewD), p);
        }


        private void ViewCClose(IDialogResult dialogResult)
        {
            if (dialogResult.Result == ButtonResult.OK)
            {
                var result = dialogResult.Parameters.GetValue<string>(nameof(ViewCViewModel.ViewCTextBox.Value));
                SystemDateLabel.Value = result;
            }
        }

        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;

            SystemDateUpdateButton.WithSubscribe(SystemDateUpdateButtonExecute);
            ShowViewAButton.WithSubscribe(ShowViewAButtonExecute);
            ShowViewBButton.WithSubscribe(ShowViewBButtonExecute);
            ShowViewCButton.WithSubscribe(ShowViewCButtonExecute);
            ShowViewDButton.WithSubscribe(ShowViewDButtonExecute);
        }
    }
}
