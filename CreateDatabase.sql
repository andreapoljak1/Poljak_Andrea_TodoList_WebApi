Create database MVCToDoList;


USE [MVCToDoList]
GO

CREATE TABLE TodoList (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(100) NOT NULL,
    Description VARCHAR(MAX),
	IsComplited BIT DEFAULT 0 NOT NULL
);
