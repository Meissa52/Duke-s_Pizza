create proc Order_History_ForEmployee
as
begin
	select OrderInfo.OrderID, Customer.Fullname,OrderInfo.OrderMethod, OrderInfo.Date, OrderInfo.Time,
	OrderInfo.Street, OrderInfo.City,OrderInfo.State,OrderItem.Is_delivered
	from OrderItem
	inner join Customer
	on Customer.CustomerID = OrderItem.CustomerID
	inner join OrderInfo
	on OrderInfo.OrderID = OrderItem.OrderID
end