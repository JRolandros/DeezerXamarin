using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OneDeezer.Services;
using Xamarin.Forms;
using OnDeezerDroid.Services;
using Android.Media;

[assembly: Dependency(typeof(AudioService))]
namespace OnDeezerDroid.Services
{
    public class AudioService : IAudioService
    {
        public AudioService()
        {
        }
        protected MediaPlayer player;
        private Boolean isPlaying = false;
         
        public Boolean IsPlaying()
        {
            return isPlaying;
        }
        public void MediaPause()
        {
            player.Pause();
            isPlaying = false;
        }

        public void playAudio(string filePath)
        {
            if (player == null)
            {
                player = new MediaPlayer();
                player.SetDataSource(filePath);
                player.Prepare();
                player.Start();
            }
            else
            {
                player.Reset();
                player.SetDataSource(filePath);
                player.Prepare();
                player.Start();
            }
            isPlaying = true;
        }

        public void playVideo()
        {
            throw new NotImplementedException();
        }

        public void stopAudio()
        {
            player.Stop();
            isPlaying = false;
        }

        public void stopVideo()
        {
            throw new NotImplementedException();
        }
    }
}