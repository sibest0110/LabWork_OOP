using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{
    /// <summary>
    /// Ребёнок
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// Минимальный возраст ребёнка
        /// </summary>
        private const int MINYEAR = 0;

        /// <summary>
        /// Максимальный возраст ребёнка
        /// </summary>
        private const int MAXYEAR = 17;

        /// <summary>
        /// Возраст, с которого идут в школу
        /// </summary>
        private const int SchoolAge = 6;

        /// <summary>
        /// Мама
        /// </summary>
        private Adult _mom;

        /// <summary>
        /// Отец
        /// </summary>
        private Adult _dad;

        /// <summary>
        /// Возраст
        /// </summary>
        private int _age;

        /// <summary>
        /// Школа/садик
        /// </summary>
        private string _schoolName;

        /// <summary>
        /// Возраст
        /// </summary>
        override public int Age
        {
            get
            {
                return _age;
            }
            internal set
            {
                if (value < MINYEAR)
                {
                    throw new IndexOutOfRangeException
                        ("Возраст не может быть отрицательным");
                }
                if (value > MAXYEAR)
                {
                    throw new IndexOutOfRangeException
                        ("У ребёнка возраст должен быть меньше 18");
                }
                _age = value;
            }
        }

        /// <summary>
        /// Мама ребёнка
        /// </summary>
        public Adult Mom
        {
            get
            {
                return _mom;
            }
            set
            {
                if (value.Gender == Gender.Male)
                {
                    throw new FormatException("Мама должна быть женщиной!");
                }
                _mom = value;
            }
        }

        /// <summary>
        /// Отец ребёнка
        /// </summary>
        public Adult Dad
        {
            get
            {
                return _dad;
            }
            set
            {
                if (value.Gender == Gender.Female)
                {
                    throw new FormatException("Отец должен быть мужчиной!");
                }
                _dad = value;
            }
        }

        /// <summary>
        /// Название школы/садика
        /// </summary>
        public string SchoolName
        {
            get
            {
                return _schoolName;
            }
            set
            {
                Supporting.CheckIsEmptyString(value);

                if (_age > SchoolAge)
                {
                    _schoolName = "Школа ";
                }
                else
                {
                    _schoolName = "Садик ";
                }
                _schoolName += value;
            }
        }


        #region Конструкторы

        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        public Child()
            : base()
        {
            SchoolName = "Сидит дома";
        }

        public Child(string name, string lastname, int age, Gender gender,
            Adult mom, Adult dad, string schoolname)
            : base(name, lastname, age, gender)
        {
            Name = name;
            LastName = lastname;
            Age = age;
            Gender = gender;
            Mom = mom;
            Dad = dad;
            SchoolName = schoolname;
        }

        #endregion

        /// <summary>
        /// Получение случайного ребёнка
        /// </summary>
        /// <param name="gender">Пол ребёнка</param>
        /// <returns></returns>
        public static Child GetRandomChild(Gender gender)
        {
            Random rand = new Random();

            Adult dad = Adult.GetRandomAdult(Gender.Male);
            Adult mom = Adult.GetRandomCouple(dad);
            var name = RandomPersonData.GetRandomName(gender);
            var lastname = GetChildLastname(gender, mom);
            var age = rand.Next(MINYEAR, MAXYEAR);
            var education = GetChildEducation(age);

            return new Child(name, lastname, age, gender, mom, dad, education);
        }

        /// <summary>
        /// В зависимости от возраста ребёнка,
        /// определяется название школы или садика
        /// </summary>
        /// <param name="age">Возраст ребёнка</param>
        /// <returns></returns>
        private static string GetChildEducation(int age)
        {
            if (age > SchoolAge)
            {
                return RandomPersonData.GetRandomSchool();
            }
            else
            {
                return RandomPersonData.GetRandomKindergarten();
            }
        }

        /// <summary>
        /// Получение фамилии для ребёнка, основываясь на данных по родителю
        /// </summary>
        /// <param name="childGender">Пол ребёнка</param>
        /// <param name="parent">Любой из родителей</param>
        /// <returns></returns>
        private static string GetChildLastname(Gender childGender, Adult parent)
        {
            if (childGender == parent.Gender)
            {
                return parent.LastName;
            }
            else
            {
                return PersonBase.ChangeGenderLastName
                    (parent.LastName, parent.Gender);
            }
        }


        /// <summary>
        /// Получения информации о ребёнке
        /// </summary>
        /// <returns></returns>
        public override string GetInfo()
        {
            string info = $"{this.Info} \nРодители:\t";

            if (Mom != null && Dad != null)
            {
                info += $"Мама: {Mom.Name} {Mom.LastName}" +
                    $"\n\t\tПапа: {Dad.Name} {Dad.LastName}";
            }
            else if (Mom != null && Dad == null)
            {
                info += $"Живёт только с мамой {Mom.Name} {Mom.LastName}";
            }
            else if (Mom == null && Dad != null)
            {
                info += $"Живёт только с папой {Dad.Name} {Dad.LastName}";
            }
            info += $"\nСадик/школа:\t{SchoolName}";

            return info;
        }

        /// <summary>
        /// Похныкать
        /// </summary>
        /// <returns></returns>
        public string Cry()
        {
            switch (Gender)
            {
                case Gender.Male:
                {
                    return $"Мужчины не плачут!";
                }
                case Gender.Female:
                {
                    return $"Хнык хнык хнык";
                }
            }
            return $"Хнык хнык хнык";
        }
    }
}
