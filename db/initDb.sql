IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'BSDemoShopCatalog')
BEGIN
    CREATE DATABASE BSDemoShopCatalog;
END

GO

-- 切換到 BSDemoShopCatalog 資料庫
USE [BSDemoShopCatalog];

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = N'Catalog')
BEGIN
CREATE TABLE [Catalog] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [ParentCatalogId] int NULL,
    [Seq] int NOT NULL,
    [IsDelete] bit NOT NULL,
    [CreateAt] datetime2 NOT NULL,
    [UpdateAt] datetime2 NULL,
    CONSTRAINT [PK_Catalog] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Catalog_Catalog_ParentCatalogId] FOREIGN KEY ([ParentCatalogId]) REFERENCES [Catalog] ([Id])
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = N'Coupons')
BEGIN
CREATE TABLE [Coupons] (
    [Id] int NOT NULL IDENTITY,
    [CouponCode] nvarchar(max) NOT NULL,
    [DiscountPercentage] decimal(5,2) NOT NULL,
    [Seq] int NOT NULL,
    [IsDelete] bit NOT NULL,
    [CreateAt] datetime2 NOT NULL,
    [UpdateAt] datetime2 NULL,
    CONSTRAINT [PK_Coupons] PRIMARY KEY ([Id])
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = N'Members')
BEGIN
CREATE TABLE [Members] (
    [Id] int NOT NULL IDENTITY,
    [MemberName] nvarchar(max) NOT NULL,
    [Seq] int NOT NULL,
    [IsDelete] bit NOT NULL,
    [CreateAt] datetime2 NOT NULL,
    [UpdateAt] datetime2 NULL,
    CONSTRAINT [PK_Members] PRIMARY KEY ([Id])
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = N'Products')
BEGIN
CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [ProductName] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NULL,
    [IsOnTheMarket] bit NOT NULL,
    [ImagePath] nvarchar(max) NULL,
    [Seq] int NOT NULL,
    [IsDelete] bit NOT NULL,
    [CreateAt] datetime2 NOT NULL,
    [UpdateAt] datetime2 NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = N'SpecificationReferences')
BEGIN
CREATE TABLE [SpecificationReferences] (
    [Id] int NOT NULL IDENTITY,
    [SpecificationName] nvarchar(max) NOT NULL,
    [Seq] int NOT NULL,
    [IsDelete] bit NOT NULL,
    [CreateAt] datetime2 NOT NULL,
    [UpdateAt] datetime2 NULL,
    CONSTRAINT [PK_SpecificationReferences] PRIMARY KEY ([Id])
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = N'TodoItems')
BEGIN
CREATE TABLE [TodoItems] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NOT NULL,
    [IsDone] bit NOT NULL,
    [Seq] int NOT NULL,
    [IsDelete] bit NOT NULL,
    [CreateAt] datetime2 NOT NULL,
    [UpdateAt] datetime2 NULL,
    CONSTRAINT [PK_TodoItems] PRIMARY KEY ([Id])
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = N'Orders')
BEGIN
CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [BuyerName] nvarchar(max) NOT NULL,
    [BuyerEmail] nvarchar(max) NOT NULL,
    [BuyerAddress] nvarchar(max) NOT NULL,
    [TotalAmount] decimal(14,0) NOT NULL,
    [OrderStatus] int NOT NULL,
    [MemberId] int NOT NULL,
    [CouponId] int NULL,
    [Seq] int NOT NULL,
    [IsDelete] bit NOT NULL,
    [CreateAt] datetime2 NOT NULL,
    [UpdateAt] datetime2 NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orders_Coupons_CouponId] FOREIGN KEY ([CouponId]) REFERENCES [Coupons] ([Id]),
    CONSTRAINT [FK_Orders_Members_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id]) ON DELETE CASCADE
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = N'ProductDetails')
BEGIN
CREATE TABLE [ProductDetails] (
    [Id] int NOT NULL IDENTITY,
    [ProductId] int NOT NULL,
    [SKU] nvarchar(max) NOT NULL,
    [Inventory] int NOT NULL,
    [UnitPrice] decimal(14,2) NOT NULL,
    [Seq] int NOT NULL,
    [IsDelete] bit NOT NULL,
    [CreateAt] datetime2 NOT NULL,
    [UpdateAt] datetime2 NULL,
    CONSTRAINT [PK_ProductDetails] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductDetails_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = N'OrderItems')
