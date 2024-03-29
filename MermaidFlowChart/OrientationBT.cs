﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MermaidFlowChart
{
    public class OrientationBT : IFlowChartOrientation
    {
        private readonly List<IFlowChartShape> shapes;
        private readonly int spacing = 20;
        private readonly int half = 2;
        private int prevHeight = 20;
        private string svg = "";

        public OrientationBT(string text)
        {
            var textToShapes = new TextToShape(text, "BT");
            shapes = textToShapes.AddShapes().ToList();
            shapes.Reverse();
        }

        public string Draw()
        {
            shapes.ForEach(x => x.UpdateDimensions());
            int maxLenghth = shapes.OrderBy(x => x.GetDimensions().width).Last().GetDimensions().width;

            foreach (var elem in shapes)
            {
                int currentHeight = elem.GetDimensions().height;
                (int, int) newCoordinates = (maxLenghth / half + spacing, prevHeight + (currentHeight / half));
                elem.UpdateCoordinates(newCoordinates);
                svg += elem.DrawShape();
                prevHeight += currentHeight;
            }

            return svg;
        }
    }
}
