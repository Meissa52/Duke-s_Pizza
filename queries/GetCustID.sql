Use Pizzeria
GO

CREATE PROC GetCustomerID
@Username varchar(50)
AS
BEGIN
SELECT CustomerID FROM Customer WHERE Username = @Username
END