using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyChallenge_4_Maya
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayName;

            DateTime date = ReadDate();
            DateTime newTzolkin = new DateTime(2017, 7, 9);
            DateTime newHaab = new DateTime(2017, 4, 1);
            DateTime newLongCount = new DateTime(2012, 12, 21);

            int deltaTzolkin = (date - newTzolkin).Days;
            int deltaHaab = (date - newHaab).Days;
            int deltaLongCount = (date - newLongCount).Days;

            int inTzolkin = deltaTzolkin % 260;
            int inHaab = deltaHaab % 365;

            if (inTzolkin < 0)
                inTzolkin += 260;
            if (inHaab < 0)
                inHaab += 365;

            Console.WriteLine($"корреляция JD 584283: {GetLongCount(deltaLongCount)}, " +
                              $"{inTzolkin % 13 + 1} " +
                              $"{GetTzolkinName(inTzolkin % 20)} " +
                              $"{inHaab % 20} " +
                              $"{GetHaabName(inHaab / 20)}");

            Console.WriteLine($"корреляция JD 584285: {GetLongCount(deltaLongCount - 2)}, " +
                              $"{(inTzolkin - 2) % 13 + 1} " +
                              $"{GetTzolkinName((inTzolkin - 2) % 20)} " +                           
                              $"{(inHaab - 2) % 20} " +
                              $"{GetHaabName((inHaab - 2) / 20)}");

            Console.ReadLine();
        }

        public static DateTime ReadDate()
        {
            Console.WriteLine("Введите дату.");
            int year, month, day;
            Console.Write("Год:");
            year = int.Parse(Console.ReadLine());
            Console.Write("Месяц:");
            month = int.Parse(Console.ReadLine());
            Console.Write("День:");
            day = int.Parse(Console.ReadLine());
            return new DateTime(year, month, day);
        }

        public static string GetLongCount(int delta)
        {
            delta += 13 * 144000;
            int baktun = delta / 144000;
            delta = Math.Abs(delta);
            delta %= 144000;
            int katun = delta / 7200;
            delta %= 7200;
            int tun = delta / 360;
            delta %= 360;
            int winal = delta / 20;
            int kin = delta % 20;

            return $"{baktun}.{katun}.{tun}.{winal}.{kin}";
        }

        public static string GetTzolkinName(int n)
        {
            switch (n)
            {
                case 0:
                    return "Имиш";
                case 1:
                    return "Ик";
                case 2:
                    return "Акбаль";
                case 3:
                    return "Кан";
                case 4:
                    return "Чик-Чан";
                case 5:
                    return "Кими";
                case 6:
                    return "Маник";
                case 7:
                    return "Ламат";
                case 8:
                    return "Мулук";
                case 9:
                    return "Ок";
                case 10:
                    return "Чуэн";
                case 11:
                    return "Эб";
                case 12:
                    return "Бен";
                case 13:
                    return "Хиш";
                case 14:
                    return "Мен";
                case 15:
                    return "Киб";
                case 16:
                    return "Кабан";
                case 17:
                    return "Эцнаб";
                case 18:
                    return "Кавак";
                case 19:
                    return "Ахау";
            }

            return "Ошибка";
        }

        public static string GetHaabName(int n)
        {
            switch (n)
            {
                case 0:
                    return "Поп";
                case 1:
                    return "Во";
                case 2:
                    return "Сип";
                case 3:
                    return "Соц";
                case 4:
                    return "Сек";
                case 5:
                    return "Шуль";
                case 6:
                    return "Яакшин";
                case 7:
                    return "Моль";
                case 8:
                    return "Чен";
                case 9:
                    return "Йаш";
                case 10:
                    return "Сак";
                case 11:
                    return "Кех";
                case 12:
                    return "Мак";
                case 13:
                    return "Канкин";
                case 14:
                    return "Муан";
                case 15:
                    return "Паш";
                case 16:
                    return "Кайяб";
                case 17:
                    return "Кумху";
                case 18:
                    return "Вайеб";
            }

            return "Ошибка";
        }
    }
}
