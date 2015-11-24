using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDeezer.Services
{
    public interface IAudioService
    {
        void playAudio();
        void playVideo();
        void stopAudio();
        void stopVideo();

   
    }
}
