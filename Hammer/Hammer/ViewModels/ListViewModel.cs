using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Hammer.Models;
using Xamarin.Forms;


namespace Hammer.ViewModels
{
    public class ListViewModel:BaseViewModel
    {
        
        private ObservableCollection<Product> _products;

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value; OnPropertyChanged(); }
        }

        private Product _selectedProduct;

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; OnPropertyChanged(); }
        }

        public ICommand GoToDetailsCommand { private set; get; }

        public INavigation Navigation { get; set; }

        public ListViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GoToDetailsCommand = new Command<Type>(async (pageType) => await GoToDetails(pageType));

            Products = new ObservableCollection<Product>();
            
            
            //Si se crea un array global con los productos. Se puede usar un foreach para cargar todos los productos dentro de ese array
            //Entonces cada que se que se entre a la listview, se van a cargar los productos.
            //Se Para eso solo bastaria hacer un array.append para agregar un nuevo producto al array global
            
            for (int i = 0; i <= 5; i++)
            {
                Products.Add(new Product() { Id = 1, Name = "Leche", Price = 10.30, IsAvailable = true });
            }
            
            
        }

        async Task GoToDetails(Type pageType)
        {
            if (SelectedProduct != null)
            {
                var page = (Page)Activator.CreateInstance(pageType);

                page.BindingContext = new ProductViewModel()
                {
                    IsAvailable = SelectedProduct.IsAvailable,
                    Name = SelectedProduct.Name,
                    Price = SelectedProduct.Price
                };

                await Navigation.PushAsync(page);
            }
        }
    }
}