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
		}

        private void Edit_Clicked(object sender, EventArgs e)
        {

        }

        private void Delete_Clicked(object sender, EventArgs e)
        {

        }
        //switch(recipeId.Rate)

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Xamarin.Essentials.Share.RequestAsync("tresc", "send");

        }

    }
}