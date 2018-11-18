CREATE TABLE [dbo].[ListAttributes] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [ListName] NVARCHAR (250) NOT NULL,
    [Comment]  NVARCHAR (250) NULL,
    CONSTRAINT [PK_ListAttributes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

