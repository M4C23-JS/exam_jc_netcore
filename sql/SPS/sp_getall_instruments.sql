CREATE PROCEDURE GetAllInstruments
AS
BEGIN
    SELECT Id, Name, Type, Price
    FROM Instruments;
END
