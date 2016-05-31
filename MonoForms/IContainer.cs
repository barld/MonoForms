using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoForms
{
    public interface IContainer
    {
        Collections.ILinkedList<IControl> Controls { get; set; }
    }
}