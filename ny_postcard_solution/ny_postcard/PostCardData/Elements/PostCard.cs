using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ny_postcard
{
    public class PostCard
    {
        string postCardCode = "";
        //
        PostCardText postcardtext;
        MovePicture postCardPicture;
        string textPositionOnCard = "";
        string imagePositionOnCard = "";

        public PostCard()
        {
            postcardtext =  null;
            postCardPicture = null;
        }


        public PostCard(PostCardText p_postcardtext, MovePicture p_postCardPicture)
        {
            postcardtext = p_postcardtext;
            postCardPicture = p_postCardPicture;
        }

        public void ChangeTextPosution(string p_textPosition)
        {
            textPositionOnCard = p_textPosition;
            //redraw form
        }

        public void ChangeImagePosution(string p_imagePosition)
        {
            imagePositionOnCard = p_imagePosition;
            //redraw form
        }

        // Others methods

    }
}
