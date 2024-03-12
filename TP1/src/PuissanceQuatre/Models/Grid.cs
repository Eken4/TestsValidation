namespace MorpionApp.Models
{
    public class Grid
    {
        private char[,] cases;

        public int Height { get; }
        public int Width { get; }

        public Grid(int height, int width)
        {
            Width = width;
            Height = height;
            cases = new char[height, width];
        }

        public void SetCase(int x, int y, char token)
        {
            cases[x, y] = token;
        }

        public char GetCase(int x, int y)
        {
            return cases[x, y];
        }

        public bool IsCaseEmpty(int x, int y)
        {
            return cases[x, y] == ' ';
        }

        public bool IsTopEdge(int x, int y)
        {
            if (x == 0)
                return true;
            else return false;

        }

        public bool IsBottomEdge(int x, int y)
        {
            if (x == Height)
                return true;
            else return false;

        }

        public bool IsLeftEdge(int x, int y)
        {
            if (y == 0)
                return true;
            else return false;

        }

        public bool IsRightEdge(int x, int y)
        {
            if (x == Width)
                return true;
            else return false;

        }
    }
}
