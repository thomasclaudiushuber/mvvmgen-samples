using MvvmGen;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinFormsFlyoutApp.ViewModels
{
  [ViewModel]
  public partial class AboutViewModel : BaseViewModel
  {
    partial void OnInitialize()
    {
      Title = "About";
    }

    [Command]
    public async void OpenWeb() => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart");
  }
}
