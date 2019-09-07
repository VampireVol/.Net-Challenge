using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQLibraryNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Town town = new Town("Нижнее верховье");

            List<District> districts = new List<District>()
            {
                new District("Северный", town.Id),
                new District("Южный", town.Id),
                new District("Центральный", town.Id),
                new District("Западный", town.Id),
                new District("Восточный", town.Id)
            };

            List<Visitor> visitors = new List<Visitor>()
            {
                new Visitor("Артем"),
                new Visitor("Иллидан"),
                new Visitor("Георгий"),
                new Visitor("Виктор"),
                new Visitor("Алиса"),
                new Visitor("Ангелина"),
                new Visitor("Артес"),
                new Visitor("Джайна")
            };

            List<Library> libraries = new List<Library>()
            {
                new Library("Центральная библиотека Нижне Верховья", "Ул. Пирожкова, 3а", districts[2].Id),
                new Library("Детская библиотека №1", "Ул. Петрушкина, 40", districts[3].Id),
                new Library("Областная библиотека", "Ул. Пролетарская, 22", districts[3].Id),
                new Library("Городская библиотека №5", "Ул. Испытаний, 13", districts[3].Id),
                new Library("Городская библиотека №2", "Ул. Мира, 49", districts[1].Id),
                new Library("Детская библиотека №3", "Ул. Предприятий, 11", districts[1].Id),
                new Library("Библиотека им. В.И.Ульянова", "Ул. Дверей, 57", districts[4].Id),
                new Library("Городская библиотека №4", "Ул. Каменская, 33", districts[2].Id)
            };

            List<Book> books = new List<Book>()
            {
                new Book("Крис Метцен","World of Warcraft. Варкрафт: Хроники. Энциклопедия. Том 1", Genre.Fantasy),
                new Book("Крис Метцен","World of Warcraft. Варкрафт: Хроники. Энциклопедия. Том 2", Genre.Fantasy),
                new Book("Крис Метцен","World of Warcraft. Варкрафт: Хроники. Энциклопедия. Том 3", Genre.Fantasy),
                new Book("Кристи Голден", "Артас: Восхождение Короля-Лича", Genre.Fantasy),
                new Book("Лев Николаевич Толстой", "Война и мир", Genre.Classic),
                new Book("Лев Николаевич Толстой", "Мастер и Маргарита", Genre.Classic),
            };

            List<CopyBook> copyBooks = new List<CopyBook>()
            {
                new CopyBook(RelaseForm.Collectible, books[0].Id),
                new CopyBook(RelaseForm.Collectible, books[0].Id),
                new CopyBook(RelaseForm.Collectible, books[1].Id),
                new CopyBook(RelaseForm.Collectible, books[1].Id),
                new CopyBook(RelaseForm.Collectible, books[2].Id),
                new CopyBook(RelaseForm.Collectible, books[2].Id),
                new CopyBook(RelaseForm.Collectible, books[3].Id),
                new CopyBook(RelaseForm.Solid, books[3].Id),
                new CopyBook(RelaseForm.Solid, books[4].Id),
                new CopyBook(RelaseForm.Old, books[4].Id),
                new CopyBook(RelaseForm.Solid, books[4].Id),
                new CopyBook(RelaseForm.Soft, books[4].Id),
                new CopyBook(RelaseForm.Solid, books[5].Id),
                new CopyBook(RelaseForm.Soft, books[5].Id),
                new CopyBook(RelaseForm.Solid, books[5].Id),
            };

            var libNames = from lib in libraries
                select  lib.Name;

            foreach (var libName in libNames)
            {
                Console.WriteLine(libName);
            }

            Console.WriteLine();

            var libNamesGroup = from lib in libraries
                                join dis in districts on lib.DistrictId equals dis.Id
                                group lib by dis.Name;

            foreach (var libNameGroup in libNamesGroup)
            {
                Console.WriteLine($"{libNameGroup.Key} ({libNameGroup.Count()})");
                foreach (var library in libNameGroup)
                {
                    Console.WriteLine(library.Name);
                }
            }

            Console.WriteLine();

            var withLibDistricts = (from dis in districts
                                    join lib in libraries on dis.Id equals lib.DistrictId
                                    select dis).ToList();
            var withoutLibDistricts = districts.Except(withLibDistricts);

            foreach (var withoutLibDistrict in withoutLibDistricts)
            {
                Console.WriteLine(withoutLibDistrict.Name);
            }


            Console.ReadKey();
        }
    }
}
