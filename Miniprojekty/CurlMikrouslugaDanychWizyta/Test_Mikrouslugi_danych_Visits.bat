@echo off

echo Pobranie wszystkich wizyt:
curl -X "GET" "https://localhost:44346/GetAllVisits" -H "accept: text/plain"
echo. 
echo.

echo Pobranie wizyty dla wybranego lekarza"
curl -X "GET" "https://localhost:44346/GetVisits?doctorId=2" -H "accept: text/plain"
echo.
echo.

echo Dodawanie wizyty..."
curl -X "POST" -H "Content-Type: application/json" -d {"id": 0, "doctorId": 0, "patientId": 0, "problem": "string", "date": "string", "room": "string"}
echo.
echo.

echo Pobranie wszystkich wizyt (Sprawdzenie czy dodała się nowa wizyta):
curl -X "GET" "https://localhost:44346/GetAllVisits" -H "accept: text/plain"
echo. 
echo.

pause