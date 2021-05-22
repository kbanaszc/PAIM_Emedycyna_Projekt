using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PAIM_wyk1
{
    public class Doctor : Person
    {
        public IList<Specjalization> Specjalizations { get; private set; } = new List<Specjalization>();

        public Doctor(int id, string name) : base(id, name)
        {

        }

        public Doctor(int id, string name, IList<Specjalization> specjalizations) : this(id, name)
        {
            Specjalizations = specjalizations;

        }

        public void AddSpecjalization(Specjalization specjalization)
        {
            Specjalizations.Add(specjalization);
        }

        public void AddSpecjalizations(IEnumerable<Specjalization> specjalizations)
        {
            foreach (var specjalization in specjalizations)
                Specjalizations.Add(specjalization);
        }

        public override string GetDescription()
        {
            return String.Format("{0}, specialization - {1} ", this.Name, this.Specjalizations);
        }


    }


}





