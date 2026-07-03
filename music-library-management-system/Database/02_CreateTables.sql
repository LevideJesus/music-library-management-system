USE music_library;

CREATE TABLE Artists
(
Id INT AUTO_INCREMENT PRIMARY KEY,
Name VARCHAR(100),
DateOfBirth DATE,
Country VARCHAR(50),
Biography LONGTEXT

);