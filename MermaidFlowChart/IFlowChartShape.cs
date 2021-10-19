using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public interface IFlowChartShape
    {
        public (int width, int height) GetDimensions();

        public string DrawShape();

        public void UpdateDimensions();

        public void UpdateCoordinates((int x, int y) coordinates);
    }
}
