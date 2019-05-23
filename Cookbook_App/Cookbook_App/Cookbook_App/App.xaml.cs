using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Cookbook_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        public static ImageSource GetImageByCategory(CategoryDataType cat)
        {
            switch (cat)
            {
                case CategoryDataType.Dessers:
                    return ImageSource.FromResource(string.Empty);
                case CategoryDataType.Soups:
                    return ImageSource.FormFile("");
                default:
                    return ImageSource.FormFile("123");
            }
        }
    }
}
