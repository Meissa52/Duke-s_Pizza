Use Pizzeria
go

CREATE PROC UpdateOrderInfo
@OrderID int,
@OrderMethod varchar(30),
@Date date,
@Time varchar(50),
@Street varchar(100),
@City varchar(30),
@State varchar(4),
@Zip int
AS 
BEGIN
	update OrderInfo set 
		OrderMethod = @OrderMethod,
		Date = @Date,
		Time = @Time,
		Street = @Street,
		City = @City,
		State = @State,
		Zip = @Zip
	where OrderID = @OrderID
END