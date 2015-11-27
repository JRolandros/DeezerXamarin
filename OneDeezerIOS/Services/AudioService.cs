using AVFoundation;
using Foundation;
using OneDeezer.Services;
using OneDeezerIOS.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioService))]
namespace OneDeezerIOS.Services
{
    public class AudioService : IAudioService
    {
        Boolean isPlaying = false;
        private AVPlayer player;
        public bool IsPlaying()
        {
            return isPlaying;
        }

        public void MediaPause()
        {
            throw new NotImplementedException();
        }

        public void playAudio(string filePath)
        {
            if (player != null)
            {
                player.Pause();
            }

            player = AVPlayer.FromUrl(new NSUrl(filePath));
            player.Play();
        }

        public void playVideo()
        {
            throw new NotImplementedException();
        }

        public void stopAudio()
        {
            player.Dispose();
        }

        public void stopVideo()
        {
            throw new NotImplementedException();
        }
    }
}
