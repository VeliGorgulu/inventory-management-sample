using InventoryManagementApplication.Core.Entities.Abstract;

namespace InventoryManagementApplication.Core.Entities.Concrete
{
    public class UserOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
