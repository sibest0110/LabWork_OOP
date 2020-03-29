using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonLib;

namespace PersonLib
{
    /// <summary>
    /// Класс, который описывает список людей
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Название списка
        /// </summary>
        private string _name;

        /// <summary>
        /// Массив из объектов "Person", находящихся в данном "PersonList"
        /// </summary>
        private PersonBase[] _persons = new PersonBase[0];

        #region Свойства

        /// <summary>
        /// Имя списка
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value ?? throw new ArgumentNullException
                        ("В свойство имени передано Null");
            }
        }

        /// <summary>
        /// Кол-во людей в текущем листе
        /// </summary>
        public int Size
        {
            get
            {
                return _persons.Length;
            }
        }

        #endregion

        /// <summary>
        /// Индексатор
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns></returns>
        public PersonBase this[int index]
        {
            get
            {
                if (index < 0 || index > _persons.Length)
                {
                    throw new IndexOutOfRangeException
                        ("Не существует человека с указанным индексом");
                }
                return _persons[index];
            }
        }

        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        public PersonList(string name)
        {
            Name = name;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Добавление человека в указанный список
        /// </summary>
        /// <param name="newPerson">Вносимый человек в список</param>
        public void AddPerson(PersonBase newPerson)
        {
            int _currentSizePersonList = this._persons.Length;
            Array.Resize(ref this._persons, _currentSizePersonList + 1);
            this._persons[_currentSizePersonList] = newPerson;
        }

        /// <summary>
        /// Формирование в текстовую переменную список людей, 
        /// входящих в текущий лист
        /// </summary>
        /// <returns></returns>
        public string[] Info()
        {
            string[] data = new string[_persons.Length];
            for (int indexPerson = 0;
                indexPerson < _persons.Length;
                indexPerson++)
            {
                data[indexPerson] = _persons[indexPerson].GetInfo();
            }
            return data;
        }

        /// <summary>
        /// Удаление из списка людей человека по индексу
        /// </summary>
        /// <param name="indexOfDeletePerson">Индекс удаляемого человека</param>
        /// <returns></returns>
        public void DeletePerson(int indexOfDeletePerson)
        {
            int _currentSizePersonList = this._persons.Length;
            if (_currentSizePersonList <= indexOfDeletePerson)
            {
                throw new IndexOutOfRangeException(
                    $"{nameof(indexOfDeletePerson)} Index out of range!");
            }

            if (_currentSizePersonList == indexOfDeletePerson + 1)
            {
                Array.Resize(ref this._persons, _currentSizePersonList - 1);
            }
            // Смещение вверх списка
            else
            {
                for (int i = indexOfDeletePerson; i < _currentSizePersonList - 1; i++)
                {
                    this._persons[i] = this._persons[i + 1];
                }
                Array.Resize(ref this._persons, _currentSizePersonList - 1);
            }
        }

        /// <summary>
        /// Очистить список людей
        /// </summary>
        /// <returns></returns>
        public void ClearPersonList()
        {
            int defaultSizeList = this.Size;
            for (int i = 0; i < defaultSizeList; i++)
            {
                this.DeletePerson(0);
            }
        }

        #endregion
    }
}
