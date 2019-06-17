using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookbook_App.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;

namespace Cookbook_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailEditPage : ContentPage
    {
        private Recipe _recipe;
        string pathToFile;
        private CategoryDataType formcategory;
        public DetailEditPage(Recipe recipe)
        {
            _recipe = recipe;
            InitializeComponent();
            string _ingredients = recipe.Ingredient;
            string[] listIng = _ingredients.Split(';');
            //Entry entry;
            foreach( var x in listIng)
            {
                
                ingList.Children.Add(new Entry { Text = x });
            }

            if(_recipe != null)
            {
                entryName.Text = _recipe.Name;
                entryRate.Text = _recipe.Rate.ToString();
                entryRecipe_Text_Area.Text = _recipe.Recipe_Text_Area;
                btnAdd.IsVisible = false;
            }
        }

        private async Task AddNewRecipe()
        {
            string ingredients = string.Empty;

            foreach (var x in ingList.Children)
            {
                var entry = (Entry)x;
                ingredients += entry.Text + " ";
            }

            var recipe = new Recipe()
            {
                Name = entryName.Text,
                Rate = int.Parse(entryRate.Text),
                Ingredient = ingredients,
                Recipe_Text_Area = entryRecipe_Text_Area.Text,
                FilePath = pathToFile,
                Category = formcategory,
            };

            if (_recipe != null)
            {
                recipe.ID = _recipe.ID;
            }

            await App.LocalDB.SaveItem(recipe);
            await DisplayAlert("Sukces", "Zapis powiódł się", "OK");
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
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
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