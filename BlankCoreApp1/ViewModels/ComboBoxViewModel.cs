using System;
using System.Collections.Generic;
using System.Text;

namespace BlankCoreApp1.ViewModels
{
    public sealed class ComboBoxViewModel
    {
        public int Value { get; }
        public string DisplayValue { get; }

        public ComboBoxViewModel(int value, string displayValue)
        {
            Value = value;
            DisplayValue = displayValue;

        }
    }
}
