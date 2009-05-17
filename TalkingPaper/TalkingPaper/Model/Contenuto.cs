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

        private int[] coordinate;

        //Forse serve solo questo costruttore (e non quello più sotto)
        public Contenuto()
        {
            this.nomeContenuto = null;
            this.audioPath = null;
            this.videoPath = null;
            this.imagePath = null;
            this.textPath = null;
            this.coordinate = new int[2]{0,0};
        }
        
        
        //Il valore 'null' indica che la risorsa corrispondente non è disponibile
        public Contenuto(String nomeContenuto, String audioPath, String videoPath, String imagePath, String textPath)
        {
            this.nomeContenuto = nomeContenuto;
            this.audioPath = audioPath;
            this.videoPath = videoPath;
            this.imagePath = imagePath;
            this.textPath = textPath;
            this.coordinate = new int[2] { 0, 0 };
        }

        public void resetContenuto()
        {
            this.nomeContenuto = null;
            this.audioPath = null;
            this.videoPath = null;
            this.imagePath = null;
            this.textPath = null;
            this.coordinate = new int[2] { 0, 0 };
        }

        public String getNomeContenuto() { return nomeContenuto; }
        public String getAudioPath() { return audioPath; }
        public String getVideoPath() { return videoPath; }
        public String getImagePath() { return imagePath; }
        public String getTextPath() { return textPath; }
        public int[] getCoordinate() { return coordinate; }

        public void setNomeContenuto(String nomeContenuto) { this.nomeContenuto = nomeContenuto; }
        public void setAudioPath(String audioPath) { if (audioPath != "") this.audioPath = audioPath; else this.audioPath = null; }
        public void setVideoPath(String videoPath) { if (videoPath != "") this.videoPath = videoPath; else videoPath = null; }
        public void setImagePath(String imagePath) { if (imagePath != "")  this.imagePath = imagePath; else imagePath = null; }
        public void setTextPath(String textPath) { if (textPath != "")  this.textPath = textPath; else textPath = null; }
        public void setCoordinate(int[] coordinate)
        {
            if ((coordinate != null) && (coordinate.Length == 2))
                this.coordinate = coordinate;
            else coordinate = new int[2] { 0, 0 };
        }

    }
}
