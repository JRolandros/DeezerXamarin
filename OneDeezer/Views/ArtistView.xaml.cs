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
    public partial class ArtistView : ContentPage
    {
        public ArtistView(OneDeezerSearchResult oneDResult)
        {
            InitializeComponent();

            MessagingCenter.Send("", "showArtist", oneDResult);


            ArtistName.Animate("opacité", d =>
            {
                ArtistName.Opacity = d;

            }, 0, 1, 20, 5000, Easing.BounceIn);
        }
    }
}
