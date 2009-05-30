using System;
using System.Collections.Generic;
using System.Text;
using TalkingPaper.Common;

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

        /*Costruttore vuoto*/
        public Contenuto()
        {
            this.nomeContenuto = null;
            this.audioPath = null;
            this.videoPath = null;
            this.imagePath = null;
            this.textPath = null;
            this.coordinate = new int[2]{0,0};
        }
        
        /*Costruttore*/
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

        /*Reimposta il contenuto con valori nulli*/
        public void resetContenuto()
        {
            this.nomeContenuto = null;
            this.audioPath = null;
            this.videoPath = null;
            this.imagePath = null;
            this.textPath = null;
            this.coordinate = new int[2] { 0, 0 };
        }

        /*Getters e setters*/

        public String getNomeContenuto() { return this.nomeContenuto; }
        public String getAudioPath() { return this.audioPath; }
        public String getVideoPath() { return this.videoPath; }
        public String getImagePath() { return this.imagePath; }
        public String getTextPath() { return this.textPath; }
        public int[] getCoordinate() { return this.coordinate; }

        public void setNomeContenuto(String nomeContenuto) 
        {
            if (Global.isNotEmpty(nomeContenuto))
                this.nomeContenuto = nomeContenuto;
            else
                this.nomeContenuto = "";
        }

        public void setAudioPath(String audioPath) 
        { 
            if (Global.isNotEmpty(audioPath)) 
                this.audioPath = audioPath; 
            else 
                this.audioPath = null; 
        }
        
        public void setVideoPath(String videoPath) 
        {
            if (Global.isNotEmpty(videoPath))
                this.videoPath = videoPath; 
            else 
                this.videoPath = null; 
        }
        
        public void setImagePath(String imagePath) 
        {
            if (Global.isNotEmpty(imagePath))
                this.imagePath = imagePath; 
            else 
                this.imagePath = null; 
        }
        
        public void setTextPath(String textPath)
        {
            if (Global.isNotEmpty(textPath)) 
                this.textPath = textPath;
            else 
                this.textPath = null;
        }

        public void setCoordinate(int[] coordinate)
        {
            if ((coordinate != null) && (coordinate.Length == 2))
                this.coordinate = coordinate;
            else 
                this.coordinate = new int[2] { 0, 0 };
        }

    }
}
