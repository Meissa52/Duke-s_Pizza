use Pizzeria
GO

create proc GetPizzaID
as
begin
select max(PizzaID) from Pizza
end