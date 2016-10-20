using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ny_postcard
{
    public interface IXMLLoader
    {
        PostCard GetPostCardFromFile(string p_postCardFile);
        List<PostCard> GetPostCardsListFromFile(string p_postCardFile);
    }
}
