using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using System.Diagnostics;
using System.Collections.ObjectModel;
using App4;

namespace App4
{
    public class MuridManager
    {
        private IMobileServiceTable<Murid> _tablemurid;

        public MuridManager()
        {
            var client = new MobileServiceClient(Constants.ApplicationURL);
            _tablemurid = client.GetTable<Murid>();
        }

        public async Task<ObservableCollection<Murid>> GetMuridAsync()
        {
            try
            {
                IEnumerable<Murid> murids = await _tablemurid.ToEnumerableAsync();
                return new ObservableCollection<Murid>(murids);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine("@Invalid Sync Operation : {0}", msioe.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"Sync error : {0}", e.Message);
            }
            return null;

        }

        public async Task SaveTaskAsync(Murid murid)
        {
            if (murid.Id == null)
            {
                await _tablemurid.InsertAsync(murid);
            }
            else
            {
                await _tablemurid.UpdateAsync(murid);
            }
        }




    }
}
