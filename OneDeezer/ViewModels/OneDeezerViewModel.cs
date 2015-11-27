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
using XLabs.Forms.Mvvm;

namespace OneDeezer.ViewModels
{
   public class OneDeezerViewModel : ViewModel, INotifyPropertyChanged
    {
        private IAudioService audioService= DependencyService.Get<IAudioService>();
        private string isListening=null;

        public OneDeezerViewModel()
        {
            
            listArtist = new ObservableCollection<OneDeezerSearchResult>();
            Play ="play.png";
        }

        private ObservableCollection<OneDeezerSearchResult> listArtist;
        public ObservableCollection<OneDeezerSearchResult> ListArtist
        {
            get { return listArtist; }
            set
            {
                if(value!=null)
                listArtist = value;
            }
        }

        private string searchText;
        private string play;

        public string Play
        {
            get { return play; }
            set { play = value; OnPropertyChanged("Play"); }
        }
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
        public ICommand SearchCommand {
            get {
               return new Command(btnSearchClick);
            }
        }

        public ICommand PlayCommand
        {
            get
            {
                return new Command<OneDeezerSearchResult>(AudioPlay);
            }
        }

        public ICommand ArtistDetailCommand
        {
            get
            {
                return new Command<OneDeezerSearchResult>(oneDeezerSearch =>
                {
                    //Navigation.PushAsync<ArtistPageViewModel>(new ArtistPage(deezerSearch.artist));
                    NavigationService.NavigateTo<ArtistViewModel>(true, oneDeezerSearch);
                });
            }
        }

        // boiler-plate
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void btnSearchClick()
        {
            //Debug.WriteLine("\n\nEvent sent cool!!!! \n\n");
            await Task.Yield();
            var api = new Services.OneDeezerAPI();
            var items = (await api.search(SearchText).ConfigureAwait(false))
                .Where(s => s.type== "track")
                .ToList();

            Device.BeginInvokeOnMainThread(() =>
            {
                if(listArtist!=null)
                    listArtist.Clear();
                else
                listArtist = new ObservableCollection<OneDeezerSearchResult>();
                if (items != null)
                    foreach (OneDeezerSearchResult rest in items)
                    {
                        if (rest != null)
                        {
                            listArtist.Add(rest);
                        }
                            
                        
                    }
                else
                    Debug.WriteLine("\n\nNull on Item object! \n\n");
            });
        }
        //
        public void AudioPlay(OneDeezerSearchResult prev)
        {
            Debug.WriteLine("\n\nEvent sent cool!!!! \n\n");
            
            if (audioService.IsPlaying() && isListening==prev.preview)
            {
                Play = "stop.png";
                audioService.stopAudio();
            }
            else
            {
                isListening = prev.preview;
                Play= "listening.png";
                audioService.playAudio(prev.preview);
                
            }
        }


        

    }
}
