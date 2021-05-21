using XamarinFormsFlyoutApp.Models;
using XamarinFormsFlyoutApp.Services;
using MvvmGen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace XamarinFormsFlyoutApp.ViewModels
{
  [ViewModel]
  public partial class BaseViewModel
  {
    public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

    [Property]
    bool isBusy = false;

    [Property]
    string title = string.Empty;
  }
}
