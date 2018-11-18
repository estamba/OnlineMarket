CREATE TABLE [dbo].[ItemAttributes] (
    [ItemId]         INT            NOT NULL,
    [AttributeId]    INT            NOT NULL,
    [AttributeValue] NVARCHAR (250) NOT NULL,
    CONSTRAINT [PK_ItemAttributes] PRIMARY KEY CLUSTERED ([ItemId] ASC, [AttributeId] ASC),
    CONSTRAINT [FK_ItemAttributes_CategoryAttributes] FOREIGN KEY ([AttributeId]) REFERENCES [dbo].[CategoryAttributes] ([Id]),
    CONSTRAINT [FK_ItemAttributes_Item] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Item] ([Id])
);

