Use Pizzeria
Go

CREATE PROC Login_Customer
@Username	varchar(50),
@Password	varchar(50)
AS
BEGIN
SELECT * FROM Customer WHERE Username = @Username and Password = @Password 
END