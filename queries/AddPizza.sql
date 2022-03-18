CREATE PROC AddPizza
@OrderID int,
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
	INSERT INTO Pizza(OrderID,Size,Cheese,Blackolives,Bacon,Greenpeppers,Pineapple,Mushroom,Spinatch,Onions,Shrimp,Sausages,Chicken,Price)
	VALUES (@OrderID,@Size,@Cheese,@Blackolives,@Bacon,@Greenpeppers,@Pinapple,@Mushroom,@Spinach,@Onions,@Shrimp,@Sausages,@Chicken,@Price)
END