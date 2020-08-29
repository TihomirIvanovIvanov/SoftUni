namespace P03_JediGalaxy
{
    public class Board
    {
        private readonly int[,] matrix;

        public Board(int rows, int cols)
        {
            this.Matrix = new int[rows, cols];
        }

        public int[,] Matrix { get; set; }

        public void InitializeMatrix()
        {
            int value = 0;
            for (int i = 0; i < this.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.Matrix.GetLength(1); j++)
                {
                    this.Matrix[i, j] = value++;
                }
            }
        }

        public bool IsInside(int row, int col)
        {
            return row >= 0 && row < this.Matrix.GetLength(0) &&
                   col >= 0 && col < this.Matrix.GetLength(1);
        }
    }
}
