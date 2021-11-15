using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public class ArrowRight : IFlowChartShape
    {
        private readonly int defaultWidth = 80;
        private readonly int defaultHeight;
        private readonly int markerWidth = 20;
        private readonly int thickness = 2;
        private readonly int dashLength = 5;
        private readonly bool hasArrow;
        private (int width, int height) dimensions;
        private (int x, int y) coordinatesCenter;

        public ArrowRight(bool isDotted, bool isThick, bool hasArrow)
        {
            dimensions = (defaultWidth, defaultHeight);

            this.hasArrow = hasArrow;
            thickness = !isThick ? thickness : (1 + 1) * thickness;
            markerWidth = !isThick ? markerWidth : (1 + 1) * markerWidth;
            markerWidth = !hasArrow ? 0 : markerWidth;
            dashLength = !isDotted ? 0 : dashLength;
        }

        public string DrawShape()
        {
            int x1 = coordinatesCenter.x - dimensions.width / 2;
            int x2 = coordinatesCenter.x + dimensions.width / 2 - markerWidth;
            int y = coordinatesCenter.y;
            string markerHead = "<defs><marker id=\"endarrow\" markerWidth=\"10\" markerHeight=\"7\" refX=\"0\" refY=\"3.5\" orient=\"auto\">" +
                            "<polygon points=\"0 0, 10 3.5, 0 7\" /></marker></defs>";
            string line = "<line x1=\"" + x1 + "\" y1=\"" + y + "\" x2=\"" + x2 + "\" y2=\"" + y + "\" " +
                            "stroke=\"#000\" stroke-dasharray=\"" + dashLength + "\" stroke-width=\"" + thickness + "\" marker-end =\"url(#endarrow)\" />";
            string shape = !hasArrow ? line : markerHead + line;
            return shape;
        }

        public (int width, int height) GetDimensions()
        {
            return this.dimensions;
        }

        public void UpdateDimensions()
        {
            dimensions.height = 0;
        }

        public void UpdateCoordinates((int x, int y) coordinates)
        {
            this.coordinatesCenter = coordinates;
        }
    }
}
