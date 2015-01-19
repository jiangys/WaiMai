USE [WaiMai]
GO
/****** Object:  Table [dbo].[Sarcasm]    Script Date: 12/31/2014 18:09:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sarcasm](
	[SarcasmID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Content] [nvarchar](4000) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[IsDel] [bit] NOT NULL,
 CONSTRAINT [PK_Sarcasm] PRIMARY KEY CLUSTERED 
(
	[SarcasmID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 12/31/2014 18:09:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[SarcasmID] [int] NOT NULL,
	[Content] [nvarchar](200) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[IsDel] [bit] NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Comment_Sarcasm]    Script Date: 12/31/2014 18:09:33 ******/
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Sarcasm] FOREIGN KEY([SarcasmID])
REFERENCES [dbo].[Sarcasm] ([SarcasmID])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Sarcasm]
GO
/****** Object:  ForeignKey [FK_Comment_User]    Script Date: 12/31/2014 18:09:33 ******/
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_User]
GO
/****** Object:  ForeignKey [FK_Sarcasm_User]    Script Date: 12/31/2014 18:09:33 ******/
ALTER TABLE [dbo].[Sarcasm]  WITH CHECK ADD  CONSTRAINT [FK_Sarcasm_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Sarcasm] CHECK CONSTRAINT [FK_Sarcasm_User]
GO
