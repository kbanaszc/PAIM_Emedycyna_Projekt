namespace DoctorsWebApp.Application.Queries

{
    using DoctorsWebApp.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IDoctorQueriesHandler
    {
        Task<IEnumerable<DoctorsDto>> GetAllAsync();
        IEnumerable<DoctorsDto> GetBySpecType(int SpecType);

    }
}
