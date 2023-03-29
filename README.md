# MvvmGen Samples
This repository contains .NET projects that show how to use [the MvvmGen library](https://www.nuget.org/packages/MvvmGen) to build XAML applications with the Model-View-ViewModel-pattern, also known as MVVM. 

This repository contains the following samples

- **EmployeeManager** - a multi-project solution that has ViewModels in a separate .NET class library project. There are two client projects: WPF and WinUI. 
  Look at this solution to learn how to
  - generate ViewModels with MvvmGen
  - use MvvmGen's EventAggregator 
  - use MvvmGen's ViewModelFactory
  - set up Dependency Injection
  - write unit tests
- **MobileFlyoutApp** - a Xamarin.Forms Flyout app created with the Visual Studio project template. The ViewModels are adjusted to use code generation with MvvmGen 
- **RegistrationScreen** - a simple WPF app that shows you how to generate properties and commands with MvvmGen.

Learn more about MvvmGen [in the MvvmGen repository](https://github.com/thomasclaudiushuber/mvvmgen)
