USE [WaiMai]
GO
/****** Object:  Table [dbo].[Config]    Script Date: 12/22/2014 00:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Config](
	[ConfigName] [nvarchar](50) NOT NULL,
	[ConfigValue] [nvarchar](2000) NOT NULL,
 CONSTRAINT [PK_Config] PRIMARY KEY CLUSTERED 
(
	[ConfigName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/22/2014 00:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IPAddress] [varchar](20) NOT NULL,
	[Amount] [decimal](18, 1) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[IsDel] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否是管理员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'IsAdmin'
GO
/****** Object:  Table [dbo].[Restaurant]    Script Date: 12/22/2014 00:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restaurant](
	[RestaurantID] [int] IDENTITY(1,1) NOT NULL,
	[RestaurantName] [nvarchar](50) NOT NULL,
	[SendOutCount] [int] NOT NULL,
	[TakeoutPhone] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[IsEnable] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Creator] [nvarchar](50) NULL,
	[EditDate] [datetime] NULL,
	[Editor] [nvarchar](50) NULL,
	[IsDel] [bit] NOT NULL,
	[Version] [int] NOT NULL,
 CONSTRAINT [PK_Restaurant] PRIMARY KEY CLUSTERED 
(
	[RestaurantID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recharge]    Script Date: 12/22/2014 00:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recharge](
	[RechargeID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[RechargeAmount] [decimal](18, 1) NOT NULL,
	[OpeningBalance] [decimal](18, 1) NOT NULL,
	[CurrentBalance] [decimal](18, 1) NOT NULL,
	[Status] [int] NOT NULL,
	[Remark] [nvarchar](100) NULL,
	[CreateDate] [datetime] NOT NULL,
	[RechargeUserName] [nvarchar](50) NOT NULL,
	[IsDel] [bit] NOT NULL,
 CONSTRAINT [PK_Recharge] PRIMARY KEY CLUSTERED 
(
	[RechargeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1充值成功' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Recharge', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'充值人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Recharge', @level2type=N'COLUMN',@level2name=N'RechargeUserName'
GO
/****** Object:  Table [dbo].[FoodMenuCategory]    Script Date: 12/22/2014 00:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodMenuCategory](
	[FoodMenuCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[RestaurantID] [int] NOT NULL,
	[CName] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Creator] [nvarchar](50) NULL,
	[EditDate] [datetime] NULL,
	[Editor] [nvarchar](50) NULL,
	[IsSale] [bit] NOT NULL,
	[IsDel] [bit] NOT NULL,
	[Version] [int] NOT NULL,
 CONSTRAINT [PK_FoodMenuCategory] PRIMARY KEY CLUSTERED 
(
	[FoodMenuCategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodMenu]    Script Date: 12/22/2014 00:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodMenu](
	[FoodMenuID] [int] IDENTITY(1,1) NOT NULL,
	[FoodMenuCategoryID] [int] NOT NULL,
	[MenuName] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 1) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Creator] [nvarchar](50) NULL,
	[EditDate] [datetime] NULL,
	[Editor] [nvarchar](50) NULL,
	[IsSale] [bit] NOT NULL,
	[IsDel] [bit] NOT NULL,
	[Version] [int] NOT NULL,
 CONSTRAINT [PK_FoodMenu] PRIMARY KEY CLUSTERED 
(
	[FoodMenuID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 12/22/2014 00:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[FoodMenuID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[TotalCount] [int] NOT NULL,
	[TotalPrice] [decimal](18, 1) NOT NULL,
	[NickName] [nvarchar](100) NULL,
	[Remark] [nvarchar](100) NULL,
	[CreateDate] [datetime] NOT NULL,
	[Creator] [nvarchar](50) NULL,
	[EditDate] [datetime] NULL,
	[Editor] [nvarchar](50) NULL,
	[IsDel] [bit] NOT NULL,
	[Version] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_FoodMenu_IsSale]    Script Date: 12/22/2014 00:43:55 ******/
ALTER TABLE [dbo].[FoodMenu] ADD  CONSTRAINT [DF_FoodMenu_IsSale]  DEFAULT ((1)) FOR [IsSale]
GO
/****** Object:  Default [DF_FoodMenuCategory_IsSale]    Script Date: 12/22/2014 00:43:55 ******/
ALTER TABLE [dbo].[FoodMenuCategory] ADD  CONSTRAINT [DF_FoodMenuCategory_IsSale]  DEFAULT ((1)) FOR [IsSale]
GO
/****** Object:  Default [DF_Restaurant_SendOutCount]    Script Date: 12/22/2014 00:43:55 ******/
ALTER TABLE [dbo].[Restaurant] ADD  CONSTRAINT [DF_Restaurant_SendOutCount]  DEFAULT ((0)) FOR [SendOutCount]
GO
/****** Object:  Default [DF_User_IsAdmin]    Script Date: 12/22/2014 00:43:55 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsAdmin]  DEFAULT ((0)) FOR [IsAdmin]
GO
/****** Object:  ForeignKey [FK_FoodMenu_FoodMenuCategory]    Script Date: 12/22/2014 00:43:55 ******/
ALTER TABLE [dbo].[FoodMenu]  WITH CHECK ADD  CONSTRAINT [FK_FoodMenu_FoodMenuCategory] FOREIGN KEY([FoodMenuCategoryID])
REFERENCES [dbo].[FoodMenuCategory] ([FoodMenuCategoryID])
GO
ALTER TABLE [dbo].[FoodMenu] CHECK CONSTRAINT [FK_FoodMenu_FoodMenuCategory]
GO
/****** Object:  ForeignKey [FK_FoodMenuCategory_Restaurant]    Script Date: 12/22/2014 00:43:55 ******/
ALTER TABLE [dbo].[FoodMenuCategory]  WITH CHECK ADD  CONSTRAINT [FK_FoodMenuCategory_Restaurant] FOREIGN KEY([RestaurantID])
REFERENCES [dbo].[Restaurant] ([RestaurantID])
GO
ALTER TABLE [dbo].[FoodMenuCategory] CHECK CONSTRAINT [FK_FoodMenuCategory_Restaurant]
GO
/****** Object:  ForeignKey [FK_Order_FoodMenu]    Script Date: 12/22/2014 00:43:55 ******/
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_FoodMenu] FOREIGN KEY([FoodMenuID])
REFERENCES [dbo].[FoodMenu] ([FoodMenuID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_FoodMenu]
GO
/****** Object:  ForeignKey [FK_Order_User]    Script Date: 12/22/2014 00:43:55 ******/
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
/****** Object:  ForeignKey [FK_Recharge_User]    Script Date: 12/22/2014 00:43:55 ******/
ALTER TABLE [dbo].[Recharge]  WITH CHECK ADD  CONSTRAINT [FK_Recharge_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Recharge] CHECK CONSTRAINT [FK_Recharge_User]
GO
