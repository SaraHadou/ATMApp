﻿using System.Text;
using System;
using System.Globalization;

namespace ATMApp.UI
{
	public static class Utility
	{
        private static int TransactionId;
        private static CultureInfo culture = new CultureInfo("en-US");


        public static string GetSecretInput(string prompt)
        {
            bool isPrompt = true;
            string asterics = "";

            StringBuilder input = new StringBuilder();

            while (true)
            {
                if (isPrompt)
                    Console.WriteLine(prompt);
                isPrompt = false;

                ConsoleKeyInfo inputKey = Console.ReadKey(true);

                if (inputKey.Key == ConsoleKey.Enter)
                {
                    if (input.Length == 6)
                    {
                        break;
                    }
                    else
                    {
                        PrintMessage("\nInvalid PIN. Please enter 6 digits.", false);
                        isPrompt = true;
                        input.Clear();
                        continue;
                    }
                }

                if (inputKey.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input.Remove(input.Length - 1, 1);
                    Console.Write("\b \b");
                }
                else if (inputKey.Key != ConsoleKey.Backspace)
                {
                    input.Append(inputKey.KeyChar);
                    Console.Write(asterics + "*");
                }

            }
            return input.ToString();
        }


        public static void PrintMessage(string msg, bool success=true)
        {
            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(msg);
            Console.ResetColor();
            PressEnterToContinue();
        }


        public static string GetUserInput(string prompt)
        {
            Console.WriteLine($"Enter {prompt}");
            return Console.ReadLine();
        }

        public static void PrintDotAnimation(int timer=10)
        {
            for (int i = 0; i < timer; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }
            Console.Clear();
        }


        public static void PressEnterToContinue()
        {
            Console.WriteLine("\n\nPlease Enter to continue...\n");
            Console.ReadLine();
        }


        public static string FormatAmount(decimal amount)
        {
            return String.Format(culture, "{0:C2}", amount);
        }


        public static int GetTransactionId()
        {
            return TransactionId++;
        }


    }
}

