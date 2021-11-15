using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MermaidFlowChart
{
    public class DrawFlowChart
    {
        private readonly IFlowChartOrientation orientation;
        private string remainingText;

        public DrawFlowChart(string textInput)
        {
            this.remainingText = File.ReadAllText(textInput);
            GenerateFlowchart();
            orientation = SetOrientation();
        }

        public string Draw()
        {
            return orientation.Draw();
        }

        private void GenerateFlowchart()
        {
            var whitespace = new Many(new Any(" \r\n\t"));
            var graph = new Choice(
                            new CharacterText("flowchart"),
                            new CharacterText("graph"),
                            new CharacterText("subgraph"));
            var graphSequence = new Sequence(
                                    new Many(whitespace),
                                    graph,
                                    new Many(whitespace));
            var graphElement = graphSequence.Match(remainingText);

            if (!graphElement.Success())
            {
                throw new ArgumentException("Use correct format to generate flowchart!");
            }

            remainingText = graphElement.RemainingText();
        }

        private IFlowChartOrientation SetOrientation()
        {
            var whitespace = new Many(new Any(" \r\n\t"));
            var orientationText = new Choice(
                                    new CharacterText("TB"),
                                    new CharacterText("BT"),
                                    new CharacterText("LR"),
                                    new CharacterText("RL"));
            var orientationTextSequence = new Sequence(
                                            new Many(whitespace),
                                            orientationText,
                                            new Many(whitespace));
            var orientationElement = orientationTextSequence.Match(remainingText);

            if (!orientationElement.Success())
            {
                throw new ArgumentException("Use correct format to generate flowchart orientation!");
            }

            string newOrientation = orientationElement.CutText().Trim();
            remainingText = orientationElement.RemainingText();

            return newOrientation switch
            {
                "BT" => new OrientationBT(remainingText),
                "LR" => new OrientationLR(remainingText),
                "RL" => new OrientationRL(remainingText),
                _ => new OrientationTB(remainingText),
            };
        }
    }
}
