using Prism.Commands;
using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BlankCoreApp1.ViewModels
{
    public class ViewDViewModel : BindableBase
    {
        MainWindowViewModel _mainWindowViewModel;

        public ReactiveCollection<string> Areas { get; } = new ReactiveCollection<string>();
        public ReactiveCollection<ComboBoxViewModel> Products { get; } = new ReactiveCollection<ComboBoxViewModel>();

        public ReactiveCommand<object[]> ProductsSelectionChanged { get; } = new ReactiveCommand<object[]>();

        public ReactiveProperty<string> SelectedText { get; } = new ReactiveProperty<string>("--");

        public ReactiveProperty<ComboBoxViewModel> SelectedProduct { get; } = new ReactiveProperty<ComboBoxViewModel>();

        private void ProductsSelectionChangedExecute(object[] selectedItems)
        {
            try
            {
                var selectedItem = selectedItems[0] as ComboBoxViewModel;
                SelectedText.Value = selectedItem.Value + ":" + selectedItem.DisplayValue;
            }
            catch
            {

            }
        }

        public ViewDViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;

            Areas.Add("神戸");
            Areas.Add("神奈川");
            Areas.Add("金沢");

            Products.Add(new ComboBoxViewModel(10, "パン"));
            Products.Add(new ComboBoxViewModel(20, "珈琲牛乳"));
            Products.Add(new ComboBoxViewModel(30, "傘"));

            ProductsSelectionChanged.WithSubscribe(ProductsSelectionChangedExecute);
            SelectedText.Subscribe(title => _mainWindowViewModel.Title.Value = title);
        }
    }
}
