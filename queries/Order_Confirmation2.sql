create proc Order_Confirmation2
@OrderID int
as
begin
	select *
	from Pizza
	inner join OrderInfo
	ON OrderInfo.OrderID = Pizza.OrderID
	Where Pizza.OrderID = @OrderID
end