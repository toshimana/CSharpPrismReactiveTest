using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace BlankCoreApp1.Services
{
    public interface IMessageService
    {
        void ShowDialog(string message);
        MessageBoxResult Question(string message);
    }
}
