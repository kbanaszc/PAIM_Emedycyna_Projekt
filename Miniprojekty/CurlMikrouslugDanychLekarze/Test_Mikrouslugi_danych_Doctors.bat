@echo off

echo Pobranie wszystkich lekarzy:
curl -X "GET" "https://localhost:44341/GetAllDoctors" -H "accept: text/plain"
echo. 
echo.

echo Pobranie lekarza o nazwisku "Wysocki"
curl -X "GET" "https://localhost:44341/GetDoctor?lastName=Wysocki" -H "accept: text/plain"
echo.
echo.

pause