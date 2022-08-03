using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AbiRent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarDetails : ContentPage
    {
        public int _id;
        public CarDetails(int id)
        {
            _id = id;
            InitializeComponent();
        }
    }
}