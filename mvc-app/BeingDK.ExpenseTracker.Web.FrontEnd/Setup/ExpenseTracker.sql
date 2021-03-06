USE [ExpenseTracker]
GO
/****** Object:  Table [dbo].[ExpenseCategory]    Script Date: 14-09-2018 12:26:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpenseCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
 CONSTRAINT [PK_ExpensesCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExpenseCategoryMasters]    Script Date: 14-09-2018 12:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpenseCategoryMasters](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_ExpensesCategoryMasters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 14-09-2018 12:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expenses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [money] NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[IncurredAt] [datetime] NOT NULL,
	[IncurredBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
 CONSTRAINT [PK_Expenses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 14-09-2018 12:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nvarchar](15) NULL,
	[Address] [nvarchar](150) NULL,
	[BirthDate] [date] NULL,
	[Gender] [nvarchar](10) NULL,
	[AlternatePhone] [nvarchar](15) NULL,
	[RegistrationDate] [date] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ExpenseCategory] ON 
GO
INSERT [dbo].[ExpenseCategory] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (1, N'Bills', CAST(N'2018-09-13T17:05:41.000' AS DateTime), CAST(N'2018-09-13T17:27:52.350' AS DateTime), 1, 1)
GO
INSERT [dbo].[ExpenseCategory] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (2, N'Grocery', CAST(N'2018-09-13T17:05:41.303' AS DateTime), CAST(N'2018-09-13T17:05:41.303' AS DateTime), 1, 1)
GO
INSERT [dbo].[ExpenseCategory] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (3, N'Food', CAST(N'2018-09-13T17:05:41.303' AS DateTime), CAST(N'2018-09-13T17:05:41.303' AS DateTime), 1, 1)
GO
INSERT [dbo].[ExpenseCategory] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (4, N'Entertainment', CAST(N'2018-09-13T17:05:41.303' AS DateTime), CAST(N'2018-09-13T17:05:41.303' AS DateTime), 1, 1)
GO
INSERT [dbo].[ExpenseCategory] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (5, N'Fuel', CAST(N'2018-09-13T17:05:41.303' AS DateTime), CAST(N'2018-09-13T17:05:41.303' AS DateTime), 1, 1)
GO
INSERT [dbo].[ExpenseCategory] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (6, N'Shopping', CAST(N'2018-09-13T17:05:41.303' AS DateTime), CAST(N'2018-09-13T17:05:41.303' AS DateTime), 1, 1)
GO
INSERT [dbo].[ExpenseCategory] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (7, N'Travel', CAST(N'2018-09-13T17:05:41.303' AS DateTime), CAST(N'2018-09-13T17:05:41.303' AS DateTime), 1, 1)
GO
INSERT [dbo].[ExpenseCategory] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (8, N'Health', CAST(N'2018-09-13T17:05:41.303' AS DateTime), CAST(N'2018-09-13T17:05:41.303' AS DateTime), 1, 1)
GO
INSERT [dbo].[ExpenseCategory] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (9, N'Other', CAST(N'2018-09-13T17:05:41.303' AS DateTime), CAST(N'2018-09-13T17:05:41.303' AS DateTime), 1, 1)
GO
INSERT [dbo].[ExpenseCategory] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (11, N'Gas', CAST(N'2018-09-13T17:05:41.303' AS DateTime), CAST(N'2018-09-13T17:05:41.303' AS DateTime), 1, 1)
GO
INSERT [dbo].[ExpenseCategory] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (13, N'Unknown', CAST(N'2018-09-13T17:05:41.303' AS DateTime), CAST(N'2018-09-13T17:05:41.303' AS DateTime), 1, 1)
GO
INSERT [dbo].[ExpenseCategory] ([Id], [Name], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (15, N'Unknown#2 ', CAST(N'2018-09-13T17:12:28.563' AS DateTime), CAST(N'2018-09-13T17:12:28.563' AS DateTime), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[ExpenseCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[Expenses] ON 
GO
INSERT [dbo].[Expenses] ([Id], [Amount], [Description], [CategoryId], [IncurredAt], [IncurredBy], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (4, 200.0000, N'Electricity', 1, CAST(N'2018-09-13T00:00:00.000' AS DateTime), 1, CAST(N'2018-09-13T16:20:46.483' AS DateTime), CAST(N'2018-09-13T16:20:46.483' AS DateTime), 1, 1)
GO
INSERT [dbo].[Expenses] ([Id], [Amount], [Description], [CategoryId], [IncurredAt], [IncurredBy], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (5, 2300.0000, N'DMart', 2, CAST(N'2018-09-01T00:00:00.000' AS DateTime), 1, CAST(N'2018-09-13T16:21:08.000' AS DateTime), CAST(N'2018-09-13T16:38:10.707' AS DateTime), 1, 1)
GO
INSERT [dbo].[Expenses] ([Id], [Amount], [Description], [CategoryId], [IncurredAt], [IncurredBy], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (6, 5000.0000, N'Shruti Summar Fees', 1, CAST(N'2018-09-13T00:00:00.000' AS DateTime), 1, CAST(N'2018-09-13T16:42:03.280' AS DateTime), CAST(N'2018-09-13T16:42:03.280' AS DateTime), 1, 1)
GO
INSERT [dbo].[Expenses] ([Id], [Amount], [Description], [CategoryId], [IncurredAt], [IncurredBy], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (7, 6000.0000, N'Arnav Summar Fees', 1, CAST(N'2018-09-13T00:00:00.000' AS DateTime), 1, CAST(N'2018-09-13T16:42:21.587' AS DateTime), CAST(N'2018-09-13T16:42:21.587' AS DateTime), 1, 1)
GO
INSERT [dbo].[Expenses] ([Id], [Amount], [Description], [CategoryId], [IncurredAt], [IncurredBy], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (8, 5000.0000, N'New year celebration', 4, CAST(N'2018-01-01T00:00:00.000' AS DateTime), 1, CAST(N'2018-09-13T16:42:59.370' AS DateTime), CAST(N'2018-09-13T16:42:59.370' AS DateTime), 1, 1)
GO
INSERT [dbo].[Expenses] ([Id], [Amount], [Description], [CategoryId], [IncurredAt], [IncurredBy], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (9, 1000.0000, N'Movie followed by Dinner', 4, CAST(N'2018-09-10T00:00:00.000' AS DateTime), 1, CAST(N'2018-09-13T16:43:30.513' AS DateTime), CAST(N'2018-09-13T16:43:30.513' AS DateTime), 1, 1)
GO
INSERT [dbo].[Expenses] ([Id], [Amount], [Description], [CategoryId], [IncurredAt], [IncurredBy], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (10, 3000.0000, N'Children having Cold and Fever', 8, CAST(N'2018-09-12T00:00:00.000' AS DateTime), 1, CAST(N'2018-09-13T16:44:29.130' AS DateTime), CAST(N'2018-09-13T16:44:29.130' AS DateTime), 1, 1)
GO
INSERT [dbo].[Expenses] ([Id], [Amount], [Description], [CategoryId], [IncurredAt], [IncurredBy], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (11, 4000.0000, N'Telephone and internet for whole family', 1, CAST(N'2018-01-21T00:00:00.000' AS DateTime), 1, CAST(N'2018-09-13T16:45:22.237' AS DateTime), CAST(N'2018-09-13T16:45:22.237' AS DateTime), 1, 1)
GO
INSERT [dbo].[Expenses] ([Id], [Amount], [Description], [CategoryId], [IncurredAt], [IncurredBy], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (12, 4000.0000, N'Telephone and internet for whole family', 1, CAST(N'2018-02-20T00:00:00.000' AS DateTime), 1, CAST(N'2018-09-13T16:45:22.000' AS DateTime), CAST(N'2018-09-13T16:46:59.437' AS DateTime), 1, 1)
GO
INSERT [dbo].[Expenses] ([Id], [Amount], [Description], [CategoryId], [IncurredAt], [IncurredBy], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (13, 4000.0000, N'Telephone and internet for whole family', 1, CAST(N'2018-03-08T00:00:00.000' AS DateTime), 1, CAST(N'2018-09-13T16:45:22.000' AS DateTime), CAST(N'2018-09-13T16:47:06.870' AS DateTime), 1, 1)
GO
INSERT [dbo].[Expenses] ([Id], [Amount], [Description], [CategoryId], [IncurredAt], [IncurredBy], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (14, 4000.0000, N'Telephone and internet for whole family', 1, CAST(N'2018-04-05T00:00:00.000' AS DateTime), 1, CAST(N'2018-09-13T16:45:22.000' AS DateTime), CAST(N'2018-09-13T16:47:18.940' AS DateTime), 1, 1)
GO
INSERT [dbo].[Expenses] ([Id], [Amount], [Description], [CategoryId], [IncurredAt], [IncurredBy], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (15, 4000.0000, N'Telephone and internet for whole family', 1, CAST(N'2018-06-13T00:00:00.000' AS DateTime), 1, CAST(N'2018-09-13T16:45:22.000' AS DateTime), CAST(N'2018-09-13T16:47:26.350' AS DateTime), 1, 1)
GO
INSERT [dbo].[Expenses] ([Id], [Amount], [Description], [CategoryId], [IncurredAt], [IncurredBy], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (16, 4000.0000, N'Telephone and internet for whole family', 1, CAST(N'2018-07-20T00:00:00.000' AS DateTime), 1, CAST(N'2018-09-13T16:45:22.000' AS DateTime), CAST(N'2018-09-13T16:47:34.030' AS DateTime), 1, 1)
GO
INSERT [dbo].[Expenses] ([Id], [Amount], [Description], [CategoryId], [IncurredAt], [IncurredBy], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (17, 4000.0000, N'Telephone and internet for whole family', 1, CAST(N'2018-08-16T00:00:00.000' AS DateTime), 1, CAST(N'2018-09-13T16:45:22.000' AS DateTime), CAST(N'2018-09-13T16:47:55.720' AS DateTime), 1, 1)
GO
INSERT [dbo].[Expenses] ([Id], [Amount], [Description], [CategoryId], [IncurredAt], [IncurredBy], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (18, 4000.0000, N'Telephone and internet for whole family', 1, CAST(N'2018-09-19T00:00:00.000' AS DateTime), 1, CAST(N'2018-09-13T16:45:22.000' AS DateTime), CAST(N'2018-09-13T16:48:02.307' AS DateTime), 1, 1)
GO
INSERT [dbo].[Expenses] ([Id], [Amount], [Description], [CategoryId], [IncurredAt], [IncurredBy], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (19, 4000.0000, N'Telephone and internet for whole family', 1, CAST(N'2018-10-24T00:00:00.000' AS DateTime), 1, CAST(N'2018-09-13T16:45:22.000' AS DateTime), CAST(N'2018-09-13T16:48:08.527' AS DateTime), 1, 1)
GO
INSERT [dbo].[Expenses] ([Id], [Amount], [Description], [CategoryId], [IncurredAt], [IncurredBy], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (20, 4000.0000, N'Telephone and internet for whole family', 1, CAST(N'2018-11-15T00:00:00.000' AS DateTime), 1, CAST(N'2018-09-13T16:45:22.000' AS DateTime), CAST(N'2018-09-13T16:48:18.217' AS DateTime), 1, 1)
GO
INSERT [dbo].[Expenses] ([Id], [Amount], [Description], [CategoryId], [IncurredAt], [IncurredBy], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (21, 4000.0000, N'Telephone and internet for whole family', 1, CAST(N'2018-12-13T00:00:00.000' AS DateTime), 1, CAST(N'2018-09-13T16:45:22.000' AS DateTime), CAST(N'2018-09-13T16:48:24.417' AS DateTime), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Expenses] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [UserName], [Password], [Email], [Phone], [Address], [BirthDate], [Gender], [AlternatePhone], [RegistrationDate], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy]) VALUES (1, N'Being', N'Craftsman', N'admin', N'admin', N'admin@FakeDomain.com', NULL, NULL, NULL, N'Male', NULL, CAST(N'2018-09-12' AS Date), CAST(N'2018-09-12T08:32:01.000' AS DateTime), CAST(N'2018-09-14T12:24:35.683' AS DateTime), NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_ExpenseCategory_Name]    Script Date: 14-09-2018 12:26:55 ******/
ALTER TABLE [dbo].[ExpenseCategory] ADD  CONSTRAINT [UK_ExpenseCategory_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_Users_Email]    Script Date: 14-09-2018 12:26:55 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UK_Users_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_Users_Phone]    Script Date: 14-09-2018 12:26:55 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UK_Users_Phone] UNIQUE NONCLUSTERED 
(
	[Phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_Users_UserName]    Script Date: 14-09-2018 12:26:55 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UK_Users_UserName] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD  CONSTRAINT [FK_Expenses_CreatedBy_Users] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Expenses] CHECK CONSTRAINT [FK_Expenses_CreatedBy_Users]
GO
ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD  CONSTRAINT [FK_Expenses_ExpenseCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ExpenseCategory] ([Id])
GO
ALTER TABLE [dbo].[Expenses] CHECK CONSTRAINT [FK_Expenses_ExpenseCategory]
GO
ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD  CONSTRAINT [FK_Expenses_IncuredBy_Users] FOREIGN KEY([IncurredBy])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Expenses] CHECK CONSTRAINT [FK_Expenses_IncuredBy_Users]
GO
ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD  CONSTRAINT [FK_Expenses_UodatedBy_Users] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Expenses] CHECK CONSTRAINT [FK_Expenses_UodatedBy_Users]
GO
