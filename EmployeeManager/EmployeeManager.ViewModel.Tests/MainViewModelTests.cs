// ***************************************************************************
// ⚡ MvvmGen Samples => https://github.com/thomasclaudiushuber/mvvmgen-samples
// Copyright © by Thomas Claudius Huber
// Licensed under the MIT license => See LICENSE file in project root
// ***************************************************************************

using EmployeeManager.ViewModel.Events;
using Moq;
using MvvmGen.Events;

namespace EmployeeManager.ViewModel
{
    public class MainViewModelTests
    {
        private readonly Mock<IEventAggregator> _eventAggregatorMock;
        private readonly Mock<INavigationViewModel> _navigationVmMock;
        private readonly Mock<IEmployeeViewModelFactory> _employeeVmFactoryMock;
        private readonly MainViewModel _mainViewModel;

        public MainViewModelTests()
        {
            _eventAggregatorMock = new Mock<IEventAggregator>();
            _navigationVmMock = new Mock<INavigationViewModel>();
            _employeeVmFactoryMock = new Mock<IEmployeeViewModelFactory>();

            _mainViewModel = new MainViewModel(
                _eventAggregatorMock.Object,
                _navigationVmMock.Object,
                _employeeVmFactoryMock.Object);
        }

        [Fact]
        public void ShouldCreateNewEmployeeViewModel()
        {
            var employeeId = 5;
            var employeeVmMock = new Mock<IEmployeeViewModel>();
            _employeeVmFactoryMock.Setup(x => x.Create())
                .Returns(employeeVmMock.Object);

            var eventData = new EmployeeNavigationSelectedEvent(employeeId);

            _mainViewModel.OnEvent(eventData);

            _employeeVmFactoryMock.Verify(x => x.Create(), Times.Once);
        }

        [Fact]
        public void ShouldSelectNewEmployeeViewModel()
        {
            var employeeId = 5;
            var employeeVmMock = new Mock<IEmployeeViewModel>();
            _employeeVmFactoryMock.Setup(x => x.Create())
                .Returns(employeeVmMock.Object);

            var eventData = new EmployeeNavigationSelectedEvent(employeeId);

            _mainViewModel.OnEvent(eventData);

            Assert.Equal(employeeVmMock.Object, _mainViewModel.SelectedEmployee);
        }

        [Fact]
        public void ShouldLoadEmployeeViewModel()
        {
            var employeeId = 5;
            var employeeVmMock = new Mock<IEmployeeViewModel>();
            _employeeVmFactoryMock.Setup(x => x.Create())
                .Returns(employeeVmMock.Object);

            var eventData = new EmployeeNavigationSelectedEvent(employeeId);

            _mainViewModel.OnEvent(eventData);

            employeeVmMock.Verify(x => x.Load(employeeId), Times.Once);
            employeeVmMock.Verify(x => x.Load(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void ShouldUseExistingEmployeeViewModel()
        {
            var employeeId = 5;
            var employeeVmMock = new Mock<IEmployeeViewModel>();
            employeeVmMock.Setup(x => x.Id).Returns(employeeId);

            _employeeVmFactoryMock.Setup(x => x.Create())
                .Returns(employeeVmMock.Object);

            var eventData = new EmployeeNavigationSelectedEvent(employeeId);

            _mainViewModel.OnEvent(eventData);
            _mainViewModel.SelectedEmployee = null!;

            _mainViewModel.OnEvent(eventData);

            _employeeVmFactoryMock.Verify(x => x.Create(), Times.Once);
            employeeVmMock.Verify(x => x.Load(employeeId), Times.Once);
            employeeVmMock.Verify(x => x.Load(It.IsAny<int>()), Times.Once);
            Assert.Equal(employeeVmMock.Object, _mainViewModel.SelectedEmployee);
        }

        [Fact]
        public void ShouldRemoveEmployeeViewModelOnTabClose()
        {
            var employeeId = 5;
            var employeeVmMock = new Mock<IEmployeeViewModel>();
            _employeeVmFactoryMock.Setup(x => x.Create())
                .Returns(employeeVmMock.Object);

            var eventData = new EmployeeNavigationSelectedEvent(employeeId);

            _mainViewModel.OnEvent(eventData);

            _mainViewModel.TabCloseCommand.Execute(employeeVmMock.Object);

            Assert.Empty(_mainViewModel.EmployeeViewModels);
        }

        [Fact]
        public void ShouldCallLoadOnNavigationViewModel()
        {
            _mainViewModel.Load();

            _navigationVmMock.Verify(x => x.Load(), Times.Once);
        }
    }
}
