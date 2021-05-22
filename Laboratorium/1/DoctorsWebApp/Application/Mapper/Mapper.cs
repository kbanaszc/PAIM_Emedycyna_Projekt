namespace DoctorsWebApp.Application.Mapper
{
    using PAIM_wyk1;
    using DoctorsWebApp.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class Mapper
    {
        public static DoctorsDto Map(this Doctor doctor)
        {
            if (doctor == null)
                return null;

            return new DoctorsDto
            {
                Name = doctor.Name,
                Specjalizations = doctor?.Specjalizations.Select(s => s.Type.ToString())
            };
        }
    }
}
