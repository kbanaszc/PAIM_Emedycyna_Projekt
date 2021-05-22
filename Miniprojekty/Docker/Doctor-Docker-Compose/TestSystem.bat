
curl -X GET "http://localhost:8080/GetVisits?doctorId=2" -H "accept: application/json"

curl -X GET "http://localhost:8080/GetPrescriptions?pesel=00000000001" -H  "accept: text/plain"

curl -X POST "http://localhost:8080/AddPrescription" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"id\":1001,\"patientId\":101,\"doctorId\":101,\"expiryDate\":\"25.09.2021\",\"medicines\":[{\"id\":1,\"name\":\"test\"}]}"

pause
