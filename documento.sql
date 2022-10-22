CREATE TABLE `documento` (
  `Id` int unsigned NOT NULL AUTO_INCREMENT,
  `Codigo` varchar(45) NOT NULL,
  `Titulo` varchar(45) NOT NULL,
  `Revisao` char(1) NOT NULL,
  `DataPlanejada` date NOT NULL,
  `Valor` decimal(15,2) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
