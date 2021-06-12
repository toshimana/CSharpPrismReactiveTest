using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BlankCoreApp1.ViewModels
{
    public class ViewDViewModel : BindableBase
    {
        private ObservableCollection<string> _areas = new ObservableCollection<string>();

        public ObservableCollection<string> Areas
        {
            get { return _areas; }
            set { SetProperty(ref _areas, value); }
        }

        public ViewDViewModel()
        {
            _areas.Add("神戸");
            _areas.Add("神奈川");
            _areas.Add("金沢");
        }
    }
}
