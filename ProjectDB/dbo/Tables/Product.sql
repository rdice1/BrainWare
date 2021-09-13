CREATE TABLE [dbo].[Product] (
    [product_id] INT             NOT NULL,
    [name]       NVARCHAR (128)  NOT NULL,
    [price]      DECIMAL (18, 2) NULL,
    PRIMARY KEY CLUSTERED ([product_id] ASC)
);

