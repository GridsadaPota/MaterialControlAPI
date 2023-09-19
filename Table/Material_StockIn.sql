USE [Demo]
GO

/****** Object:  Table [dbo].[Material_StockIn]    Script Date: 19/9/2566 19:05:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Material_StockIn](
	[StockIn_Id] [int] IDENTITY(1001,1) NOT NULL,
	[Material_Id] [int] NOT NULL,
	[Invoice_No] [nvarchar](50) NULL,
	[Invoice_Date] [datetime] NULL,
	[Item_No] [nvarchar](50) NULL,
	[Input_Qty] [decimal](10, 2) NULL,
	[Staff_Id] [nvarchar](10) NULL,
	[Remark] [nvarchar](50) NULL,
	[Creat_Date] [datetime] NULL,
	[Modify_Date] [datetime] NULL,
 CONSTRAINT [PK_Material_StockIn] PRIMARY KEY CLUSTERED 
(
	[StockIn_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Material_StockIn]  WITH CHECK ADD  CONSTRAINT [FK_Material_StockIn_Material_StockMain] FOREIGN KEY([Material_Id])
REFERENCES [dbo].[Material_StockMain] ([Material_Id])
GO

ALTER TABLE [dbo].[Material_StockIn] CHECK CONSTRAINT [FK_Material_StockIn_Material_StockMain]
GO

