using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqExercitii
{
    public class ValidateSudoku
    {
        public static bool IsValidSudokuBoard(byte[,] sudokuBoard)
        {
            var sudokuLineSize = 9;

            if (sudokuBoard is null || sudokuBoard.GetLength(0) != sudokuLineSize || sudokuBoard.GetLength(1) != sudokuLineSize)
            {
                return false;
            }

            var sudokuLines = GenerateSudokuLines(sudokuBoard);
            var sudokuColumns = GenerateSudokuColumns(sudokuBoard);
            var sudokuBlocks = GenerateSudokuBlocks(sudokuBoard);

            var result = IsValidSudokuItem(sudokuLines.Concat(sudokuColumns).Concat(sudokuBlocks));

            return result;
        }

        public static bool IsValidSudokuItem(IEnumerable<IEnumerable<byte>> itemType)
        {
            var result = itemType.All(item => item.All(value => value >= 1 && value <= 9) && item.Count() == item.Distinct().Count() && item.Count() == 9);

            return result;
        }

        private static IEnumerable<IEnumerable<byte>> GenerateSudokuLines(byte[,] sudokuBoard)
        {
            var result = Enumerable.Range(0, sudokuBoard.GetLength(0)).
                Select(line => Enumerable.Range(0, sudokuBoard.GetLength(1)).
                Select(column => sudokuBoard[line, column]));

            return result;
        }

        private static IEnumerable<IEnumerable<byte>> GenerateSudokuColumns(byte[,] sudokuBoard)
        {
            var result = Enumerable.Range(0, sudokuBoard.GetLength(0)).
                Select(line => Enumerable.Range(0, sudokuBoard.GetLength(1)).
                Select(column => sudokuBoard[column, line]));

            return result;
        }

        private static IEnumerable<IEnumerable<byte>> GenerateSudokuBlocks(byte[,] sudokuBoard)
        {
            var sudokuBlockSize = 3;
            var result = Enumerable.Range(0, sudokuBoard.GetLength(0)).
                Select(line => Enumerable.Range(0, sudokuBoard.GetLength(1)).
                Select(column => sudokuBoard[line / sudokuBlockSize * sudokuBlockSize + column / sudokuBlockSize, line % sudokuBlockSize * sudokuBlockSize + column % sudokuBlockSize]));

            return result;
        }
    }
}
