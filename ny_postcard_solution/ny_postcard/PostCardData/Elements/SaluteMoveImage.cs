using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ny_postcard
{
    class SaluteMoveImage : MovePicture
    {
        public SaluteMoveImage() : base()
        {
        }

        public SaluteMoveImage(string p_imageCode, string p_ImageFile, string p_backColor, string p_imageeffect, int p_hidthImage, int p_heightImage) :
            base(p_imageCode,p_ImageFile, p_backColor, p_imageeffect, p_hidthImage, p_heightImage)
        {
        }

        public override void DrawImage()
        { 
        }


    }
}
