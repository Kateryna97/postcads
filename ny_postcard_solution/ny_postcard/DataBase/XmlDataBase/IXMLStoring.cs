using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ny_postcard
{
    public interface IXMLStoring
    {
        void SavePostCardToFile(PostCard p_postcard,string p_postCardFile);
        void SavePostCardsListToFile(List<PostCard> p_listPostCards,string p_postCardFile);
    }
}
