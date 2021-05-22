using ExaminationRoomsSelector.Web.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationRoomsSelector.Web.Controllers
{
    [ApiController]
    public class ExaminationRoomsSelectorController : ControllerBase
    {
        private readonly ILogger<ExaminationRoomsSelectorController> logger;
        private readonly IExaminationRoomsSelectorHandler examinationRoomsSelectorHandler;

        public ExaminationRoomsSelectorController(ILogger<ExaminationRoomsSelectorController> logger, IExaminationRoomsSelectorHandler examinationRoomsSelectorHandler)
        {
            this.logger = logger;
            this.examinationRoomsSelectorHandler = examinationRoomsSelectorHandler;
        }

        [HttpGet("examination-rooms-selection")]
        public List<List<string>> GetExaminationRoomsSelectionAsync()
        {
            return examinationRoomsSelectorHandler.GetExaminationRoomsSelection();
        }
    }
}
