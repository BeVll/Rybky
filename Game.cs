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
        private int points;
        public Game()
        {
            points = 0;
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

        private void GenerateFishs(int count_row)
        {
            for (int j = 0; j < count_row; j++)
            {
                Random rnd = new Random();
                for (int i = 0; i < 6; i++)
                {
                    if (rnd.Next(0, 2) != 1)
                    {
                        Fishs f = new Fishs();
                        Fishs[j][i] = f;
                    }
                }
            }
        }
        public bool CheckGenerate()
        {
            int count = 0;
            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    if (Fishs[i][j].Type != " ")
                        count++;
                }
            }

            if (count < 4)
                return true;
            else
                return false;
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
            Random random = new Random();
            bool check = true;
            int row = 0;
            int column = 0;
            int row_temp = 0;
            int column_temp = 0;
            picked.Type = "Empty";
            while (Fishs[row][column].Type == " " || LastRow(column) == -1)
            {
                if (Fishs[row][column].Type == " ")
                {
                    column = ColumnPlus(column);
                    if (LastRow(column) == -1)
                        column = ColumnMinus(column);
                    else
                        row = LastRow(column);
                }
            }
            while (check != false)
            {
                if (CheckGenerate() == true)
                    GenerateFishs(random.Next(1, 6));
                Console.Clear();
                Console.WriteLine($"Points: {points}");
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
                            row_temp = row;
                            column_temp = column;
                            picked.Type = Fishs[row][column].Type;
                            Fishs[row][column].Type = empty_fish.Type;
                        }
                        else
                        {
                            string temp = Fishs[row][column].Eat(picked.Type);
                            if (temp == "0")
                            {
                                Fishs[row][column].Type = empty_fish.Type;
                                picked.Type = "Empty";
                                points++;
                                column = ColumnPlus(column);
                                if (LastRow(column) == -1)
                                    column = ColumnPlus(column);
                                else
                                    row = LastRow(column);
                            }

                            else if (temp == "1")
                            {
                                Fishs[row_temp][column_temp].Type = picked.Type;
                                picked.Type = "Empty";
                            }
                            else
                            {
                                Fishs[row][column].Type = temp;
                                picked.Type = "Empty";
                            }
                        }
                    }
                }
                
                
            }
        }

        public void StartGame()
        {
            Random random = new Random();
            bool finished = true;
            GenerateFishs(random.Next(1, 6));
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
