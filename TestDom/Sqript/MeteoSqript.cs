using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using TestDom.Data;

namespace TestDom.Sqript
{
    static class MeteoSqript
    {
        public static string APPID = "c0c1060fcb2fcce14b69e5b7eb719672";

        // Получение данных
        public static Meteo GetData(string CountryName)
        {
            // URL с именем города и ключем
            WebRequest url = WebRequest.Create(
                "http://api.openweathermap.org/data/2.5/find?q=" +
                CountryName +
                "&type=like&APPID="
                + APPID);

            url.Method = "GET";
            WebResponse response = url.GetResponse(); // Запрос на сервер
            string answer = string.Empty;
            using (Stream s = response.GetResponseStream())// чтение запроса
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    answer = reader.ReadToEnd();
                }
            }
            response.Close();
         
            Meteo meteo = new Meteo();
            
            // Парсинг города
            JsonDocument jsonDoc = JsonDocument.Parse(answer); // Преобразование в документ
            JsonElement root = jsonDoc.RootElement; // Переход к корневому элементу JSON
                                                    // Извлечение из свойства list, первого города
            JsonElement firstCity = root.GetProperty("list").EnumerateArray().FirstOrDefault();

            if (!firstCity.Equals(default(JsonElement)))
            {
                meteo = new Meteo(
                    firstCity.GetProperty("main").GetProperty("temp").GetSingle() - 273,
                    firstCity.GetProperty("weather")[0].GetProperty("description").GetString(),
                    firstCity.GetProperty("wind").GetProperty("speed").GetSingle());
            }
            else
                return null;
            jsonDoc.Dispose();

            return meteo;
        }

    }
 
}
