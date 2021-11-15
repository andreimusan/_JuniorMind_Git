using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public class TextToShape
    {
        private readonly string text;
        private readonly List<IFlowChartShape> shapes;
        private readonly string orientation;
        private readonly List<IPattern> pattern;

        public TextToShape(string text, string orientation)
        {
            this.text = text;
            shapes = new List<IFlowChartShape>();
            pattern = new List<IPattern>() { new ShapeTextSequence(), new LinkTextSequence() };
            this.orientation = orientation;
        }

        public ICollection<IFlowChartShape> AddShapes()
        {
            var lines = new List<string>();
            var remainingText = text;
            var prevText = "";

            while (remainingText != "" || remainingText != prevText)
            {
                foreach (var elem in pattern)
                {
                    var match = elem.Match(remainingText);
                    prevText = remainingText;

                    if (match.Success())
                    {
                        lines.Add(elem.CutText().Trim());
                    }

                    remainingText = match.RemainingText();
                }
            }

            string shapeElement = ")]}";
            string linkElement = "|-=>";

            foreach (var elem in lines)
            {
                if (shapeElement.Contains(elem[^1]))
                {
                    SelectShape(elem);
                }
                else if (linkElement.Contains(elem[^1]))
                {
                    SelectArrow();
                }
            }

            return shapes;
        }

        private void SelectArrow()
        {
            if (orientation == "TB")
            {
                shapes.Add(new ArrowDown(false, false, true));
            }
            else if (orientation == "BT")
            {
                shapes.Add(new ArrowUp(false, false, false));
            }
            else if (orientation == "LR")
            {
                shapes.Add(new ArrowRight(false, false, false));
            }
            else if (orientation == "RL")
            {
                shapes.Add(new ArrowLeft(false, false, false));
            }
        }

        private void SelectShape(string elem)
        {
            int two = 2;
            if ("/\\".Contains(elem[1]) && "/\\".Contains(elem[^two]))
            {
                ParallelShape(elem);
            }
            else if ("([".Contains(elem[1]) && ")]".Contains(elem[^two]))
            {
                ComplexShape(elem);
            }
            else if (elem.Substring(0, two) == "{{" && elem.Substring(elem.Length - two, two) == "}}")
            {
                shapes.Add(new HexagonNode(elem[two..^two]));
            }
            else
            {
                SimpleShape(elem);
            }
        }

        private void SimpleShape(string element)
        {
            string words = element[1..^1];

            if (element[0] == '[' && element[^1] == ']')
            {
                shapes.Add(new RectangleNode(words));
            }
            else if (element[0] == '(' && element[^1] == ')')
            {
                shapes.Add(new RoundEdgedNode(words));
            }
            else if (element[0] == '>' && element[^1] == ']')
            {
                shapes.Add(new AsymmetricNode(words));
            }
            else if (element[0] == '{' && element[^1] == '}')
            {
                shapes.Add(new RhombusNode(words));
            }
            else
            {
                shapes.Add(new RectangleNode(element));
            }
        }

        private void ComplexShape(string element)
        {
            int two = 2;
            string words = element[2..^2];

            if (element.Substring(0, two) == "([" && element.Substring(element.Length - two, two) == "])")
            {
                shapes.Add(new StadiumShapedNode(words));
            }
            else if (element.Substring(0, two) == "[[" && element.Substring(element.Length - two, two) == "]]")
            {
                shapes.Add(new SubroutineNode(words));
            }
            else if (element.Substring(0, two) == "[(" && element.Substring(element.Length - two, two) == ")]")
            {
                shapes.Add(new CylindricalNode(words));
            }
            else if (element.Substring(0, two) == "((" && element.Substring(element.Length - two, two) == "))")
            {
                shapes.Add(new CircleNode(words));
            }
            else
            {
                shapes.Add(new RectangleNode(element));
            }
        }

        private void ParallelShape(string element)
        {
            int two = 2;
            string words = element[2..^2];

            if (element.Substring(0, two) == "[/" && element.Substring(element.Length - two, two) == "\\]")
            {
                shapes.Add(new TrapezoidNode(words));
            }
            else if (element.Substring(0, two) == "[\\" && element.Substring(element.Length - two, two) == "/]")
            {
                shapes.Add(new TrapezoidAltNode(words));
            }
            else if (element.Substring(0, two) == "[/" && element.Substring(element.Length - two, two) == "/]")
            {
                shapes.Add(new ParallelogramNode(words));
            }
            else if (element.Substring(0, two) == "[\\" && element.Substring(element.Length - two, two) == "\\]")
            {
                shapes.Add(new ParallelogramAltNode(words));
            }
            else
            {
                shapes.Add(new RectangleNode(element));
            }
        }
    }
}
