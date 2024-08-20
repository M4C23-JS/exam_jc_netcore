CREATE TABLE Instruments (
    Id NVARCHAR(50) PRIMARY KEY,
    Name NVARCHAR(100) ,
    Type NVARCHAR(100) ,
    Price NVARCHAR(50) ,
	IsDeleted BIT DEFAULT 0  -- Cambiado a NVARCHAR
);
