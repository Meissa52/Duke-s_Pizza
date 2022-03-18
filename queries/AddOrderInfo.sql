Use Pizzeria
go

CREATE PROC AddOrderInfo
@OrderMethod varchar(30),
@Date date,
@Time varchar(50),
@Street varchar(100),
@City varchar(30),
@State varchar(4),
@Zip int
AS 
BEGIN
	INSERT INTO OrderInfo(OrderMethod,Date,Time,Street,City,State,Zip)
	VALUES (@OrderMethod,@Date,@Time,@Street,@City,@State,@Zip)
END