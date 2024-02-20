using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection1
{
    public class MethodsMein
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Лекия 1
        /*struct SomeData
        {
            public int Data;
        }
        static void CopyAndModiryData(SomeData someData) 
        {
            someData.Data = 10;
        }
        static void ModifyData(ref SomeData someData)  // ref получает ссылку на оригинал, вместо того чтобы получить копию
        {
            someData.Data = 10;
        }*/

        /*public class Today
        {
            public string Day => DateTime.Now.DayOfWeek.ToString();  // лямбда-выражение
        }*/
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///

        public void MethodMain()
        {

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Лекция 1

            // Console.WriteLine(new Today().Day);  // вывод лямбда-выражения

            /*SomeData a = new SomeData();
            SomeData b = new SomeData();
            a.Data = 5; 
            b.Data = 5;

            CopyAndModiryData (a);
            ModifyData (ref b);

            Console.WriteLine(a.Data);
            Console.WriteLine(b.Data);
            */

            /*Person person1 = new Person();
            person1.Name = "Иван";
            person1.BirthDate = DateTime.Parse("12.12.2012");
            person1.Height = 180;

            Console.WriteLine($"Имя - {person1.Name},\nДата рождения - {person1.BirthDate},\nРост - {person1.Height}");*/

            /*// способы создания класса
            Person person2 = new Person();
            Person person3 = new();
            var person4 = new Person();
            var person5 = new Person() {Name = "Alex", BirthDate = DateTime.Parse("24.12.2024"), Height = 180};
            Person person6 = new() {Name = "Bill", BirthDate = DateTime.Parse("24.09.2014"), Height = 190};*/

            /*// Person pers = new Person("Name", DateTime.Now.AddDays(1), 180);
            Person pers1 = new Person("Manny", DateTime.Now.AddDays(-1), 180);
            pers1.Print();
            Console.ReadLine();*/

            /*  int x = 10;
              Console.WriteLine(x.ToString());
              Console.WriteLine(x.ToString("X")); // выдаст 'А' - это шестнацатиричное пердставление числа 10*/

            /*Person namePers = new Person("Name", DateTime.Parse("18.02.2013"), 190);
            Console.WriteLine(namePers.IsAdult(5));*/

            /*Person myPerson = new Person("Dmitry", DateTime.Parse("17.01.1975"), 176);
            Person son = new Person("Bogdan", DateTime.Parse("02.02.2015"), 135);
            Person daughter = new Person("Polina", DateTime.Parse("30.04.2002"), 176);
            Person father = new Person("Alexandr", DateTime.Parse("10.08.1950"), 172);
            Person mother = new Person("Ekaterina", DateTime.Parse("22.01.1956"), 170);

            myPerson.AddFamilyInfo(father, mother, daughter, son);
            myPerson.PrintFamily();

            Person[] children;      // можно так
            var res = myPerson.GetChildren(out children);
            if (res == true) 
            {
                Console.WriteLine("Дети есть");
            }
            */

            /*var someClass = new SomeClass(10);

            Console.WriteLine($"{someClass.SomeProperty},\n{someClass.SomeProperty1},\n{someClass.SomeProperty2}");

            var someClass1 = new SomeClass(10) { SomeProperty1 = 40, SomeProperty = 50};  // т.к init заменить можно только здесь
            someClass1.SomeProperty2 = 140;
            // someClass1.SomeProperty1 = 4;  // так не идет
            // someClass1.SomeProperty = 24;  // и так не идет

            Console.WriteLine($"{someClass1.SomeProperty},\n{someClass1.SomeProperty1},\n{someClass1.SomeProperty2}");*/

            /*TwoClass twoClass = new TwoClass(10);
            Console.WriteLine($"{twoClass.pow1}\n{twoClass.pow2}\n{twoClass.pow3}");*/

            /*var per = new ThreeClass();
            per.Age = 10;
            Console.WriteLine(per.Age);*/

            //var woman = new Women("Anna", DateTime.Parse("12.12.1990"));
            //var man = new Man("Ben", DateTime.Parse("24.06.1985"));
            //woman.Print();
            //woman.PutMakeup();
            //woman.RemoveMakeup();

            //man.Print();
            //man.Shave();    

            //Person[] people = new Person[] { woman, man }; // создаем массив людей 
            //foreach (var item in people)
            //{
            //    item.Print();
            //}

            // приведение типов
            //foreach (var item in people)
            //{
            //    Women w = (Women)item;  // первая итерация проедет, т.к Women соответствует Women, иторая уже Men будет ошибка
            //    w.PutMakeup();
            //}

            // перепишем, чтобы небыло исключения
            //foreach (var item in people)
            //{
            //    Women w = (item as Women)!;  // as - спец оператор
            //    if (w != null)
            //    {
            //        w.PutMakeup();
            //    } 
            //}

            // еще вариант
            //foreach (var item in people)
            //{
            //    if (item is Women)      // is - спей оператор
            //    {
            //        (item as Women)!.PutMakeup();
            //    }
            //}

            // Условный оператор '?'
            //foreach (var item in people)
            //{
            //    (item as Women)?.PutMakeup();
            //    (item as Man)?.Shave();
            //}

            // переопределение методов
            //foreach (var item in people)
            //{
            //    (item as Women)?.SayHello();
            //    (item as Man)?.SayHello();
            //}

            // переопределение свойств
            //foreach (var item in people)
            //{
            //    item.SayHelloPhrase();
            //}

            // обращение к базовому методу
            // man.SayHelloLikeParent();

            // скрытый метод
            //Person p = man;
            //p.Print();
            //man.Print();

            // статический метод
            // Console.WriteLine(Person.AreSiblings(woman, man));

            // статический класс
            var str = "qwerty".StringReverse();
            Console.WriteLine(str);

            var str2 = "asdfgh";
            Console.WriteLine(str2.StringReverse());  // это когда в методе доп 'this'


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        }

    }
}
