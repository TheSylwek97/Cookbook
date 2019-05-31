using Cookbook_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cookbook_App
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListPage : ContentPage
	{
        private Recipe _recipe;
        private CategoryDataType _cat;
        public ListPage(CategoryDataType category)
		{
            _cat = category;
			InitializeComponent ();
            switch (category)
            {
                case CategoryDataType.ScDish:
                    img.Source = ImageSource.FromFile("Assets/2nd_Dish.jpg");
                    break;
                case CategoryDataType.Dessers:
                    img.Source = ImageSource.FromFile("Assets/Dessers.jpg");
                    break;
                default:
                    img.Source = ImageSource.FromFile("Assets/Soups.jpg");
                    break;

            }
        }
        //konstruktor ze listą znalezionych przepisów parametr listPage list of recipe = do wyświetlenia jako mylistviwe 
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FormPage());
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await RefreshData();
        }
        private async Task RefreshData()
        {
            //_recipe = await App.LocalDB.GetRecpies<Recipe>();
            //MyListView.ItemsSource = _recipe;
            var recpies = await App.LocalDB.GetRecpies();
            MyListView.ItemsSource = recpies;
        }

        private async void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
           var recp = e.Item as Recipe;
           await DisplayAlert(recp.Name, $"Przepis zawiera: {recp.Recipe_Text_Area} oraz skł: {recp.Ingredient}", "OK");

        }
    }
}