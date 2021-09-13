CREATE TABLE [dbo].[orderproduct] (
    [order_id]   INT             NOT NULL,
    [product_id] INT             NOT NULL,
    [price]      DECIMAL (18, 2) NULL,
    [quantity]   INT             NOT NULL,
    CONSTRAINT [PK_orderproduct] PRIMARY KEY CLUSTERED ([order_id] ASC, [product_id] ASC),
    CONSTRAINT [FK_orderproduct_order] FOREIGN KEY ([order_id]) REFERENCES [dbo].[Order] ([order_id]),
    CONSTRAINT [FK_orderproduct_product] FOREIGN KEY ([product_id]) REFERENCES [dbo].[Product] ([product_id])
);