BEGIN
CREATE TABLE [OrderItems] (
    [Id] int NOT NULL IDENTITY,
    [ItemName] nvarchar(max) NULL,
    [Units] int NOT NULL,
    [UnitPrice] decimal(14,2) NOT NULL,
    [Discount] decimal(5,2) NOT NULL,
    [OrderId] int NOT NULL,
    [Seq] int NOT NULL,
    [IsDelete] bit NOT NULL,
    [CreateAt] datetime2 NOT NULL,
    [UpdateAt] datetime2 NULL,
    CONSTRAINT [PK_OrderItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = N'Specifications')
BEGIN
CREATE TABLE [Specifications] (
    [Id] int NOT NULL IDENTITY,
    [SpecificationValue] nvarchar(max) NOT NULL,
    [SpecificationReferenceId] int NOT NULL,
    [ProductDetailId] int NOT NULL,
    [Seq] int NOT NULL,
    [IsDelete] bit NOT NULL,
    [CreateAt] datetime2 NOT NULL,
    [UpdateAt] datetime2 NULL,
    CONSTRAINT [PK_Specifications] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Specifications_ProductDetails_ProductDetailId] FOREIGN KEY ([ProductDetailId]) REFERENCES [ProductDetails] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Specifications_SpecificationReferences_SpecificationReferenceId] FOREIGN KEY ([SpecificationReferenceId]) REFERENCES [SpecificationReferences] ([Id]) ON DELETE CASCADE
    );
END
GO
    
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreateAt', N'IsDelete', N'Name', N'ParentCatalogId', N'Seq', N'UpdateAt') AND [object_id] = OBJECT_ID(N'[Catalog]'))
BEGIN
    IF NOT EXISTS (SELECT TOP 1 * FROM [Catalog])
BEGIN
        SET IDENTITY_INSERT [Catalog] ON;
INSERT INTO [Catalog] ([Id], [CreateAt], [IsDelete], [Name], [ParentCatalogId], [Seq], [UpdateAt])
VALUES
    (1, '2024-10-07T06:54:31.9779640Z', CAST(0 AS bit), N'Catalog 1', NULL, 0, NULL),
    (2, '2024-10-07T06:54:31.9779650Z', CAST(0 AS bit), N'Catalog 2', NULL, 0, NULL),
    (3, '2024-10-07T06:54:31.9779650Z', CAST(0 AS bit), N'Catalog 3', NULL, 0, NULL);
SET IDENTITY_INSERT [Catalog] OFF;
END
END
GO
    
    
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreateAt', N'Description', N'ImagePath', N'IsDelete', N'IsOnTheMarket', N'ProductName', N'Seq', N'UpdateAt') AND [object_id] = OBJECT_ID(N'[Products]'))
BEGIN
    IF NOT EXISTS (SELECT TOP 1 * FROM [Products])
BEGIN
        SET IDENTITY_INSERT [Products] ON;
INSERT INTO [Products] ([Id], [CreateAt], [Description], [ImagePath], [IsDelete], [IsOnTheMarket], [ProductName], [Seq], [UpdateAt])
VALUES
    (1, '2024-10-07T06:54:31.9770230Z', N'米奇潮T', N'https://picsum.photos/300/200/?random=1', CAST(0 AS bit), CAST(1 AS bit), N'潮T', 0, NULL),
    (2, '2024-10-07T06:54:31.9770230Z', N'圍巾 DESC.', N'https://picsum.photos/300/200/?random=2', CAST(0 AS bit), CAST(1 AS bit), N'圍巾', 0, NULL),
    (3, '2024-10-07T06:54:31.9770230Z', N'蛋糕 DESC.', N'https://picsum.photos/300/200/?random=3', CAST(0 AS bit), CAST(1 AS bit), N'蛋糕', 0, NULL);
SET IDENTITY_INSERT [Products] OFF;
END
END
GO
    
    
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreateAt', N'IsDelete', N'Seq', N'SpecificationName', N'UpdateAt') AND [object_id] = OBJECT_ID(N'[SpecificationReferences]'))
BEGIN
IF NOT EXISTS (SELECT TOP 1 * FROM [SpecificationReferences])
BEGIN
        SET IDENTITY_INSERT [SpecificationReferences] ON;
INSERT INTO [SpecificationReferences] ([Id], [CreateAt], [IsDelete], [Seq], [SpecificationName], [UpdateAt])
VALUES
    (1, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 1, N'尺寸', NULL),
    (2, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 0, N'規格', NULL),
    (3, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 0, N'顏色', NULL),
    (4, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 0, N'口味', NULL);
SET IDENTITY_INSERT [SpecificationReferences] OFF;
END
END
GO
    
    
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreateAt', N'Description', N'IsDelete', N'IsDone', N'Seq', N'UpdateAt') AND [object_id] = OBJECT_ID(N'[TodoItems]'))
BEGIN
IF NOT EXISTS (SELECT TOP 1 * FROM [TodoItems])
BEGIN
        SET IDENTITY_INSERT [TodoItems] ON;
