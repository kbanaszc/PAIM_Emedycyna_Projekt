using System;
using System.Collections.Generic;
using System.Text;

namespace PAIM_wyk1
{
    public class Specjalization : Entity
    {
        public string SpecName { get; private set; }

        public int Type { get; private set; }


        public Specjalization(int id, string specName, int type) : base(id)
        {
            SpecName = specName;
            Type = type;
        }
    }
}
