DROP DATABASE IF EXISTS game_db;
create database game_db;
use game_db;

CREATE TABLE `GameResults` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) NOT NULL,
  `BestTime` double NOT NULL,
  PRIMARY KEY (`Id`)
);
INSERT INTO `GameResults` (`Username`, `BestTime`) VALUES
('Jason', 99),
('Alex', 99),
('Daimon', 99),
('Lewis', 99),
('Asher', 99);