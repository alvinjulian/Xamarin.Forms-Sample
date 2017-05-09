﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MuridPage : ContentPage
	{
        private MuridManager _muridmanager = new MuridManager();

		public MuridPage ()
		{
			InitializeComponent ();

		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await RefreshItems(true);
        }

        private async Task RefreshItems(bool showActivityIndicator)
        {
            using (var scope = new ActivityIndicatorScope(syncIndicator, showActivityIndicator)) 
            {
                listViewMurid.ItemsSource = await _muridmanager.GetMuridAsync();
            }
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            TambahMuridPage tambahPage = new TambahMuridPage();
            Murid item = (Murid)e.Item;
            tambahPage.BindingContext = item;
            ((ListView)sender).SelectedItem = null;
            await Navigation.PushAsync(tambahPage);
        }

        private async void MenuItem_OnClicked(object sender, EventArgs e)
        {
            TambahMuridPage tambahPge = new TambahMuridPage(true);
            await Navigation.PushAsync(tambahPge);

        }

        private async void ListViewMurid_OnRefreshing(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            Exception error = null;
            try
            {
                await RefreshItems(false);
            }
            catch (Exception ex)
            {
                error = ex;
            }
            finally
            {
                list.EndRefresh();
            }

            if (error != null)
            {
                await DisplayAlert("Refresh Error !", "Couldn't refresh data (" + error.Message + ")", "OK");
            }
        }


    }
}
