namespace AsanNobat.Domain.QueueEntry;

public class JoinPage : BaseEntity
{


    public string BusinessSlug { get; set; } = string.Empty;
    public string BusinessName { get; set; } = string.Empty;
    public string BusinessDescription { get; set; } = string.Empty;
    public int CurrentPeopleInQueue { get; set; }
    public int EstimatedWaitMinutes { get; set; }
    //public JoinFormSettings Form { get; set; }
    public bool ShowsBenefitsSection { get; set; }
    public bool IsQueueOpen { get; set; }


    public JoinPage()
    {
    }
    private JoinPage(string businessSlug, string businessName, string businessDescription,
        int currentPeopleInQueue, int estimatedWaitMinutes, bool showsBenefitsSection, bool isQueueOpen)
    {
        BusinessSlug = businessSlug;
        BusinessName = businessName;
        BusinessDescription = businessDescription;
        CurrentPeopleInQueue = currentPeopleInQueue;
        EstimatedWaitMinutes = estimatedWaitMinutes;
        ShowsBenefitsSection = showsBenefitsSection;
        IsQueueOpen = isQueueOpen;
    }



    public static JoinPage Create(string businessSlug, string businessName, string businessDescription,
        int currentPeopleInQueue, int estimatedWaitMinutes, bool showsBenefitsSection, bool isQueueOpen)
        => new(businessSlug, businessName, businessDescription, currentPeopleInQueue, estimatedWaitMinutes, showsBenefitsSection,
            isQueueOpen);

    public void Update(string businessSlug, string businessName, string businessDescription,
        int currentPeopleInQueue, int estimatedWaitMinutes, bool showsBenefitsSection, bool isQueueOpen)
    {
        BusinessSlug = businessSlug;
        BusinessName = businessName;
        BusinessDescription = businessDescription;
        CurrentPeopleInQueue = currentPeopleInQueue;
        EstimatedWaitMinutes = estimatedWaitMinutes;
        ShowsBenefitsSection = showsBenefitsSection;
        IsQueueOpen = isQueueOpen;
    }

    public void Delete()
    {

    }
}
