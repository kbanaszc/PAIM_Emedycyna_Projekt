namespace ExaminationRoomsSelector.Web.Application.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DoctorsDto
    {
        public DoctorsDto()
        {
        }
        public DoctorsDto(string name, IEnumerable<string> specjalizations)
        {
            Name = name;
            Specjalizations = specjalizations;
        }

        public string Name { get; set; }
        public IEnumerable<string> Specjalizations { get; set; }
    }


}
