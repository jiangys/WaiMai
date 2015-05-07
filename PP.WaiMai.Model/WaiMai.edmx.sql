
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/07/2015 23:23:16
-- Generated from EDMX file: G:\solution\waimai\PP.WaiMai.Model\WaiMai.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [waimai_6f];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Comment_Sarcasm]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comment] DROP CONSTRAINT [FK_Comment_Sarcasm];
GO
IF OBJECT_ID(N'[dbo].[FK_Comment_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comment] DROP CONSTRAINT [FK_Comment_User];
GO
IF OBJECT_ID(N'[dbo].[FK_ExpendLog_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExpendLog] DROP CONSTRAINT [FK_ExpendLog_User];
GO
IF OBJECT_ID(N'[dbo].[FK_FoodMenu_FoodMenuCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FoodMenu] DROP CONSTRAINT [FK_FoodMenu_FoodMenuCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_FoodMenuCategory_Restaurant]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FoodMenuCategory] DROP CONSTRAINT [FK_FoodMenuCategory_Restaurant];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_FoodMenu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_Order_FoodMenu];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_Order_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Recharge_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Recharge] DROP CONSTRAINT [FK_Recharge_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Sarcasm_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sarcasm] DROP CONSTRAINT [FK_Sarcasm_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Comment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comment];
GO
IF OBJECT_ID(N'[dbo].[Config]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Config];
GO
IF OBJECT_ID(N'[dbo].[ExpendLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExpendLog];
GO
IF OBJECT_ID(N'[dbo].[Feedback]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Feedback];
GO
IF OBJECT_ID(N'[dbo].[FoodMenu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FoodMenu];
GO
IF OBJECT_ID(N'[dbo].[FoodMenuCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FoodMenuCategory];
GO
IF OBJECT_ID(N'[dbo].[Order]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order];
GO
IF OBJECT_ID(N'[dbo].[Recharge]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Recharge];
GO
IF OBJECT_ID(N'[dbo].[Restaurant]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Restaurant];
GO
IF OBJECT_ID(N'[dbo].[Sarcasm]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sarcasm];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Config'
CREATE TABLE [dbo].[Config] (
    [ConfigName] nvarchar(50)  NOT NULL,
    [ConfigValue] nvarchar(2000)  NOT NULL
);
GO

-- Creating table 'ExpendLog'
CREATE TABLE [dbo].[ExpendLog] (
    [ExpendLogID] int IDENTITY(1,1) NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [ConsumeAmount] decimal(18,1)  NOT NULL,
    [RechargeAmount] decimal(18,1)  NOT NULL,
    [Description] nvarchar(200)  NULL,
    [ExpendLogType] int  NOT NULL,
    [ExpendLogTypeID] int  NOT NULL,
    [UserID] int  NOT NULL
);
GO

-- Creating table 'FoodMenu'
CREATE TABLE [dbo].[FoodMenu] (
    [FoodMenuID] int IDENTITY(1,1) NOT NULL,
    [FoodMenuCategoryID] int  NOT NULL,
    [MenuName] nvarchar(50)  NOT NULL,
    [Price] decimal(18,1)  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [Creator] nvarchar(50)  NULL,
    [EditDate] datetime  NULL,
    [Editor] nvarchar(50)  NULL,
    [IsSale] bit  NOT NULL,
    [IsDel] bit  NOT NULL,
    [Version] int  NOT NULL
);
GO

-- Creating table 'FoodMenuCategory'
CREATE TABLE [dbo].[FoodMenuCategory] (
    [FoodMenuCategoryID] int IDENTITY(1,1) NOT NULL,
    [RestaurantID] int  NOT NULL,
    [CName] nvarchar(50)  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [Creator] nvarchar(50)  NULL,
    [EditDate] datetime  NULL,
    [Editor] nvarchar(50)  NULL,
    [IsSale] bit  NOT NULL,
    [IsDel] bit  NOT NULL,
    [Version] int  NOT NULL
);
GO

-- Creating table 'Order'
CREATE TABLE [dbo].[Order] (
    [OrderID] int IDENTITY(1,1) NOT NULL,
    [FoodMenuID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [TotalCount] int  NOT NULL,
    [TotalPrice] decimal(18,1)  NOT NULL,
    [NickName] nvarchar(100)  NULL,
    [Remark] nvarchar(100)  NULL,
    [CreateDate] datetime  NOT NULL,
    [Creator] nvarchar(50)  NULL,
    [EditDate] datetime  NULL,
    [Editor] nvarchar(50)  NULL,
    [IsDel] bit  NOT NULL,
    [Version] int  NOT NULL,
    [OrderStatus] int  NOT NULL
);
GO

-- Creating table 'Recharge'
CREATE TABLE [dbo].[Recharge] (
    [RechargeID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [RechargeAmount] decimal(18,1)  NOT NULL,
    [OpeningBalance] decimal(18,1)  NOT NULL,
    [CurrentBalance] decimal(18,1)  NOT NULL,
    [Status] int  NOT NULL,
    [Remark] nvarchar(100)  NULL,
    [CreateDate] datetime  NOT NULL,
    [RechargeUserName] nvarchar(50)  NOT NULL,
    [IsDel] bit  NOT NULL
);
GO

-- Creating table 'Restaurant'
CREATE TABLE [dbo].[Restaurant] (
    [RestaurantID] int IDENTITY(1,1) NOT NULL,
    [RestaurantName] nvarchar(50)  NOT NULL,
    [SendOutCount] int  NOT NULL,
    [TakeoutPhone] nvarchar(50)  NOT NULL,
    [Description] nvarchar(500)  NULL,
    [IsEnable] bit  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [Creator] nvarchar(50)  NULL,
    [EditDate] datetime  NULL,
    [Editor] nvarchar(50)  NULL,
    [IsDel] bit  NOT NULL,
    [Version] int  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NOT NULL,
    [Password] nvarchar(50)  NOT NULL,
    [IPAddress] varchar(20)  NOT NULL,
    [Amount] decimal(18,1)  NOT NULL,
    [IsAdmin] bit  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [IsDel] bit  NOT NULL,
    [DepartmentType] int  NOT NULL
);
GO

-- Creating table 'Comment'
CREATE TABLE [dbo].[Comment] (
    [CommentID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [SarcasmID] int  NOT NULL,
    [Content] nvarchar(200)  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [IsDel] bit  NOT NULL
);
GO

-- Creating table 'Sarcasm'
CREATE TABLE [dbo].[Sarcasm] (
    [SarcasmID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [Content] nvarchar(4000)  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [IsDel] bit  NOT NULL
);
GO

-- Creating table 'Feedback'
CREATE TABLE [dbo].[Feedback] (
    [FeedbackID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NULL,
    [ContentMsg] nvarchar(2000)  NOT NULL,
    [CreateTime] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ConfigName] in table 'Config'
ALTER TABLE [dbo].[Config]
ADD CONSTRAINT [PK_Config]
    PRIMARY KEY CLUSTERED ([ConfigName] ASC);
GO

-- Creating primary key on [ExpendLogID] in table 'ExpendLog'
ALTER TABLE [dbo].[ExpendLog]
ADD CONSTRAINT [PK_ExpendLog]
    PRIMARY KEY CLUSTERED ([ExpendLogID] ASC);
GO

-- Creating primary key on [FoodMenuID] in table 'FoodMenu'
ALTER TABLE [dbo].[FoodMenu]
ADD CONSTRAINT [PK_FoodMenu]
    PRIMARY KEY CLUSTERED ([FoodMenuID] ASC);
GO

-- Creating primary key on [FoodMenuCategoryID] in table 'FoodMenuCategory'
ALTER TABLE [dbo].[FoodMenuCategory]
ADD CONSTRAINT [PK_FoodMenuCategory]
    PRIMARY KEY CLUSTERED ([FoodMenuCategoryID] ASC);
GO

-- Creating primary key on [OrderID] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [PK_Order]
    PRIMARY KEY CLUSTERED ([OrderID] ASC);
GO

-- Creating primary key on [RechargeID] in table 'Recharge'
ALTER TABLE [dbo].[Recharge]
ADD CONSTRAINT [PK_Recharge]
    PRIMARY KEY CLUSTERED ([RechargeID] ASC);
GO

-- Creating primary key on [RestaurantID] in table 'Restaurant'
ALTER TABLE [dbo].[Restaurant]
ADD CONSTRAINT [PK_Restaurant]
    PRIMARY KEY CLUSTERED ([RestaurantID] ASC);
GO

-- Creating primary key on [UserID] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [CommentID] in table 'Comment'
ALTER TABLE [dbo].[Comment]
ADD CONSTRAINT [PK_Comment]
    PRIMARY KEY CLUSTERED ([CommentID] ASC);
GO

-- Creating primary key on [SarcasmID] in table 'Sarcasm'
ALTER TABLE [dbo].[Sarcasm]
ADD CONSTRAINT [PK_Sarcasm]
    PRIMARY KEY CLUSTERED ([SarcasmID] ASC);
GO

-- Creating primary key on [FeedbackID] in table 'Feedback'
ALTER TABLE [dbo].[Feedback]
ADD CONSTRAINT [PK_Feedback]
    PRIMARY KEY CLUSTERED ([FeedbackID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FoodMenuCategoryID] in table 'FoodMenu'
ALTER TABLE [dbo].[FoodMenu]
ADD CONSTRAINT [FK_FoodMenu_FoodMenuCategory]
    FOREIGN KEY ([FoodMenuCategoryID])
    REFERENCES [dbo].[FoodMenuCategory]
        ([FoodMenuCategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FoodMenu_FoodMenuCategory'
CREATE INDEX [IX_FK_FoodMenu_FoodMenuCategory]
ON [dbo].[FoodMenu]
    ([FoodMenuCategoryID]);
GO

-- Creating foreign key on [FoodMenuID] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [FK_Order_FoodMenu]
    FOREIGN KEY ([FoodMenuID])
    REFERENCES [dbo].[FoodMenu]
        ([FoodMenuID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_FoodMenu'
CREATE INDEX [IX_FK_Order_FoodMenu]
ON [dbo].[Order]
    ([FoodMenuID]);
GO

-- Creating foreign key on [RestaurantID] in table 'FoodMenuCategory'
ALTER TABLE [dbo].[FoodMenuCategory]
ADD CONSTRAINT [FK_FoodMenuCategory_Restaurant]
    FOREIGN KEY ([RestaurantID])
    REFERENCES [dbo].[Restaurant]
        ([RestaurantID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FoodMenuCategory_Restaurant'
CREATE INDEX [IX_FK_FoodMenuCategory_Restaurant]
ON [dbo].[FoodMenuCategory]
    ([RestaurantID]);
GO

-- Creating foreign key on [UserID] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [FK_Order_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[User]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_User'
CREATE INDEX [IX_FK_Order_User]
ON [dbo].[Order]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'Recharge'
ALTER TABLE [dbo].[Recharge]
ADD CONSTRAINT [FK_Recharge_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[User]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Recharge_User'
CREATE INDEX [IX_FK_Recharge_User]
ON [dbo].[Recharge]
    ([UserID]);
GO

-- Creating foreign key on [SarcasmID] in table 'Comment'
ALTER TABLE [dbo].[Comment]
ADD CONSTRAINT [FK_Comment_Sarcasm]
    FOREIGN KEY ([SarcasmID])
    REFERENCES [dbo].[Sarcasm]
        ([SarcasmID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Comment_Sarcasm'
CREATE INDEX [IX_FK_Comment_Sarcasm]
ON [dbo].[Comment]
    ([SarcasmID]);
GO

-- Creating foreign key on [UserID] in table 'Comment'
ALTER TABLE [dbo].[Comment]
ADD CONSTRAINT [FK_Comment_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[User]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Comment_User'
CREATE INDEX [IX_FK_Comment_User]
ON [dbo].[Comment]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'ExpendLog'
ALTER TABLE [dbo].[ExpendLog]
ADD CONSTRAINT [FK_ExpendLog_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[User]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ExpendLog_User'
CREATE INDEX [IX_FK_ExpendLog_User]
ON [dbo].[ExpendLog]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'Sarcasm'
ALTER TABLE [dbo].[Sarcasm]
ADD CONSTRAINT [FK_Sarcasm_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[User]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Sarcasm_User'
CREATE INDEX [IX_FK_Sarcasm_User]
ON [dbo].[Sarcasm]
    ([UserID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------