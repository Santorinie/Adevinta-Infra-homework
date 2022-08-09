# KÖNYVTÁR

###### Használt technológiák:
- Backend: ASP.NET, Docker, Nginx
- Adatbázis: MySQL

###### Használat:
Klónozd a repot: `git clone https://github.com/Santorinie/Adevinta-Infra-homework`

Nyisd meg a mappát: **`cd ./Adevinta-Infra-homework`**

A mappában található **docker-compose.yml** fájl segítségével az indítás pofonegyszerű: `docker-compose up --build`
> Megjegyzés: Alapból az 5000-es portra van mapolva az API, amennyiben ez a port nem szabad a docker-compose.yml fájlban lehetőség van ennek a megváltoztatására.

Health check az API-on: `/health` routeon kereszült lehetséges.
