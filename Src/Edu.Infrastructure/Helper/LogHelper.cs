using System;

[assembly: log4net.Config.XmlConfigurator(Watch = true)] 
namespace Edu.Infrastructure.Helper
{
    public class LogHelper
    {
        public static void Error(Type type,Exception exp)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(type);
            log.Error("Error",exp);
        }
        public static void Error(Type type, string messege, Exception exp)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(type);
            log.Error(messege, exp);
        }
        public static void Info(Type type,string i)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(type);
            log.Info(i);
        }

        public static void Debug(Type type, string message, Exception exp)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(type);
            log.Debug(message, exp);
        }
        
    }
}
