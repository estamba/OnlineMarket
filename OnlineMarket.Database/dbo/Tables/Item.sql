CREATE TABLE [dbo].[Item] (
    [Id]             INT              IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (200)   NULL,
    [Description]    NVARCHAR (300)   NULL,
    [CategoryID]     INT              NULL,
    [SellerID]       INT              NULL,
    [LocationID]     INT              NULL,
    [Price]          MONEY            NULL,
    [IsDeleted]      BIT              CONSTRAINT [DF_Item_IsDeleted] DEFAULT ((1)) NOT NULL,
    [CreatedDateUtc] DATETIME         NULL,
    [CreatedDate]    DATETIME         NULL,
    [PictureCount]   INT              NOT NULL,
    [CoverPhotoId]   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Item_Category] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Category] ([Id]),
    CONSTRAINT [FK_Item_Location] FOREIGN KEY ([LocationID]) REFERENCES [dbo].[Location] ([Id]),
    CONSTRAINT [FK_Item_Seller] FOREIGN KEY ([SellerID]) REFERENCES [dbo].[Seller] ([Id])
);

