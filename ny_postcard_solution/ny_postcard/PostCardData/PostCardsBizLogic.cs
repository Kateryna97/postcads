using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ny_postcard
{
    public class PostCardsBizLogic
    {

        private List<PostCard> list_postcards;

        public List<PostCard>  ListPostCards
        {
            get { return list_postcards; }
            set { list_postcards = value; }
        }

        public PostCardsBizLogic()
        { 
        }

        public void CreatePostCard(string p_postcardCode,PostCard p_postCard)
        { 
        }

        public PostCard GetPostCardByCode(string p_postCardCode)
        {
            return (new PostCard());
        }

        public PostCard GetPostCardByNumber(int p_index)
        {
            return (new PostCard());
        }


        public void SavePostCardToListByCode(string p_code, PostCard p_postCard)
        {
        }

        public void SavePostCardToListByIndex(int p_index, PostCard p_postCard)
        {

        }

        public void DeletePostCardFromList(string p_code)
        {

        }


    }
}
