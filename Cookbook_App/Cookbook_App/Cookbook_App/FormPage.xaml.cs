using Cookbook_App.Model;
using Plugin.Media;
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
        string pathToFile;
        private CategoryDataType _category;
        public FormPage (Recipe recipe = null)
		{
			InitializeComponent ();
            _recipe = recipe;

            
            if (_recipe != null)
            {
                entryName.Text = _recipe.Name;
                entryRate.Text = _recipe.Rate.ToString();
                oneEntOfIngList.Text = _recipe.Ingredient;
                entryRecipe_Text_Area.Text = _recipe.Recipe_Text_Area;
                _category = _recipe.Category;
            }
        }

        public FormPage(CategoryDataType category)//, Rate rattig)
        {
            _category = category;
    
        }

        private async Task AddNewRecipe()
        {
            string ingredients = string.Empty;
            
            foreach(var x in ingList.Children)
            {
                var entry = (Entry)x;
                ingredients += entry.Text + "; ";
            }

            var recipe = new Recipe()
            {
                Name = entryName.Text,
                Rate = int.Parse(entryRate.Text),
                Ingredient = ingredients,
                Recipe_Text_Area = entryRecipe_Text_Area.Text,
                FilePath = pathToFile,
                Category = _category
            };

            if (_recipe != null)
            {
                recipe.ID = _recipe.ID;
            }

            await App.LocalDB.SaveItem(recipe);
            await DisplayAlert("Sukces", "Przepis został dodany do bazy", "Ok");
            await Navigation.PopAsync();
        }
        
        private void Add_Next_Clicked(object sender, EventArgs e)
        {
            ingList.Children.Add(new Entry());
        }

        private async void BtnTakePho_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Aparat niedostępny", ":(Brak dostępu do aplikacji Aparat.", "Ok");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            //await DisplayAlert("File Location", file.Path, "OK");
            pathToFile = file.Path;

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }

        private async void Add_Recipe_Clicked(object sender, EventArgs e)
        {
            await AddNewRecipe();
        }
    }
}