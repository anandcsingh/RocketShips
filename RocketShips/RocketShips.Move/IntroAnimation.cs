using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RocketShips.Move
{
    public class IntroAnimation
    {

        public void PlayReverse()
        {
            int Left = Console.WindowLeft + 50, Top = Console.WindowTop + 1;
            int length = 80;
            int inverseSpeed = 30;

            for (int i = length; i >= 0; i--)
            {
                var buffer = string.Join(' ', Enumerable.Repeat(" ", i));
                Console.WriteLine(new string(line1.Reverse().ToArray()));
                Console.WriteLine(new string(line2.Reverse().ToArray()));
                Console.WriteLine(new string(line3.Reverse().ToArray()));
                Console.WriteLine(new string(line4.Reverse().ToArray()));

                Thread.Sleep(inverseSpeed);
                Console.SetCursorPosition(Left, Top);
            }
            Console.SetCursorPosition(Left, Top);
            Console.WriteLine(text);
        }
        public void Play()
        {
            int Left = Console.WindowLeft, Top = Console.WindowTop + 1;
            int length = 80;
            int inverseSpeed = 30;

            for (int i = 0; i < length; i++)
            {
                var buffer = string.Join(' ', Enumerable.Repeat(" ", i));
                Console.WriteLine(buffer + line1);
                Console.WriteLine(buffer + line2);
                Console.WriteLine(buffer + line3);
                Console.WriteLine(buffer + line4);

                Thread.Sleep(inverseSpeed);
                Console.SetCursorPosition(Left, Top);
            }
            Console.SetCursorPosition(Left, Top);
            Console.WriteLine(text);
        }

        string line1 = "   __";
        string line2 = @"   \ \_____";
        string line3 = "###[==_____>";
        string line4 = "   /_/";

        // 86 chars
        string text =
@"  _    ___ _  _  ___                 _   ___         _       _     ___ _    _         
 | |  |_ _| \| |/ _ \   __ _ _ _  __| | | _ \___  __| |_____| |_  / __| |_ (_)_ __ ___
 | |__ | || .` | (_) | / _` | ' \/ _` | |   / _ \/ _| / / -_)  _| \__ \ ' \| | '_ (_-<
 |____|___|_|\_|\__\_\ \__,_|_||_\__,_| |_|_\___/\__|_\_\___|\__| |___/_||_|_| .__/__/
                                                                             |_|      ";

    }
}
