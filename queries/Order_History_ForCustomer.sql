create proc Order_History_ForCustomer
@CustomerID int
as
begin
	select OrderInfo.OrderID, OrderInfo.OrderMethod, OrderInfo.Date, OrderInfo.Time,
	OrderInfo.Street, OrderInfo.City,OrderInfo.State
	from OrderItem
	inner join Customer
	on Customer.CustomerID = OrderItem.CustomerID
	inner join OrderInfo
	on OrderInfo.OrderID = OrderItem.OrderID
	where OrderItem.CustomerID = @CustomerID
end