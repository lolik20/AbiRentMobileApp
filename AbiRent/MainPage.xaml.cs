using AbiRent.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AbiRent
{
    public partial class MainPage : ContentPage
    {
        public List<City> _cities;
        public MainPage()
        {
            Initial();
            InitializeComponent();
            CreateLayout();
        }
        public void CreateLayout()
        {
            var mainObj = FindByName("main");

            StackLayout container = (StackLayout)mainObj;
            foreach (var city in _cities)
            {
                var frame = new Frame {CornerRadius=10,Margin=new Thickness(20, 0, 20, 0) };
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.CommandParameter = city.NameEn;
                tapGestureRecognizer.Tapped += (s, e) =>
                {
                    GoTo(s, e);
                };
                var stack1 = new StackLayout { };
                var stack2 = new StackLayout { Orientation=StackOrientation.Horizontal,Padding=0};
                var label = new Label {TextColor=Color.Black,Text=city.NameRu,HorizontalOptions=LayoutOptions.Start,VerticalOptions=LayoutOptions.Center,FontFamily="Poppins",FontSize=20, };
                var image = new Xamarin.Forms.Image { Source = "Vector.png",HorizontalOptions=LayoutOptions.EndAndExpand,VerticalOptions=LayoutOptions.Center };
                container.Children.Add(frame);
                frame.GestureRecognizers.Add(tapGestureRecognizer);
                frame.Content = stack1;
                stack1.Children.Add(stack2);
                stack2.Children.Add(label);
                stack2.Children.Add(image);
            }

        }
        public async void Initial()
        {
            _cities = await HttpService.GetCities();
        }
        async void GoTo(object sender, EventArgs e)
        {
            var param = ((TappedEventArgs)e).Parameter;

            await Navigation.PushAsync(new CarsChoose(param.ToString()));
        }
    }
}
