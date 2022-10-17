using System;
using System.Collections.Generic;

namespace Model.DL
{
    public class TestEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<UserEntity> Users { get; set; }
        public ICollection<QuestionEntity > Questions { get; set;}

    }
}
