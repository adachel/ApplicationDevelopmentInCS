using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection6
{
    // Исключения это специальные типы ошибок которые происходят при выполнении приложения и помогают
    // обработать различные нетипичные ситуации.Все исключения происходят от одного типа System.Exception.

    // запись в сообщении об ошибке "Unhandled Exeption" - не обработанная ошибка

    internal class MainLec6
    {
        static EventHandler<EventArgs> MyEvent;


        class DivideArraysExeption : Exception  // создали собственный класс исключение
        {
            public DivideArraysExeption(string? message, Exception? e) : base(message, e)
            {}
        }
        class DivideArraysCriticalExeption : Exception  // создали собственный класс для критических исключений
        {
            public DivideArraysCriticalExeption(string? message, Exception? e) : base(message, e)
            { }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// собственный класс с датой и временем исключения
        /// 
        class MyExeption : Exception
        {
            public MyExeption()
            {
                this.HelpLink = "http://yandex.ru";  // дополнительно. Ссылка на ресурс
                this.Data.Add("Дата", new DateTime());
                this.Data.Add("программа", "Демоприложение");
            }
        }

        /// ///////////////////////////////////////////////////////////////////////////////////////////////////
        static int DivideTwoNumbers(int x, int y)  // не верный подход
        {
            try
            {
                return x / y;
            }
            catch (Exception)       // подобная обработка некорректна и плоха тем, что подменяется результат
            {
                Console.WriteLine("Ошибка");
                return default(int);    
            }
        }

        static bool TryDivideTwoNumbers(int x, int y, out int res)  // корректный подход
        {
            try  // в данном случае можно заменить на if
            {
                res = x / y;
                return true;
            }
            catch (Exception)      // на else
            {
                Console.WriteLine("Ошибка");
                res = default(int);
                return false;
            }
        }

        static int ThreeVarDivideTwoNumbers(int x, int y) // вариант, когда ошибка будет обработана при вызове
        {
            return x / y;
        }
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////

        static int[] DivideTwoArray(int[] arr1, int[] arr2)
        {
            var len = Math.Min(arr1.Length, arr2.Length);  // вариант, избежать исключение
            int[] res = new int[arr1.Length];
            for (int i = 0; i < len; i++)
            {
                res[i] = arr1[i] / arr2[i];
            }

            return res;
        }

        static void RunDivideTwoArray(int[] arr1, int[] arr2)
        {
            try
            {
                var resl = DivideTwoArray(arr1, arr2);
                foreach (var item in resl)
                    Console.WriteLine(item + " ");
            }
            catch (Exception e)
            {
                Console.WriteLine("Oшибка" + e.ToString());
            }
            finally
            {
                Console.WriteLine("RunDivideTwoArray. Выход из метода");
            }
        }


        public void Run()
        {
            /////////////////////////////////////////////////////////////////////
            /// методы DivideTwoNumbers и TryDivideTwoNumbers
            if (TryDivideTwoNumbers(1, 0, out int res))
            {
                Console.WriteLine(res);
            }
            else Console.WriteLine("");

            // обработка при вызове
            try
            {
                var result = ThreeVarDivideTwoNumbers(1, 0);
            }
            /*catch (DivideByZeroException e)
            {
                Console.WriteLine("Деление на ноль"); // еще больше информации
            }
            catch (ArithmeticException e)
            {
                // Console.WriteLine("Ошибка " + e.Message); // обработали ошибку
                Console.WriteLine("возникла арифметическая ошибка"); // так еще лучше обработали
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("выход за границу диапазона");
            }
            catch (NullReferenceException e)
            {
                 Console.WriteLine("Один из массивов передан в метод null");
            }*/
            catch (Exception e) when (e is ArithmeticException || e is IndexOutOfRangeException)  // здесь с условием
            {
                Console.WriteLine("Деление на ноль или возникла ошибка выхода за границу");
            }
            /*catch (Exception e)
            { 
                throw new DivideArraysExeption("не предусмотренное исключение ", e);  // использовали свой класс
            }*/
            catch (NullReferenceException e)
            { 
                throw new DivideArraysCriticalExeption("не предусмотренное исключение ", e);  // использовали свой класс
            }


            /////////////////////////////////////////////////////////////////////

            // System.OverFlowExeption
            checked
            {
                int i = 256;
                byte b = (byte)i;   // byte до 255
            }


            // InvalidCastExeption
            var list = new ArrayList();
            list.Add(2);
            list.Add(54);
            list.Add(99);
            list.Add(3);
            list.Add("4");

            int sum = 0;

            foreach (var item in list)
                sum += (item as int?) ?? 0; // '??' - если тип приведения не совпадет с типом операнда,
                                            // то получим null. ?? - заменяем null на 0.

            foreach (var item in list)
                sum += (int)item;   // Приведет к ошибке


            // ArgumentOutOfRangeExeption. Аргумент, переданный в метод не соответствует диапазону
            string s = "1231231";
            var sres = s.Substring(0, -1); // попытка получить подстроку от 0 до -1

            // IndexOutOfRangeExeption. Выход за границы массива

            // NullReferensExeption. Попытка записать в несущ ячейку
            int[] arr = null;
            arr[1] = 0;

            MyEvent.Invoke(null, null); // на события никто не подписан
            MyEvent?.Invoke(null, null); // так ошибки не будет

            // StackOverFlowExeption. Ошибка переполнения стека. Нельзя обработать!!!

            // блок try - catch. Блоков catch может быть несколько.

            // обработка в блоках catch идет от более спец к менее спец. ПОРЯДОК ВАЖЕН

            // с помощью инструкции throw без параметров, выбрасываем исключение дальше, при этом,
            // вызывающий метод не догадывается, что оно было перехвачено,
            // поскольку стек вызовов исключений, все также указывает на то, что оно было выбрашено в методе

            //////////////////////////////////////////////////////////////////////////////
            ///
            string str = "000";
            if (int.TryParse(str, out int rrr))
            {
                Console.WriteLine(rrr);
            }
            else Console.WriteLine("Строка не преобразовалась");

            ////////////////////////////////////////////////////////////////////////////////
            /// 
            try
            {

            }
            catch (ArgumentOutOfRangeException e)  // такие исключения не ловятся
            {

                throw;
            }
            ////////////////////////////////////////////////////////////////////////////////
            /// DivideTwoArray
            /// 

            try
            {
                RunDivideTwoArray(new int[] { 2, 4, 8 }, new int[] { 2, 4, 8 });
                RunDivideTwoArray(new int[] { 2, 4, 8 }, new int[] { 0, 4, 8 });
                RunDivideTwoArray(new int[] { 2, 4, 8 }, new int[] {});
                RunDivideTwoArray(new int[] { 2, 4, 8 }, null);
            }
            catch (DivideArraysExeption e)
            {
                Console.WriteLine("ошибка обработки: " + e.Message);
                Console.WriteLine("вызванная: " + e.InnerException);
            }
            catch (DivideArraysCriticalExeption e)
            {
                Console.WriteLine("ошибка обработки: " + e.Message);
                Console.WriteLine("вызванная: " + e.InnerException);
            }



            Console.WriteLine("Завершается");

            ///////////////////////////////////////////////////////////////////////////////
            /// увидеть необрабатываемые исключения
            /// 
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
            // событие FirstChanceException возникает всегда, когда возникает исключение

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            /////////////////////////////////////////////////////////////////////////////////
            /// для своего класса с датой
            /// 
            try
            {
                throw new MyExeption();
            }
            catch (MyExeption e)
            {
                Console.WriteLine(e.Source);  // хранит источник возникновения ошибки
                Console.WriteLine(e.StackTrace);  // хранит строку с ошибкой
                Console.WriteLine(e.TargetSite);  // хранит название метода с исключением


                // e.HResult;  // 32 - бит число, представляющее код в ос 
                Console.WriteLine($"Дата = {e.Data["дата"]}");
                Console.WriteLine($"Программа = {e.Data["программа"]}");
                Console.WriteLine($"Помощь = {e.HelpLink}");
            }

            /////////////////////////
            /// еще свойства
            /// 
            try
            {
                RunDivideTwoArray(null, null);
            }
            catch (Exception e)
            {
                /*Exception ex = e;
                while (ex.InnerException != null)
                    ex = ex.InnerException;
                Console.WriteLine(ex); // докапались до самого верхнего исключения*/

                Console.WriteLine("!" + e.GetBaseException());  // тоже только проще
            }

        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("это нас убъет");
            Console.WriteLine(e.ExceptionObject); // получаем инфо о необработанных ошибках
        }

        private void CurrentDomain_FirstChanceException(object? sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            Console.WriteLine(e.Exception);  // получаем инфо об исключении
        }
    }
}
