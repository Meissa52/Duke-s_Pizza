use Pizzeria
go

create proc DeleteOrderItem
@CustomerID int,
@OrderId int
as
begin
	delete from OrderItem where CustomerID = @CustomerID and OrderID = @OrderId
end