using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{
    /// <summary>
    /// Взрослый человек
    /// </summary>
    public class Adult : PersonBase
    {
        /// <summary>
        /// Минимальный возраст взрослого человека
        /// </summary>
        private const int MINYEAR = 18;

        /// <summary>
        /// Максимальный возраст взрослого человека
        /// </summary>
        private const int MAXYEAR = 101;

        /// <summary>
        /// Начальное значение номера паспорта
        /// </summary>
        private const int STARTNUMPASPORT = 100000;

        /// <summary>
        /// Конечное значение номера паспорта
        /// </summary>
        private const int LASTNUMPASPORT = 999999;

        #region Поля

        /// <summary>
        /// Возраст
        /// </summary>
        private int _age;

        /// <summary>
        /// Номер паспорта
        /// </summary>
        private int _pasportNumber;

        #endregion

        #region Свойства

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
                if (value > MAXYEAR)
                {
                    throw new IndexOutOfRangeException
                        ("Указан нереальный возраст");
                }
                if (value < MINYEAR)
                {
                    throw new IndexOutOfRangeException
                        ("У взрослого человека " +
                        "возраст должен быть больше 17");
                }
                _age = value;
            }
        }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        public int PasportNumber
        {
            get
            {
                return _pasportNumber;
            }
            internal set
            {
                if (value <= STARTNUMPASPORT || value >= LASTNUMPASPORT)
                {
                    throw new ArgumentOutOfRangeException(
                        "Номер паспорта должен состоять из 6 цифр");
                }
                _pasportNumber = value;
            }
        }

        /// <summary>
        /// Место работы
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        /// Состояние брака
        /// </summary>
        public bool Marriage { get; set; }

        /// <summary>
        /// Супруга/супруг
        /// </summary>
        public Adult Couple { get; set; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Взрослый человек
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="lastname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        /// <param name="pasportNumber">Номер паспорта (6-ти значное число)</param>
        /// <param name="jobname">Место работы</param>
        /// <param name="marriage">Семейное положение</param>
        /// <param name="couple">Супружеская пара</param>
        public Adult(string name, string lastname, int age, Gender gender,
            int pasportNumber, string jobname, bool marriage, Adult couple)
            : base(name, lastname, age, gender)
        {
            Age = age;
            PasportNumber = pasportNumber;
            JobName = jobname;
            Marriage = marriage;
            Couple = couple;
        }

        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        public Adult() : base() { }

        #endregion


        /// <summary>
        /// Создание случайного взрослого человека указанного пола
        /// </summary>
        /// <param name="gender">Желаемый пол</param>
        /// <returns></returns>
        public static Adult GetRandomAdult(Gender gender)
        {
            Random rand = new Random();

            var name = RandomPersonData.GetRandomName(gender);
            var lastname = RandomPersonData.GetRandomLastname(gender);
            var age = rand.Next(MINYEAR, MAXYEAR);
            var pasportNumber = rand.Next(STARTNUMPASPORT, LASTNUMPASPORT);
            var jobName = RandomPersonData.GetRandomJobName();
            var marriage = false;
            Adult couple = null;

            return new Adult(
                name, lastname, age,
                gender,
                pasportNumber,
                jobName,
                marriage,
                couple);
        }

        /// <summary>
        /// Создание случайной пары для указанного человека
        /// </summary>
        /// <param name="person">Для кого создаётся пара</param>
        /// <returns></returns>
        public static Adult GetRandomCouple(Adult person)
        {
            Gender coupleGender = GenderSetup.ChangeGender(person.Gender);

            Adult couple = GetRandomAdult(coupleGender);
            couple.LastName = PersonBase.ChangeGenderLastName
                (person.LastName, person.Gender);

            person.Marriage = true;
            person.Couple = couple;
            couple.Marriage = true;
            couple.Couple = person;

            return couple;
        }


        /// <summary>
        /// Получения информации о взрослом человеке
        /// </summary>
        /// <returns></returns>
        public override string GetInfo()
        {
            string info = $"{this.Info}" +
                $"\nНомер паспорта: {PasportNumber}";

            if (JobName != "")
            {
                info += $"\nМесто работы:\t{JobName}";
            }
            else
            {
                info += $"\n\t\tБезработный";
            }

            if (Marriage == true && Couple != null)
            {
                switch (this.Gender)
                {
                    case Gender.Male:
                    {
                        info += $"\nСостояние брака: Женат" +
                            $"\nСупруга:\t{Couple.Name} {Couple.LastName}";
                        break;
                    }
                    case Gender.Female:
                    {
                        info += $"\nСостояние брака: Замужем" +
                        $"\nСупруг:\t\t{Couple.Name} {Couple.LastName}";
                        break;
                    }
                }
            }
            else
            {
                info += $"\nСостояние брака: Не в браке";
            }

            return info;
        }

        /// <summary>
        /// Ругаться
        /// </summary>
        /// <returns></returns>
        public string Curse()
        {
            switch (Gender)
            {
                case Gender.Male:
                {
                    return $"Ругается по-мужски!";
                }
                case Gender.Female:
                {
                    return $"Ругается по-женски!";
                }
            }
            return $"Ругается!";
        }
    }
}
