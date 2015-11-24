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
        public OneDeezerView()
        {
            InitializeComponent();
            this.BindingContext = new OneDeezerViewModel();
            
        }
    }
}
