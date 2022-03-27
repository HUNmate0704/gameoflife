using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameoflife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameDrawer gamedraw = new GameDrawer(29, 120); //max 29 row and 120 column

            //crawls right down
            gamedraw.AddCell(3, 2);
            gamedraw.AddCell(4, 3);
            gamedraw.AddCell(2, 4);
            gamedraw.AddCell(3, 4);
            gamedraw.AddCell(4, 4);
            //3 in one line
            //jatekrajzolo.AddCell(7, 5);
            //jatekrajzolo.AddCell(7, 6);
            //jatekrajzolo.AddCell(7, 7);

            //3 in one column
            //jatekrajzolo.AddCell(7, 3);
            //jatekrajzolo.AddCell(8, 3);
            //jatekrajzolo.AddCell(9, 3);

            //cube
            //jatekrajzolo.AddCell(7, 3);
            //jatekrajzolo.AddCell(7, 4);
            //jatekrajzolo.AddCell(8, 3);
            //jatekrajzolo.AddCell(8, 4);

            //works on keypress
            //while (true)
            //{
            //    gamedraw.Draw();
            //    Console.ReadKey();
            //    gamedraw.NextGeneration();
            //}


            //works on tick
            while (true)
            {
                gamedraw.Draw();
                System.Threading.Thread.Sleep(100);
                gamedraw.NextGeneration();
            }

        }
    }
}
