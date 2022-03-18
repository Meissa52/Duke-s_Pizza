create proc Order_Confirmation1
@OrderID int
as
begin
	select *
	from OrderInfo
	Where OrderID = @OrderID
end