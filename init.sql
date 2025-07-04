DROP DATABASE IF EXISTS game_db;
create database game_db;
use game_db;

CREATE TABLE `GameResults` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) NOT NULL,
  `BestTime` double NOT NULL,
  PRIMARY KEY (`Id`)
);

CREATE TABLE Users (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(100) NOT NULL,
    Password VARCHAR(100) NOT NULL,
    IsPaid BOOLEAN NOT NULL
);

INSERT INTO `GameResults` (`Username`, `BestTime`) VALUES
('Jason', 99),
('Alex', 99),
('Daimon', 99),
('Lewis', 99),
('Asher', 99);

INSERT INTO Users (Username, Password, IsPaid) VALUES
('Jason', 'Jason1234', TRUE),
('Alex', 'Alex1234', TRUE),
('Daimon', 'Daimon1234', FALSE),
('Lewis', 'Lewis1234', FALSE),
('Asher', 'Asher1234', FALSE);