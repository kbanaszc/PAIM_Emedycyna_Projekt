using ExaminationRoomsSelector.Web.Application.Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationRoomsSelector.Web.Application.Queries;
using ExaminationRoomsSelector.Web.Application.DataServiceClients;

namespace ExaminationRoomsSelector.Test
{
    [TestClass]
    public class InputTests
    {

        ///////////////////////////////////// Testing objects data
        public IEnumerable<DoctorsDto> TestDoctorDtoObject()
        {
            DoctorsDto testDoctorDtoObject = new DoctorsDto();
            testDoctorDtoObject.Name = "Doktorek";
            testDoctorDtoObject.Specjalizations = new string[] { "1", "2", "3" };
            List<DoctorsDto> result = new() { testDoctorDtoObject };
            return result;
        }
        public IEnumerable<ExaminationRoomDto> TestExaminationRoomDtoObject()
        {
            ExaminationRoomDto testExaminationRoomDtoObject = new();
            testExaminationRoomDtoObject.Number = "101c";
            testExaminationRoomDtoObject.Certifications = new string[] { "1", "2", "3" };
            List<ExaminationRoomDto> result = new() { testExaminationRoomDtoObject };
            return result;
        }

        ////////////////////////////////// Testing objects

        public List<List<string>> TestingDoctor()
        {
            ExaminationRoomsSelectorQueryHandler e = new();

            var testDoctor = TestDoctorDtoObject();

            return e.GetAllDoctors(testDoctor);
        }

        public List<List<string>> TestingExaminationRoom()
        {
            ExaminationRoomsSelectorQueryHandler e = new();

            var testExaminationRoom = TestExaminationRoomDtoObject();

            return e.GetAllExaminationRooms(testExaminationRoom);
        }
        /// ////////////////// Tests Doctor

        [TestMethod]
        public void IsGetAllDoctorsNotNull()
        {
            List<List<string>> result = TestingDoctor();

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void IsGetAllDoctorsNotEmpty()
        {
            List<List<string>> result = TestingDoctor();

            bool isAny = true;

            if (result.Count == 0) isAny = false;

            Assert.IsTrue(isAny);
        }

        [TestMethod]
        public void IsDoctorsSpecListString()
        {
            List<List<string>> result = TestingDoctor();
            Assert.IsInstanceOfType(result, typeof(List<List<string>>));
        }

        [TestMethod]
        public void IsGetAllDoctorsSpecNotEmpty()
        {
            List<List<string>> result = TestingDoctor();

            bool isAny = true;

            if (result.ElementAt(0).Count == 0) isAny = false;

            Assert.IsTrue(isAny);
        }

        [TestMethod]
        public void IsGetAllDoctorsSpecNotNull()
        {
            List<List<string>> result = TestingDoctor();

            Assert.IsNotNull(result.ElementAt(0));
        }

        /// ////////////////// Tests ExaminationRooms
        [TestMethod]
        public void IsGetAllExaminationRoomsNotNull()
        {
            List<List<string>> result = TestingExaminationRoom();

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void IsGetAllExaminationRoomsNotEmpty()
        {
            List<List<string>> result = TestingExaminationRoom();

            bool isAny = true;

            if (result.Count == 0) isAny = false;

            Assert.IsTrue(isAny);
        }

        [TestMethod]
        public void IsExaminationRoomsCertificateListString()
        {
            List<List<string>> result = TestingExaminationRoom();
            Assert.IsInstanceOfType(result, typeof(List<List<string>>));
        }

        [TestMethod]
        public void IsGetAllExaminationRoomsCertificateNotEmpty()
        {
            List<List<string>> result = TestingExaminationRoom();

            bool isAny = true;

            if (result.ElementAt(0).Count == 0) isAny = false;

            Assert.IsTrue(isAny);
        }

        [TestMethod]
        public void IsGetAllExaminationRoomsCertificateNotNull()
        {
            List<List<string>> result = TestingExaminationRoom();

            Assert.IsNotNull(result.ElementAt(0));
        }

    }
}
