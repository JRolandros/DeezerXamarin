using OneDeezer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OneDeezer.ViewModels
{
   public class OneDeezerViewModel : INotifyPropertyChanged
    {

        public OneDeezerViewModel()
        {
            //instanciating command
            CommandBtnSeachClick = new Command(btnSearchClick);
            listArtist = new ObservableCollection<Artist>();
        }
        private ObservableCollection<OneDeezer.Services.Artist> listArtist;
        public ObservableCollection<OneDeezer.Services.Artist> ListArtist { get { return listArtist; } }

        private string searchText;
        public String SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
               // OnPropertyChanged("SearchText");
            }
        }

        //command to be bound
        public ICommand CommandBtnSeachClick { protected set; get; }
        
        // boiler-plate
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void btnSearchClick()
        {
            Debug.WriteLine("\n\nEvent sent cool!!!! \n\n");
            await Task.Yield();
            var api = new Services.OneDeezerAPI();
            var items = (await api.search(SearchText).ConfigureAwait(false))
                .Where(s => s.type== "track")
                .ToList();

            Device.BeginInvokeOnMainThread(() =>
            {
                foreach (OneDeezerSearchResult rest in items)
                    listArtist.Add(rest.artist);
            });
        }
    }
}
