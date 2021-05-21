using XamarinFormsFlyoutApp.Models;
using MvvmGen;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinFormsFlyoutApp.ViewModels
{
  [ViewModel]
  public partial class NewItemViewModel : BaseViewModel
  {
    [Property] private string text;
    [Property] private string description;

    [CommandInvalidate(nameof(Text),nameof(Description))]
    private bool ValidateSave()
    {
      return !String.IsNullOrWhiteSpace(text)
          && !String.IsNullOrWhiteSpace(description);
    }

    [Command]
    private async void Cancel()
    {
      // This will pop the current page off the navigation stack
      await Shell.Current.GoToAsync("..");
    }

    [Command(CanExecuteMethod = nameof(ValidateSave))]
    private async void Save()
    {
      Item newItem = new Item()
      {
        Id = Guid.NewGuid().ToString(),
        Text = Text,
        Description = Description
      };

      await DataStore.AddItemAsync(newItem);

      // This will pop the current page off the navigation stack
      await Shell.Current.GoToAsync("..");
    }
  }
}
