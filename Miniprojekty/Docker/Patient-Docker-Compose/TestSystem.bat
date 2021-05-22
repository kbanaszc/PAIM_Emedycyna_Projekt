curl -X GET "http://localhost:8080/GetAllPrescriptions?patientId=2" -H  "accept: text/plain"

curl -X GET "http://localhost:8080/GetAllVisits?patientId=2" -H  "accept: text/plain"

curl -X GET "http://localhost:8080/GetPatientId?pesel=00000000002" -H "accept: text/plain"

curl -X POST "http://localhost:8080/AddVisit" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"patientId\":2,\"problem\":\"Neurologia\",\"date\":\"15.05.2021\"}"

curl -X GET "http://localhost:8080/GetAllVisits?patientId=2" -H  "accept: text/plain"

pause
