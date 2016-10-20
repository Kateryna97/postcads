using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ny_postcard
{
    class RectanglePCText : PostCardText
    {
        public RectanglePCText(string p_textCode, string p_inputText, string p_textColor, string p_textFont, Int32 p_fontSize)
            : base(p_textCode, p_inputText, p_textColor, p_textFont, p_fontSize) { }
        public RectanglePCText() : base() { }

	    public override void TextForm()
        {
            // Create RectanglePCText form Text
        }
    }
}
