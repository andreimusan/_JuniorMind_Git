using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public class CircleNode
    {
        private readonly int defaultRadius = 70;
        private readonly int defaultTextWidth = 5;
        private readonly int textWidthMultiplier = 8;
        private readonly string text;
        private (int width, int height) dimensions;

        public CircleNode(string textInput)
        {
            text = textInput;
            dimensions = (defaultRadius, defaultRadius);
        }

        public string DrawShape()
        {
            int textX = dimensions.width / 2;
            int textY = dimensions.height / 2 + 5;
            string shape = "<ellipse fill=\"#aaaaff\" stroke=\"#3f007f\" stroke-width=\"1\" ry=\"" + dimensions.height + "\" rx=\"" + dimensions.width + "\" cx=\"200\" cy=\"200\"/>";
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
            dimensions.height = dimensions.width;
        }
    }
}
