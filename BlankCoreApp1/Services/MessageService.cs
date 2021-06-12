using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace BlankCoreApp1.Services
{
    internal sealed class MessageService : IMessageService
    {
        public MessageBoxResult Question(string message)
        {
            return MessageBox.Show(message, "確認", MessageBoxButton.OKCancel, MessageBoxImage.Question);
        }

        public void ShowDialog(string message)
        {
            MessageBox.Show(message);
        }
    }
}
