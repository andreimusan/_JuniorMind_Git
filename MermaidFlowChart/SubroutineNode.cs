﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public class SubroutineNode : IFlowChartShape
    {
        private readonly int defaultWidth = 84;
        private readonly int defaultHeight = 40;
        private readonly int defaultTextWidth = 5;
        private readonly int textWidthMultiplier = 8;
        private readonly string text;
        private (int width, int height) dimensions;
        private (int x, int y) coordinates;

        public SubroutineNode(string textInput)
        {
            text = textInput;
            dimensions = (defaultWidth, defaultHeight);
        }

        public string DrawShape()
        {
            int textX = coordinates.x;
            int textY = coordinates.y + 5;
            int x = coordinates.x - dimensions.width / 2;
            int y = coordinates.y - dimensions.height / 2;
            string shape = "<rect fill=\"#aaaaff\" stroke=\"#3f007f\" stroke-width=\"1\" height=\"" + dimensions.height + "\" width=\"" + dimensions.width +
                            "\" x=\"" + x + "\" y=\"" + y + "\"/>";
            string smallRectangle = "<rect fill=\"#aaaaff\" stroke=\"#3f007f\" stroke-width=\"1\" height=\"" + dimensions.height + "\" width=\"" + (dimensions.width - 14) +
                            "\" x=\"" + (x + 7) + "\" y=\"" + y + "\"/>";
            string shapeText = "<text fill=\"#000000\" font-size=\"20\" text-anchor=\"middle\" x=\"" + textX + "\" xml:space=\"preserve\" y=\"" + textY + "\">" + text + "</text>";
            return shape + smallRectangle + shapeText;
        }

        public (int width, int height) GetDimensions()
        {
            return this.dimensions;
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
            this.coordinates = coordinates;
        }
    }
}