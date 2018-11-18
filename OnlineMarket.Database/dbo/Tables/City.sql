CREATE TABLE [dbo].[City] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (500) NULL,
    [IsEnabled] BIT            NOT NULL,
    CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED ([ID] ASC)
);

