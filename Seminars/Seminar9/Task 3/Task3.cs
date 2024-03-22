using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar9.Task_3
{
    // Напишите метод для поиска значений в JSON. В качестве JSON можно использовать JSON из предыдущего примера.
    // Метод должен принимать строку-название ключа и возвращать список найденных значений.
    // Используйте например JsonDocument.Parse
    public class Task3
    {
        public void Run() 
        {
            string json = """
                {"Current": {"Time":"2023-06-18T20:35:06.722127+04:00","Temperature":29,"Weathercode":1,"Windspeed":2.1,"Winddirection":1},
                 "History":[{"Time":"2023-06-17T20:35:06.77707+04:00","Temperature":29,"Weathercode":2,"Windspeed":2.4,"Winddirection":1},
                            {"Time":"2023-06-16T20:35:06.777081+04:00","Temperature":22,"Weathercode":2,"Windspeed":2.4,"Winddirection":1},
                            {"Time":"2023-06-15T20:35:06.777082+04:00","Temperature":21,"Weathercode":4,"Windspeed":2.2,"Winddirection":1}]} 
                """;

            // var res = (new JsonParser()).ParsJson(json, "Temperature");
            JsonParser jsonParser = new JsonParser();
            var res = jsonParser.ParsJson(json, "Temperature");


            foreach (var item in res)
            {
                Console.WriteLine(res);
            }


        }   
    }
}
