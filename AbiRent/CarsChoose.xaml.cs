using AbiRent.Entities;
using Npgsql;
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
    public partial class CarsChoose : ContentPage
    {
        public List<CarResponse> _cars;
        public string _city;
        public CarsChoose(string city)
        {
            _city = city;
            Initial();
            InitializeComponent();
            CreateLayout();
        }
        public void CreateLayout()
        {
            var containerObj = FindByName("main");
            StackLayout container = (StackLayout)containerObj;
            foreach (var car in _cars)
            {
                var frame = new Frame()
                {
                    HasShadow = false,
                    CornerRadius = 10,
                    WidthRequest = 335,
                    BackgroundColor = Color.White,
                    BorderColor = Color.FromHex("#E2E2E2"),
                    HeightRequest = 200,

                };
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.CommandParameter = car.Id;
                tapGestureRecognizer.Tapped += (s, e) =>
                {
                    GoTo(s, e);
                };
                var stackLayout1 = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.End,
                };
                var stackLayout2 = new StackLayout { };
                var image = new Xamarin.Forms.Image { Source = "https://cizgirentacar.com/upcache/araclar/11/11-a.png",WidthRequest =274,HeightRequest=113};


                var title = new Label
                {
                    FontFamily = "Poppins",
                    FontAttributes = FontAttributes.Bold,
                    TextColor = Color.Black,
                    Text = car.Name,
                    FontSize = 14
                };
                var stackLayout3 = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Margin = new Thickness(0, 10, 0, 10),
                    WidthRequest=335
                };
                var gearIcon = new Xamarin.Forms.Image { Source = "gearboxIcon.png" };
                var gearLabel = new Label { FontFamily = "Poppins", Text = car.TransmissonType.ToString(), TextColor = Color.Black, FontSize = 14 };
                var peopleIcon = new Xamarin.Forms.Image { Source = "passengerIcon.png" };
                var peopleLabel = new Label { FontFamily = "Poppins", Text = car.Places.ToString(), TextColor = Color.Black, FontSize = 14 };
                var conditionerIcon = new Xamarin.Forms.Image { Source = "ACIcon.png" };
                var conditionerLabel = new Label { FontFamily = "Poppins", Text = "A/C", TextColor = Color.Black, FontSize = 14 };
                var priceLabel = new Label {HorizontalOptions=LayoutOptions.EndAndExpand, FontFamily = "Poppins", TextColor = Color.Black, FontAttributes = FontAttributes.Bold, Margin = new Thickness(40, 0, 0, 0), Text = car.Price.ToString() + "€", FontSize = 14 };
                var dayLable = new Label {HorizontalOptions = LayoutOptions.End, FontFamily = "Poppins", TextColor = Color.FromHex("#01d28e"), FontAttributes = FontAttributes.Bold, Text = "/сутки", FontSize = 14 };

                stackLayout3.Children.Add(gearIcon);
                stackLayout3.Children.Add(gearLabel);
                stackLayout3.Children.Add(peopleIcon);
                stackLayout3.Children.Add(peopleLabel);
                stackLayout3.Children.Add(conditionerIcon);
                stackLayout3.Children.Add(conditionerLabel);
                stackLayout3.Children.Add(priceLabel);
                stackLayout3.Children.Add(dayLable);
                stackLayout2.Children.Add(image);

                stackLayout2.Children.Add(title);
                stackLayout2.Children.Add(stackLayout3);
                stackLayout1.Children.Add(stackLayout2);
                frame.Content= stackLayout1;
                frame.GestureRecognizers.Add(tapGestureRecognizer);
                container.Children.Add(frame);
            }
        }
        public async void Initial()
        {
            _cars = await HttpService.GetCars(_city);
          
        }
        async void GoTo(object sender, EventArgs e)
        {
            var param = ((TappedEventArgs)e).Parameter;

            await Navigation.PushAsync(new CarDetails((int)param));
        }
    }
  
}