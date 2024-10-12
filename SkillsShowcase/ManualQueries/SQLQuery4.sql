CREATE TABLE dbo.NarutoCharacters (
    NarutoCharacterId INT PRIMARY KEY,
    CharacterName NVARCHAR(255),
    ClanBloodline NVARCHAR(255),
    Age INT,
    Village INT
);

CREATE TABLE NarutoCharacterDetails (
    NarutoCharacterId INT PRIMARY KEY,
    Status INT,
    CharacterBio NVARCHAR(MAX),
    KillCount INT,
    CONSTRAINT FK_NarutoCharacter FOREIGN KEY (NarutoCharacterId) 
    REFERENCES NarutoCharacters(NarutoCharacterId)
);

INSERT INTO dbo.NarutoCharacters (NarutoCharacterId, CharacterName, ClanBloodline, Age, Village) VALUES
(1, 'Naruto Uzumaki', 'Uzumaki', 35, 1),
(2, 'Sasuke Uchiha', 'Uchiha', 36, 1),
(3, 'Sakura Haruno', 'None', 33, 1),
(4, 'Kakashi Hatake', 'Hatake', 50, 1),
(5, 'Minato Namikaze', 'None', 34, 1),
(6, 'Madara Uchiha', 'Uchiha', 41, 1),
(7, 'Jiraiya', 'None', 55, 1),
(8, 'Onoki', 'None', 93, 5),
(9, 'Zabuza Momochi', 'None', 29, 3),
(10, 'Killer Bee', 'None', 47, 4),
(11, 'Gaara', 'None', 37, 2),
(12, 'Pain', 'None', 40, 6),
(13, 'Orochimaru', 'None', 79, 7),
(14, 'Kurama', 'None', 200, 1);

INSERT INTO dbo.NarutoCharacterDetails (NarutoCharacterId, Status, CharacterBio, KillCount) VALUES
(1, 1, 'Naruto Uzumaki is the main character of the Naruto series. He is a ninja from the Hidden Leaf Village and current Hokage.', 50),
(2, 4, 'Sasuke Uchiha is a rogue ninja from the Hidden Leaf Village. He is a former member of Team 7 and is known for his Sharingan.', 100),
(3, 2, 'Sakura Haruno is a ninja from the Hidden Leaf Village. She is a medical ninja and a member of Team 7.', 10),
(4, 1, 'Kakashi Hatake is a former Hokage of the Hidden Leaf Village. He is known as the Copy Ninja.', 200),
(5, 1, 'Minato Namikaze is the Fourth Hokage of the Hidden Leaf Village. He is known as the Yellow Flash.', 300),
(6, 4, 'Madara Uchiha is a rogue ninja from the Hidden Leaf Village. He is known as the founder of the Uchiha clan.', 1000),
(7, 3, 'Jiraiya is one of the Legendary Sannin of the Hidden Leaf Village. He is known as the Toad Sage.', 500),
(8, 7, 'Onoki is the Third Tsuchikage of the Hidden Stone Village. He is known as the Dust Release user.', 400),
(9, 2, 'Zabuza Momochi is a rogue ninja from the Hidden Mist Village. He is known as the Demon of the Hidden Mist.', 300),
(10, 9, 'Killer Bee is the Eight Tails Jinchuriki of the Hidden Cloud Village. He is known as the Eight Tails Host.', 200),
(11, 6, 'Gaara is the Fifth Kazekage of the Hidden Sand Village. He is known as the One-Tail Jinchuriki.', 150),
(12, 4, 'Pain is the leader of the Akatsuki organization. He is known as the Deva Path.', 900),
(13, 3, 'Orochimaru is a rogue ninja from the Hidden Sound Village. He is known as the Snake Sannin.', 700),
(14, 9, 'Kurama is the Nine Tails Bijuu of the Hidden Leaf Village. He is known as the Nine Tails Fox.', 5000);