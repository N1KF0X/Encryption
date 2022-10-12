using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    internal static class Encryption
    {
        static private Random random = new Random();
        public static int[,] Key_Generation()
        {
            int[] quarter = new int[25];
            int[,] grid = new int[10,10];       

            for (int i = 0; i < 25; i++)
            {
                quarter[i] = random.Next(4);                
            }

            int cageNumber = 0;

            for (int line = 0; line < 5; line++)
            {
                for (int column = 0; column < 5; column++)
                {                
                    switch (quarter[cageNumber])
                    {
                        default:
                            break;

                        case 0:
                            grid[line, column] = 1;
                            break;

                        case 1:
                            grid[column, 9 - line] = 1;
                            break;

                        case 2:
                            grid[9 - column, line] = 1;
                            break;

                        case 3:
                            grid[9 - line, 9 - column] = 1;
                            break;
                    }
                    cageNumber++;
                }
            }
            return grid;
        }   
        
        public static String Encryp_Text(String text, int[,] grid)
        {
            String encrypteЕext = "";
            char[,] textChars = new char[10, 10];
            int counter = 0;
            text = text.Replace("\n", "");

            if (text.Length != 100)
            {
                if (text.Length > 100)
                {
                    return Convert.ToString(text.Length) + " Ошибка: превышенно допустимое число символов";
                }

                if (text.Length < 100)
                {
                    for (int i = text.Length; i < 100; i++)
                    {
                        text += "b";
                    }
                }
            }

            //ШИФРОВАНИЕ

            for (int line = 0; line < 10; line++)
            {
                for (int column = 0; column < 10; column++)
                {
                        textChars[line, column] = 'a';
                        counter++;
                }
            }
            counter = 0;
            for (int line = 0; line < 10; line++)
            {
                for (int column = 0; column < 10; column++)
                {                 
                    if (grid[line, column] == 1)
                    {
                        textChars[line, column] = text[counter];
                        counter++;
                    }
                }
            }
            counter = 0;
            for (int line = 0; line < 10; line++)
            {
                for (int column = 0; column < 10; column++)
                {
                    if (grid[line, column] == 1)
                    {
                        textChars[column, 9 - line] = text[counter];
                        counter++;
                    }
                }
            }

            for (int line = 0; line < 10; line++)
            {
                for (int column = 0; column < 10; column++)
                {
                    if (grid[line, column] == 1)
                    {
                        textChars[9 - line, 9 - column] = text[counter];
                        counter++;
                    }
                }
            }
            
            for (int line = 0; line < 10; line++)
            {
                for (int column = 0; column < 10; column++)
                {
                    if (grid[line, column] == 1)
                    {
                        textChars[9- column, line] = text[counter];
                        counter++;
                    }
                }
            }           

            //ВЫВОД
            for (int line = 0; line < 10; line++)
            {
                for (int column = 0; column < 10; column++)
                {
                    encrypteЕext += textChars[line, column];
                }
            }
            return encrypteЕext;
        }
    }
}
