CREATE TABLE [dbo].[CategoryAttributes] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (250) NOT NULL,
    [CategoryId]  INT            NOT NULL,
    [ValueType]   INT            NOT NULL,
    [ListId]      INT            NULL,
    [IsMandatory] BIT            NOT NULL,
    [IsEnabled]   BIT            NOT NULL,
    [IsDeleted]   BIT            NOT NULL,
    CONSTRAINT [PK_CategoryAttributes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CategoryAttributes_AttributeValueTypes] FOREIGN KEY ([ValueType]) REFERENCES [dbo].[AttributeValueTypes] ([Id]),
    CONSTRAINT [FK_CategoryAttributes_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id]),
    CONSTRAINT [FK_CategoryAttributes_ListAttributes] FOREIGN KEY ([ListId]) REFERENCES [dbo].[ListAttributes] ([Id])
);

