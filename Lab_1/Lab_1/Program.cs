using System;

namespace Lab1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("--- Базовый класс ---");

            char char1 = InputChar("Введите первый символ: ");
            char char2 = InputChar("Введите второй символ: ");

            Initials initials = new Initials(char1, char2);
            Console.WriteLine("Конструктор с параметрами: " + initials.ToString());

            Console.WriteLine("Метод CreateString(): " + initials.CreateString());

            Initials initials2 = new Initials(initials);
            Console.WriteLine("Конструктор копирования: " + initials2.ToString());

            Initials initials3 = new Initials();
            Console.WriteLine("Конструктор по умолчанию: " + initials3.ToString());

            Console.WriteLine("\n --- Дочерний класс ---");

            int id = InputInt("Введите ID сотрудника (целое число): ");
            string dept = InputString("Введите название отдела: ");

            EmployeeBadge employee1 = new EmployeeBadge(char1, char2, id, dept);
            Console.WriteLine("\nСотрудник создан: " + employee1.ToString());

            employee1.PrintAccessLevel();
            employee1.ChangeDepartment("IT Безопасность");

            EmployeeBadge employee2 = new EmployeeBadge();
            Console.WriteLine("\nПустой бейдж (по умолчанию): " + employee2.ToString());

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        public static char InputChar(string OneChar)
        {
            char result;
            bool isValid = false;

            do
            {
                Console.Write(OneChar);
                string input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input) && input.Length == 1 && char.TryParse(input, out result))
                {
                    if (char.IsLetter(result))
                    {
                        isValid = true;
                        return result;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: символ должен быть буквой. Попробуйте снова.");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: необходимо ввести ровно один символ. Попробуйте снова.");
                }
            }
            while (!isValid);

            return ' ';
        }

        public static int InputInt(string OneInt)
        {
            int result;
            bool isValid = false;

            do
            {
                Console.Write(OneInt);
                string input = Console.ReadLine();

                if (int.TryParse(input, out result))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Ошибка. необходимо ввести целое число (int). Попробуйте снова.");
                }
            }
            while (!isValid);

            return result;
        }

        private static string InputString(string OneString)
        {
            string result;
            bool isValid;

            do
            {
                isValid = true;
                Console.Write(OneString);
                result = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(result))
                {
                    Console.WriteLine("Ошибка: строка не может быть пустой. Попробуйте снова.");
                    isValid = false;
                    continue;
                }

                foreach (char c in result)
                {
                    if (char.IsDigit(c))
                    {
                        Console.WriteLine("Ошибка: строка не должна содержать цифры. Попробуйте снова.");
                        isValid = false;
                        break;
                    }
                }
            }
            while (!isValid);

            return result;
        }
    }
}