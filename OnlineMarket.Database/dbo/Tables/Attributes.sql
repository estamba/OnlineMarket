CREATE TABLE [dbo].[Attributes] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (100) NULL,
    CONSTRAINT [PK_Attributes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

