namespace Ticketing.Domain.Common
{
    public abstract class AuditableEntity
    {
        public int Id { get; set; }

        public DateOnly DateCreated { get; set; }

        public DateOnly? DateModified { get; set; }

        public string? CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
