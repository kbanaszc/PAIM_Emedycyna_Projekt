namespace ExaminationRoomsSelector.Web.Application.Queries
{
    using ExaminationRoomsSelector.Web.Application.DataServiceClients;
    using ExaminationRoomsSelector.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ExaminationRoomsSelectorQueryHandler : IExaminationRoomsSelectorHandler
    {
        private readonly IExaminationRoomsServiceClient examinationRoomsServiceClient;
        private readonly IDoctorsServiceClient doctorsServiceClient;

        public ExaminationRoomsSelectorQueryHandler()
        {

        }

        public ExaminationRoomsSelectorQueryHandler(IExaminationRoomsServiceClient examinationRoomsServiceClient, IDoctorsServiceClient doctorsServiceClient)
        {
            this.examinationRoomsServiceClient = examinationRoomsServiceClient;
            this.doctorsServiceClient = doctorsServiceClient;
        }


        public List<List<string>> GetExaminationRoomsSelection()
        {
            IEnumerable<ExaminationRoomDto> rooms = GetExaminatiomRoomsDtoAsync().Result;
            IEnumerable<DoctorsDto> doctors = GetDoctorsDtoAsync().Result;
            List<List<string>> DoctorsSpecjalizationsList = GetAllDoctors(doctors);
            List<List<string>> RoomsCertifcationsList = GetAllExaminationRooms(rooms);
            List<List<string>> result = Logic(RoomsCertifcationsList, DoctorsSpecjalizationsList);
            return result;
        }


        public async Task<IEnumerable<ExaminationRoomDto>> GetExaminatiomRoomsDtoAsync()
        {
            IEnumerable<ExaminationRoomDto> rooms = await examinationRoomsServiceClient.GetAllExaminationRoomsAsync();
            return rooms;
        }

        public async Task<IEnumerable<DoctorsDto>> GetDoctorsDtoAsync()
        {
            IEnumerable<DoctorsDto> doctors = await doctorsServiceClient.GetAllDoctorsAsync();
            return doctors;
        }
        public List<List<string>> GetAllExaminationRooms(IEnumerable<ExaminationRoomDto> rooms)
        {

            List<List<string>> RoomsCertifcationsList = new();

            int x = rooms.Count();
            for (int i = 0; i < x; i++)
            {
                IEnumerable<string> certs = rooms.ElementAt(i).Certifications;
                RoomsCertifcationsList.Add(certs.ToList());
            }
            return RoomsCertifcationsList;
        }

        public List<List<string>> GetAllDoctors(IEnumerable<DoctorsDto> doctors)
        {
            List<List<string>> DoctorsSpecjalizationsList = new();

            int x = doctors.Count();
            for (int i = 0; i < x; i++)
            {
                IEnumerable<string> doc = doctors.ElementAt(i).Specjalizations;
                DoctorsSpecjalizationsList.Add(doc.ToList());
            }
            return DoctorsSpecjalizationsList;
        }


        public List<List<string>> Logic(List<List<string>> RoomsCertifcationsList, List<List<string>> DoctorsSpecjalizationsList)
        {

            int indexDoctor = 0;
            int indexRoom = 1;
            List<List<string>> whereCanDocGo = new();

            foreach (List<string> docSpec in DoctorsSpecjalizationsList)
            {
                List<string> tempList = new();
                indexRoom = 1;
                tempList.Add(indexDoctor.ToString() + "d");
                foreach (List<string> cerInRoom in RoomsCertifcationsList)
                {

                    foreach (string singleSpec in docSpec)
                    {

                        if (cerInRoom.Contains(singleSpec))
                        {
                            if (tempList.Contains(indexRoom.ToString()))
                            {
                                continue;
                            }
                            else
                            {
                                tempList.Add(indexRoom.ToString());
                            }
                        }

                    }
                    indexRoom++;
                }
                whereCanDocGo.Add(tempList);
                indexDoctor++;
                List<string> temp;
                for (int i = 0; i < indexDoctor - 1; i++)
                {
                    for (int j = 0; j < indexDoctor - 1 - i; j++)
                    {
                        if (whereCanDocGo[j].Count > whereCanDocGo[j + 1].Count)
                        {
                            temp = whereCanDocGo[j + 1];
                            whereCanDocGo[j + 1] = whereCanDocGo[j];
                            whereCanDocGo[j] = temp;
                        }
                    }
                }
            }

            List<List<string>> docInRoom = new();
            List<string> takenRooms = new();

            for (int iii = 0; iii < whereCanDocGo.Count; iii++)
            {
                List<string> DocRoomsCopy = whereCanDocGo[iii];

                List<string> l = new();
                int flag = 0;
                for (int i = 1; i < DocRoomsCopy.Count; i++)
                {
                    string roomm = DocRoomsCopy.ElementAt(i);

                    if (takenRooms.Contains(roomm) == false && flag == 0)
                    {
                        flag = 1;
                        string docId = DocRoomsCopy.ElementAt(0).Trim('d');
                        takenRooms.Add(roomm);
                        int docIdInt = (Int32.Parse(docId) + 1);
                        l.Add((docIdInt.ToString()).ToString());
                        l.Add(roomm);

                        System.Diagnostics.Debug.WriteLine(l);

                        whereCanDocGo.Remove(DocRoomsCopy);
                    }

                }
                if (l.Count != 0)
                {
                    docInRoom.Add(l);
                }
            }

            //List<string> awailableRooms = new();
            //for (int n = 1; n < RoomsCertifcationsList.Count(); n++)
            //{
            //    if (takenRooms.Contains(n.ToString()) == false)
            //    {
            //        awailableRooms.Add(n.ToString());
            //    }
            //}


            //for (int i = 0; i < whereCanDocGo.Count; i++)
            //{
            //    List<string> l = new();
            //    string docId = whereCanDocGo[i].ElementAt(0).Trim('d');
            //    int docIdInt = (Int32.Parse(docId) + 1);
            //    l.Add(docIdInt.ToString());
            //    l.Add(awailableRooms[0]);
            //    awailableRooms.Remove(awailableRooms.ElementAt(0));
            //    docInRoom.Add(l);
            //}


            return docInRoom;
        }
    }
}
