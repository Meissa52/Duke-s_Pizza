CREATE PROC Add_Customer
@Username varchar(50),
@Password varchar(50),
@Fullname varchar(50),
@Phone varchar(50)
AS 
BEGIN
	INSERT INTO Customer(Username,Password,Fullname,Phone)
	VALUES (@Username,@Password,@Fullname,@Phone)
END