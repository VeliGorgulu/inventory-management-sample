using InventoryManagementApplication.Core.Entities.Abstract;

namespace InventoryManagementApplication.Core.Entities.Concrete
{
    public class OperationClaim : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
