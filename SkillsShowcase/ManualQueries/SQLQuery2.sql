CREATE TABLE dbo.MarvelVillains (
    MarvelVillainId INT PRIMARY KEY,
    VillainName INT,
    VillainConfirmedKills INT
);

INSERT INTO MarvelVillains (MarvelVillainId, VillainName, VillainConfirmedKills)
VALUES
    (1, 1, 1053),
    (2, 2, 850),
    (3, 3, 6021),
    (4, 4, 2022),
    (5, 5, 721);