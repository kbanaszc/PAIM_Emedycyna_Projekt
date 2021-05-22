namespace DoctorsWebApp.Application.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DoctorsDto
    {
        public string Name { get; set; }
        public IEnumerable<string> Specjalizations { get; set; }
    }
}
