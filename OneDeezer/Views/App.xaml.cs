using OneDeezer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using XLabs.Forms.Services;
using XLabs.Ioc;
using XLabs.Platform.Services;

namespace OneDeezer.Views
{
    public partial class App : Application
    {
        public App()
        {
            ViewFactory.Register<OneDeezerView, OneDeezerViewModel>();
            ViewFactory.Register<ArtistView, ArtistViewModel>();

            var oneDeezerView = ViewFactory.CreatePage<OneDeezerViewModel, OneDeezerView>();
            MainPage = new NavigationPage((Page)oneDeezerView)
            {
                //BackgroundColor = Color.White,
                //BarTextColor = Color.Black, //NE FONCTIONNE PAS SUR ANDROID
                //BarBackgroundColor = Color.White
            };

            Resolver.Resolve<IDependencyContainer>()
                .Register<INavigationService>(t => new NavigationService(MainPage.Navigation));
        }
    }
}
