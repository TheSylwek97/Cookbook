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
	public partial class CategoryPage : ContentPage
	{
		public CategoryPage ()
		{
			InitializeComponent ();
		}

        private async void Soups_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListPage());
        }

        private async void Main_Courses_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListPage());
        }

        private async void Desserts_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListPage());
        }
    }
}