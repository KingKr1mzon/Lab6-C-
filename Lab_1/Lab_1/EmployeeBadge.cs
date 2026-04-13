using System;

namespace Lab1
{
    class EmployeeBadge : Initials
    {
        private int _employeeId;
        private string _department;

        public int EmployeeId
        {
            get
            {
                return _employeeId;
            }
            set
            {
                _employeeId = value;
            }
        }

        public string Department
        {
            get
            {
                return _department;
            }
            set
            {
                _department = value;
            }
        }

        public EmployeeBadge() : base()
        {
            _employeeId = 0;
            _department = "Не назначен";
        }

        public EmployeeBadge(char first, char second, int id, string department)
            : base(first, second)
        {
            this._employeeId = id;
            this._department = department;
        }

        public void PrintAccessLevel()
        {
            Console.WriteLine("Бейдж " + _employeeId +
                ": Доступ в помещения отдела [" + _department + "] разрешен.");
        }

        public void ChangeDepartment(string newDepartment)
        {
            this._department = newDepartment;
            Console.WriteLine("Сотрудник " + EmployeeId +
                " переведен в отдел: " + _department);
        }

        public override string ToString()
        {
            return base.ToString() + " | ID сотрудника: " +
                _employeeId + " | Отдел: " + _department;
        }
    }
}