use Pizzeria
go

create proc DeleteEntirePizzaInfo
@OrderID int
as
begin
	delete from Pizza where OrderID = @OrderID
end