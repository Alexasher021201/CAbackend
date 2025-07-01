DROP DATABASE IF EXISTS game_db;
create database game_db

CREATE TABLE `GameResults` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) NOT NULL,
  `BestTime` double NOT NULL,
  PRIMARY KEY (`Id`)
);
