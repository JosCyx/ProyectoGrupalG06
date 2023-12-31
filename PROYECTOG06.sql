USE [PROYECTOG06]
GO
/****** Object:  Table [dbo].[Agentes]    Script Date: 22/8/2023 19:49:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agentes](
	[ID] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[CorreoElectronico] [varchar](50) NULL,
	[EmpresaID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Casos]    Script Date: 22/8/2023 19:49:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Casos](
	[ID] [int] NOT NULL,
	[SolicitudID] [int] NULL,
	[AgenteID] [int] NULL,
	[DescripcionCaso] [varchar](200) NULL,
	[PrioridadCaso] [varchar](20) NULL,
	[EstadoCaso] [varchar](20) NULL,
	[FechaCreacion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresas]    Script Date: 22/8/2023 19:49:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresas](
	[ID] [int] NOT NULL,
	[NombreEmpresa] [varchar](50) NULL,
	[Descripcion] [varchar](100) NULL,
	[Direccion] [varchar](100) NULL,
	[Telefono] [varchar](20) NULL,
	[CorreoElectronico] [varchar](50) NULL,
	[ProductosServicios] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Encuestas]    Script Date: 22/8/2023 19:49:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encuestas](
	[ID] [int] NOT NULL,
	[Pregunta1] [varchar](200) NULL,
	[Pregunta2] [varchar](200) NULL,
	[Pregunta3] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 22/8/2023 19:49:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID] [int] NOT NULL,
	[NombreRol] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Solicitudes]    Script Date: 22/8/2023 19:49:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitudes](
	[ID] [int] NOT NULL,
	[ClienteID] [varchar](100) NULL,
	[EmpresaID] [varchar](100) NULL,
	[DescripcionSolicitud] [varchar](200) NULL,
	[EstadoSolicitud] [varchar](20) NULL,
	[FechaCreacion] [date] NULL,
	[NombreEmpresa] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sugerencias]    Script Date: 22/8/2023 19:49:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sugerencias](
	[ID] [int] NOT NULL,
	[ClienteID] [int] NULL,
	[Comentario] [varchar](200) NULL,
	[EncuestaID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 22/8/2023 19:49:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[ID] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Nombre_usuario] [varchar](25) NULL,
	[CorreoElectronico] [varchar](50) NULL,
	[Contraseña] [varchar](50) NULL,
	[RolID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Agentes]  WITH CHECK ADD FOREIGN KEY([EmpresaID])
REFERENCES [dbo].[Empresas] ([ID])
GO
ALTER TABLE [dbo].[Casos]  WITH CHECK ADD FOREIGN KEY([AgenteID])
REFERENCES [dbo].[Agentes] ([ID])
GO
ALTER TABLE [dbo].[Sugerencias]  WITH CHECK ADD FOREIGN KEY([ClienteID])
REFERENCES [dbo].[Usuarios] ([ID])
GO
ALTER TABLE [dbo].[Sugerencias]  WITH CHECK ADD FOREIGN KEY([EncuestaID])
REFERENCES [dbo].[Encuestas] ([ID])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([RolID])
REFERENCES [dbo].[Roles] ([ID])
GO
