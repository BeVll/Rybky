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
            picked = new Fishs();
            empty_fish = new Fishs();
            Fishs = new List<List<Fishs>>();
            empty_fish.Type = " ";
            for (int i=0;i<6;i++)
            {
                Fishs.Add(new List<Fishs>());
                for(int j=0;j<6;j++)
                {
                    Fishs[i].Add(empty_fish);
                }

            }
        }

        private void Show(int row, int coloum)
        {
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 6; j++)
                {
                    if(row == i && coloum == j)
                        Console.Write($"|*{Fishs[i][j].Type}*");
                    else
                        Console.Write($"| {Fishs[i][j].Type} ");
                }
               
            }
        }

        private void GenerateFishs(int row)
        {
           
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                if (rnd.Next(0, 2) != 1)
                {
                    Fishs f = new Fishs();
                    Fishs[row][i] = f;
                }
            }
        }

        private int ColumnPlus(int column)
        {
            if (column == 5)
                column = 0;
            else
                column++;

            return column;
        }

        private int ColumnMinus(int column)
        {
            if (column == 0)
                column = 5;
            else
                column--;

            return column;
        }

        public void ChooseFish()
        {
            bool check = true;
            int row = 0;
            int column = 0;
            picked.Type = "Empty";
            while (check != false)
            {
                if (Fishs[row][column].Type == " ")
                    column = ColumnPlus(column);
                Console.Clear();
                Console.WriteLine($"Picked: {picked.Type}");
                Show(row, column);
                ConsoleKeyInfo key = Console.ReadKey();
                

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    column = ColumnMinus(column);
                    if (LastRow(column) == -1)
                        column = ColumnMinus(column);
                    else
                        row = LastRow(column);
                }

                else if (key.Key == ConsoleKey.RightArrow)
                {
                    column = ColumnPlus(column);
                    if (LastRow(column) == -1)
                        column = ColumnPlus(column);
                    else
                        row = LastRow(column);
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (Fishs[row][column].Type == "m" || Fishs[row][column].Type == "M" || Fishs[row][column].Type == "s" || Fishs[row][column].Type == "S" || Fishs[row][column].Type == "b" || Fishs[row][column].Type == "B")
                    {
                        if (picked.Type == "Empty")
                        {
                            picked.Type = Fishs[row][column].Type;
                            Fishs[row][column].Type = empty_fish.Type;
                        }
                        else
                        {
                            if (Fishs[row][column].Eat(picked.Type) == "0")
                            {
                                Fishs[row][column].Type = empty_fish.Type;
                                picked.Type = "Empty";
                            }

                            else if (Fishs[row][column].Eat(picked.Type) != "1")
                            {
                                Fishs[row][column].Type = Fishs[row][column].Eat(picked.Type);
                                picked.Type = "Empty";
                            }
                        }
                    }
                }
                
                
            }
        }

        public void StartGame()
        {
            bool finished = true;
            GenerateFishs(0);
            GenerateFishs(1);
            while (finished != false)
            {
                
                ChooseFish();
            }
        }

        private int LastRow(int column)
        {
            int last = -1;
            for(int i = 0; i < 6; i++)
            {
                if (Fishs[i][column].Type != " ")
                    last = i;
            }
            return last;
        }
    }
}
