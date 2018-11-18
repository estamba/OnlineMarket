CREATE TABLE [dbo].[Category] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50) NULL,
    [ParentId] INT           NULL,
    [IsActive] BIT           CONSTRAINT [DF_Category_isActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([Id] ASC)
);

