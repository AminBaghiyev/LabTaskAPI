using WorkshopManagement.Core.Entities.Base;

namespace WorkshopManagement.Core.Entities;

public class Workshop : BaseAuditableEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public ICollection<Participant> Participants { get; set; }
}
