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
        private CategoryDataType _Category;
        private bool _isSelectable;
        private List<Recipe> _recipesSelected;
        private List<Recipe> _recipes;

        public ListPage(CategoryDataType category)
        {
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

            _recipesSelected = new List<Recipe>();
            _recipes = new List<Recipe>();
            _isSelectable = false;
            _Category = category;

            InitializeComponent();

        }
        private async void NewRcp_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FormPage(_Category));
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await RefreshData();
        }
        private async Task RefreshData()
        {
            _recipes = await App.LocalDB.GetRecpies();
            MyListView.ItemsSource = _recipes;
        }

        private async void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var recp = e.Item as Recipe;
            //await DisplayAlert(recp.Name, $"Przepis zawiera: {recp.Recipe_Text_Area} oraz skł: {recp.Ingredient}", "OK");
            //await Navigation.PushAsync(new DetailPage(recp.ID));
            await Navigation.PushAsync(new DetailPage(recp));
        }

        private async void BtnDeletle_Clicked(object sender, EventArgs e)
        {
            if (_isSelectable)
            {
                if (_recipesSelected.Any())
                {

                    foreach (var r in _recipesSelected)
                    {
                        //var answer = await DisplayAlert("Usuń przepis", "Czy na pewno chcesz usunąć ten przepis?", "Tak", "Nie");
                        // if (answer)
                        // {
                        await App.LocalDB.DeleteItem(r);
                        // }
                    }

                    _recipesSelected.Clear();
                    await DisplayAlert(" ", "Usunięto przepisy z bazy", "OK");
                    await RefreshData();
                }
            }

            _isSelectable = !_isSelectable;
            BtnDeletle.Text = _isSelectable ? "Zaznacz przepis" : "Odznacz przepis";
        }
    
        async  void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var recp = e.Item as Recipe;

            if (!_isSelectable)
            {
                if (await DisplayAlert($"{recp.Name}", $"Czy przejść do edycji?", "Tak", "Nie"))
                {
                    await Navigation.PushAsync(new FormPage(recp));

                    //Deselect Item
                    ((ListView)sender).SelectedItem = null;
                }
            }
            else
            {
                if (_recipesSelected.Contains(recp))
                {
                    _recipesSelected.Remove(recp);
                    var name = recp.Name.Remove(0, 2);
                    _recipes.Where(s => s.ID == recp.ID).First().Name = name;
                }
                else
                {
                    var recipesSelected = _recipes.Where(s => s.ID == recp.ID).First();
                    recipesSelected.Name = "X " + recp.Name;
                    _recipesSelected.Add(recipesSelected);
                }

                MyListView.ItemsSource = null;
                MyListView.ItemsSource = _recipes;
                BtnDeletle.Text = $"Remove students ({_recipesSelected.Count})";
            }
        }
    }
}