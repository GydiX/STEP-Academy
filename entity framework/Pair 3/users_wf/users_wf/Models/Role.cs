namespace users_wf.Models
{
    public class Role
    {
        public required string Id { get; set; }
        public required string Name { get; set; }

        public virtual ICollection<User> Users { get; set; } = [];
    }
}
