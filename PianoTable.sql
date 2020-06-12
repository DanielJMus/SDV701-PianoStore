CREATE TABLE [dbo].[piano] (
    [listingID] INT IDENTITY (1, 1) NOT NULL,
    [name]        VARCHAR (255)  NOT NULL,
    [description] VARCHAR (1000) NULL,
    [finish] VARCHAR (50) NULL,
    [stand] VARCHAR (50) NULL,
    [price] DECIMAL (18)   NOT NULL,
    [keys] INT NOT NULL,
    [voices] INT NULL,
    [instock] BIT NOT NULL,
	[type] VARCHAR (20) NOT NULL,
	[style] VARCHAR (50) NULL,
    [dateModified] DATETIME NOT NULL,
    [manufacturerID] VARCHAR(255) NOT NULL,
    PRIMARY KEY CLUSTERED ([listingID] ASC),
    CONSTRAINT [FK_MANUFACTURER] FOREIGN KEY ([manufacturerID]) REFERENCES [dbo].[manufacturer] ([manufacturerID]) ON DELETE CASCADE
);