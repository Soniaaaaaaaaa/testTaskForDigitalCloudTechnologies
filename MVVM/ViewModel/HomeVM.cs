using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using test202.Core;
using test202.MVVM.Model;
using test202.Services;

namespace test202.MVVM.ViewModel
{
    public class HomeVM : Core.ViewModel
    {

        public ObservableCollection<CoinModel> Coins { get; set; }

        public HomeVM()
        {
            Coins = new ObservableCollection<CoinModel>();

            LoadCoins();
        }

        private async void LoadCoins()
        {
            string url = "https://api.coincap.io/v2/assets";
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                var CoinRoot = JsonConvert.DeserializeObject<Root>(json);
                foreach (var coin in CoinRoot.data)
                {
                    Coins.Add(coin);
                }
            }
        }
    }
}
