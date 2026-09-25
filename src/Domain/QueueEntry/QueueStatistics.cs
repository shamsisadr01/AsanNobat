namespace AsanNobat.Domain.QueueEntry;

public class QueueStatistics : BaseEntity
{
    

    public int TotalWaiting { get; set; }
    public int TotalBeingServed { get; set; }
    public int AverageWaitMinutes { get; set; }
    public int EstimatedWaitForNextMinutes { get; set; }
    public QueueStatistics()
    {
    }
    private QueueStatistics(int totalWaiting, int totalBeingServed, int averageWaitMinutes, int estimatedWaitForNextMinutes)
    {
        TotalWaiting = totalWaiting;
        TotalBeingServed = totalBeingServed;
        AverageWaitMinutes = averageWaitMinutes;
        EstimatedWaitForNextMinutes = estimatedWaitForNextMinutes;
    }

    public static QueueStatistics Create(int totalWaiting, int totalBeingServed, int averageWaitMinutes, int estimatedWaitForNextMinutes)
        => new(totalWaiting, totalBeingServed, averageWaitMinutes, estimatedWaitForNextMinutes);

    public void Update(int totalWaiting, int totalBeingServed, int averageWaitMinutes, int estimatedWaitForNextMinutes)
    {
        TotalWaiting = totalWaiting;
        TotalBeingServed = totalBeingServed;
        AverageWaitMinutes = averageWaitMinutes;
        EstimatedWaitForNextMinutes = estimatedWaitForNextMinutes;
    }
}
