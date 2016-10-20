using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ny_postcard
{
    public class CirclePCText : PostCardText
    {
        public CirclePCText(string p_textCode, string p_inputText, string p_textColor, string p_textFont, Int32 p_fontSize) :
            base(p_textCode, p_inputText, p_textColor, p_textFont, p_fontSize) { }
        public CirclePCText() : base() { }

	    public override void TextForm()
        {
            // Create Circle form Text
        }

    }
}
