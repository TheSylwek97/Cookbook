using Cookbook_App.Model;
using Cookbook_App.ViewModel;
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
        CategoryDataType formcategory;
        //private CategoryDataType _cat;
        public ListPage(CategoryDataType category)
		{
            //_cat = category;
			InitializeComponent ();
            switch (category)
            {
                case CategoryDataType.ScDish:
                    img.Source = ImageSource.FromFile("Assets/2nd_Dish_Small.jpg");
                    formcategory = CategoryDataType.ScDish;
                    break;
                case CategoryDataType.Dessers:
                    img.Source = ImageSource.FromFile("Assets/Dessers_Small.jpg");
                    formcategory = CategoryDataType.Dessers;
                    break;
                default:
                    img.Source = ImageSource.FromFile("Assets/Soups_Small.jpg");
                    formcategory = CategoryDataType.Soups;
                    break;

            }
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FormPage(/*formcategory*/));
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
            //await DisplayAlert(recp.Name, $"Przepis zawiera: {recp.Recipe_Text_Area} oraz skł: {recp.Ingredient}", "OK");
            //await Navigation.PushAsync(new DetailPage(recp.ID));
            await Navigation.PushAsync(new DetailPage(recp));
        }
    }
}