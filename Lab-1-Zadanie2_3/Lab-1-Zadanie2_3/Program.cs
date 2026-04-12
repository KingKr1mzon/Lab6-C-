using System;

namespace Lab1
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("--- Задание 2. Перегрузка операций ---");

            // Ввод данных для первого кошелька
            Console.WriteLine("Введите данные для первого кошелька: ");
            uint rubles1 = ReadUint("Рубли: ");
            byte kopeks1 = ReadByte("Копейки: ");
            Money wallet1 = new Money(rubles1, kopeks1);

            // Ввод данных для второго кошелька
            Console.WriteLine("\nВведите данные для вычитания:");
            uint rubles2 = ReadUint("Рубли: ");
            byte kopeks2 = ReadByte("Копейки: ");
            Money wallet2 = new Money(rubles2, kopeks2);

            // Вызов конструктора копирования
            Money wallet1Copy = new Money(wallet1);
            Console.WriteLine("\nКопия первого кошелька: " + wallet1Copy.ToString());

            // Выполнение вычитания
            Money result = wallet1.Subtract(wallet2);

            Console.WriteLine("\nРезультат вычитания:");
            Console.WriteLine(wallet1.ToString() + " - " + wallet2.ToString() + " = " + result.ToString());


            Console.WriteLine("\n--- Задание 3. Перегрузка операций ---");

            // Унарные
            Money mInc = new Money(wallet1);
            mInc++;
            Console.WriteLine("wallet1++ (добавили копейку): " + mInc.ToString());

            Money mDec = new Money(wallet1);
            mDec--;
            Console.WriteLine("wallet1-- (убрали копейку): " + mDec.ToString());

            // Приведение типов
            uint rublesOnly = wallet1; // Неявное
            double kopeksOnly = (double)wallet1; // Явное
            Console.WriteLine("\nНеявный uint (рубли): " + rublesOnly);
            Console.WriteLine("Явный double (копейки как дробь): " + kopeksOnly);

            // Бинарные
            Console.WriteLine("\nБинарное вычитание (wallet1 - wallet2): " + (wallet1 - wallet2).ToString());

            uint scalar = ReadUint("\nВведите число для вычитания из wallet1: ");
            Console.WriteLine("wallet1 - uint: " + (wallet1 - scalar).ToString());
            Console.WriteLine("uint - wallet1: " + (scalar - wallet1).ToString());

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        private static uint ReadUint(string prompt)
        {
            uint res;
            while (true)
            {
                Console.Write(prompt);
                if (uint.TryParse(Console.ReadLine(), out res))
                    return res;
                Console.WriteLine("Ошибка. Введите целое положительное число (uint).");
            }
        }

        private static byte ReadByte(string prompt)
        {
            byte res;
            while (true)
            {
                Console.Write(prompt);
                // Читаем как обычное число. 
                if (byte.TryParse(Console.ReadLine(), out res))
                    return res;
                Console.WriteLine("Ошибка. Введите число от 0 до 255 (byte).");
            }
        }
    }
}