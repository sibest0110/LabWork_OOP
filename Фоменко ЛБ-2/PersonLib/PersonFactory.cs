using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{
    public static class PersonFactory
    {
        /// <summary>
        /// Получение случайного человека
        /// </summary>
        /// <returns></returns>
        public static PersonBase GetRandomPerson()
        {
            Random rand = new Random();

            //Определение, создасться взрослый человек или ребёнок
            switch (rand.Next(1, 3))
            {
                case 1:
                {
                    rand.Next(1, 3);
                    Adult randomPerson =
                            Adult.GetRandomAdult(GenderSetup.GetRandomGender());
                    if (rand.Next(1, 3) == 1)
                    {
                        Adult.GetRandomCouple(randomPerson);
                    }
                    return randomPerson;
                }
                case 2:
                {
                    return Child.GetRandomChild
                        (GenderSetup.GetRandomGender());
                }
                default:
                {
                    throw new FormatException
                            ("public static Person GetRandomPerson()");
                }
            }
        }
    }
}
