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
        }/*
        public static ImageSource GetImageByCategory(CategoryDataType cate)
        {
            switch (category)
            {
                case CategoryDataType.Dessers:
                    return ImageSource.FormFile(stirng.Empty);
                case CategoryDataType.Soup:
                    return ImageSource.FormFile("");
                default:
                    return ImageSource.FormFile("123");
            }
        }*/
    }
}
