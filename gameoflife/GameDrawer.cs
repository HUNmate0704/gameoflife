using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameoflife
{
    internal class GameDrawer
    {
        String[,] drawArray;
        //A=alive, O=dead, 29 is max size, cause this is the default console height and width 
        public GameDrawer(int row, int column)
        {
            if (row > 29)
            {
                throw new OutOfBoundsException("Row too big, max size: 29");
            }

            if (column > 120)
            {
                throw new OutOfBoundsException("Column too big, max size: 120");
            }

            drawArray = new string[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    drawArray[i, j] = "O";
                }
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(0, Console.WindowTop);
            for (int i = 0; i < drawArray.GetLength(0); i++)
            {
                for (int j = 0; j < drawArray.GetLength(1); j++)
                {
                    Console.BackgroundColor = ConsoleColor.White;     //dead color
                    if (drawArray[i, j] == "A")
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;  //alive color
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                }
                Console.Write("\n");
            }
        }

        public void NextGeneration()
        {
            String[,] nextStateDrawArray = drawArray.Clone() as String[,];


            for (int i = 0; i < drawArray.GetLength(0); i++)
            {
                for (int j = 0; j < drawArray.GetLength(1); j++)
                {
                    if (drawArray[i, j] == "A") //if alive
                    {
                        if (Neighbors(i, j) < 2)
                        {
                            int ne = Neighbors(i, j);
                            nextStateDrawArray[i, j] = "O";

                        }
                        if (Neighbors(i, j) > 3)
                        {
                            nextStateDrawArray[i, j] = "O";
                        }
                    }
                    else //if dead
                    {
                        if (Neighbors(i, j) == 3)
                        {
                            nextStateDrawArray[i, j] = "A";
                        }
                    }
                }
            }

            //comment the line below if you want to separate the drawing from the next generation
            Draw();

            drawArray = nextStateDrawArray.Clone() as string[,];  //weird way, but needed to clone, "as" is mandatory
        }
        public int Neighbors(int row, int column)
        {
            int neighborCounter = 0;

            if (row != 0 && column != 0)
            {
                if (drawArray[row - 1, column - 1] == "A") //left up
                {
                    neighborCounter++;
                }
            }
            if (row != 0)
            {
                if (drawArray[row - 1, column] == "A") //left
                {
                    neighborCounter++;
                }
            }
            if (row != 0 && column != 119)
            {
                if (drawArray[row - 1, column + 1] == "A") //right up
                {
                    neighborCounter++;
                }
            }
            if (column != 119)
            {
                if (drawArray[row, column + 1] == "A") //right
                {
                    neighborCounter++;
                }
            }
            if (row != 28 && column != 119)
            {
                if (drawArray[row + 1, column + 1] == "A") //right down
                {
                    neighborCounter++;
                }
            }
            if (row != 28)
            {
                if (drawArray[row + 1, column] == "A") //down
                {
                    neighborCounter++;
                }
            }
            if (row != 28 && column != 0)
            {
                if (drawArray[row + 1, column - 1] == "A") //left down
                {
                    neighborCounter++;
                }
            }
            if (column != 0)
            {
                if (drawArray[row, column - 1] == "A") //left
                {
                    neighborCounter++;
                }
            }
            return neighborCounter;
        }

        public void AddCell(int row, int column)
        {
            drawArray[row, column] = "A";
        }
    }
}
