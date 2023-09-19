USE [Demo]
GO

/****** Object:  Table [dbo].[Material_StockMain]    Script Date: 19/9/2566 19:05:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Material_StockMain](
	[Material_Id] [int] IDENTITY(1001,1) NOT NULL,
	[Material_Code] [nvarchar](10) NOT NULL,
	[Material_Name] [nvarchar](50) NULL,
	[Unit] [nvarchar](10) NULL,
	[Type_Id] [int] NOT NULL,
	[Shelf_Id] [int] NOT NULL,
	[Stock_Qty] [decimal](10, 2) NULL,
	[Hold_Stock] [bit] NULL,
	[Remark] [nvarchar](50) NULL,
	[Create_Date] [datetime] NULL,
	[Modify_Date] [datetime] NULL,
 CONSTRAINT [PK_Material_StockMain_1] PRIMARY KEY CLUSTERED 
(
	[Material_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Material_StockMain]  WITH CHECK ADD  CONSTRAINT [FK_Material_StockMain_Mat_Shelf] FOREIGN KEY([Shelf_Id])
REFERENCES [dbo].[Mat_Shelf] ([Shelf_Id])
GO

ALTER TABLE [dbo].[Material_StockMain] CHECK CONSTRAINT [FK_Material_StockMain_Mat_Shelf]
GO

ALTER TABLE [dbo].[Material_StockMain]  WITH CHECK ADD  CONSTRAINT [FK_Material_StockMain_Material_Type] FOREIGN KEY([Type_Id])
REFERENCES [dbo].[Material_Type] ([Type_Id])
GO

ALTER TABLE [dbo].[Material_StockMain] CHECK CONSTRAINT [FK_Material_StockMain_Material_Type]
GO

