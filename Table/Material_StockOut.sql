USE [Demo]
GO

/****** Object:  Table [dbo].[Material_StockOut]    Script Date: 25/9/2566 20:40:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Material_StockOut](
	[StockOut_Id] [int] IDENTITY(1001,1) NOT NULL,
	[Material_Id] [int] NOT NULL,
	[Product_Lot] [nvarchar](50) NULL,
	[StockOut_Qty] [decimal](10, 2) NULL,
	[Staff_Id] [nvarchar](10) NULL,
	[Remark] [nvarchar](50) NULL,
	[Create_Date] [datetime] NULL,
	[Modify_Date] [datetime] NULL,
 CONSTRAINT [PK_Material_StockOut] PRIMARY KEY CLUSTERED 
(
	[StockOut_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

