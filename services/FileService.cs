using Newtonsoft.Json;

namespace Module2HW5
{
    public class FileService
    {
        public void WriteLogs(List<Log> logs)
        {
            var config = SerializeConfigFile();

            TryToCreateDir(config);

            CheckNumberOfFiles(config);

            string fileName = DateTime.Now.ToString(config.Logger.FileNameFormat);
            string fileExtension = config.Logger.FileExtension;

            string filePath = $"{config.Logger.DirectoryPath}\\{fileName}{fileExtension}";

            using StreamWriter streamWriter = new StreamWriter(filePath, false, System.Text.Encoding.UTF8);
            {
                try
                {
                    foreach (var item in Logger.ReturnLogList())
                    {
                        streamWriter.WriteLine($"{item.Time}: {item.Type}: {item.Message}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public Config SerializeConfigFile()
        {
            string configFile = string.Empty;
            configFile = File.ReadAllText(@"C:\Users\Kirill\source\repos\Module2HW5\config.json");
            var loggerConfig = JsonConvert.DeserializeObject<Config>(configFile);

            return loggerConfig;
        }

        public void TryToCreateDir(Config config)
        {
            string path = config.Logger.DirectoryPath;
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
        }

        private void CheckNumberOfFiles(Config config)
        {
            string path = config.Logger.DirectoryPath;
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            var files = directoryInfo.GetFiles();

            if (files.Length >= 3)
            {
                var oldestFileDate = DateTime.Now;
                string oldestFilePath = string.Empty;

                foreach (var item in files)
                {
                    if (oldestFileDate > item.LastWriteTime)
                    {
                        oldestFileDate = item.LastWriteTime;
                        oldestFilePath = item.Name;
                    }
                }

                File.Delete($"{path}\\{oldestFilePath}");
            }
        }
    }
}