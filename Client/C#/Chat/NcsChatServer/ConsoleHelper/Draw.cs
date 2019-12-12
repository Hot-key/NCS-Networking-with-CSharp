using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using NLog.Fluent;

namespace NcsChatServer.ConsoleHelper
{
    public class Draw
    {
        private Queue<string> logData = new Queue<string>();

        private Queue<WriteData> writeQueue = new Queue<WriteData>();

        public bool IsDraw = false;

        private Size size;

        private int userCount = 0;
        private int roomCount = 0;
        private int portNum = 0;

        public Draw(int width, int height, string name)
        {
            this.size = new Size(width, height);
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
            if (name.Length % 2 == 1)
            {
                name += '!';
            }
            Console.Title = name;
            Console.Clear();
        }

        public void InitConsole()
        {
            
            Console.WriteLine($"┌{("  " + Console.Title + " ").PadRight((size.Width + Console.Title.Length + 6) / 2 - 4, '─').PadLeft(size.Width - 4, '─')}┐");
            Console.WriteLine($"{"│   UserData Count :        Room Count :        Port : ".PadRight(size.Width - 3)}│");
            Console.WriteLine($"├{"".PadLeft(size.Width - 4, '─')}┤");

            for (int i = 0; i < size.Height - 6; i++)
            {
                Console.WriteLine($"│{"".PadLeft(size.Width - 4)}│");
            }

            Console.WriteLine($"├{"".PadLeft(size.Width - 4, '─')}┤");
            Console.WriteLine($"│{"".PadLeft(size.Width - 4)}│");
            Console.Write    ($"└{"".PadLeft(size.Width - 4, '─')}┘");
            WriteLog("[Console] Console LogSystem SetUp");

            IsDraw = true;

            //Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.SetCursorPosition(2, size.Height - 2);
        }

        public void SetUserCount(int count)
        {
            writeQueue.Enqueue(new WriteData(17, 1, count.ToString().PadLeft(4, '0')));
            userCount = count;
        }

        public void AddUserCount(int count)
        {
            Interlocked.Add(ref userCount, count);
            writeQueue.Enqueue(new WriteData(17, 1, userCount.ToString().PadLeft(4, '0')));
        }

        public void SetRoomCount(int count)
        {
            writeQueue.Enqueue(new WriteData(37, 1, count.ToString().PadLeft(3,'0')));
            roomCount = count;
        }

        public void AddRoomCount(int count)
        {
            Interlocked.Add(ref roomCount, count);
            writeQueue.Enqueue(new WriteData(37, 1, roomCount.ToString().PadLeft(3, '0')));
        }

        public void SetPortNum(int num)
        {
            writeQueue.Enqueue(new WriteData(51, 1, num.ToString().PadLeft(3, '0')));
            portNum = num;
        }

        public void WriteLog(string data)
        {
            logData.Enqueue(data);
        }

        public void OnDraw()
        {
            var prevPoint = new Point(Console.CursorLeft, Console.CursorTop);
            while (writeQueue.Count > 0)
            {
                var data = writeQueue.Dequeue();

                Console.SetCursorPosition(data.X, data.Y);

                Console.Write(data.Text);
            }

            if (logData.Count > 0)
            {
                var data = logData.Dequeue();

                Console.MoveBufferArea(2,4, size.Width - 5, size.Height - 7, 2, 3);
                Console.SetCursorPosition(2, size.Height - 4);
                Console.Write(data.Substring(0, Math.Min(data.Length, size.Width - 5)));

                Program.Logger.Info("Console : " + data);
            }

            Console.SetCursorPosition(Math.Min(prevPoint.X, size.Width - 4), size.Height - 2);
        }

        public void SendCmd(string data)
        {
            WriteLog($"[Cmd] {data}");
            switch (data.ToLower())
            {
                case "exit":
                    IsDraw = false;
                    return;
            }
            Console.SetCursorPosition(2, size.Height - 2);
            Console.Write(" ".PadRight(size.Width - 5));
            Console.SetCursorPosition(2, size.Height - 2);
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
