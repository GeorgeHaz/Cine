namespace Cine.Api.Models.Entities
{
    public class AuditableEntity
    {
        public DateTime? AuditDeleteDate { get; set; }
        public int? AuditDeleteUser { get; set; }
    }
}
