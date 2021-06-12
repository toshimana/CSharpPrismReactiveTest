using BlankCoreApp1.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;

namespace BlankCoreApp1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private readonly IDialogService _dialogService;

        private string _title = "Prism Sample";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private object _systemDateLabel = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

        public object SystemDateLabel { get => _systemDateLabel; set => SetProperty(ref _systemDateLabel, value); }

        public DelegateCommand SystemDateUpdateButton { get; }

        public void SystemDateUpdateButtonExecute()
        {
            ShowAEnabled = true;
            SystemDateLabel = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        public DelegateCommand ShowViewAButton { get; }

        public void ShowViewAButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(ViewA));
        }

        public DelegateCommand ShowViewBButton { get; }

        public void ShowViewBButtonExecute()
        {
            var p = new NavigationParameters();
            p.Add(nameof(ViewBViewModel.MyLabel), SystemDateLabel);
            _regionManager.RequestNavigate("ContentRegion", nameof(ViewB), p);
        }

        public DelegateCommand ShowViewCButton { get; }

        public void ShowViewCButtonExecute()
        {
            var p = new DialogParameters();
            p.Add(nameof(ViewCViewModel.ViewCTextBox), SystemDateLabel);
            _dialogService.ShowDialog(nameof(ViewC), p, ViewCClose);
        }

        public DelegateCommand ShowViewDButton { get; }

        public void ShowViewDButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(ViewD));
        }

        private bool _showAEnabled = false;
        public bool ShowAEnabled
        {
            get { return _showAEnabled; }
            set { SetProperty(ref _showAEnabled, value); }
        }

        private void ViewCClose(IDialogResult dialogResult)
        {
            if (dialogResult.Result == ButtonResult.OK)
            {
                SystemDateLabel = dialogResult.Parameters.GetValue<string>(nameof(ViewCViewModel.ViewCTextBox));
            }
        }

        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;

            SystemDateUpdateButton = new DelegateCommand(SystemDateUpdateButtonExecute);
            ShowViewAButton = new DelegateCommand(ShowViewAButtonExecute).ObservesCanExecute(() => ShowAEnabled);
            ShowViewBButton = new DelegateCommand(ShowViewBButtonExecute);
            ShowViewCButton = new DelegateCommand(ShowViewCButtonExecute);
            ShowViewDButton = new DelegateCommand(ShowViewDButtonExecute);
        }
    }
}
