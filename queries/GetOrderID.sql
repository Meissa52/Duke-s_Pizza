use Pizzeria
GO

create proc GetOrderID
as
begin
select max(OrderId) from OrderInfo
end

