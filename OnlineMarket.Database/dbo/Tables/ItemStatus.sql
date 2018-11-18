CREATE TABLE [dbo].[ItemStatus] (
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (100) NULL,
    CONSTRAINT [PK_ItemStatus] PRIMARY KEY CLUSTERED ([Name] ASC)
);

