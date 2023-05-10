using DataAccessLayer.Models.Employees;

namespace DataAccessLayer.Models;

public class Report
{
    public Report(int processedMessages, int timedMessages, BaseEmployee author, Guid id, DateTime creationDate)
    {
        ProcessedMessages = processedMessages;
        DeviceCountPairs = new List<DeviceCountPair>();
        TimedMessages = timedMessages;
        Author = author;
        Id = id;
        CreationDate = creationDate;
    }

    protected Report()
    {
        DeviceCountPairs = new List<DeviceCountPair>();
    }

    public int ProcessedMessages { get; set; }
    public virtual ICollection<DeviceCountPair> DeviceCountPairs { get; set; }
    public int TimedMessages { get; set; }
    public BaseEmployee Author { get; set; }
    public DateTime CreationDate { get; set; }
    public Guid Id { get; set; }
}