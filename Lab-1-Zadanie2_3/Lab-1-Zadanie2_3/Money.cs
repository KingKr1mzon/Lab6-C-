using System;

namespace Lab1
{
    // --- Класс Money ---
    internal class Money
    {
        // Поля
        private uint _rubles;
        private byte _kopeks;

        // Свойства
        public uint Rubles
        {
            get { return _rubles; }
            set { _rubles = value; }
        }

        public byte Kopeks
        {
            get { return _kopeks; }
            set
            {
                // Если копеек больше 99, переносим их в рубли
                if (value >= 100)
                {
                    _rubles += (uint)(value / 100);
                    _kopeks = (byte)(value % 100);
                }
                else
                {
                    _kopeks = value;
                }
            }
        }

        // Конструктор по умолчанию
        public Money()
        {
            _rubles = 0;
            _kopeks = 0;
        }

        // Конструктор с параметрами
        public Money(uint rubles, byte kopeks)
        {
            this._rubles = rubles;
            this.Kopeks = kopeks;
        }

        // Конструктор копирования
        public Money(Money money)
        {
            this._rubles = money._rubles;
            this._kopeks = money._kopeks;
        }

        // Метод вычитания
        public Money Subtract(Money money)
        {
            // Переводим всё в копейки для точности расчетов. 
            long totalKopeks1 = this._rubles * 100 + this._kopeks;
            long totalKopeks2 = money._rubles * 100 + money._kopeks;

            // Вычитаем копейки
            long resultKopeks = totalKopeks1 - totalKopeks2;

            // Условие задачи: величина не может быть меньше 0
            if (resultKopeks < 0)
            {
                return new Money(0, 0);
            }
            // Преобразуем обратно в рубли и копейки
            uint resultRubles = (uint)(resultKopeks / 100);
            byte resultKopeksByte = (byte)(resultKopeks % 100);

            return new Money(resultRubles, resultKopeksByte);
        }

        // Перегрузка ToString()
        public override string ToString()
        {
            return _rubles + " руб. " + _kopeks + " коп.";
        }

        // --- ЗАДАНИЕ 3: ДОПОЛНИТЕЛЬНЫЕ МЕТОДЫ И ОПЕРАТОРЫ ---

        // Унарные
        public static Money operator ++(Money m)
        {
            return new Money(m.Rubles, (byte)(m.Kopeks + 1));
        }

        public static Money operator --(Money m)
        {
            if (m.Rubles == 0 && m.Kopeks == 0) return new Money(0, 0);

            if (m.Kopeks == 0) return new Money(m.Rubles - 1, 99);
            return new Money(m.Rubles, (byte)(m.Kopeks - 1));
        }

        // Приведение типов
        public static implicit operator uint(Money m)
        {
            return m.Rubles;
        }

        public static explicit operator double(Money m)
        {
            return (double)m.Kopeks / 100.0;
        }

        // Бинарные
        public static Money operator -(Money m1, Money m2)
        {
            return m1.Subtract(m2);
        }

        public static Money operator -(Money m, uint val)
        {
            long mAll = (long)m.Rubles * 100 + m.Kopeks;
            long valAll = (long)val * 100;
            long diff = mAll - valAll;

            if (diff < 0) return new Money(0, 0);
            return new Money((uint)(diff / 100), (byte)(diff % 100));
        }

        public static Money operator -(uint val, Money m)
        {
            long valAll = (long)val * 100;
            long mAll = (long)m.Rubles * 100 + m.Kopeks;
            long diff = valAll - mAll;

            if (diff < 0) return new Money(0, 0);
            return new Money((uint)(diff / 100), (byte)(diff % 100));
        }
    }
}
