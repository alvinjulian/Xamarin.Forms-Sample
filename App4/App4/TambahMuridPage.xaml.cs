using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TambahMuridPage : ContentPage
	{
        private MuridManager _muridManager = new MuridManager();
        private bool _isNew = false;

		public TambahMuridPage ()
		{
			InitializeComponent ();
		}

        private void ClearAll()
        {
            foreach (var ctr in gvMurid.Children)
            {
                if (ctr is Entry)
                {
                    var item = ctr as Entry;
                    item.Text = string.Empty;
                }

            }
        }

        public TambahMuridPage(bool isNew)
        {
            InitializeComponent();
            _isNew = isNew;
            if (_isNew)
            {
                txtName.Focus();
            }
        }

        private async void BtnSave_OnClicked(object sender, EventArgs e)
        {
            if (_isNew)
            {
                var murid = new Murid()
                {
                    Name = txtName.Text,
                    Age = txtAge.Text
                };
                await _muridManager.SaveTaskAsync(murid);
                ClearAll();
                await DisplayAlert("Keterangan", "Data Barang Berhasil Ditambah !", "OK");
            }
            else
            {
                var murid = (Murid)this.BindingContext;
                await _muridManager.SaveTaskAsync(murid);
                await DisplayAlert("Keterangan", "Data Barang berhasil diupdate !", "OK");
            }
        }

	}
}
