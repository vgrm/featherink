CREATE DATABASE IF NOT EXISTS `featherink`;

DROP TABLE IF EXISTS User;
DROP TABLE IF EXISTS Art;
DROP TABLE IF EXISTS Comment;
DROP TABLE IF EXISTS Task;
DROP TABLE IF EXISTS Designer;

CREATE TABLE User
(
	Id INT AUTO_INCREMENT PRIMARY KEY,
	Role varchar (255),
	Username varchar (255),
	Password varchar (255),
	Email varchar (255),
	Photo varchar (255)
);

CREATE TABLE Designer
(
	Id INT AUTO_INCREMENT PRIMARY KEY,
	Description varchar (255),
	Rating integer,
	UserId integer NOT NULL,
	UNIQUE(UserId),
	FOREIGN KEY(UserId) REFERENCES User (Id)
);

CREATE TABLE Art
(
	Id INT AUTO_INCREMENT PRIMARY KEY,
	FilePath varchar (255),
	Name varchar (255),
	Description varchar (255),
	DesignerId integer NOT NULL,
	CONSTRAINT uploaded FOREIGN KEY(DesignerId) REFERENCES Designer (Id)
);

CREATE TABLE Comment
(
	Id INT AUTO_INCREMENT PRIMARY KEY,
	Rating integer,
	Comment varchar (255),
	UserId integer NOT NULL,
	DesignerId integer NOT NULL,
	CONSTRAINT writes FOREIGN KEY(UserId) REFERENCES User (Id),
	CONSTRAINT has FOREIGN KEY(DesignerId) REFERENCES Designer (Id)
);

CREATE TABLE Task
(
	Id INT AUTO_INCREMENT PRIMARY KEY,
	Name varchar (255),
	Description varchar (255),
	DesignerId integer NOT NULL,
	UserId integer NOT NULL,
	CONSTRAINT accepts FOREIGN KEY(DesignerId) REFERENCES Designer (Id),
	CONSTRAINT places FOREIGN KEY(UserId) REFERENCES User (Id)
);
