using BlankCoreApp1.Services;
using BlankCoreApp1.ViewModels;
using Moq;
using Prism.Services.Dialogs;
using System;
using Xunit;

namespace BlankCoreApp1.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var dialogServiceMock = new Mock<IDialogService>();
            var messageServiceMock = new Mock<IMessageService>();

            var vm = new ViewCViewModel(dialogServiceMock.Object, messageServiceMock.Object);
            vm.OKButton.Execute();
        }
    }
}
