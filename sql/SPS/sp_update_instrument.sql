CREATE PROCEDURE EditInstrument
    @Id NVARCHAR(50),
    @Name NVARCHAR(100),
    @Type NVARCHAR(100),
    @Price NVARCHAR(50)  -- Cambiado a NVARCHAR
AS
BEGIN
    UPDATE Instruments
    SET Name = @Name,
        Type = @Type,
        Price = @Price
    WHERE Id = @Id;
END
