﻿using System;
using System.IO;
using System.Text;

namespace ClashRoyaleProxy
{
    class Logger
    {
        /// <summary>
        /// Logs passed text
        /// </summary>
        public static void Log(string text, LogType type)
        {
            Console.ForegroundColor = (type == LogType.EXCEPTION || type == LogType.WARNING) ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write("[" + type + "] ");
            Console.ResetColor();
            Console.WriteLine(text);
            //LogToFile(text, type);
        }

        /// <summary>
        /// Logs passed packet
        /// </summary>
        public static void LogPacket(Packet p)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("[PACKET " + p.ID + "] ");
            Console.ResetColor();
            Console.WriteLine(p.Type);
            //LogToFile("Packet " + p.ID + " : " + p.DecryptedPayload, type);
        }

        /// <summary>
        /// Logs passed text to a file
        /// </summary>
        public static void LogToFile(string text, LogType type)
        {
            if (!Directory.Exists("logs"))
                Directory.CreateDirectory("logs");

            string path = Environment.CurrentDirectory + @"\\logs\\log_" + System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy") + "." + "log";
            StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Append));
            sw.WriteLine("[" + System.DateTime.UtcNow.ToLocalTime().ToString("hh-mm-ss") + "-" + type + "] " + text);
            sw.Close();
        }
    }
}
