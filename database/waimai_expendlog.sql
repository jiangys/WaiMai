USE [WaiMai]
GO
/****** Object:  Table [dbo].[ExpendLog]    Script Date: 12/22/2014 17:59:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpendLog](
	[ExpendLogID] [int] IDENTITY(1,1) NOT NULL,
	[ExpendLogTypeID] [int] NOT NULL,
	[ExpendLogType] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ConsumeAmount] [decimal](18, 1) NOT NULL,
	[RechargeAmount] [decimal](18, 1) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_ExpendLog] PRIMARY KEY CLUSTERED 
(
	[ExpendLogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
