using System.Collections.Generic;

namespace Model.DL
{
    public class RoleEntity : BaseEntity
    {
        public string Title { get; set; }

        public ICollection<UserEntity> Users { get; set; }
    }
}
