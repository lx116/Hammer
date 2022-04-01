using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hammer.ViewModels
{
    public class ProductViewModel:BaseViewModel
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        private double _price;

        public double Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(); }
        }

        private bool _isAvailable;

        public bool IsAvailable
        {
            get { return _isAvailable; }
            set { _isAvailable = value; OnPropertyChanged(); }
        }

        public ICommand ClearCommand { private set; get; }
        public ICommand CreateCommand { private set; get; }

        public ProductViewModel()
        {
            ClearCommand = new Command(() => Clear());
            CreateCommand = new Command(async () => await Create());
        }

        void Clear()
        {
            Name = string.Empty;
            Price = 0;
            IsAvailable = false;
        }

        async Task Create()
        {
            
        }
    }
}