using System;
using System.Collections.Generic;

namespace Question_StackOverflow.Models
{
    public class Foo
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid MainEntityId { get; set; }

        public IReadOnlyList<Bar> Bars { get; set; }
    }
}
