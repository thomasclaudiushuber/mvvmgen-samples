// ***************************************************************************
// ⚡ MvvmGen Samples => https://github.com/thomasclaudiushuber/mvvmgen-samples
// Copyright © by Thomas Claudius Huber
// Licensed under the MIT license => See LICENSE file in project root
// ***************************************************************************

using MvvmGen;

namespace MvvmGenSamples.RegistrationScreen.Wpf.ViewModel
{
    [ViewModel]
    public partial class MainViewModel
    {
        [Property] private string _firstName;
        [Property] private bool _isDeveloper;
        [Property] private string _registerStatus;

        [Command(CanExecuteMethod = nameof(CanRegister))]
        private void Register()
        {
            var firstName = FirstName.TrimEnd().TrimStart();
            var status = $"Hey {firstName}, you're registered";
            if (IsDeveloper)
            {
                status += " as a developer";
            }

            RegisterStatus = status;
        }

        [CommandInvalidate(nameof(FirstName))]
        private bool CanRegister()
        {
            return !string.IsNullOrWhiteSpace(FirstName);
        }
    }
}
