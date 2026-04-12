using System;

namespace Lab1
{
    // --- Основной класс ---
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("--- Базовый класс ---");

            // ввод данных для базового класса
            char char1 = InputChar("Введите первый символ: ");
            char char2 = InputChar("Введите второй символ: ");

            // Вывод конструктора с параметрами
            Initials initials = new Initials(char1, char2);
            Console.WriteLine("Конструктор с параметрами: " + initials.ToString());

            // метод создающий строку
            Console.WriteLine("Метод CreateString(): " + initials.CreateString());

            // Вывод конструктора копирования
            Initials initials2 = new Initials(initials);
            Console.WriteLine("Конструктор копирования: " + initials2.ToString());

            // Вывод конструктора по умолчанию
            Initials initials3 = new Initials();
            Console.WriteLine("Конструктор по умолчанию: " + initials3.ToString());


            Console.WriteLine("\n --- Дочерний класс ---");

            int id = InputInt("Введите ID сотрудника (целое число): ");
            string dept = InputString("Введите название отдела: ");

            // Вывод конструктора с параметрами дочернего класса
            EmployeeBadge employee1 = new EmployeeBadge(char1, char2, id, dept);
            Console.WriteLine("\nСотрудник создан: " + employee1.ToString());

            // Вывод метода дочернего класса
            employee1.PrintAccessLevel();
            employee1.ChangeDepartment("IT Безопасность");

            // Конструктор по умолчанию дочернего класса
            EmployeeBadge employee2 = new EmployeeBadge();
            Console.WriteLine("\nПустой бейдж (по умолчанию): " + employee2.ToString());

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // --- Проверка ввода данных ---

        // Метод для проверки ввода одного символа
        public static char InputChar(string OneChar)
        {
            char result;
            bool isValid = false;

            do
            {
                Console.Write(OneChar);
                string input = Console.ReadLine();

                // Проверяем: не пусто, 1 символ, успешно конвертируется
                if (!string.IsNullOrEmpty(input) && input.Length == 1 && char.TryParse(input, out result))
                {
                    // Дополнительная проверка: это буква?
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
            } while (!isValid);

            return ' ';
        }

        // Метод для проверки ввода целого числа
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
            } while (!isValid);

            return result;
        }

        // Метод для проверки ввода строки
        private static string InputString(string OneString)
        {
            string result;
            bool isValid;

            do
            {
                isValid = true;
                Console.Write(OneString);
                result = Console.ReadLine();

                // Проверка на пустоту
                if (string.IsNullOrWhiteSpace(result))
                {
                    Console.WriteLine("Ошибка: строка не может быть пустой. Попробуйте снова.");
                    isValid = false;
                    continue;
                }

                // Проверка на наличие цифр
                foreach (char c in result)
                {
                    if (char.IsDigit(c))
                    {
                        Console.WriteLine("Ошибка: строка не должна содержать цифры. Попробуйте снова.");
                        isValid = false;
                        break; // Прерываем foreach, так как уже нашли ошибку
                    }
                }

            } while (!isValid);

            return result;
        }
    }
}