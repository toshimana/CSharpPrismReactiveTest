using BlankCoreApp1.ViewModels;
using Xunit;

namespace BlankCoreApp1.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var vm = new ViewCViewModel();
            vm.OKButton.Execute();
        }
    }
}
