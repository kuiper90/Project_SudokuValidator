using System.Linq;

namespace Project_SudokuValidator
{
    public static class SudokuValidator
    {
        private static bool Distinct(int[] row)
        {
            int[] mask = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < 9; i++)
            {
                if (row[i] < 1 || row[i] > 9)
                    return false;
                mask[row[i] - 1] = 1;
            }
            return mask.Sum(x => x) == 9;
        }

        private static bool ValidateRows(int[][] sudokuBoard)
            => sudokuBoard.All(row => Distinct(row));

        private static bool ValidateColumns(int[][] sudokuBoard)
            => sudokuBoard
                .Select((row, i) => sudokuBoard
                .Select(r => r[i]))
                .All(t => Distinct(t.ToArray()));

        private static bool ValidateBox(int[][] sudokuBoard)
            => sudokuBoard.Select((row, i) =>
                 sudokuBoard.Skip((i / 3) * 3).Take(3)
                 .Select(r => r.Skip((i % 3) * 3).Take(3))
                 .SelectMany(x => x).ToArray()).All(square => Distinct(square));

        public static bool ValidateSudoku(int[][] sudokuBoard)
            => ValidateRows(sudokuBoard) && ValidateColumns(sudokuBoard) && ValidateBox(sudokuBoard);
    }
}