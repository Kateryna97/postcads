using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ny_postcard
{
    public abstract class MovePicture
    {
        string ImageCode;
        ImageAnimator InputImage ;
        string BackColor;
        string Image_effect;
        int WidthImage, HeightImage;

        public MovePicture()
        {
            //InputImage = new Image();
            //LoadImageFromFile(p_ImageFile);
            //
            ImageCode = "";
            BackColor = "";
            Image_effect = "";
            WidthImage = 100;
            HeightImage = 100;
        }

        public MovePicture(string p_imageCode, string p_ImageFile, string p_backColor, string p_imageeffect,int p_hidthImage, int p_heightImage)	
        {
            LoadImageFromFile(p_ImageFile, p_imageCode);	
            //
            ImageCode = p_imageCode;
	        BackColor = p_backColor;
	        Image_effect = p_imageeffect;
            WidthImage = p_hidthImage;
            HeightImage = p_heightImage;
        }

        public void LoadImageFromFile(string p_imageFileName, string p_imageCode)
        {
        }

        public abstract void DrawImage();



    }
}
