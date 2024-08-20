CREATE PROCEDURE AddInstrument
    @Id NVARCHAR(50),
    @Name NVARCHAR(100),
    @Type NVARCHAR(100),
    @Price NVARCHAR(50)  
AS
BEGIN
    INSERT INTO Instruments (Id, Name, Type, Price)
    VALUES (@Id, @Name, @Type, @Price);
END
