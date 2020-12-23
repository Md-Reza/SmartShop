namespace SmartShop.Models
{
    public class Departments : BaseEntity
    {
        public int Id { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public bool Status { get; set; }
    }
}
