namespace Module2HW5
{
    public partial class Logger
    {
        private static readonly List<Log> LogList = new ();
        private static Logger instance = new ();

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }

                return instance;
            }
        }

        public static void WriteLog(LogType type, string logMesage)
        {
            string now = DateTime.Now.ToLongTimeString();

            string logString = $"{now} : {type.ToString()} : {logMesage}";
            Console.WriteLine(logString);

            AddLogsToLogList(now, type, logMesage);
        }

        public static void AddLogsToLogList(string now, LogType logType, string message)
        {
            LogList.Add(new Log
            {
                Time = now, Type = logType.ToString(), Message = message
            });
        }

        public static List<Log> ReturnLogList()
        {
            return LogList;
        }
    }
}
