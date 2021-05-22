using ExaminationRoomsSelector.Web.Application.DataServiceClients;
using ExaminationRoomsSelector.Web.Application.Dtos;
using ExaminationRoomsSelector.Web.Application.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExaminationRoomsSelector.Test
{
    [TestClass]
    public class RationalExecutionTimeTest
    {

        public List<DoctorsDto> TestDoctorsList()
        {
            List<DoctorsDto> doctorsDtoForTestList = new();
            for (int i = 0; i < 59; i++)
            {
                int y = i % 14;
                var newDocDto = new DoctorsDto("Oetker" + i.ToString(), new string[] { y.ToString() });
                doctorsDtoForTestList.Add(newDocDto);
            }
            return doctorsDtoForTestList;

        }

        public List<ExaminationRoomDto> TestExaminationRoomList()
        {
            List<ExaminationRoomDto> examinationRoomDtoForTestList = new();
            for (int i = 0; i < 60; i++)
            {
                int y = i % 14;
                var newRoomDto = new ExaminationRoomDto("ExaminationRoom " + i.ToString(), new string[] { y.ToString() });
                examinationRoomDtoForTestList.Add(newRoomDto);
            }
            return examinationRoomDtoForTestList;
        }

        [TestMethod]
        [Timeout(10)]
        public void CheckIfProgramMatchesRoomsWithDoctors()
        {
            ExaminationRoomsSelectorQueryHandler e = new();
            List<List<string>> DoctorsSpecjalizationsList = e.GetAllDoctors(TestDoctorsList());
            List<List<string>> RoomsCertifcationsList = e.GetAllExaminationRooms(TestExaminationRoomList());
            List<List<string>> result = e.Logic(RoomsCertifcationsList, DoctorsSpecjalizationsList);

        }
    }
}
