CREATE PROC UpdatePizzaInfo
@PizzaID int,
@Size varchar(30),
@Cheese tinyint,
@Blackolives tinyint,
@Bacon tinyint,
@Greenpeppers tinyint,
@Pinapple tinyint,
@Mushroom tinyint,
@Spinach tinyint,
@Onions tinyint,
@Shrimp tinyint,
@Sausages tinyint,
@Chicken tinyint,
@Price money
AS 
BEGIN
	update Pizza set 
		Size = @Size,
		Cheese = @Cheese,
		BlackOlives = @Blackolives,
		Bacon = @Bacon,
		Greenpeppers = @Greenpeppers,
		Pineapple = @Pinapple,
		Mushroom = @Mushroom,
		Spinatch = @Spinach,
		Onions = @Onions,
		Shrimp = @Shrimp,
		Sausages  =@Sausages,
		Chicken = @Chicken,
		Price = @Price
	where PizzaID = @PizzaID
End