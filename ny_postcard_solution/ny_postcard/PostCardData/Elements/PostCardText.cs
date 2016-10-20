using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ny_postcard
{
    public abstract class PostCardText
    {
        public string TextCode;
        public string InputText;
        public string TextColor;
        public string TextFont;
        public Int32  FontSize;

        public PostCardText()
        {
            TextCode = "";
            InputText = "";
            TextColor = "";
            TextFont = "";
            FontSize = 8;
        }


        public PostCardText(string p_textCode, string p_inputText, string p_textColor, string p_textFont, Int32 p_fontSize)
        {
            TextCode = p_textCode;
            InputText = p_inputText;
            TextColor = p_textColor;
            TextFont = p_textFont;
            FontSize = p_fontSize;
        }

        public abstract void TextForm();
    }

}
