using System;
using System.Collections;
using System.Collections.Generic;

namespace NcsChatServer.ConsoleHelper
{
    public class Draw
    {
        private Stack<string> logData = new Stack<string>();

        private Queue<WriteData> writeQueue = new Queue<WriteData>();

        public Draw(int width, int height)
        {
            Console.SetWindowSize(width, height);

            Console.Clear();
        }

        public void InitConsole()
        {
            Console.WriteLine("┌──────────────────── NcsChatServer! ────────────────────┐");
            Console.WriteLine("│   User Count :        Room Count :        Port :       │");
            Console.WriteLine("├────────────────────────────────────────────────────────┤");
            Console.WriteLine("│                                                        │");
            Console.WriteLine("│                                                        │");
            Console.WriteLine("│                                                        │");
            Console.WriteLine("│                                                        │");
            Console.WriteLine("│                                                        │");
            Console.WriteLine("│                                                        │");
            Console.WriteLine("│                                                        │");
            Console.WriteLine("│                                                        │");
            Console.WriteLine("│                                                        │");
            Console.WriteLine("│                                                        │");
            Console.WriteLine("├────────────────────────────────────────────────────────┤");
            Console.WriteLine("│                                                        │");
            Console.WriteLine("└────────────────────────────────────────────────────────┘");
            logData.Push("[Console] LogSystem SetUp");
        }

        public void SetUserCount(int count)
        {
            writeQueue.Enqueue(new WriteData(2, 23, count.ToString().PadLeft(4, '0')));
        }

        public void SetRoomCount(int count)
        {
            writeQueue.Enqueue(new WriteData(2, 39, count.ToString().PadLeft(3,'0')));
        }

        public void SetPortNum(int num)
        {
            writeQueue.Enqueue(new WriteData(2, 39, num.ToString().PadLeft(3, '0')));
        }

        public void OnDraw()
        {
            while (writeQueue.Count == 0)
            {
                var data = writeQueue.Peek();
                
                Console.SetCursorPosition(data.X, data.Y);

                Console.Write(data.Text);
            }

            if (logData.Count > 1)
            {
                logData.Pop();
            }
        }
    }

    public class WriteData
    {
        public readonly int X;
        public readonly int Y;
        public readonly string Text;

        public WriteData(int x, int y, string text)
        {
            X = x;
            Y = y;
            Text = text;
        }
    }
}
