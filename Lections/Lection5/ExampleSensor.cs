using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection5
{
    /*public class SensorEventArgs : EventArgs
    { 
        public int Data { get; set; }
    }
    public delegate void SensorEventHandler(object sender, SensorEventArgs args);
    class Sensor
    { 
        public int Nimber { get; set; } = 0;
        public event SensorEventHandler? SomeEvent;
        protected void OnSomeEvent(SensorEventArgs args)
        {
            SomeEvent?.Invoke(this, args);
        }
        public void DoSomeWork()
        {
            new Thread
                (
                    () =>
                    { 
                        var x = new Random().Next(5000);
                        Thread.Sleep (x);
                        OnSomeEvent(new SensorEventArgs { Data = x });
                    }
                ).Start();
        }
    }*/

    internal class ExampleSensor
    {
        public void MainSensor()
        {
            /*List<Sensor> list = new List<Sensor>();
            for (int i = 0; i <= 10; i++)
            {
                var sensor = new Sensor() { Nimber = i };
                sensor.SomeEvent += Sensor_SomeEvent;
                list.Add(sensor);
                sensor.DoSomeWork();
            }

            Console.WriteLine("Запущено на выполнение");

            Console.ReadLine();

            foreach (var item in list)
                item.SomeEvent -= Sensor_SomeEvent;*/

        }

        private void Sensor_SomeEvent(object sender, SensorEventArgs args)
        {
            Console.WriteLine("Сoбытие от класса Sensor# " + (sender as Sensor)?.Nimber + ", = " + args.Data);
        }
    }
}
