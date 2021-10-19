using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public class CylindricalNode : IFlowChartShape
    {
        private readonly int defaultWidth = 70;
        private readonly int defaultHeight = 90;
        private readonly int defaultTextWidth = 5;
        private readonly int textWidthMultiplier = 8;
        private readonly int heightMultiplier = 2;
        private readonly string text;
        private (int width, int height) dimensions;
        private (int x, int y) coordinatesCenter;

        public CylindricalNode(string textInput)
        {
            text = textInput;
            dimensions = (defaultWidth, defaultHeight);
        }

        public string DrawShape()
        {
            int textX = coordinatesCenter.x;
            int textY = coordinatesCenter.y + 10;
            int x = coordinatesCenter.x - dimensions.width / 2;
            int y = coordinatesCenter.y - dimensions.height / 3;
            string upperEllipse = "<ellipse fill=\"#aaaaff\" stroke=\"#3f007f\" stroke-width=\"1\" ry=\"" + (dimensions.height / 6) + "\" rx=\"" + (dimensions.width / 2) +
                            "\" cx=\"" + coordinatesCenter.x + "\" cy=\"" + (coordinatesCenter.y - dimensions.height / 3) + "\"/>";
            string rectangle = "<rect fill=\"#aaaaff\" stroke=\"none\" height=\"" + (dimensions.height / 1.5) + "\" width=\"" + dimensions.width +
                            "\" x=\"" + x + "\" y=\"" + y + "\"/>";
            string lowerEllipse = "<ellipse fill=\"#aaaaff\" stroke=\"#3f007f\" stroke-width=\"1\" ry=\"" + (dimensions.height / 6) + "\" rx=\"" + (dimensions.width / 2) +
                            "\" cx=\"" + coordinatesCenter.x + "\" cy=\"" + (coordinatesCenter.y + dimensions.height / 3) + "\"/>";
            string leftLine = "<line fill=\"none\" stroke=\"#3f007f\" stroke-width=\"1\" x1=\"" + x + "\" x2=\"" + x +
                            "\" y1=\"" + (coordinatesCenter.y - dimensions.height / 3) + "\" y2=\"" + (coordinatesCenter.y + dimensions.height / 3) + "\"/>";
            string rightLine = "<line fill=\"none\" stroke=\"#3f007f\" stroke-width=\"1\" x1=\"" + (x + dimensions.width) + "\" x2=\"" + (x + dimensions.width) +
                            "\" y1=\"" + (coordinatesCenter.y - dimensions.height / 3) + "\" y2=\"" + (coordinatesCenter.y + dimensions.height / 3) + "\"/>";
            string shape = lowerEllipse + rectangle + upperEllipse + leftLine + rightLine;
            string shapeText = "<text fill=\"#000000\" font-size=\"20\" text-anchor=\"middle\" x=\"" + textX + "\" xml:space=\"preserve\" y=\"" + textY + "\">" + text + "</text>";
            return shape + shapeText;
        }

        public (int width, int height) GetDimensions()
        {
            return this.dimensions;
        }

        public void UpdateDimensions()
        {
            if (text.Length <= defaultTextWidth)
            {
                return;
            }

            dimensions.width += (text.Length - defaultTextWidth) * textWidthMultiplier;
            dimensions.height += (text.Length - defaultTextWidth) * heightMultiplier;
        }

        public void UpdateCoordinates((int x, int y) coordinates)
        {
            this.coordinatesCenter = coordinates;
        }
    }
}
