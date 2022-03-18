use Pizzeria
go

create proc DeleteOrderInfo
@OrderID int
as
begin
	delete from OrderInfo where OrderID = @OrderID
end