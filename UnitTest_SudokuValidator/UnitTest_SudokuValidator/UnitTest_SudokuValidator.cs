using static Project_SudokuValidator.SudokuUtils;
using Xunit;

namespace UnitTest_SudokuValidator
{
    public class UnitTest_SudokuValidator
    {
        [Fact]
        public void SudokuOK_Validator_ShouldReturn_True()
        {
            int[][] sudokuBoard = new int[][] { new int[] { 4,3,5,2,6,9,7,8,1},
                                                new int[] { 6,8,2,5,7,1,4,9,3},
                                                new int[] { 1,9,7,8,3,4,5,6,2},
                                                new int[] { 8,2,6,1,9,5,3,4,7},
                                                new int[] { 3,7,4,6,8,2,9,1,5},
                                                new int[] { 9,5,1,7,4,3,6,2,8},
                                                new int[] { 5,1,9,3,2,6,8,7,4},
                                                new int[] { 2,4,8,9,5,7,1,3,6},
                                                new int[] { 7,6,3,4,1,8,2,5,9},
                                            };
            Assert.True(ValidateSudoku(sudokuBoard) == true);
        }

        [Fact]
        public void SudokuWithDuplicates_Validator_ShouldReturn_False()
        {
            int[][] sudokuBoard = new int[][] { new int[] { 4,3,5,2,6,9,7,8,1},
                                                new int[] { 6,8,2,5,7,1,4,9,3},
                                                new int[] { 1,9,7,8,3,4,5,6,2},
                                                new int[] { 8,2,6,1,9,5,3,4,7},
                                                new int[] { 3,7,4,6,8,2,9,1,5},
                                                new int[] { 9,5,1,7,4,3,6,2,8},
                                                new int[] { 5,1,9,3,2,6,8,7,4},
                                                new int[] { 2,4,8,9,5,7,1,3,6},
                                                new int[] { 1,6,3,4,1,8,2,5,9},
                                             };
            Assert.True(ValidateSudoku(sudokuBoard) == false);
        }

        [Fact]
        public void IncorrectSudoku_Validator_ShouldReturn_False()
        {
            int[][] sudokuBoard = new int[][] { new int[] { 4,3,5,2,6,9,7,8,1},
                                                new int[] { 6,8,2,5,7,1,4,9,3},
                                                new int[] { 1,9,7,8,3,4,5,6,2},
                                                new int[] { 8,2,6,1,9,5,3,4,7},
                                                new int[] { 3,7,4,6,0,2,9,1,5},
                                                new int[] { 9,5,1,7,4,3,6,2,8},
                                                new int[] { 5,1,9,3,2,6,8,7,4},
                                                new int[] { 2,4,8,9,5,7,1,3,6},
                                                new int[] { 1,6,3,4,1,8,2,5,9},
                                            };
            Assert.True(ValidateSudoku(sudokuBoard) == false);
        }

        [Fact]
        public void IncompleteSudoku_Validator_ShouldReturn_False()
        {
            int[][] sudokuBoard = new int[][] { new int[] { 4,3,5,2,6,9,7,8,1},
                                                new int[] { 6,8,2,5,7,1,4,9,3},
                                                new int[] { 1,9,7,8,3,4,5,6,2},
                                                new int[] { 8,2,6,1,9,5,3,4,7},
                                                new int[] { 3,7,4,6,0,2,9,1,5},
                                                new int[] { 9,5,1,7,4,3,6,2,8},
                                                new int[] { 5,1,9,3,2,6,8,7,4},
                                                new int[] { 2,4,8,9,5,7,1,6},
                                                new int[] { 1,6,3,4,1,8,2,5,9},
                                            };
            Assert.True(ValidateSudoku(sudokuBoard) == false);
        }
    }
}