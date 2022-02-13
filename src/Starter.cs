namespace Module2HW5
{
    public class Starter
    {
        public static void Run()
        {
            Random random = new ();

            for (int i = 0; i < 100; i++)
            {
                int action = random.Next(1, 4);

                try
                {
                    switch (action)
                    {
                        case 1:
                            Actions.InfoMethod();
                            break;
                        case 2:
                            var ex = Actions.SkippedLogic();
                            Logger.WriteLog(Logger.LogType.Warning, $"Action got this custom Exception: {ex.Message}");
                            break;
                        case 3:
                            Actions.BrokeLogic();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(Logger.LogType.Error, $"Action failed by a reason: {ex}");
                }
            }

            var logList = Logger.ReturnLogList();

            FileService fileService = new FileService();
            fileService.WriteLogs(logList);
        }
    }
}
