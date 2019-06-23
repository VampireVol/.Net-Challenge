using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter flat style: (light or dark)");
            string flatStyle = Console.ReadLine();
            
            Flat flat = new Flat();

            flat.Room1 = SetRoomStyle(flatStyle);
            flat.Room2 = SetRoomStyle(flatStyle);

            Console.WriteLine("Room 1:");
            PrintRoomStyle(flat.Room1);
            Console.WriteLine("Room 2:");
            PrintRoomStyle(flat.Room2);
            Console.ReadKey();
        }

        private static Room SetRoomStyle(string flatStyle)
        {
            Room room = new Room();
            if (flatStyle == "light")
            {
                room.Wallpaper = new LightWallpaper();
                room.Chandelier = new LightChandelier();
            }
            else
            {
                room.Wallpaper = new DarkWallpaper();
                room.Chandelier = new DarkChandelier();
            }
            return room;
        }

        private static void PrintRoomStyle(Room room)
        {
            Console.WriteLine("Wallpaper: {0}", room.Wallpaper.Color);
            Console.WriteLine("Chandelier: {0}", room.Chandelier.Color);
        }
    }
}
