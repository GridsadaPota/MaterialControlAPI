USE [Demo]
GO

/****** Object:  Table [dbo].[Material_StockIn]    Script Date: 25/9/2566 20:39:20 ******/
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
	[StockIn_Qty] [decimal](10, 2) NULL,
	[Staff_Id] [nvarchar](10) NULL,
	[Remark] [nvarchar](50) NULL,
	[Create_Date] [datetime] NULL,
	[Modify_Date] [datetime] NULL,
 CONSTRAINT [PK_Material_StockIn] PRIMARY KEY CLUSTERED 
(
	[StockIn_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

