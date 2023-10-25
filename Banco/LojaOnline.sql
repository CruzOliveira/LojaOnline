USE [master]
GO
/****** Object:  Database [LOJA_ONLINE]    Script Date: 25/10/2023 17:39:49 ******/
CREATE DATABASE [LOJA_ONLINE]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LOJA_ONLINE', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.PDA_DEV\MSSQL\DATA\LOJA_ONLINE.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LOJA_ONLINE_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.PDA_DEV\MSSQL\DATA\LOJA_ONLINE_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [LOJA_ONLINE] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LOJA_ONLINE].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LOJA_ONLINE] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LOJA_ONLINE] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LOJA_ONLINE] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LOJA_ONLINE] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LOJA_ONLINE] SET ARITHABORT OFF 
GO
ALTER DATABASE [LOJA_ONLINE] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LOJA_ONLINE] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LOJA_ONLINE] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LOJA_ONLINE] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LOJA_ONLINE] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LOJA_ONLINE] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LOJA_ONLINE] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LOJA_ONLINE] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LOJA_ONLINE] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LOJA_ONLINE] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LOJA_ONLINE] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LOJA_ONLINE] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LOJA_ONLINE] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LOJA_ONLINE] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LOJA_ONLINE] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LOJA_ONLINE] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LOJA_ONLINE] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LOJA_ONLINE] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LOJA_ONLINE] SET  MULTI_USER 
GO
ALTER DATABASE [LOJA_ONLINE] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LOJA_ONLINE] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LOJA_ONLINE] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LOJA_ONLINE] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LOJA_ONLINE] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LOJA_ONLINE] SET QUERY_STORE = OFF
GO
USE [LOJA_ONLINE]
GO
/****** Object:  Table [dbo].[LO_TB__LOJA]    Script Date: 25/10/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LO_TB__LOJA](
	[ID_LOJA] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](50) NOT NULL,
 CONSTRAINT [PK_LO_TB__LOJA] PRIMARY KEY CLUSTERED 
(
	[ID_LOJA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LO_TB_CATEGORIA01]    Script Date: 25/10/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LO_TB_CATEGORIA01](
	[ID_CATEGORIA01] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](255) NOT NULL,
 CONSTRAINT [PK_LOJA_TB_CATEGORIAS] PRIMARY KEY CLUSTERED 
(
	[ID_CATEGORIA01] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LO_TB_CATEGORIA02]    Script Date: 25/10/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LO_TB_CATEGORIA02](
	[ID_CATEGORIA02] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](255) NOT NULL,
	[ID_CATEGORIA01] [int] NOT NULL,
 CONSTRAINT [PK_LOJA_TB_TAGS] PRIMARY KEY CLUSTERED 
(
	[ID_CATEGORIA02] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LO_TB_ESTOQUE]    Script Date: 25/10/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LO_TB_ESTOQUE](
	[ID_ESTOQUE] [int] IDENTITY(1,1) NOT NULL,
	[QUANTIDADE] [int] NOT NULL,
	[PRECO] [decimal](10, 2) NOT NULL,
	[ID_LOJA] [int] NOT NULL,
	[EAN] [int] NOT NULL,
 CONSTRAINT [PK_LO_TB_ESTOQUE] PRIMARY KEY CLUSTERED 
(
	[ID_ESTOQUE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LO_TB_INSUFICIENTE]    Script Date: 25/10/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LO_TB_INSUFICIENTE](
	[ID_INSUFICIENTE] [int] NOT NULL,
	[ID_PRODUTO] [int] NOT NULL,
 CONSTRAINT [PK_LO_TB_INSUFICIENTE] PRIMARY KEY CLUSTERED 
(
	[ID_INSUFICIENTE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LO_TB_PRODUTO]    Script Date: 25/10/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LO_TB_PRODUTO](
	[CD_PRODUTO] [int] NOT NULL,
	[NOME] [varchar](255) NOT NULL,
	[DESCRICAO] [varchar](max) NOT NULL,
	[ID_CATEGORIA01] [int] NOT NULL,
	[ID_CATEGORIA02] [int] NOT NULL,
	[ATIVO] [bit] NOT NULL,
 CONSTRAINT [PK_LOJA_TB_PRODUTOS] PRIMARY KEY CLUSTERED 
(
	[CD_PRODUTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LO_TB_PRODUTO_EAN]    Script Date: 25/10/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LO_TB_PRODUTO_EAN](
	[CD_PRODUTO] [int] NOT NULL,
	[EAN] [int] NOT NULL,
	[TAMANHO] [int] NOT NULL,
	[COR] [varchar](50) NOT NULL,
 CONSTRAINT [PK_LO_TB_PRODUTO_EAN] PRIMARY KEY CLUSTERED 
(
	[EAN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LO_TB_CATEGORIA02]  WITH CHECK ADD  CONSTRAINT [FK_LO_TB_CATEGORIA02_LO_TB_CATEGORIA01] FOREIGN KEY([ID_CATEGORIA01])
REFERENCES [dbo].[LO_TB_CATEGORIA01] ([ID_CATEGORIA01])
GO
ALTER TABLE [dbo].[LO_TB_CATEGORIA02] CHECK CONSTRAINT [FK_LO_TB_CATEGORIA02_LO_TB_CATEGORIA01]
GO
ALTER TABLE [dbo].[LO_TB_ESTOQUE]  WITH CHECK ADD  CONSTRAINT [FK_LO_TB_ESTOQUE_LO_TB__LOJA] FOREIGN KEY([ID_LOJA])
REFERENCES [dbo].[LO_TB__LOJA] ([ID_LOJA])
GO
ALTER TABLE [dbo].[LO_TB_ESTOQUE] CHECK CONSTRAINT [FK_LO_TB_ESTOQUE_LO_TB__LOJA]
GO
ALTER TABLE [dbo].[LO_TB_ESTOQUE]  WITH CHECK ADD  CONSTRAINT [FK_LO_TB_ESTOQUE_LO_TB_PRODUTO_EAN] FOREIGN KEY([EAN])
REFERENCES [dbo].[LO_TB_PRODUTO_EAN] ([EAN])
GO
ALTER TABLE [dbo].[LO_TB_ESTOQUE] CHECK CONSTRAINT [FK_LO_TB_ESTOQUE_LO_TB_PRODUTO_EAN]
GO
ALTER TABLE [dbo].[LO_TB_INSUFICIENTE]  WITH CHECK ADD  CONSTRAINT [FK_LO_TB_INSUFICIENTE_LO_TB_PRODUTOS] FOREIGN KEY([ID_PRODUTO])
REFERENCES [dbo].[LO_TB_PRODUTO] ([CD_PRODUTO])
GO
ALTER TABLE [dbo].[LO_TB_INSUFICIENTE] CHECK CONSTRAINT [FK_LO_TB_INSUFICIENTE_LO_TB_PRODUTOS]
GO
ALTER TABLE [dbo].[LO_TB_PRODUTO]  WITH CHECK ADD  CONSTRAINT [FK_LO_TB_PRODUTOS_LO_TB_CATEGORIA01] FOREIGN KEY([ID_CATEGORIA01])
REFERENCES [dbo].[LO_TB_CATEGORIA01] ([ID_CATEGORIA01])
GO
ALTER TABLE [dbo].[LO_TB_PRODUTO] CHECK CONSTRAINT [FK_LO_TB_PRODUTOS_LO_TB_CATEGORIA01]
GO
ALTER TABLE [dbo].[LO_TB_PRODUTO]  WITH CHECK ADD  CONSTRAINT [FK_LO_TB_PRODUTOS_LO_TB_CATEGORIA02] FOREIGN KEY([ID_CATEGORIA02])
REFERENCES [dbo].[LO_TB_CATEGORIA02] ([ID_CATEGORIA02])
GO
ALTER TABLE [dbo].[LO_TB_PRODUTO] CHECK CONSTRAINT [FK_LO_TB_PRODUTOS_LO_TB_CATEGORIA02]
GO
ALTER TABLE [dbo].[LO_TB_PRODUTO_EAN]  WITH CHECK ADD  CONSTRAINT [FK_LO_TB_PRODUTO_EAN_LO_TB_PRODUTOS] FOREIGN KEY([CD_PRODUTO])
REFERENCES [dbo].[LO_TB_PRODUTO] ([CD_PRODUTO])
GO
ALTER TABLE [dbo].[LO_TB_PRODUTO_EAN] CHECK CONSTRAINT [FK_LO_TB_PRODUTO_EAN_LO_TB_PRODUTOS]
GO
/****** Object:  StoredProcedure [dbo].[LO_SP_CATEGORIA02_I]    Script Date: 25/10/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[LO_SP_CATEGORIA02_I] 
	 @NOME VARCHAR(50)
   , @ID_CATEGORIA01 INT
AS
BEGIN
	INSERT INTO LO_TB_CATEGORIA02(
		NOME
	  , ID_CATEGORIA01
	  )VALUES(
		@NOME
	  , @ID_CATEGORIA01
	  ) 
END

GO
/****** Object:  StoredProcedure [dbo].[LO_SP_EAN_I]    Script Date: 25/10/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LO_SP_EAN_I]
	  @CD_PRODUTO INT
	, @EAN INT
	, @TAMANHO VARCHAR(2)
	, @COR VARCHAR(50)
AS
BEGIN
INSERT INTO LO_TB_PRODUTO_EAN (CD_PRODUTO
							 , EAN
							 , TAMANHO
							 , COR
							 ) 
							 VALUES( @CD_PRODUTO
								   , @EAN
								   , @TAMANHO
								   , @COR
									  )
END
GO
/****** Object:  StoredProcedure [dbo].[LO_SP_ESTOQUE_I]    Script Date: 25/10/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LO_SP_ESTOQUE_I]
	  @QUANTIDADE INT
	, @PRECO DECIMAL
	, @EAN INT
	, @ID_LOJA INT
AS
BEGIN
	INSERT INTO LO_TB_ESTOQUE(
		  QUANTIDADE 
		, PRECO 
		, EAN
		, ID_LOJA 
		) 
		VALUES (	
			  @QUANTIDADE 
			, @PRECO 
			, @EAN
			, @ID_LOJA 
		)

END
GO
/****** Object:  StoredProcedure [dbo].[LO_SP_ESTOQUE_S]    Script Date: 25/10/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LO_SP_ESTOQUE_S] 
	  @ID_LOJA INT 
	, @CD_PRODUTO INT = NULL
AS
BEGIN

	;WITH CONSULTA AS (SELECT F.ID_LOJA
							, B.EAN
							, B.COR
							, B.TAMANHO
							, F.NOME LOJA
							, B.CD_PRODUTO
							, A.PRECO
							, A.QUANTIDADE
							, C.NOME PRODUTO
							, C.DESCRICAO
							, E.NOME CAT_1
							, D.NOME CAT_2
					   FROM LO_TB_ESTOQUE A 
							JOIN LO_TB_PRODUTO_EAN B
								 ON B.EAN = A.EAN
							JOIN LO_TB_PRODUTO C 
								 ON C.CD_PRODUTO = B.CD_PRODUTO
							JOIN LO_TB_CATEGORIA02 D 
								 ON D.ID_CATEGORIA02 = C.ID_CATEGORIA02 
						    JOIN LO_TB_CATEGORIA01 E 
								 ON E.ID_CATEGORIA01 = D.ID_CATEGORIA01 
							JOIN LO_TB__LOJA F 
								 ON F.ID_LOJA = A.ID_LOJA
							WHERE F.ID_LOJA = @ID_LOJA
								  AND C.ATIVO = 1
							)

	SELECT A.LOJA
		, (SELECT B.CD_PRODUTO
				, B.EAN
				, B.CAT_1
				, B.CAT_2
				, B.PRODUTO
				, B.DESCRICAO
				, B.COR
				, B.TAMANHO
				, (SELECT C.PRECO
						, C.QUANTIDADE 
				   FROM CONSULTA C 
				   WHERE ((@CD_PRODUTO IS NULL) OR(C.CD_PRODUTO = @CD_PRODUTO))
					 AND C.CD_PRODUTO = B.CD_PRODUTO
				     AND C.ID_LOJA = A.ID_LOJA
				   FOR JSON PATH
					) AS INFOPRODUTO
		   FROM CONSULTA B
		   WHERE B.ID_LOJA = A.ID_LOJA
			AND ((@CD_PRODUTO IS NULL) OR(B.CD_PRODUTO = @CD_PRODUTO))
		   FOR JSON PATH
		  ) PRODUTO
	FROM CONSULTA A
	WHERE ((@CD_PRODUTO IS NULL) OR(A.CD_PRODUTO = @CD_PRODUTO))
	FOR JSON PATH, ROOT('LOJA')
END

GO
/****** Object:  StoredProcedure [dbo].[LO_SP_PRODUTO_I]    Script Date: 25/10/2023 17:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LO_SP_PRODUTO_I]
	  @CD_PRODUTO INT	
	, @ID_CATEGORIA01 INT
	, @ID_CATEGORIA02 INT
	, @NOME VARCHAR(50)
	, @DESCRICAO VARCHAR (255)
	, @ATIVO BIT 
AS
BEGIN

	DECLARE @CO_PRODUTO_V INT
	SELECT @CO_PRODUTO_V = CD_PRODUTO FROM LO_TB_PRODUTO

	IF @CD_PRODUTO != @CO_PRODUTO_V
	BEGIN
		INSERT INTO LO_TB_PRODUTO(
			  CD_PRODUTO
			, ID_CATEGORIA01
			, ID_CATEGORIA02
			, NOME
			, DESCRICAO
			, ATIVO
		) 
		VALUES(
			  @CD_PRODUTO 
			, @ID_CATEGORIA01 
			, @ID_CATEGORIA02 
			, @NOME 
			, @DESCRICAO 
			, @ATIVO 
		) 
	END
	ELSE
	BEGIN
		UPDATE LO_TB_PRODUTO 
			SET ID_CATEGORIA01 = @ID_CATEGORIA01
			  , ID_CATEGORIA02 = @ID_CATEGORIA02
			  , DESCRICAO = @DESCRICAO
			  , ATIVO = @ATIVO
	END
END

GO
USE [master]
GO
ALTER DATABASE [LOJA_ONLINE] SET  READ_WRITE 
GO
