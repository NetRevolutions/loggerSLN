﻿using System;

using Belatrix.Logger.Entities;
using Belatrix.Logger.Enum;
using Belatrix.Logger;

namespace Belatrix.Logger.Console
{
    class Program
    {
        static void Main(string[] args)
        {           

            LoggerEntity loggerEntity = new LoggerEntity();
            loggerEntity.Message = "This is a general message";
            loggerEntity.Level = Level.MESSAGE;          
            LogAllRepositories(loggerEntity);

            loggerEntity.Message = "This is a warning message";
            loggerEntity.Level = Level.WARNING;
            LogAllRepositories(loggerEntity);

            loggerEntity.Message = "This is a error message";
            loggerEntity.Level = Level.ERROR;
            LogAllRepositories(loggerEntity);

            System.Console.ReadLine();            
            
        }

        static void LogAllRepositories(LoggerEntity loggerEntity)
        {
            // Console section
            ILogger loggerCSN = new LoggerFactory().GetLogger(ObjectType.CONSOLE);
            loggerCSN.Write(loggerEntity);

            // DataBase section
            ILogger loggerDB = new LoggerFactory().GetLogger(ObjectType.DATABASE);
            loggerDB.Write(loggerEntity);

            // File section
            ILogger loggerFL = new LoggerFactory().GetLogger(ObjectType.FILE);
            loggerFL.Write(loggerEntity);
            
        }
    }
}
