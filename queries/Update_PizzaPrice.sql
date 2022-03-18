create proc Update_PizzaPrice
@PizzaID int,
@Price money
as

begin
	Update Pizza
	SET Price = @Price
	WHERE PizzaID = @PizzaID
end