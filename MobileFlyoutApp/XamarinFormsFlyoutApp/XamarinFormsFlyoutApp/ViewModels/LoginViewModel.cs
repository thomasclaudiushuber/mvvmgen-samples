using XamarinFormsFlyoutApp.Views;
using MvvmGen;
using Xamarin.Forms;

namespace XamarinFormsFlyoutApp.ViewModels
{
  [ViewModel]
  public partial class LoginViewModel : BaseViewModel
  {
    [Command]
    private async void Login(object obj)
    {
      // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
      await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
    }
  }
}
