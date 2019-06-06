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
	public partial class FormPage : ContentPage
	{
        private Recipe _recipe;
        public FormPage (Recipe recipe = null)
		{
			InitializeComponent ();
            _recipe = recipe;
            //lblCategory.Text = $"Teacher: {_recipe.Category}";
            //CategoryDataType categoryForm;

            if (_recipe != null)
            {
                entryName.Text = _recipe.Name;
                entryRate.Text = _recipe.Rate.ToString();
                //entryIngredient.Text = _recipe.Ingredient;
                //entryGrade.Text = _recipe.Grade.ToString();
                entryRecipe_Text_Area.Text = _recipe.Recipe_Text_Area;
               // categoryForm = _recipe.Category;
                btnDelete.IsVisible = true;
                btnAdd.IsVisible = false;
            }
        }
        
        private async void Add_Recipe_Clicked(object sender, EventArgs e)
        {
            overlayBusy.IsVisible = true;
            stackBusy.IsVisible = true;
            await AddNewRecipe();
            overlayBusy.IsVisible = false;
            stackBusy.IsVisible = false;
            /*
            if (string.IsNullOrWhiteSpace(entryName.Text) 
                || string.IsNullOrWhiteSpace(entryIngredient.Text) 
                || string.IsNullOrWhiteSpace(entryRecipe_Text_Area.Text))
            {
                await DisplayAlert("Błąd!", "Proszę wprowadzić dane", "OK");
                return;
            }

            Data.Properties.AppProperties["nameOfDish"] = entryName.Text;
            Data.Properties.AppProperties["ingredientOfDish"] = entryIngredient.Text;
            Data.Properties.AppProperties["recipeOfDish"] = entryRecipe_Text_Area.Text;

            await Application.Current.SavePropertiesAsync();
            ClearFields();
            */
        }

        private async Task AddNewRecipe()
        {
            string ingredients = string.Empty;
            
            foreach(var x in ingList.Children)
            {
                var entry = (Entry)x;
                ingredients += entry.Text + ";";
            }

            var recipe = new Recipe()
            {
                Name = entryName.Text,
                Rate = int.Parse(entryRate.Text),
                Ingredient = ingredients,
                Recipe_Text_Area = entryRecipe_Text_Area.Text,
                //Category = lblCategory.Text
            };

            if (_recipe != null)
            {
                recipe.ID = _recipe.ID;
            }

            await App.LocalDB.SaveItem(recipe);
            await DisplayAlert("Sukces", "Zapis powiódł się", "OK");
            await Navigation.PopAsync();
        }/*
        private void ClearFields()
        {
            entryName.Text = string.Empty;
            entryIngredient.Text = string.Empty;
            entryRecipe_Text_Area.Text = string.Empty;
        }
        */

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            await DeleteRecipe();
        }

        private async Task DeleteRecipe()
        {
            if (_recipe != null)
            {
                await App.LocalDB.DeleteItem(_recipe);
                await DisplayAlert("Sukces", "Udało się usunąć przepis", "OK");
                await Navigation.PopAsync();
            }
        }

        private void Add_Next_Clicked(object sender, EventArgs e)
        {
            ingList.Children.Add(new Entry());
        }
    }
}