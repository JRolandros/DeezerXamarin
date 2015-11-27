using OneDeezer.Services;
using OneDeezer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace OneDeezer.Views
{
    public partial class OneDeezerView : ContentPage
    {
        private OneDeezerViewModel context { get { return BindingContext as OneDeezerViewModel; } }

        public OneDeezerView()
        {
            InitializeComponent();
            this.BindingContext = context;
                
            playList.ItemTapped += (o, e) => {
                //MessagingCenter.Send<OneDeezerSearchResult>((OneDeezerSearchResult)e.Item, "showArtist");

                context.ArtistDetailCommand.Execute(e.Item);

                //App.Current.MainPage=new NavigationPage(new ArtistView());
            };
            
            

        }
    }
}
