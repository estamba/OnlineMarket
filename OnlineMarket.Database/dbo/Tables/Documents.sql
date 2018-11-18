CREATE TABLE [dbo].[Documents] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (150)   NULL,
    [Extension]   VARCHAR (10)     NOT NULL,
    [ContentType] VARCHAR (150)    NULL,
    [Content]     VARBINARY (MAX)  NULL,
    CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED ([Id] ASC)
);

