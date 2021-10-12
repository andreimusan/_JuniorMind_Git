﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public class TrapezoidAltNode : IFlowChartShape
    {
        private readonly int defaultWidth = 80;
        private readonly int defaultHeight = 40;
        private readonly int defaultTextWidth = 5;
        private readonly int textWidthMultiplier = 8;
        private readonly int two = 2;
        private readonly string text;
        private (int width, int height) dimensions;
        private (int x, int y) coordinatesCenter;

        public TrapezoidAltNode(string textInput)
        {
            text = textInput;
            dimensions = (defaultWidth, defaultHeight);
        }

        public string DrawShape()
        {
            int textX = coordinatesCenter.x;
            int textY = coordinatesCenter.y + 5;
            (int x, int y) a = (coordinatesCenter.x + dimensions.width / 2 + (defaultTextWidth * 2), coordinatesCenter.y - dimensions.height / 2);
            (int x, int y) b = (coordinatesCenter.x + dimensions.width / 2 - (defaultTextWidth * 2), coordinatesCenter.y + dimensions.height / 2);
            (int x, int y) c = (coordinatesCenter.x - dimensions.width / 2 + (defaultTextWidth * 2), coordinatesCenter.y + dimensions.height / 2);
            (int x, int y) d = (coordinatesCenter.x - dimensions.width / 2 - (defaultTextWidth * 2), coordinatesCenter.y - dimensions.height / 2);
            string shape = "<polygon fill=\"#aaaaff\" stroke=\"#3f007f\" stroke-width=\"1\" points=\"" +
                            a.x + "," + a.y + " " + b.x + "," + b.y + " " + c.x + "," + c.y + " " + d.x + "," + d.y + " " + "\"/>";
            string shapeText = "<text fill=\"#000000\" font-size=\"20\" text-anchor=\"middle\" x=\"" + textX + "\" xml:space=\"preserve\" y=\"" + textY + "\">" + text + "</text>";
            return shape + shapeText;
        }

        public (int width, int height) GetDimensions()
        {
            return ((int)Math.Sqrt(two) * dimensions.width, (int)Math.Sqrt(two) * dimensions.height);
        }

        public void UpdateWidth()
        {
            if (text.Length <= defaultTextWidth)
            {
                return;
            }

            dimensions.width += (text.Length - defaultTextWidth) * textWidthMultiplier;
        }

        public void UpdateCoordinates((int x, int y) coordinates)
        {
            this.coordinatesCenter = coordinates;
        }
    }
}
