using System;

namespace Lab1
{
    // --- Базовый класс ---
    // Требование 1: Разработать класс с двумя символьными полями.
    class Initials
    {
        // инкапсулированные поля класса Initials
        private char _firstChar;
        private char _secondChar;

        // свойства для доступа к полям класса Initials
        public char FirstChar
        {
            get { return _firstChar; }
            set { _firstChar = value; }
        }

        public char SecondChar
        {
            get { return _secondChar; }
            set { _secondChar = value; }
        }

        // 1. конструктор по умолчанию
        public Initials()
        {
            _firstChar = 'A';
            _secondChar = 'B';
        }

        // 2. конструктор с параметрами
        public Initials(char first, char second)
        {
            this._firstChar = first;    // запись в экземпляр   
            this._secondChar = second;  // запись в экземпляр  
        }

        // Требование 2: Создать конструктор копирования.
        public Initials(Initials other)
        {
            this._firstChar = other._firstChar;    // запись в экземпляр   
            this._secondChar = other._secondChar;  // запись в экземпляр  
        }

        // Требование 3: Разработать метод, создающий строки из полей.
        public string CreateString()
        {
            string result = "Символ 1: " + _firstChar.ToString() + ", Символ 2: " + _secondChar.ToString();
            return result;
        }

        // Требование 4: Перегрузить метод ToString() для формирования строки из полей класса.
        public override string ToString()
        {
            return "Инициалы: " + _firstChar + "." + _secondChar + ".";
        }
    }

    // --- Дочерний класс, наследующий от класса Initials ---
    // Требование 5: Реализовать дочерний класс (предложить содержание самостоятельно и описать смысл).

    /*
    Создан класс EmployeeBadge (Бейдж сотрудника), который наследует базовый класс Initials

    Бейдж расширяет понятие инициалов. Любой бейдж содержит инициалы сотрудника (наследует их),
    но дополняется уникальными характеристиками: 
    табельным номером (_employeeId) и названием отдела (_department).
    */
    class EmployeeBadge : Initials
    {
        private int _employeeId;
        private string _department;

        public int EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; }
        }

        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        // Вызов конструктора по умолчанию базового класса 
        public EmployeeBadge() : base()
        {
            _employeeId = 0;
            _department = "Не назначен";
        }

        // Вызов конструктора с параметрами базавого класса
        public EmployeeBadge(char first, char second, int id, string department) : base(first, second)
        {
            this._employeeId = id;
            this._department = department;
        }

        // 1 Метод дочернего класса
        public void PrintAccessLevel()
        {
            Console.WriteLine("Бейдж " + _employeeId + ": Доступ в помещения отдела [" + _department + "] разрешен.");
        }

        // 2 Метод дочернего класса
        public void ChangeDepartment(string newDepartment)
        {
            this._department = newDepartment;
            Console.WriteLine("Сотрудник " + EmployeeId + " переведен в отдел: " + _department);
        }

        // Перегрузка ToString() с вызовом базового метода
        public override string ToString()
        {
            // Используем base.ToString() для получения данных из родительского класса
            return base.ToString() + " | ID сотрудника: " + _employeeId + " | Отдел: " + _department;
        }
    }
}
