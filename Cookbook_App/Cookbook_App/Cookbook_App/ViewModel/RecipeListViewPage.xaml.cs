using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Cookbook_App.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cookbook_App.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeListViewPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public RecipeListViewPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };
			
			//MyListView.ItemsSource = Items;
        }

        public RecipeListViewPage(Recipe recipe)
        {
            /*switch (Rate)
            {
                case Rate=1:
                    img.Source = ImageSource.FromFile("Assets/r1.png");
                    break;
                case Rate=2:
                    img.Source = ImageSource.FromFile("Assets/r2.png");
                    break;
                default:
                    img.Source = ImageSource.FromFile("Assets/r3.png");
                    break;

            }*/
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void BtnAddNew_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnRemove_Clicked(object sender, EventArgs e)
        {

        }
    }
}
