using System;

namespace Model.DL
{
    public class OptionEntity : BaseEntity
    {
        public char Letter { get; set; }
        public string Text { get; set; }
        public bool IsRight { get; set; }

        public Guid QuestionId { get; set; }
        public QuestionEntity  Question { get; set; }
    }
}
