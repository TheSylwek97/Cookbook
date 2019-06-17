﻿using Cookbook_App.Model;
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
	public partial class DetailPage : ContentPage
	{
        private List<Recipe> _recipesSelected;
        private List<Recipe> _recipes;
        private Recipe currentRecipe;

        public DetailPage (Recipe _recipe)
		{
            currentRecipe = _recipe;
            InitializeComponent ();
            BindingContext = _recipe;

            switch (_recipe.Rate)
            {
                case 0:
                    imgRate.Source = ImageSource.FromFile("Assets/r0.png");
                    break;
                case 1:
                    imgRate.Source = ImageSource.FromFile("Assets/r1.png");
                    break;
                case 2:
                    imgRate.Source = ImageSource.FromFile("Assets/r2.png");
                    break;
                case 3:
                    imgRate.Source = ImageSource.FromFile("Assets/r3.png");
                    break;
                case 4:
                    imgRate.Source = ImageSource.FromFile("Assets/r4.png");
                    break;
                default:
                    imgRate.Source = ImageSource.FromFile("Assets/r5.png");
                    break;
            }

            imgOfDish.Source = ImageSource.FromFile(_recipe.FilePath);

        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailEditPage(currentRecipe));
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Usuń", "Czy jesteś pewień, że chcesz usunąć ten przepis?", "Tak", "Nie");
            if (answer)
            {
                await App.LocalDB.DeleteItem(currentRecipe);
                await Navigation.PopAsync();
            }

        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Xamarin.Essentials.Share.RequestAsync("tresc", "send");

        }

    }
}