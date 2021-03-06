USE [ToDo1]
GO
/****** Object:  Table [dbo].[A_Risorsa_Task]    Script Date: 13-Jul-20 2:54:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_Risorsa_Task](
	[ID_RISORSA] [int] NOT NULL,
	[ID_TASK] [int] NOT NULL,
 CONSTRAINT [PK_A_Risorsa_Task] PRIMARY KEY CLUSTERED 
(
	[ID_RISORSA] ASC,
	[ID_TASK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E_ProjectItem]    Script Date: 13-Jul-20 2:54:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_ProjectItem](
	[ID_ProjectItem] [int] NOT NULL,
	[Titolo] [varchar](200) NOT NULL,
	[Descrizione] [varchar](max) NULL,
	[ID_CategoriaProjectItem] [int] NOT NULL,
	[DataInserimento] [datetime] NOT NULL,
	[DataUltimoAggiornamento] [datetime] NOT NULL,
 CONSTRAINT [PK_E_ProjectItem] PRIMARY KEY CLUSTERED 
(
	[ID_ProjectItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E_Risorsa]    Script Date: 13-Jul-20 2:54:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_Risorsa](
	[ID_Risorsa] [int] identity NOT NULL,
	[MatricolaRisorsa] [varchar](10) NOT NULL,
	[Cognome] [varchar](100) NULL,
	[Nome] [nchar](100) NULL,
	[Mail] [nchar](100) NULL,
	[Telefono] [varchar](50) NULL,
	[Cellulare] [varchar](50) NULL,
 CONSTRAINT [PK_Risorsa] PRIMARY KEY CLUSTERED 
(
	[ID_Risorsa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E_Task]    Script Date: 13-Jul-20 2:54:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_Task](
	[ID_Task] [int] IDENTITY(1,1) NOT NULL,
	[Titolo] [varchar](200) NOT NULL,
	[Descrizione] [varchar](max) NULL,
	[ID_ParentTask] [int] NULL,
	[DataInserimento] [datetime] NOT NULL,
	[DataUltimoAggiornamento] [datetime] NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[ID_Task] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_CategoriaProjectItem]    Script Date: 13-Jul-20 2:54:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_CategoriaProjectItem](
	[ID_CategoriaProjectItem] [int] NOT NULL,
	[Nome] [varbinary](100) NULL,
	[Descrizione] [varchar](500) NULL,
	[DataInserimento] [datetime] NOT NULL,
	[DataUltimaModifica] [datetime] NOT NULL,
 CONSTRAINT [PK_T_CategoriaProjectItem] PRIMARY KEY CLUSTERED 
(
	[ID_CategoriaProjectItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Risorsa]    Script Date: 13-Jul-20 2:54:48 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Risorsa] ON [dbo].[E_Risorsa]
(
	[MatricolaRisorsa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[A_Risorsa_Task]  WITH CHECK ADD  CONSTRAINT [FK_A_Risorsa_Task_E_Risorsa] FOREIGN KEY([ID_RISORSA])
REFERENCES [dbo].[E_Risorsa] ([ID_Risorsa])
GO
ALTER TABLE [dbo].[A_Risorsa_Task] CHECK CONSTRAINT [FK_A_Risorsa_Task_E_Risorsa]
GO
ALTER TABLE [dbo].[A_Risorsa_Task]  WITH CHECK ADD  CONSTRAINT [FK_A_Risorsa_Task_E_Task] FOREIGN KEY([ID_TASK])
REFERENCES [dbo].[E_Task] ([ID_Task])
GO
ALTER TABLE [dbo].[A_Risorsa_Task] CHECK CONSTRAINT [FK_A_Risorsa_Task_E_Task]
GO
ALTER TABLE [dbo].[E_ProjectItem]  WITH CHECK ADD  CONSTRAINT [FK_E_ProjectItem_T_CategoriaProjectItem] FOREIGN KEY([ID_CategoriaProjectItem])
REFERENCES [dbo].[T_CategoriaProjectItem] ([ID_CategoriaProjectItem])
GO
ALTER TABLE [dbo].[E_ProjectItem] CHECK CONSTRAINT [FK_E_ProjectItem_T_CategoriaProjectItem]
GO
ALTER TABLE [dbo].[E_Task]  WITH CHECK ADD  CONSTRAINT [FK_E_Task_E_Task] FOREIGN KEY([ID_ParentTask])
REFERENCES [dbo].[E_Task] ([ID_Task])
GO
ALTER TABLE [dbo].[E_Task] CHECK CONSTRAINT [FK_E_Task_E_Task]
GO
