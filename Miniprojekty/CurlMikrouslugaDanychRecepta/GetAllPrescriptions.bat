@echo off

echo Pobranie wszystkich recept:
curl -X GET "https://localhost:44309/GetAllPrescriptions" -H  "accept: text/plain"
echo. 
echo.

echo Pobranie recepty pacjenta o ID "1"
curl -X GET "https://localhost:44309/GetPrescription?patientId=1" -H  "accept: text/plain"
echo.
echo.

echo Dodanie recepty:
curl -X POST "https://localhost:44309/AddPrescription" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"id\":66,\"patientId\":23,\"doctorId\":32,\"givenAt\":\"01.01.2021\",\"expiryDate\":\"03.03.2021\",\"medicines\":[{\"id\":2,\"name\":\"Apap\"},{\"id\":4,\"name\":\"Ibum\"}]}"

pause