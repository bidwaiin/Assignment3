CREATE procedure usp_Customers
@CustId int
as
begin
	Select * from Customers where CustomerID=@CustId
end
