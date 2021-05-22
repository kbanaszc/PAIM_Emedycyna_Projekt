namespace DoctorsWebApp.Application.Queries
{
    using DoctorsWebApp.Application.Dtos;
    using DoctorsWebApp.Application.Mapper;
    using PAIM_wyk1;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DoctorQueriesHandler : IDoctorQueriesHandler
    {
        private readonly IDoctorsRepository doctorsRepository;

        public DoctorQueriesHandler(IDoctorsRepository doctorsRepository)
        {
            this.doctorsRepository = doctorsRepository;
        }
        public async Task<IEnumerable<DoctorsDto>> GetAllAsync()
        {
            return (await doctorsRepository.GetAllAsync()).Select(r => r.Map());
        }
        public IEnumerable<DoctorsDto> GetBySpecType(int SpecType)
        {
            return doctorsRepository.GetBySpecType(SpecType)?.Select(SpecType => SpecType.Map());
        }
    }
}
