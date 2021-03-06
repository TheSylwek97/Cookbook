﻿using Cookbook_App.Model;
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
        private string localSearch;
        CategoryDataType formcategory;
        //private CategoryDataType _cat;
        public ListPage(CategoryDataType category)
        {
            //_cat = category;
            InitializeComponent();
            /*
            var scroll = new ScrollView();
            Content = scroll;

            InitializeComponent();
            */
            switch (category)
            {
                case CategoryDataType.ScDish:
                    img.Source = ImageSource.FromFile("Assets/main-courses.jpg");
                    formcategory = CategoryDataType.ScDish;
                    break;
                case CategoryDataType.Dessers:
                    img.Source = ImageSource.FromFile("Assets/Dessert.jpg");
                    formcategory = CategoryDataType.Dessers;
                    break;
                default:
                    img.Source = ImageSource.FromFile("Assets/Soup.jpg");
                    formcategory = CategoryDataType.Soups;
                    break;
            }
        }
        public ListPage(string search)
        {
            InitializeComponent();
            localSearch = search;
        }
        private async void Add_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FormPage(null, formcategory ));
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await RefreshData();
        }
        private async Task RefreshData()
        {
            List<Recipe> recpies;
            if (string.IsNullOrEmpty(localSearch))
            {
                recpies = await App.LocalDB.GetRecpies();
                recpies.RemoveAll(r => r.Category != formcategory);
            }
            else
            {
                recpies = await App.LocalDB.GetRecpiesLikeName(localSearch);
                img.Source = ImageSource.FromFile("Assets/search.jpg");
                Add_Button.IsVisible = false;

            }
            //_recipe = await App.LocalDB.GetRecpies<Recipe>();
            //MyListView.ItemsSource = _recipe;

            MyListView.ItemsSource = recpies;
        }

        private async void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var recp = e.Item as Recipe;
            await Navigation.PushAsync(new DetailPage(recp));
            //.test. 
            //await DisplayAlert(recp.Name, $"Przepis zawiera: {recp.Recipe_Text_Area} oraz skł: {recp.Ingredient}", "OK");
            //await Navigation.PushAsync(new DetailPage(recp.ID));
            
        }
        
        
    }
}