using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Linq;

namespace ConsoleProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Quicksort quicksort = new Quicksort();

            Console.Write("Введите строку: ");
            
            string inputLine = Console.ReadLine();

            while (!Regex.IsMatch(inputLine, "^[a-z]+$"))
            {
                if (Regex.Replace(inputLine, " ", "") != "")
                {
                    Console.Write("В строке должны быть только латинские буквы в нижнем регистре! Неподходящие символы: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Regex.Replace(Regex.Replace(inputLine, "[a-z]", ""), " ", " 'Пробел' "));
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine("Строка не должна быть пустой!");
                }
                
                inputLine = Console.ReadLine();
            }

            char[] mainLine = inputLine.ToCharArray();

            Console.Write("Выход: ");
            Array.Reverse(mainLine);
            string resultLine;
            Console.ForegroundColor = ConsoleColor.Green;
            if (mainLine.Length % 2 != 0)
            {
                resultLine = new string(mainLine);
                Array.Reverse(mainLine);
                resultLine += new string(mainLine);

                Console.WriteLine(resultLine);
            }
            else
            {
                var lastSegment = new ArraySegment<char>(mainLine, 0, mainLine.Length / 2);
                var firstSegment = new ArraySegment<char>(mainLine, mainLine.Length / 2, mainLine.Length / 2);
                resultLine = String.Join("", firstSegment) + (String.Join("", lastSegment));
                Console.WriteLine(resultLine);
                Array.Reverse(mainLine);
            }
            Console.ForegroundColor = ConsoleColor.White;

            foreach (char letter in mainLine)
            {
                Console.Write($"Количество '{letter}': ");
                Console.WriteLine(resultLine.Count(lt => lt == letter));
            }

            string maxLine = "";

            foreach (Match match in Regex.Matches(resultLine, "[aeiouy].*[aeiouy]"))
            {
                if (maxLine.Length < match.Value.Length)
                {
                    maxLine = match.Value;
                }
            }
            
            if (maxLine != "")
            {
                Console.Write("Самая длинная подстрока, которая начинется и заканчивается на гласную букву: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(maxLine);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write("Подстроки, которая начинется и заканчивается на гласную букву, ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("НЕТ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" в данной строке!");
            }

            char[] resultLineChars = resultLine.ToCharArray();
            
            Console.Write("Отсортированная строка: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(quicksort.QuicksortLogic(resultLineChars, 0, resultLineChars.Length - 1));
            Console.ForegroundColor = ConsoleColor.White;


            Console.Write(" . . . Нажмите любую кнопку, чтобы выйти; Enter, чтобы перезапустить  . . . ");
            char endKey = Console.ReadKey().KeyChar;

            if (endKey == '\r')
            {
                System.Diagnostics.Process.Start(Assembly.GetExecutingAssembly().Location);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
