using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ny_postcard
{
    class PCImageBizLogic
    {
        private List<MovePicture> list_moveImages;

        public List<MovePicture>  ListMoveImages
        {
            get { return list_moveImages; }
            set { list_moveImages = value; }
        }

        public PCImageBizLogic()
        { 
        }

        public void CreateMoveImage(string p_ImageCode, string p_ImageFile)
        { 
        }

        public void CreateMoveImage(string p_ImageCode)
        {
        }

        public MovePicture GetImageByCode(string p_imageCode)
        {
            return (new SaluteMoveImage());
        }

        public MovePicture GetImageByNumber(int p_index)
        {
            return (new SaluteMoveImage());
        }


        public void SaveImageToListByCode(string p_code, MovePicture p_postCard)
        {
        }

        public void SaveImageToListByIndex(int p_index, MovePicture p_postCard)
        {

        }

        public void DeleteImageFromList(string p_code)
        {

        }

    }
}
