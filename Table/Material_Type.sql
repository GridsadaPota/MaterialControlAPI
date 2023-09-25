USE [Demo]
GO

/****** Object:  Table [dbo].[Material_Type]    Script Date: 25/9/2566 20:40:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Material_Type](
	[Type_Id] [int] IDENTITY(1001,1) NOT NULL,
	[Type_Code] [nvarchar](10) NOT NULL,
	[Type_Name] [nvarchar](50) NULL,
	[Type_Remark] [nvarchar](50) NULL,
	[Create_Date] [datetime] NULL,
	[Modify_Date] [datetime] NULL,
 CONSTRAINT [PK_Material_Type_1] PRIMARY KEY CLUSTERED 
(
	[Type_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

