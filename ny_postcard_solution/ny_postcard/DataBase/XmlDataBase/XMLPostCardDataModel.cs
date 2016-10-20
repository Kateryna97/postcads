using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ny_postcard
{
    class XMLPostCardDataModel
    {
        private XMLPostCardsLoader _postCardloader;
        private XMLPostCardStorring _postCardStoring;
        // Ms sql Compact edition 3.5 


        public XMLPostCardsLoader PostCardloader
        {
            get { return _postCardloader; }
        }

        public XMLPostCardStorring PostCardStoring
        {
            get { return _postCardStoring; }
        }

        public XMLPostCardDataModel()
        {
            _postCardloader = new XMLPostCardsLoader();
            _postCardStoring = new XMLPostCardStorring();
        }


    }
}
