using OneDeezer.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace OneDeezer.ViewModels
{
    class ArtistViewModel :ViewModel
    {
        private IAudioService audioService = DependencyService.Get<IAudioService>();
        private string isListening = null;

        public Artist Artist { get; set; }
        public string Preview { get; set; }

        private string play;
        public string Play
        {
            get { return play; }
            set { play = value; }
        }

        public ArtistViewModel()
        {
            MessagingCenter.Subscribe<string, OneDeezerSearchResult>(this, "showArtist",
                (sender, oneDResult) =>
                {
                    Artist = oneDResult.artist;
                    Preview = oneDResult.preview;
                });
        }

        public void AudioPlay()
        {
            Debug.WriteLine("\n\nEvent sent cool!!!! \n\n");

            if (audioService.IsPlaying() && isListening == Preview)
            {
                Play = "stop.png";
                audioService.stopAudio();
            }
            else
            {
                isListening = Preview;
                Play = "listening.png";
                audioService.playAudio(Preview);

            }
        }

        //Implement command
   
        public ICommand PlayCommand
        {
            get
            {
                return new Command(AudioPlay);
            }
        }
    }
}
