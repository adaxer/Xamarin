using HelloCross.Core.Interfaces;
using HelloCross.Core.ViewModels;
using Moq;
using MvvmCross.Navigation;
using Xunit;

namespace HelloCross.Core.Tests
{
    public class MainViewModel_Should
    {
        [Fact]
        public void Log_Ctor_Call()
        {
            // Arrange
            var mock = new Mock<ILoggerService>();
            var mockNav = new Mock<IMvxNavigationService>();

            // Act
            var uut = new MainViewModel(mockNav.Object, mock.Object);

            // Assert
            mock.Verify(ls =>ls.Info(It.IsAny<string>()), Times.AtLeastOnce());
        }
    }
}
