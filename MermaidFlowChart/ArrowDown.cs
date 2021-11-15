using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public class ArrowDown : IFlowChartShape
    {
        private readonly int defaultWidth;
        private readonly int defaultHeight = 80;
        private readonly int markerHeight = 20;
        private readonly int thickness = 2;
        private readonly int dashLength = 5;
        private readonly bool hasArrow;
        private (int width, int height) dimensions;
        private (int x, int y) coordinatesCenter;

        public ArrowDown(bool isDotted, bool isThick, bool hasArrow)
        {
            dimensions = (defaultWidth, defaultHeight);

            this.hasArrow = hasArrow;
            thickness = !isThick ? thickness : (1 + 1) * thickness;
            markerHeight = !isThick ? markerHeight : (1 + 1) * markerHeight;
            markerHeight = !hasArrow ? 0 : markerHeight;
            dashLength = !isDotted ? 0 : dashLength;
        }

        public string DrawShape()
        {
            int x = coordinatesCenter.x;
            int y1 = coordinatesCenter.y - dimensions.height / 2;
            int y2 = coordinatesCenter.y + dimensions.height / 2 - markerHeight;
            string markerHead = "<defs><marker id=\"endarrow\" markerWidth=\"10\" markerHeight=\"7\" refX=\"0\" refY=\"3.5\" orient=\"auto\">" +
                            "<polygon points=\"0 0, 10 3.5, 0 7\" /></marker></defs>";
            string line = "<line x1=\"" + x + "\" y1=\"" + y1 + "\" x2=\"" + x + "\" y2=\"" + y2 + "\" " +
                            "stroke=\"#000\" stroke-dasharray=\"" + dashLength + "\" stroke-width=\"" + thickness + "\" marker-end=\"url(#endarrow)\" />";
            string shape = !hasArrow ? line : markerHead + line;
            return shape;
        }

        public (int width, int height) GetDimensions()
        {
            return this.dimensions;
        }

        public void UpdateDimensions()
        {
            dimensions.width = 0;
        }

        public void UpdateCoordinates((int x, int y) coordinates)
        {
            this.coordinatesCenter = coordinates;
        }
    }
}
