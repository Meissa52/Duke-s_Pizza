Use Pizzeria
go

CREATE PROC OrderFinish
@OrderID int,
@Is_delivered tinyint
AS 
BEGIN
	update OrderItem set 
		Is_delivered = @Is_delivered
	where OrderID = @OrderID
END