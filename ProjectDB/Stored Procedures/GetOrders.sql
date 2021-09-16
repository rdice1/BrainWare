

CREATE PROCEDURE [dbo].[GetOrders]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
		o.order_id AS OrderId
		,o.description AS Description
		,o.company_id AS CompanyId
		,p.product_id AS ProductId
		,p.name AS ProductName
		,p.price AS Price
		,c.name AS CompanyName
	FROM [Order] o
	LEFT JOIN orderproduct op ON o.order_id = op.order_id
	LEFT JOIN Product p ON op.product_id = p.product_id
	LEFT JOIN Company c ON o.company_id = o.company_id

END
GO

