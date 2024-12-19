using WorkshopManagement.Core.Entities.Base;

namespace WorkshopManagement.Core.Entities;

public class Participant : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int WorkshopId { get; set; }
    public Workshop? Workshop { get; set; }
}
