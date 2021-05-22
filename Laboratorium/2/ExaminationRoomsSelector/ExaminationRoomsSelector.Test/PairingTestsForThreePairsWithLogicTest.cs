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
    public class PairingTestsForThreePairsWithLogicTest
    {

        public List<DoctorsDto> TestDoctorsList()
        {
            DoctorsDto newDocDto1 = new DoctorsDto("Oetker1", new string[] { "1" });
            DoctorsDto newDocDto2 = new DoctorsDto("Oetker2", new string[] { "2" });
            DoctorsDto newDocDto3 = new DoctorsDto("Oetker3", new string[] { "3" });
            List<DoctorsDto> result = new() { newDocDto1, newDocDto2, newDocDto3 };

            return result;
        }

        public List<ExaminationRoomDto> TestExaminationRoomList()
        {
            ExaminationRoomDto newExamDto1 = new ExaminationRoomDto("Room1", new string[] { "1" });
            ExaminationRoomDto newExamDto2 = new ExaminationRoomDto("Room2", new string[] { "2" });
            ExaminationRoomDto newExamDto3 = new ExaminationRoomDto("Room3", new string[] { "3" });
            List<ExaminationRoomDto> result = new() { newExamDto1, newExamDto2, newExamDto3 };

            return result;
        }

        [TestMethod]
        public void CheckIfProgramMatchesRoomsWithDoctors()
        {
            ExaminationRoomsSelectorQueryHandler e = new();
            List<List<string>> DoctorsSpecjalizationsList = e.GetAllDoctors(TestDoctorsList());
            List<List<string>> RoomsCertifcationsList = e.GetAllExaminationRooms(TestExaminationRoomList());
            List<List<string>> result = e.Logic(RoomsCertifcationsList, DoctorsSpecjalizationsList);

            int counter = 0;
            for (int i = 0; i < result.Count; i++)
            {
                IEnumerable<string> doctorSpecs = TestDoctorsList().ElementAt(i).Specjalizations;
                IEnumerable<string> examinationRoomCertificates = TestExaminationRoomList().ElementAt(i).Certifications;
                foreach (string spec in doctorSpecs)
                {
                    if (examinationRoomCertificates.Contains(spec))
                    {
                        counter++;
                    }
                }
            }
            Assert.AreEqual(result.Count, counter);
        }


    }

}
