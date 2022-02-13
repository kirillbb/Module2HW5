namespace Module2HW5
{
    public class Log
    {
        public string? Time { get; set; }
        public string? Type { get; set; }
        public string? Message { get; set; }
        public override string ToString()
        {
            return $"{Time} : {Type} : {Message}";
        }
    }
}
