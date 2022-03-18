Use Pizzeria
Go

CREATE PROC Login_Employee
@Username	varchar(50),
@Password	varchar(50)
AS
BEGIN
SELECT * FROM Employee WHERE Username = @Username and Password = @Password 
END