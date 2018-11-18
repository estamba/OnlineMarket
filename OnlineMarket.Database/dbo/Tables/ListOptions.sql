CREATE TABLE [dbo].[ListOptions] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [OptionName] NVARCHAR (250) NOT NULL,
    [ListId]     INT            NOT NULL,
    [IsEnabled]  BIT            NOT NULL,
    [IsDeleted]  BIT            NOT NULL,
    CONSTRAINT [PK_ListOptions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ListOptions_ListAttributes] FOREIGN KEY ([ListId]) REFERENCES [dbo].[ListAttributes] ([Id])
);

