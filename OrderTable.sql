CREATE TABLE [dbo].[orders] (
    [orderID]       INT             IDENTITY (1, 1) NOT NULL,
    [customerName]  VARCHAR (255)   NOT NULL,
    [customerEmail] VARCHAR (255)   NOT NULL,
    [customerPhone] VARCHAR (20)    NOT NULL,
    [purchasePrice] DECIMAL (13, 2) NOT NULL,
    [orderDate]     DATETIME        NOT NULL,
    [listingID]     INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([orderID] ASC),
    CONSTRAINT [FK_PIANO_ID] FOREIGN KEY ([listingID]) REFERENCES [dbo].[piano] ([listingID])
);