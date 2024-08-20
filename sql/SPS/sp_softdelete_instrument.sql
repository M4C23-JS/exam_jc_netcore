CREATE PROCEDURE GetInstrumentById
    @Id NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Name, Type, Price
    FROM Instruments
    WHERE Id = @Id;
END
