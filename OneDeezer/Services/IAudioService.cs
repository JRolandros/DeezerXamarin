using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDeezer.Services
{
    public interface IAudioService
    {
        Boolean IsPlaying();
        void playAudio(string filePath);
        void MediaPause();
        void playVideo();
        void stopAudio();
        void stopVideo();

   
    }
}
