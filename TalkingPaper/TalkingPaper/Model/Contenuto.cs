using System;
using System.Collections.Generic;
using System.Text;

namespace TalkingPaper.Model
{
    public class Contenuto
    {
        private String nomeContenuto;

        private String audioPath;
        private String videoPath;
        private String imagePath;
        private String textPath;

        private String coordinate;

        //Forse serve solo questo costruttore (e non quello più sotto)
        public Contenuto()
        {
            this.nomeContenuto = null;
            this.audioPath = null;
            this.videoPath = null;
            this.imagePath = null;
            this.textPath = null;
            this.coordinate = "00";
        }
        
        
        //Il valore 'null' indica che la risorsa corrispondente non è disponibile
        public Contenuto(String nomeContenuto, String audioPath, String videoPath, String imagePath, String textPath)
        {
            this.nomeContenuto = nomeContenuto;
            this.audioPath = audioPath;
            this.videoPath = videoPath;
            this.imagePath = imagePath;
            this.textPath = textPath;
            this.coordinate = "00";
        }

        public String getNomeContenuto() { return nomeContenuto; }
        public String getAudioPath() { return audioPath; }
        public String getVideoPath() { return videoPath; }
        public String getImagePath() { return imagePath; }
        public String getTextPath() { return textPath; }
        public String getCoordinate() { return coordinate; }

        public void setNomeContenuto(String nomeContenuto) { this.nomeContenuto = nomeContenuto; }
        public void setAudioPath(String audioPath) { this.audioPath = audioPath; }
        public void setVideoPath(String videoPath) { this.videoPath = videoPath; }
        public void setImagePath(String imagePath) { this.imagePath = imagePath; }
        public void setTextPath(String textPath) { this.textPath = textPath; }
        public void setCoordinate(String coordinate) { this.coordinate = coordinate; }

    }
}
