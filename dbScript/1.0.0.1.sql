/****** Object:  Table [dbo].[Question]    Script Date: 2024-08-01 19:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[QuestionId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionText] [nvarchar](250) NOT NULL,
	[QuestionTypeId] [int] NULL,
 CONSTRAINT [PK__Question__0DC06FAC1F6A87C7] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionType]    Script Date: 2024-08-01 19:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionType](
	[QuestionTypeId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionTypeName] [nvarchar](100) NOT NULL,
	[QuestionTypeCode] [nvarchar](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[QuestionTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Question] ON 
GO
INSERT [dbo].[Question] ([QuestionId], [QuestionText], [QuestionTypeId]) VALUES (1, N'What is your name', 2)
GO
INSERT [dbo].[Question] ([QuestionId], [QuestionText], [QuestionTypeId]) VALUES (2, N'What is your phone number', 3)
GO
INSERT [dbo].[Question] ([QuestionId], [QuestionText], [QuestionTypeId]) VALUES (3, N'What is your email id', 3)
GO
INSERT [dbo].[Question] ([QuestionId], [QuestionText], [QuestionTypeId]) VALUES (4, N'What is your age', 2)
GO
SET IDENTITY_INSERT [dbo].[Question] OFF
GO
SET IDENTITY_INSERT [dbo].[QuestionType] ON 
GO
INSERT [dbo].[QuestionType] ([QuestionTypeId], [QuestionTypeName], [QuestionTypeCode]) VALUES (2, N'Regular', N'RR')
GO
INSERT [dbo].[QuestionType] ([QuestionTypeId], [QuestionTypeName], [QuestionTypeCode]) VALUES (3, N'Advance', N'AD')
GO
SET IDENTITY_INSERT [dbo].[QuestionType] OFF
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_QuestionType] FOREIGN KEY([QuestionTypeId])
REFERENCES [dbo].[QuestionType] ([QuestionTypeId])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_QuestionType]
GO
