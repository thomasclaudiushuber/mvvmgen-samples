using XamarinFormsFlyoutApp.Models;
using MvvmGen;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsFlyoutApp.ViewModels
{
  [QueryProperty(nameof(ItemId), nameof(ItemId))]
  [ViewModel]
  public partial class ItemDetailViewModel : BaseViewModel
  {
    [PropertyCallMethod(nameof(LoadItemId), MethodArgs = "itemId")]
    [Property] private string itemId;
    [Property] private string text;
    [Property] private string description;
    public string Id { get; set; }

    public async void LoadItemId(string itemId)
    {
      try
      {
        var item = await DataStore.GetItemAsync(itemId);
        Id = item.Id;
        Text = item.Text;
        Description = item.Description;
      }
      catch (Exception)
      {
        Debug.WriteLine("Failed to Load Item");
      }
    }
  }
}
