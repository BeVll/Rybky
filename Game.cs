using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Рибки
{
    internal class Game
    {
        private List<List<Fishs>> Fishs;
        private Fishs picked;
        private Fishs empty_fish;
        public Game()
        {
            empty_fish.Type = " ";
            for (int i=0;i<6;i++)
            {
                Fishs[i] = new List<Fishs>();
                for(int j=0;j<6;j++)
                {
                    Fishs[i][j] = empty_fish;
                }

            }
        }

        private void Show()
        {
            foreach(List<Fishs> fishs in Fishs)
            {
                Console.WriteLine();
                foreach (Fishs f in fishs)
                {
                    Console.Write($"|{f.Type}");
                }
               
            }
        }

        private void GenerateFishs(int row)
        {
           
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                if (rnd.Next(0, 2) != 2)
                {
                    Fishs f = new Fishs();
                    Fishs[row][i] = f;
                }
            }
        }

        public void StartGame()
        {
            bool finished = true;
            while (finished != false)
            {
                Show();
            }
        }
    }
}
