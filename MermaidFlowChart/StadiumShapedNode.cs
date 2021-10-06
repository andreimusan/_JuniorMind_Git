﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public class StadiumShapedNode
    {
        private readonly int defaultWidth = 70;
        private readonly int defaultHeight = 40;
        private readonly int defaultTextWidth = 5;
        private readonly int textWidthMultiplier = 8;
        private readonly string text;
        private (int width, int height) dimensions;

        public StadiumShapedNode(string textInput)
        {
            text = textInput;
            dimensions = (defaultWidth, defaultHeight);
        }

        public string DrawShape()
        {
            int textX = dimensions.width / 2;
            int textY = dimensions.height / 2 + 5;
            string shape = "<rect fill=\"#aaaaff\" stroke=\"#3f007f\" stroke-width=\"1\" rx=\"20\" ry=\"20\" height=\"" + dimensions.height + "\" width=\"" + dimensions.width + "\" x=\"0\" y=\"0\"/>";
            string shapeText = "<text fill=\"#000000\" font-size=\"20\" text-anchor=\"middle\" x=\"" + textX + "\" xml:space=\"preserve\" y=\"" + textY + "\">" + text + "</text>";
            return shape + shapeText;
        }

        public void UpdateWidth()
        {
            if (text.Length <= defaultTextWidth)
            {
                return;
            }

            dimensions.width += (text.Length - defaultTextWidth) * textWidthMultiplier;
        }
    }
}
