using System;
using System.Collections.Generic;

namespace Model.DL
{
    public class QuestionEntity : BaseEntity
    {
        public string Title { get; set; }

        public Guid TestId { get; set; }
        public TestEntity Test { get; set; }

        public ICollection<OptionEntity> Options { get; set; }
    }
}
