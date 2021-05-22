namespace DoctorsWebApp.Controllers
{
    using DoctorsWebApp.Application.Commands;
    using DoctorsWebApp.Application.Dtos;
    using DoctorsWebApp.Application.Queries;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly ILogger<DoctorsController> logger;
        private readonly IDoctorQueriesHandler doctorQueriesHandler;
        private readonly ICommandHandler<AddDoctorCommand> addDoctorCommandHandler;

        public DoctorsController(ILogger<DoctorsController> logger, IDoctorQueriesHandler doctorQueriesHandler, ICommandHandler<AddDoctorCommand> addDoctorCommandHandler)
        {
            this.logger = logger;
            this.doctorQueriesHandler = doctorQueriesHandler;
            this.addDoctorCommandHandler = addDoctorCommandHandler;
        }

        [HttpGet("doctors-all")]
        public async Task<IEnumerable<DoctorsDto>> GetAllAsync()
        {
            return await doctorQueriesHandler.GetAllAsync();
        }

        [HttpGet("doctors-find")]
        public IEnumerable<DoctorsDto> GetBySpecName([FromQuery] int specType)
        {
            return doctorQueriesHandler.GetBySpecType(specType);
        }

        [HttpPost("doctor-add")]
        public void AddDoctor([FromBody] AddDoctorCommand doctorCommand)
        {
            addDoctorCommandHandler.Handle(doctorCommand);
        }
    }
}
