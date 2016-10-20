using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ny_postcard
{
    public class XMLPostCardsLoader : IXMLLoader
    {

        public PostCard GetPostCardFromFile(string p_postCardFile)
        {
            return (new PostCard());
        }

        List<PostCard> IXMLLoader.GetPostCardsListFromFile(string p_postCardFile)
        { 
            return (new List<PostCard>());
        }
    }
}
