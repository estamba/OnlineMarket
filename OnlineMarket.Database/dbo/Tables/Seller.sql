CREATE TABLE [dbo].[Seller] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [AccountId]   NVARCHAR (128) NULL,
    [Name]        NVARCHAR (300) NOT NULL,
    [Location]    INT            NULL,
    [IsActive]    BIT            CONSTRAINT [DF_Seller_IsActive] DEFAULT ((1)) NOT NULL,
    [Email]       NVARCHAR (200) NULL,
    [PhoneNumber] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_Seller] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Seller_AspNetUsers] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

