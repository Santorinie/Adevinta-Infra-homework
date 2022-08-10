# KÖNYVTÁR

###### Használt technológiák:
- Backend: ASP.NET, Docker, Nginx
- ORM: Entity Framework
- Adatbázis: MySQL

###### Használat:
Klónozd a repot: `git clone https://github.com/Santorinie/Adevinta-Infra-homework`

Nyisd meg a mappát: **`cd ./Adevinta-Infra-homework`**

A mappában található **docker-compose.yml** fájl segítségével az indítás pofonegyszerű: `docker-compose up --build`
> Megjegyzés: Alapból az 5000-es portra van mapolva az API, amennyiben ez a port nem szabad a docker-compose.yml fájlban lehetőség van ennek a megváltoztatására.

###### API endpointok:

Health check az API-on: `/health` routeon kereszült lehetséges.

Kölcsönzési adatok lekérése ID alapján: `v1/book/{id}`

Új kölcsönzési adat hozzáadása: `v1/book/add`
A request bodyjába kerüljön JSON formátumban ez a kód:
```json
{
    "BorrowerName": "Tehenes Zalán",
    "BorrowedBook":{
        "Title": "A hobbit",
        "Author": "Tolkien"
    }
}
```
*A backend automatikusan hozzáilleszti a kölcsönzés időpontját az recordhoz és egy guid-t a könyvhöz (Mivel két azonos című könyv létezik, de két azonos könyv nem létezik)*

###### Jelenlegi állapot:

1. Feladat: Az adatokat JSON-ban tároltam a backenden.

2. Feladat: A második feladat leírása szerint létrehoztam **Dockeren** egy MySQL imaget és összekötöttem a backenden elhelyezett **Entity Framework** ORM-el. Ezen kereszült kommunikál a backend az adatbázissal.
