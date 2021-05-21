using XamarinFormsFlyoutApp.Models;
using XamarinFormsFlyoutApp.Views;
using MvvmGen;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsFlyoutApp.ViewModels
{
  [ViewModel]
  public partial class ItemsViewModel : BaseViewModel
  {
    [PropertyCallMethod(nameof(OnItemSelected), MethodArgs = "_selectedItem")]
    [Property]
    private Item _selectedItem;

    public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();

    partial void OnInitialize()
    {
      Title = "Browse";
    }

    [Command]
    async Task LoadItems()
    {
      IsBusy = true;

      try
      {
        Items.Clear();
        var items = await DataStore.GetItemsAsync(true);
        foreach (var item in items)
        {
          Items.Add(item);
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex);
      }
      finally
      {
        IsBusy = false;
      }
    }

    public void OnAppearing()
    {
      IsBusy = true;
      SelectedItem = null;
    }

    [Command]
    private async void AddItem(object obj)
    {
      await Shell.Current.GoToAsync(nameof(NewItemPage));
    }

    [Command(PropertyName = "ItemTapped")]
    async void OnItemSelected(object obj)
    {
      if (obj is Item item)
      {
        // This will push the ItemDetailPage onto the navigation stack
        await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
      }
    }
  }
}
