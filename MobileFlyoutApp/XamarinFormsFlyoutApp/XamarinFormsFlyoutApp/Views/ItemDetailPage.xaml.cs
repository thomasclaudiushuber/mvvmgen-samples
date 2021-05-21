using System.ComponentModel;
using Xamarin.Forms;
using XamarinFormsFlyoutApp.ViewModels;

namespace XamarinFormsFlyoutApp.Views
{
  public partial class ItemDetailPage : ContentPage
  {
    public ItemDetailPage()
    {
      InitializeComponent();
      BindingContext = new ItemDetailViewModel();
    }
  }
}