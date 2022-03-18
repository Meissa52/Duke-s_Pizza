use Pizzeria
go

Create proc AddOrderItem
@CustomerID int,
@OrderID int,
@Is_delivered tinyint
as
begin
	insert into OrderItem (CustomerID,OrderID,Is_delivered)
	values (@CustomerID, @OrderID, @Is_delivered)
end