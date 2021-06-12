﻿using BlankCoreApp1.ViewModels;
using BlankCoreApp1.Views;
using Prism.Ioc;
using System.Windows;

namespace BlankCoreApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ViewB>();
            containerRegistry.RegisterDialog<ViewC, ViewCViewModel>();
            containerRegistry.RegisterForNavigation<ViewD>();
            containerRegistry.RegisterDialog<MessageBoxView, MessageBoxViewViewModel>();
        }
    }
}
