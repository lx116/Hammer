using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hammer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListProductView : ContentPage
    {
        public ListProductView()
        {
            InitializeComponent();
            
            BindingContext = new ViewModels.ListViewModel(Navigation);
        }
    }
}