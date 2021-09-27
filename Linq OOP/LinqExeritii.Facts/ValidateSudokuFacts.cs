using LinqExercitii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LinqExeritii.Facts
{
    public class ValidateSudokuFacts
    {
        [Fact]
        public void Test_ValidateSudokuValidBoard()
        {
            byte[,] sudokuBoard = new byte[,]
            {
                { 6, 3, 9, 5, 7, 4, 1, 8, 2 },
                { 5, 4, 1, 8, 2, 9, 3, 7, 6 },
                { 7, 8, 2, 6, 1, 3, 9, 5, 4 },
                { 1, 9, 8, 4, 6, 7, 5, 2, 3 },
                { 3, 6, 5, 9, 8, 2, 4, 1, 7 },
                { 4, 2, 7, 1, 3, 5, 8, 6, 9 },
                { 9, 5, 6, 7, 4, 8, 2, 3, 1 },
                { 8, 1, 3, 2, 9, 6, 7, 4, 5 },
                { 2, 7, 4, 3, 5, 1, 6, 9, 8 }
            };

            Assert.True(ValidateSudoku.IsValidSudokuBoard(sudokuBoard));
        }

        [Fact]
        public void Test_ValidateSudokuMoreLines()
        {
            byte[,] sudokuBoard = new byte[,]
            {
                { 6, 3, 9, 5, 7, 4, 1, 8, 2 },
                { 5, 4, 1, 8, 2, 9, 3, 7, 6 },
                { 7, 8, 2, 6, 1, 3, 9, 5, 4 },
                { 1, 9, 8, 4, 6, 7, 5, 2, 3 },
                { 3, 6, 5, 9, 8, 2, 4, 1, 7 },
                { 4, 2, 7, 1, 3, 5, 8, 6, 9 },
                { 9, 5, 6, 7, 4, 8, 2, 3, 1 },
                { 8, 1, 3, 2, 9, 6, 7, 4, 5 },
                { 2, 7, 4, 3, 5, 1, 6, 9, 8 },
                { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
            };

            Assert.False(ValidateSudoku.IsValidSudokuBoard(sudokuBoard));
        }

        [Fact]
        public void Test_ValidateSudokuMoreColumns()
        {
            byte[,] sudokuBoard = new byte[,]
            {
                { 6, 3, 9, 5, 7, 4, 1, 8, 2, 1 },
                { 5, 4, 1, 8, 2, 9, 3, 7, 6, 2 },
                { 7, 8, 2, 6, 1, 3, 9, 5, 4, 3 },
                { 1, 9, 8, 4, 6, 7, 5, 2, 3, 4 },
                { 3, 6, 5, 9, 8, 2, 4, 1, 7, 5 },
                { 4, 2, 7, 1, 3, 5, 8, 6, 9, 6 },
                { 9, 5, 6, 7, 4, 8, 2, 3, 1, 7 },
                { 8, 1, 3, 2, 9, 6, 7, 4, 5, 8 },
                { 2, 7, 4, 3, 5, 1, 6, 9, 8, 9 }
            };

            Assert.False(ValidateSudoku.IsValidSudokuBoard(sudokuBoard));
        }

        [Fact]
        public void Test_ValidateSudokuDuplicateValues()
        {
            byte[,] sudokuBoard = new byte[,]
            {
                { 6, 3, 9, 5, 7, 4, 1, 8, 2, 1 },
                { 5, 4, 1, 8, 2, 9, 3, 7, 6, 2 },
                { 7, 8, 2, 6, 1, 3, 9, 5, 4, 3 },
                { 1, 9, 8, 4, 6, 7, 5, 2, 3, 4 },
                { 3, 6, 5, 9, 8, 2, 4, 1, 7, 7 },
                { 4, 2, 7, 1, 3, 5, 8, 6, 9, 6 },
                { 9, 5, 6, 7, 4, 8, 2, 3, 1, 7 },
                { 8, 1, 3, 2, 9, 6, 7, 4, 5, 8 }
            };

            Assert.False(ValidateSudoku.IsValidSudokuBoard(sudokuBoard));
        }
    }
}
