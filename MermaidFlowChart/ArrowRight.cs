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
        private (int width, int height) dimensions;
        private (int x, int y) coordinatesCenter;

        public ArrowRight()
        {
            dimensions = (defaultWidth, defaultHeight);
        }

        public string DrawShape()
        {
            int x1 = coordinatesCenter.x - dimensions.width / 2;
            int x2 = coordinatesCenter.x + dimensions.width / 2 - markerWidth;
            int y = coordinatesCenter.y;
            string shape = "<defs><marker id=\"endarrow\" markerWidth=\"10\" markerHeight=\"7\" refX=\"0\" refY=\"3.5\" orient=\"auto\">" +
                            "<polygon points=\"0 0, 10 3.5, 0 7\" /></marker></defs>" +
                            "<line x1=\"" + x1 + "\" y1=\"" + y + "\" x2=\"" + x2 + "\" y2=\"" + y + "\" " +
                            "stroke=\"#000\" stroke-width=\"2\" marker-end =\"url(#endarrow)\" />";
            return shape;
        }

        public (int width, int height) GetDimensions()
        {
            return this.dimensions;
        }

        public void UpdateWidth()
        {
            dimensions.height = 0;
        }

        public void UpdateCoordinates((int x, int y) coordinates)
        {
            this.coordinatesCenter = coordinates;
        }
    }
}
