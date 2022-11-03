using System;

namespace Encryption
{
    internal static class Encryption
    {
        static private Random random = new Random();
        public static int[,] Grid_Generation()
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

            String encryptedText = "";
            char[,,] textChars;

            if (text.Length % 100 == 0)
            {
                textChars = new char[text.Length / 100, 10, 10];
            }
            else
            {
                textChars = new char[text.Length / 100 + 1, 10, 10];              
            }

            int counter = 0;

            for (int hundred = 0; hundred < textChars.GetLength(0); hundred++) 
            {
                
                for (int line = 0; line < 10; line++)
                {
                    for (int column = 0; column < 10; column++)
                    {
                        textChars[hundred, line, column] = ' ';
                    }
                }
                
                

                for (int line = 0; counter < text.Length && line < 10; line++)
                {
                    for (int column = 0; counter < text.Length && column < 10; column++)
                    {
                        if (grid[line, column] == 1)
                        {
                            textChars[hundred, line, column] = text[counter];
                            counter++;
                        }
                    }
                }

                for (int line = 0; counter < text.Length && line < 10; line++)
                {
                    for (int column = 0; counter < text.Length && column < 10; column++)
                    {
                        if (grid[line, column] == 1)
                        {
                            textChars[hundred, column, 9 - line] = text[counter];
                            counter++;
                        }
                    }
                }

                for (int line = 0; counter < text.Length && line < 10; line++)
                {
                    for (int column = 0; counter < text.Length && column < 10; column++)
                    {
                        if (grid[line, column] == 1)
                        {
                            textChars[hundred, 9 - line, 9 - column] = text[counter];
                            counter++;                        
                        }
                    }

                }

                for (int line = 0; counter < text.Length && line < 10; line++)
                {
                    for (int column = 0; counter < text.Length && column < 10; column++)
                    {
                        if (grid[line, column] == 1)
                        {
                            textChars[hundred, 9 - column, line] = text[counter];
                            counter++;
                        }
                    }
                }
            }

            for (int hundred = 0; hundred < textChars.GetLength(0); hundred++) 
            {
                for (int line = 0; line < textChars.GetLength(1); line++)
                {
                    for (int column = 0; column < textChars.GetLength(2); column++)
                    {
                        encryptedText += textChars[hundred, line, column];
                    }
                }
            }
            return encryptedText;
        }

        public static String Decryption_Text(String key, String encryptedText)
        {
            String decryptedText = "";
            int[] intKey = Convert_Key_To_Int(key);
            int[,] grid = new int[10, 10];
            char[,,] textChars;

            if (encryptedText.Length % 100 == 0)
            {
                textChars = new char[encryptedText.Length / 100, 10, 10];
            }
            else
            {
                textChars = new char[encryptedText.Length / 100 + 1, 10, 10];
            }

            int cageCounter = 0;
            int ifCounter = 0;         

            for (int line = 0; ifCounter != 25 && line < 10; line++)
            {
                for (int column = 0; ifCounter != 25 && column < 10; column++)
                {
                    if (cageCounter == intKey[ifCounter])
                    {
                        grid[line, column] = 1;
                        grid[column, 9 - line] = 2;
                        grid[9 - line, 9 - column] = 3;
                        grid[9 - column, line] = 4;
                        ifCounter++;
                    }
                    cageCounter++;
                }
            }

            cageCounter = 0;

            for (int hundred = 0; hundred < textChars.GetLength(0); hundred++)
            {
                for (int line = 0; cageCounter < encryptedText.Length && line < 10; line++)
                {
                    for (int column = 0; cageCounter < encryptedText.Length && column < 10; column++)
                    {
                        textChars[hundred, line, column] = encryptedText[cageCounter];
                        cageCounter++;
                    }
                }
            }

            cageCounter = 0;

            for (int hundred = 0; hundred < textChars.GetLength(0); hundred++)
            {
                for (int line = 0; line < 10; line++)
                {
                    for (int column = 0; column < 10; column++)
                    {
                        if (grid[line, column] == 1)
                        {
                            decryptedText += textChars[hundred, line, column];
                        }
                        cageCounter++;
                    }
                }

                cageCounter = 0;

                for (int column = 9; column > -1; column--)
                {
                    for (int line = 0; line < 10; line++)
                    {
                        if (grid[line, column] == 2)
                        {
                            decryptedText += textChars[hundred, line, column];
                        }
                        cageCounter++;
                    }
                }

                cageCounter = 0;

                for (int line = 9; line > -1; line--)
                {
                    for (int column = 9; column > -1; column--)
                    {
                        if (grid[line, column] == 3)
                        {
                            decryptedText += textChars[hundred, line, column];
                        }
                        cageCounter++;
                    }
                }

                cageCounter = 0;

                for (int column = 0; column < 10; column++)
                {
                    for (int line = 9; line > -1; line--)
                    {
                        if (grid[line, column] == 4)
                        {
                            decryptedText += textChars[hundred, line, column];
                        }
                        cageCounter++;
                    }
                }
            }

            return decryptedText;
        }

        private static int[] Convert_Key_To_Int(string key)
        {
            string[] splitKey = key.Split('.');
            int[] intKey = new int[25];

            for (int counter = 0; counter < 25; counter++)
            {
                intKey[counter] = int.Parse(splitKey[counter]);
            }

            return intKey;
        } 
        
        public static int[,] Convert_Key_To_Grid(String key)
        {
            int[] intKey = Convert_Key_To_Int(key);
            int[,] grid = new int[10, 10];
            int cageCounter = 0;
            int keyCounter = 0;

            for (int line = 0; keyCounter != 25 && line < 10; line++)
            {
                for (int column = 0; keyCounter != 25 && column < 10; column++)
                {
                    if (cageCounter == intKey[keyCounter])
                    {
                        grid[line, column] = 1;
                        keyCounter++;
                    }
                    cageCounter++;
                }
            }

            return grid;
        }
    }
}
