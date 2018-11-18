CREATE TABLE [dbo].[AttributeValueTypes] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Type] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_CategoryAttributesTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

