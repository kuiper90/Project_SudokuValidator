using System.Collections.Generic;
using System.Linq;

namespace Project_SudokuValidator
{
    public class SudokuValidator
    {
        private readonly int[][] board;

        public SudokuValidator(int[][] sudokuBoard)
        {
            this.board = sudokuBoard;
        }

        public bool IsValid()
            => Rows()
                .Union(Columns())
                .Union(Boxes())
                .All(IsValid);

        private static bool IsValid(IEnumerable<int> elements)
        {
            return elements.Count() == 9
                && elements
                .Where(x => 0 < x && x < 10)
                .Distinct()
                .Count() == 9;
        }

        private IEnumerable<IEnumerable<int>> Columns()
            => Enumerable.Range(0, 9)
                .Select(i => board.Select(r => r[i]));

        private IEnumerable<IEnumerable<int>> Rows() => board;

        private IEnumerable<IEnumerable<int>> Boxes()
        {
            //version 1
            //var x = new[] { 0, 3, 6 };
            //return x.SelectMany(i => x.Select(j => Box(i, j)));

            //version 2
            return Enumerable.Range(0, 9)
                .Select(i => Box((i / 3) * 3, (i % 3) * 3));
        }

        private IEnumerable<int> Box(int x, int y)
        {
            return Enumerable.Range(x, 3)
                .SelectMany(i =>
                    Enumerable.Range(y, 3)
                    .Select(j => board[i][j]));
        }
    }
}
