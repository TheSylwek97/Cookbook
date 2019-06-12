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
	public partial class DetailPage : ContentPage
	{
        //private bool _isSelectable;
        private List<Recipe> _recipesSelected;
        private List<Recipe> _recipes;

        public DetailPage (Recipe _recipe)
		{
            _recipesSelected = new List<Recipe>();
            _recipes = new List<Recipe>();
            //isSelectable = false;
            InitializeComponent ();
            BindingContext = _recipe;

            /*int r = int.Parse(entryRate.Text);
    switch (r)
    {
        case r = 1:
            img.Source = ImageSource.FromFile("Assets/2nd_Dish.jpg");
            break;
        case r.2:
            img.Source = ImageSource.FromFile("Assets/Dessers.jpg");
            break;
        default:
            img.Source = ImageSource.FromFile("Assets/Soups.jpg");
            break;

    }*/
        }


        private async void Edit_Clicked(object sender, EventArgs e)
        {
           
        }

        
        //switch(recipeId.Rate)

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Xamarin.Essentials.Share.RequestAsync("tresc", "send");

        }

    }
}