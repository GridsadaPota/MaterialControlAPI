USE [Demo]
GO

/****** Object:  Table [dbo].[Mat_Shelf]    Script Date: 19/9/2566 19:05:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Mat_Shelf](
	[Shelf_Id] [int] IDENTITY(1001,1) NOT NULL,
	[Shelf_Code] [nvarchar](10) NOT NULL,
	[Shelf_Name] [nvarchar](50) NULL,
	[Shelf_Remark] [nvarchar](50) NULL,
	[Local_Id] [int] NOT NULL,
	[Create_Date] [datetime] NULL,
	[Modify_Date] [datetime] NULL,
 CONSTRAINT [PK_Mat_Shelf_1] PRIMARY KEY CLUSTERED 
(
	[Shelf_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Mat_Shelf]  WITH CHECK ADD  CONSTRAINT [FK_Mat_Shelf_Mat_Location] FOREIGN KEY([Local_Id])
REFERENCES [dbo].[Mat_Location] ([Local_Id])
GO

ALTER TABLE [dbo].[Mat_Shelf] CHECK CONSTRAINT [FK_Mat_Shelf_Mat_Location]
GO

