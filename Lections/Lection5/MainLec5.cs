using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection5
{
    delegate void MyDelegate();

    public delegate void AnotherDelegate(string s);

    delegate TREsult MyGenericDelegate<T, TREsult>(T x);

    delegate TResult MyFunc<out TResult>();

    delegate void MyAction<in T>(T x);

    // События
    public class MyEvenArgs : EventArgs // EventArgs - спец класс для событий
    {
        public string? Message { get; set; }
    }
    public delegate void MyEvenHandler(object sender, MyEvenArgs myEvenArgs); // создаем делегат, кот будем исп как событие

    public class ClassWithEvents
    {
        public event MyEvenHandler? SomeEven;

        protected void OnSomeEven(MyEvenArgs args)  // метод, вызывающий события
        {
            SomeEven?.Invoke(this, args);
        }

        public void DoSomeWork() // метод, генерирующий события
        {
            new Thread
                (
                    () =>
                    {
                        Thread.Sleep(10000);
                        OnSomeEven(new MyEvenArgs { Message = "Все" });
                    }
                ).Start();
        }
    }


    internal class MainLec5
    {
        // Делегаты предоставляют механизм позднего связывания, позволяя реализовать алгоритм
        // или его часть не всамом объекте, а за его пределами.

        // Делегат - объект, кот хранит указатель на методы. Делегат можно выполнить как метод любого класса.
        // Делегат можно передать  в ф-цию или метод.

        // Примеры делегатов - ф-ции, где в качестве параметров предикаты.

        // Объявить делегат можно вне класса, т.к. делегат и есть своеобразный класс.

        // Переменные делегатов, имеющих одинаковую сигнатуру, но относящиеся к разным классам не могут складываться

       static void SayHello()
        {
            Console.WriteLine("Привет, я делегат");
        }

        static void SayPoka() 
        {
            Console.WriteLine("Пока");
        }

        static void ForAnotherDelegate(string s)
        {
            Console.WriteLine("Привет, я " + s);
        }

        static string ForMyGenericDelegate(string s)
        {
            return  $"Меня зовут {s}";
        }

        static string DigitToRoman(int x) 
        {
            switch (x)
            {
                case 1: return "I";
                case 2: return "II";
                case 3: return "III";
                case 4: return "IV";
                case 5: return "V";
                case 6: return "VI";
                case 7: return "VII";
                case 8: return "VII";
                case 9: return "IX";
                case 10: return "X";
                default: return "";
            }
        }

        static bool IsEven(int x)
        {
            return (x % 2) == 0;
        }

        static void SomeMethodObject(object o)
        {
            Console.WriteLine("Метод объект");
            Console.WriteLine(o);
        }

        static void SomeMethoString(string s)
        {
            Console.WriteLine("Метод строка");
            Console.WriteLine(s);
        }

        static object SomeMethodObj()
        {
            Console.WriteLine("SomeMethodObj");
            return new object();
        }
        static string SomeMethodStr()
        {
            Console.WriteLine("SomeMethodStr");
            return "";
        }

        static void SomeMethodObjIn(object o)
        {
            Console.WriteLine("SomeMethodObjIn");
            Console.WriteLine(o.GetType());
        }
        static void SomeMethodStrIn(string s)
        {
            Console.WriteLine("SomeMethodStrIn");
            Console.WriteLine(s.GetType());
        }

        static void AnoMethod(Action method)
        { 
            method();
        }


        public void Run()
        {
            //MyDelegate myDelegate = new MyDelegate(SayHello);
            //MyDelegate myDelegate1 = SayHello;
            //AnotherDelegate anotherDelegate = new AnotherDelegate(ForAnotherDelegate);

            // myDelegate += SayPoka;  // делегат можно складывать с методом

            // myDelegate += myDelegate1; // так можно складывать, это разные экземпляры одного класса
            // myDelegate += anotherDelegate; // такие делегаты не складываются. Это разные классы

            // myDelegate -= myDelegate1;  // можно вычитать. Все операции м вычитанием среда подчеркивает, предупреждая о возможном null

            // myDelegate();

            // удаление метода делегата не приведет к ошибке

            // на основе делегатов реализован шаблон "Подписчик - Издатель"

            // нет способа получить пустой делегат без методов

            //if(myDelegate != null)  // проверка на null
            //    myDelegate();

            //myDelegate += SayPoka;

            // Реф типы могут быть null. Знак ? говорит компилятору, что мы понимаем, что мы делаем

            // объект делегата хоанит все добавленные методы в списке, называемый список вызова (GetInvocationList)

            // Console.WriteLine($"В списке вызовов делегата число методов = {myDelegate.GetInvocationList().Length}");

            // перебор списка
            //foreach (MyDelegate item in myDelegate.GetInvocationList()) // здесь MyDelegate item обязательно, var не сработало
            //{
            //    Console.WriteLine("Вызываем метод");
            //    item();
            //}

            //////////////////////////
            ///методы
            ///
            // myDelegate?.Invoke();
            // myDelegate.BeginInvoke(); // для асинхронной работы
            // myDelegate?.DynamicInvoke(); // позднее связывание делегата с выполняемым методом в момент его вызова. Сигнатура не проверяется.
            // в основном используется при "рефлексии"

            ////////////////////////
            ///свойства делегата
            ///
            //////////////////////
            ///Обобщённые делегаты
            ///
            // delegate TOut Name<T, TOut>(T p);
            // MyGenericDelegate<string, string> myGenericDelegate = ForMyGenericDelegate;
            // Console.WriteLine(myGenericDelegate("Сам ты делегат"));

            // тип void не может быть параметром обобщенного делегата.

            //////////////////////
            ///Предопределённые делегаты
            ///
            // Action - поддерживает до 16 параметров.
            /*var list = new List<string> {"Дмитрий", "Елена"};
            //Action<string> myDelegate2 = ForAnotherDelegate; // работает только с void
            //list.ForEach(myDelegate2);
            list.ForEach(new Action<string> (ForAnotherDelegate));*/

            // Func
            /*var inst = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<string> roman = inst.Select(new Func<int, string>(DigitToRoman)); // когда Select лучше исп не var, а явный тип
            roman.ToList().ForEach(Console.WriteLine);*/

            // Predicate. Предикат - это метод, принимающий значение и возвращающий true или false в качестве результата.
            // Применяется для различных методов, где нужно применить критерий отбора к набору значений. 
            /*var inst = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            inst.FindAll(new Predicate<int>(IsEven)).ForEach(Console.WriteLine);*/

            // контрвариантность
            /*Action<string> predicateString = new Action<string>(SomeMethoString);
            Action<object> predicateObject = new Action<object>(SomeMethodObject);

            predicateString = predicateObject;  // примет контрвариантности
            predicateString("Вставыш");*/
            // т.е делегаты менее стогих типов можно присваивать делегатам более строгих

            /////////////////////////////////////////////////////////////////////////////////////////
            /// характеристики делегатов:
            /// Ковариантность и контравариантность параметров делегатов
            /// Ковариантность — возможность использовать типы-наследники вместо базового типа. 
            /// Ковариантность может быть применена только к возвращаемым из делегата параметрам. 
            /// 'out' - ключевое слово, означающее ковариантность
            /// 
            /*MyFunc<object> myFunc = new MyFunc<string>(SomeMethodStr); // в обратную сторону работать не будет
            object result = myFunc();
            Console.WriteLine(result.GetType());*/

            // Контравариантность — возможность использовать базовые типы вместо унаследованных типов.
            // Контравариантность может быть применена только к входным параметрам делегата.
            // 'in' - ключевое слово, означающее kонтравариантность
            /*MyAction<string> myAction = new MyAction<object>(SomeMethodObjIn); // обратно нельзя
            myAction("Строка");*/

            // Инвариантность — это неспособность к контравариантности или ковариантности. 
            // Чтобы объявить параметр делегата инвариантным, нужно указать его без in или out ключевых слов.

            ////////////////////////////////////////////////////////////////////////////////////////////////

            // Анонимные методы полезны в случае, когда какое-то действие нужно использовать лишь единожды,
            // и нет резона создавать для этого отдельный метод.
            // var method = delegate (параметры){ код метода };
            /*var inst = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var res = inst.Where(new Func<int, bool>(IsEven));
            res.ToList().ForEach(x => Console.Write(x + " "));  // мне так больше нравится вывод в консоль
            Console.WriteLine();*/

            //Func<int, bool> anonimMethod = delegate (int x) { return x % 2 == 0; }; // создали анонимный метод вместо IsEven
            //var resAnonim = inst.Where(anonimMethod);
            /*var resAnonim = inst.Where(delegate (int x) { return x % 2 == 0; }); // еще минимизировал
            resAnonim.ToList().ForEach(x => Console.Write(x + " "));*/

            // Анонимный метод, объявленный в коде может использовать лок переменные метода, в кот он был объявлен, при этом,
            // если переменная value, то передачи параметров не происходит, происходит его захват.
            // 
            // для переменных, захваченных ананим методом среда резервирует участок памати в куче, копируя туда захваченное значение.
            // Также среда будет синхронизировать значение после каждого обращения. Ананим в делегате получает значение переменной
            // в момент выполнения кода, а не в момент создания. 

            /*int counter = 0;
            var method = delegate ()
            {
                Console.WriteLine($"Значение counter {counter}");
                counter++;
            };

            method();
            method();
            method();
            method();
            method();

            counter = -1;

            AnoMethod(method);*/

            // еще пример
            /*List<Action> list = new List<Action>();  // созд список из делег типа Action
            for (int i = 0; i <= 10; i++)
            {
                list.Add(
                    delegate ()
                    {
                        Console.WriteLine("Значение счетчика " + i);
                    }
                    );
            }
            foreach (var item in list)
                item.Invoke();  // будет 11*/

            // иначе

            /*List<Action> list1 = new List<Action>();  // созд список из делег типа Action
            for (int i = 0; i <= 10; i++)
            {
                int j = i;
                list1.Add(
                    delegate ()
                    {
                        Console.WriteLine("Значение счетчика " + j);
                    }
                    );
            }
            foreach (var item in list1)
                item.Invoke();  // будет от 0 до 10*/

            // ,более наглядно про захват переменной
            /*var inst = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // есть список
            int i = 8; // есть переменная

            var filter = inst.Where(delegate (int x) { return x < i; }); // фильтруем < i
            filter.ToList().ForEach(x => Console.Write(x + " "));
            Console.WriteLine();

            i = 3; // меняем i
            filter.ToList().ForEach(x => Console.Write(x + " ")); // получаем меньше 3*/

            // произошел захват i. 

            //////////////////////////////////////////////////////////////////////////////
            /// Лямбда-выражения и оператор =>
            /// (параметры) => выражение
            /// или же 
            /// (параметры) => {блок выражений}
            /// 

            /*var func = (int x) => x * 2 ;
            Console.WriteLine(func(10)); 

            var action = () => Console.WriteLine("Привет");
            action();*/

            /*var inst = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (var item in inst.Where(x => x % 2 == 0))
                Console.Write(item + " ");*/

            /*Action<string> action = ForAnotherDelegate;
            action += (string x) => { Console.WriteLine("хрен поемешь"); }; // добавили в цепочку
            action += (_) => { Console.WriteLine("нижнее подчеркивание вместо указания"); }; // добавили в цепочку
            action("Dmitry");*/


            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            /// СОБЫТИЯ
            // События  C# — это реализация шаблона проектирования издатель-подписчик. Способ,
            // при помощи которого класс может сообщать о каких - либо совершенных с ним действиях или сделанных в нем изменениях

            // по сути события являются специальными экземплярами делегатов, объявленных в классе с некоторыми особенностями 

            // delegate void SomeEventHandler(object sender, args EventArgs);
            // public event SomeEventHandler ThresholdReached;

            // События можно вызвать только коду, принадлежащему экземпляру класса.
            // По своему смыслу события должны быть опциональны классам. Факт наличия или отсутствия
            // подписчиков не должен влиять на работу класса.
            // События не умеют возвращать значения, а значит, тип используемого делегата должен быть void.

            /*var c = new ClassWithEvents();
            c.SomeEven += C_SomeEven;
            c.DoSomeWork();

            Console.WriteLine("Запущено на выполнение");

            Console.ReadLine();

            c.SomeEven -= C_SomeEven;  // отписались от события*/

            // события также могут быть обьявлены в интерфейсах
            // существует предопределенный тип делегата для событий EventHandler c обобщенным аргументом EventArgs

            /////////////// Контрвариативность событий. Означает, что подписанный на события код
            /// может использовать более универсальный обработчик для подписки на события.

            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            /*ObservableCollection<int > list = new ObservableCollection<int>();
            list.CollectionChanged += List_CollectionChanged;
            list.Add(1);*/
        }

        /*private void List_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }*/

        /*private void C_SomeEven(object sender, MyEvenArgs myEvenArgs) // создается автоматически для событий
        {
            Console.WriteLine("Событие от класса " + sender + " Сообщение " + myEvenArgs.Message);
        }*/
    }
}
