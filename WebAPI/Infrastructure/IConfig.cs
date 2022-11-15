namespace Infrastructure
{
    public interface IConfig
    {
        string AppConnectionString { get; set; }
        string MasterConnectionString { get; set; }
    }

    public class Config : IConfig
    {
        public string AppConnectionString { get; set; }
        public string MasterConnectionString { get; set; }
    }
}
