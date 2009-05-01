using System;
using System.Collections.Generic;
using System.Text;

namespace TalkingPaper
{
    class Contenuto
    {
        private String audioPath;
        private String videoPath;
        private String imagePath;
        private String textPath;

        //Il valore 'null' indica che la risorsa corrispondente non è disponibile
        public Contenuto(String audioPath, String videoPath, String imagePath, String textPath)
        {
            this.audioPath = audioPath;
            this.videoPath = videoPath;
            this.imagePath = imagePath;
            this.textPath = textPath;
        }
        
        public String getAudioPath() { return audioPath; }
        public String getVideoPath() { return videoPath; }
        public String getImagePath() { return imagePath; }
        public String getTextPath() { return textPath; }

        public void setAudioPath(String audioPath) { this.audioPath = audioPath; }
        public void setVideoPath(String videoPath) { this.videoPath = videoPath; }
        public void setImagePath(String imagePath) { this.imagePath = imagePath; }
        public void setTextPath(String textPath) { this.textPath = textPath; }

        

    }
}
