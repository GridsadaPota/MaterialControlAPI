USE [Demo]
GO

/****** Object:  Table [dbo].[Mat_Location]    Script Date: 25/9/2566 20:37:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Mat_Location](
	[Local_Id] [int] IDENTITY(1001,1) NOT NULL,
	[Local_Code] [nvarchar](10) NOT NULL,
	[Local_Name] [nvarchar](50) NULL,
	[Local_Remark] [nvarchar](50) NULL,
	[Create_Date] [datetime] NULL,
	[Modify_Date] [datetime] NULL,
 CONSTRAINT [PK_Mat_Location_1] PRIMARY KEY CLUSTERED 
(
	[Local_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