INSERT INTO [TodoItems] ([Id], [CreateAt], [Description], [IsDelete], [IsDone], [Seq], [UpdateAt])
VALUES
    (1, '2024-10-07T06:54:31.9770290Z', N'TodoItem 1', CAST(0 AS bit), CAST(0 AS bit), 0, NULL),
    (2, '2024-10-07T06:54:31.9770290Z', N'TodoItem 2', CAST(0 AS bit), CAST(0 AS bit), 0, NULL),
    (3, '2024-10-07T06:54:31.9770290Z', N'TodoItem 3', CAST(0 AS bit), CAST(0 AS bit), 0, NULL),
    (4, '2024-10-07T06:54:31.9770310Z', N'TodoItem 4', CAST(0 AS bit), CAST(0 AS bit), 0, NULL),
    (5, '2024-10-07T06:54:31.9770310Z', N'TodoItem 5', CAST(0 AS bit), CAST(0 AS bit), 0, NULL),
    (6, '2024-10-07T06:54:31.9770310Z', N'TodoItem 6', CAST(0 AS bit), CAST(0 AS bit), 0, NULL),
    (7, '2024-10-07T06:54:31.9770310Z', N'TodoItem 7', CAST(0 AS bit), CAST(0 AS bit), 0, NULL),
    (8, '2024-10-07T06:54:31.9770320Z', N'TodoItem 8', CAST(0 AS bit), CAST(0 AS bit), 0, NULL),
    (9, '2024-10-07T06:54:31.9770320Z', N'TodoItem 9', CAST(0 AS bit), CAST(0 AS bit), 0, NULL),
    (10, '2024-10-07T06:54:31.9770320Z', N'TodoItem 10', CAST(0 AS bit), CAST(0 AS bit), 0, NULL);
SET IDENTITY_INSERT [TodoItems] OFF;
END
END
GO
    
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreateAt', N'IsDelete', N'Name', N'ParentCatalogId', N'Seq', N'UpdateAt') AND [object_id] = OBJECT_ID(N'[Catalog]'))
BEGIN
    IF NOT EXISTS (SELECT TOP 1 * FROM [Catalog] WHERE [Id] = 4) AND EXISTS (SELECT TOP 1 * FROM [Catalog] WHERE [Id] = 1)
BEGIN
        SET IDENTITY_INSERT [Catalog] ON;
INSERT INTO [Catalog] ([Id], [CreateAt], [IsDelete], [Name], [ParentCatalogId], [Seq], [UpdateAt])
VALUES (4, '2024-10-07T06:54:31.9779650Z', CAST(0 AS bit), N'Catalog 1-1', 1, 0, NULL);
SET IDENTITY_INSERT [Catalog] OFF;
END
END
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreateAt', N'IsDelete', N'Name', N'ParentCatalogId', N'Seq', N'UpdateAt') AND [object_id] = OBJECT_ID(N'[Catalog]'))
BEGIN
    IF NOT EXISTS (SELECT TOP 1 * FROM [Catalog] WHERE [Id] = 5) AND EXISTS (SELECT TOP 1 * FROM [Catalog] WHERE [Id] = 4)
BEGIN
        SET IDENTITY_INSERT [Catalog] ON;
INSERT INTO [Catalog] ([Id], [CreateAt], [IsDelete], [Name], [ParentCatalogId], [Seq], [UpdateAt])
VALUES (5, '2024-10-07T06:54:31.9779650Z', CAST(0 AS bit), N'Catalog 1-1-1', 4, 0, NULL);
SET IDENTITY_INSERT [Catalog] OFF;
END
END
GO
    
    
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreateAt', N'Inventory', N'IsDelete', N'ProductId', N'SKU', N'Seq', N'UnitPrice', N'UpdateAt') AND [object_id] = OBJECT_ID(N'[ProductDetails]'))
BEGIN
    IF NOT EXISTS (SELECT TOP 1 * FROM [ProductDetails])
BEGIN
        SET IDENTITY_INSERT [ProductDetails] ON;
