using System;
using System.Collections.Generic;

namespace Question_StackOverflow.Models
{
    public class MainEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IReadOnlyList<Foo> Foos { get; set; }
    }
}
