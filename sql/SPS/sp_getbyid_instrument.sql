CREATE PROCEDURE GetInstrumentById
    @Id NVARCHAR(50)
AS
BEGIN
    SELECT Id, Name, Type, Price
    FROM Instruments
    WHERE Id = @Id;
END
