use Pizzeria
go

create proc DeleteOnePizzaInfo
@PizzaID int
as
begin
	delete from Pizza where PizzaID = @PizzaID
end