namespace SmartShop.Models
{
    public class ObjectCommand
    {
        public int OCommandId { get; set; }
        public string BusinessObjectCode { get; set; }
        public string BusinessObjectName { get; set; }
        public string ObjectFormName { get; set; }
        public string ObjectFormDescription { get; set; }
        public int UserId { get; set; }
        public string LoginName { get; set; }
        public UserLogin UserLogin { get; set; }
        public bool Permisson { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
    }
}
