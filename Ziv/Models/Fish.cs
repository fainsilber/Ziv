using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ziv.Models
{
    public abstract class Fish:Animal
    {
        public bool NeedSaltWater { get; set; }
        public string SkinColor { get; set; }
    }
}
