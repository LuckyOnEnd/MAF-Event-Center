namespace MAF_Event_Center.SPA.Models.User
{
    public class CreateUserManager
    {
        public Guid Id { get; set; }
        public string userName { get; set; }
        public string rank { get; set; }
        public string canCreate { get; set; }
    }
}