INSERT INTO [ProductDetails] ([Id], [CreateAt], [Inventory], [IsDelete], [ProductId], [SKU], [Seq], [UnitPrice], [UpdateAt])
VALUES
    (1, '2024-10-07T06:54:31.9770250Z', 10, CAST(0 AS bit), 1, N'Micky-Black-S', 1, 100.0, NULL),
    (2, '2024-10-07T06:54:31.9770260Z', 10, CAST(0 AS bit), 1, N'Micky-Black-M', 2, 100.0, NULL),
    (3, '2024-10-07T06:54:31.9770260Z', 10, CAST(0 AS bit), 1, N'Micky-Black-L', 1, 100.0, NULL),
    (4, '2024-10-07T06:54:31.9770260Z', 10, CAST(0 AS bit), 1, N'Micky-Black-XL', 1, 100.0, NULL),
    (5, '2024-10-07T06:54:31.9770260Z', 10, CAST(0 AS bit), 1, N'Micky-White-XL', 1, 100.0, NULL),
    (6, '2024-10-07T06:54:31.9770260Z', 10, CAST(0 AS bit), 1, N'Micky-White-M', 1, 100.0, NULL),
    (7, '2024-10-07T06:54:31.9770260Z', 10, CAST(0 AS bit), 1, N'Micky-Red-XS', 1, 100.0, NULL),
    (8, '2024-10-07T06:54:31.9770260Z', 10, CAST(0 AS bit), 1, N'Micky-Gray-S', 1, 100.0, NULL),
    (9, '2024-10-07T06:54:31.9770270Z', 5, CAST(0 AS bit), 2, N'Scarf', 0, 50.0, NULL),
    (10, '2024-10-07T06:54:31.9770270Z', 15, CAST(0 AS bit), 3, N'Cake-Banana', 0, 599.0, NULL),
    (11, '2024-10-07T06:54:31.9770270Z', 20, CAST(0 AS bit), 3, N'Cake-Chocolate', 1, 599.0, NULL);
SET IDENTITY_INSERT [ProductDetails] OFF;
END
END
GO
    
    
    
    
    
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreateAt', N'IsDelete', N'ProductDetailId', N'Seq', N'SpecificationReferenceId', N'SpecificationValue', N'UpdateAt') AND [object_id] = OBJECT_ID(N'[Specifications]'))
BEGIN
    IF NOT EXISTS (SELECT TOP 1 * FROM [Specifications])
BEGIN
        SET IDENTITY_INSERT [Specifications] ON;
INSERT INTO [Specifications] ([Id], [CreateAt], [IsDelete], [ProductDetailId], [Seq], [SpecificationReferenceId], [SpecificationValue], [UpdateAt])
VALUES
    (1, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 1, 0, 1, N'S', NULL),
    (2, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 2, 1, 1, N'M', NULL),
    (3, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 3, 2, 1, N'L', NULL),
    (4, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 4, 3, 1, N'XL', NULL),
    (5, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 1, 0, 3, N'黑色', NULL),
    (6, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 2, 0, 3, N'黑色', NULL),
    (7, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 3, 0, 3, N'黑色', NULL),
    (8, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 4, 0, 3, N'黑色', NULL),
    (9, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 5, 1, 3, N'白色', NULL),
    (10, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 6, 1, 3, N'白色', NULL),
    (11, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 5, 0, 1, N'M', NULL),
    (12, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 6, 1, 1, N'XL', NULL),
    (13, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 7, 2, 3, N'紅色', NULL),
    (14, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 7, 0, 1, N'XS', NULL),
    (15, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 8, 3, 3, N'灰色', NULL),
    (16, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 8, 0, 1, N'S', NULL),
    (17, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 9, 0, 2, N'單一規格', NULL),
    (18, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 10, 1, 4, N'香蕉', NULL),
    (19, '2023-08-29T00:00:00.0000000', CAST(0 AS bit), 11, 0, 4, N'巧克力', NULL);
SET IDENTITY_INSERT [Specifications] OFF;
END
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = N'IX_Catalog_ParentCatalogId' AND object_id = OBJECT_ID(N'[Catalog]'))
CREATE INDEX [IX_Catalog_ParentCatalogId] ON [Catalog] ([ParentCatalogId]);
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = N'IX_OrderItems_OrderId' AND object_id = OBJECT_ID(N'[OrderItems]'))
CREATE INDEX [IX_OrderItems_OrderId] ON [OrderItems] ([OrderId]);
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = N'IX_Orders_CouponId' AND object_id = OBJECT_ID(N'[Orders]'))
CREATE INDEX [IX_Orders_CouponId] ON [Orders] ([CouponId]);
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = N'IX_Orders_MemberId' AND object_id = OBJECT_ID(N'[Orders]'))
CREATE INDEX [IX_Orders_MemberId] ON [Orders] ([MemberId]);
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = N'IX_ProductDetails_ProductId' AND object_id = OBJECT_ID(N'[ProductDetails]'))
CREATE INDEX [IX_ProductDetails_ProductId] ON [ProductDetails] ([ProductId]);
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = N'IX_Specifications_ProductDetailId' AND object_id = OBJECT_ID(N'[Specifications]'))
CREATE INDEX [IX_Specifications_ProductDetailId] ON [Specifications] ([ProductDetailId]);
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = N'IX_Specifications_SpecificationReferenceId' AND object_id = OBJECT_ID(N'[Specifications]'))
CREATE INDEX [IX_Specifications_SpecificationReferenceId] ON [Specifications] ([SpecificationReferenceId]);
GO

