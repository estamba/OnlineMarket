CREATE TABLE [dbo].[Location] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [CityId]  INT            NULL,
    [Address] NVARCHAR (MAX) NULL,
    [Name]    NVARCHAR (250) NOT NULL,
    CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Location_City] FOREIGN KEY ([CityId]) REFERENCES [dbo].[City] ([ID])
);

