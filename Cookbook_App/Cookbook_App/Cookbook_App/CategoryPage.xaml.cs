﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cookbook_App
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoryPage : ContentPage
	{
		public CategoryPage ()
		{
			InitializeComponent ();
		}

        private async void Soups_Clicked(object sender, EventArgs e)//, CategoryDataType category)
        {
            //category = Soups;
            await Navigation.PushAsync(new ListPage(CategoryDataType.Soups));
        }

        private async void Main_Courses_Clicked(object sender, EventArgs e)
        {
            //ScDish;
            await Navigation.PushAsync(new ListPage(CategoryDataType.ScDish));
        }

        private async void Desserts_Clicked(object sender, EventArgs e)
        {
            //Dessers;
            await Navigation.PushAsync(new ListPage(CategoryDataType.Dessers));
        }

        private async void BtnSearch_Clicked(object sender, EventArgs e)
        {
            await Search();
        }

        private async Task Search()
        {
            var keyword = entrySearch.Text;
            var results = await App.LocalDB.GetRecpiesLikeName(keyword);

            string resList = string.Empty;
            foreach (var Recipe in results)
            {
                resList += Recipe.Name;
            }

            string answer = string.Empty;
            foreach (var x in resList)
            {
                answer += x;
            }
            await DisplayAlert("Znalezione przepisy:", $"{answer}", "OK");
        }
    }
}