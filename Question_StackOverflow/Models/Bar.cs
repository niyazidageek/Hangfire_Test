using System;
using System.Collections.Generic;

namespace Question_StackOverflow.Models
{
    public class Bar
    {   
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? FooId { get; set; }

        public Guid? ParentBarId { get; set; }

        public virtual Bar ParentBar { get; set; } 
        public virtual ICollection<Bar> ChildrenBars { get; set; }
    }
}
