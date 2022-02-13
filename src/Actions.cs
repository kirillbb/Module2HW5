namespace Module2HW5
{
    public static class Actions
    {
        public static bool InfoMethod()
        {
            string message = $"Start method: {nameof(InfoMethod)}";
            Logger.WriteLog(Logger.LogType.Info, message);

            return true;
        }

        public static BusinessException SkippedLogic()
        {
            string message = $"Skipped logic in method: {nameof(SkippedLogic)}";
            Logger.WriteLog(Logger.LogType.Warning, message);

            return new BusinessException(message);
        }

        public static void BrokeLogic()
        {
            string message = "I broke a logic..";
            Logger.WriteLog(Logger.LogType.Error, $"Action failed by a reason: {message}");

            throw new Exception(message);
        }
    }
}
