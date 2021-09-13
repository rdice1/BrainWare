CREATE TABLE [dbo].[Order] (
    [order_id]    INT             IDENTITY (1, 1) NOT NULL,
    [description] NVARCHAR (1000) NOT NULL,
    [company_id]  INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([order_id] ASC),
    CONSTRAINT [FK_order_to_company] FOREIGN KEY ([company_id]) REFERENCES [dbo].[Company] ([company_id])
);

