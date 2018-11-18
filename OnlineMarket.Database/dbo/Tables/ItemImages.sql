CREATE TABLE [dbo].[ItemImages] (
    [ItemId]  INT              NOT NULL,
    [ImageId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_ItemImages] PRIMARY KEY CLUSTERED ([ItemId] ASC, [ImageId] ASC),
    CONSTRAINT [FK_ItemImages_Documents] FOREIGN KEY ([ImageId]) REFERENCES [dbo].[Documents] ([Id]),
    CONSTRAINT [FK_ItemImages_Item] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Item] ([Id])
);

