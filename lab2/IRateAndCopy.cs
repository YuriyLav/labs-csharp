using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();
    }
}
