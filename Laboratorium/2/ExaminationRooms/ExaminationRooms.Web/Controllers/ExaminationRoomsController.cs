namespace ExaminationRooms.Web.Controllers
{
    using ExaminationRooms.Domain;
    using ExaminationRooms.Domain.ExaminationRoomAggregate;
    using ExaminationRooms.Web.Application;
    using ExaminationRooms.Web.Application.Commands;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    public class ExaminationRoomsController : ControllerBase
    {
        private readonly ILogger<ExaminationRoomsController> logger;
        private readonly IExaminationRoomQueriesHandler examinationRoomQueriesHandler;
        private readonly ICommandHandler<AddExaminationRoomCommand> addExaminationRoomCommandHandler;

        public ExaminationRoomsController(ILogger<ExaminationRoomsController> logger, IExaminationRoomQueriesHandler examinationRoomQueriesHandler, ICommandHandler<AddExaminationRoomCommand> addExaminationRoomCommandHandler)
        {
            this.logger = logger;
            this.examinationRoomQueriesHandler = examinationRoomQueriesHandler;
            this.addExaminationRoomCommandHandler = addExaminationRoomCommandHandler;
    }

        [HttpGet("examination-rooms")]
        public async Task<IEnumerable<ExaminationRoomDto>> GetAllAsync()
        {
            return await examinationRoomQueriesHandler.GetAllAsync();
        }

        [HttpGet("examination-room")]
        public IEnumerable<ExaminationRoomDto> GetBySpecialization([FromQuery] int certificationType)
        {
            return examinationRoomQueriesHandler.GetByCertificationType(certificationType);
        }

        [HttpPost("examination-room")]
        public void AddExaminationRoom([FromBody] AddExaminationRoomCommand examinationRoomCommand)
        {
            addExaminationRoomCommandHandler.Handle(examinationRoomCommand);
        }
    }
}
