using System.Collections.Generic;

namespace Model.DL
{
    public class UserEntity : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<RoleEntity> Roles { get; set; } 
        public ICollection<TestEntity> Tests { get; set; }
    }
}
