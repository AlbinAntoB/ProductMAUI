using Newtonsoft.Json;
using ProductMAUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductMAUI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand EditCommand { get; }
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        public MainViewModel()
        {
            LoadProductsAsync();
            EditCommand = new Command<int>(OnEdit);
        }

        private async Task LoadProductsAsync()
        {
            try
            {
                using HttpClient httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync("https://fakestoreapi.com/products");
                var productList = JsonConvert.DeserializeObject<List<Product>>(json);

                if (productList != null)
                {
                    foreach (var product in productList)
                    {
                        Products.Add(product);
                    }
                }

                // Log to console (for debug)
                System.Diagnostics.Debug.WriteLine($"Loaded {Products.Count} products");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading products: {ex.Message}");
            }
        }

        private async void OnEdit(int productId)
        {
            // Handle the edit logic using the product ID
            var product = Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                Console.WriteLine($"Editing: {product.Title}");
                // Add your edit logic here (e.g., navigate to the edit page)

                // Navigate to the product detail page
                await Application.Current.MainPage.Navigation.PushAsync(new ProductDetailPage(product));

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
