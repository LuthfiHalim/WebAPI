using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{ 

    public class Log
    {
        public int severityLevel { get; set; }
        public string message { get; set; }
        public string completeMessage { get; set; }
        public string path { get; set; }
        public DateTime dateLog { get; set; }
    }
    public class LogMessage
    {
        public static Log create(int severityLevel = 7, string messageLog = "This should be debugged!")
        {
            Log data = new Log();
            data.dateLog = DateTime.Now;
            data.message = messageLog;
            data.severityLevel = severityLevel;
            string jenisPeringatan;
            switch (data.severityLevel)
            {
                case 0:
                    jenisPeringatan = "EMERGENCY";
                    break;
                case 1:
                    jenisPeringatan = "ALERT";
                    break;
                case 2:
                    jenisPeringatan = "CRITICAL";
                    break;
                case 3:
                    jenisPeringatan = "ERROR";
                    break;
                case 4:
                    jenisPeringatan = "WARNING";
                    break;
                case 5:
                    jenisPeringatan = "NOTICE";
                    break;
                case 6:
                    jenisPeringatan = "FYI";
                    break;
                default:
                    jenisPeringatan = "DEBUG";
                    break;
            }
            data.completeMessage = $"[{data.dateLog}] {jenisPeringatan}\t: {data.message}";
            data.path = createPathDirectory("Log", "app.log");
            return data;
        }
        public static string createPathDirectory(string folderNameInCurrentDirectory = "Log", string fileName = "app.log")
        {
            if (!System.IO.Directory.Exists(folderNameInCurrentDirectory))
            {
                System.IO.Directory.CreateDirectory(folderNameInCurrentDirectory);
            }
            string path = Path.Combine(Environment.CurrentDirectory, folderNameInCurrentDirectory, fileName);
            if (!System.IO.File.Exists(path))
            {
                FileStream fs = File.Create(path);
            }
            return path;
        }
        public static IEnumerable<Log> filterBySeverityLevel(IEnumerable<Log> logs, int severityLevel)
        {
            IEnumerable<Log> temp = logs.Where(e => e.severityLevel == severityLevel);
            return temp;
        }
        public static IEnumerable<Log> filterByMessage(IEnumerable<Log> logs, string message)
        {
            IEnumerable<Log> temp = logs.Where(e => e.message.ToLower().Contains(message));
            return temp;
        }
    } 
}
