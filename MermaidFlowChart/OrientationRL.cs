using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MermaidFlowChart
{
    public class OrientationRL : IFlowChartOrientation
    {
        private readonly List<IFlowChartShape> shapes;
        private readonly int spacing = 20;
        private readonly int half = 2;
        private int prevWidth = 20;
        private string svg = "";

        public OrientationRL(ICollection<string> elements)
        {
            var textToShapes = new TextToShape(elements.ToList(), "RL");
            shapes = textToShapes.AddShapes().ToList();
            shapes.Reverse();
        }

        public string Draw()
        {
            shapes.ForEach(x => x.UpdateDimensions());
            int maxHeight = shapes.OrderBy(x => x.GetDimensions().height).Last().GetDimensions().height;

            foreach (var elem in shapes)
            {
                int currentWidth = elem.GetDimensions().width;
                (int, int) newCoordinates = (prevWidth + (currentWidth / half), maxHeight / half + spacing);
                elem.UpdateCoordinates(newCoordinates);
                svg += elem.DrawShape();
                prevWidth += currentWidth;
            }

            return svg;
        }
    }
}
