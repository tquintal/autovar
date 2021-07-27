/*
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Automoveis]') AND type in (N'U'))
DROP TABLE [dbo].[Automoveis]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Media]') AND type in (N'U'))
DROP TABLE [dbo].[Media]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Utilizador]') AND type in (N'U'))
DROP TABLE [dbo].[Utilizador]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Marca]') AND type in (N'U'))
DROP TABLE [dbo].[Marca]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Modelo]') AND type in (N'U'))
DROP TABLE [dbo].[Modelo]
GO

SELECT * FROM Automoveis
SELECT * FROM Marca
SELECT * FROM Modelo
SELECT * FROM Utilizador
*/

/* TABELA UTILIZADOR */ 
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Utilizador]') AND type in (N'U'))
DROP TABLE [dbo].[Utilizador]
GO

CREATE TABLE [dbo].[Utilizador](

	--[ID] [int] NOT NULL IDENTITY(1,1),
	[ID] [int] NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[NIF] [int] NOT NULL,
	[Contacto] [int] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Tipo] [int] NOT NULL,
	[Password] [nvarchar](50) NOT NULL

CONSTRAINT [PK_Utilizador] PRIMARY KEY CLUSTERED 
([ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

INSERT INTO [dbo].[Utilizador]
	([ID], [Nome],[NIF],[Contacto],[Email],[Tipo],[Password])
     VALUES
	(123321, 'Tomás Quintal', 123456789, 911111111, 'tquintal@mail.com', 1, 'extrasecurepassword1'),
	(321123, 'André Coval', 987654321, 922222222, 'acoval@mail.com', 2, 'extrasecurepassword2')
GO 

/* TABELA MARCA */
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Marca]') AND type in (N'U'))
DROP TABLE [dbo].[Marca]
GO

CREATE TABLE [dbo].[Marca](

	--[ID] [int] NOT NULL IDENTITY(1,1),
	[ID] [int] NOT NULL,
	[Descricao] [varchar](50) NOT NULL

CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
([ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

INSERT INTO [dbo].[Marca]
           ([ID], [Descricao])
VALUES
	(1, 'Nissan'), 
	(2, 'BMW'), 
	(3, 'Toyota'), 
	(4, 'Opel'),
	(5, 'Mini'), 
	(6, 'Honda'),
	(7, 'Audi'),
	(8, 'Volkswagen'),
	(9, 'Tesla')

GO

/* TABELA MODELO */
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Modelo]') AND type in (N'U'))
DROP TABLE [dbo].[Modelo]
GO

CREATE TABLE [dbo].[Modelo](

	--[ID] [int] NOT NULL IDENTITY(1,1),
	[ID] [int] NOT NULL,
	[IDMarca] [int] NOT NULL,
	[Descricao] [varchar](50) NOT NULL

	FOREIGN KEY (IDMarca) REFERENCES Marca(ID),

CONSTRAINT [PK_Modelo] PRIMARY KEY CLUSTERED 
([ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

INSERT INTO [dbo].[Modelo]
           ( [ID], [IDMarca], [Descricao] )
VALUES
	(1, 1, 'Primera'),
	(2, 2, '335i'),
	(3, 3, 'Supra'),
	(4, 4, 'Corsa'),
	(5, 5, 'JCW'),
	(6, 6, 'Civic'),
	(7, 1, 'Juke'),
	(8, 1, 'Qashqai'),
	(9, 5, '1100'),
	(10, 7, 'TT'),
	(11, 8, 'Golf'),
	(12, 9,'Model 3')

GO

/* TABELA AUTOMOVEIS */
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Automoveis]') AND type in (N'U'))
DROP TABLE [dbo].[Automoveis]
GO

CREATE TABLE [dbo].[Automoveis](

	[ID] [int] NOT NULL,

	/* NULL / NOT NULL ?? */
	[IDUtilizador] [int] NOT NULL,
	[IDMarca] [int] NOT NULL,
	[IDModelo] [int] NOT NULL,
	[Ano] [int] NOT NULL,
	[KMS] [int] NULL,
	[Condicao] [nvarchar] (15) NOT NULL,
	[Portas] [int] NOT NULL,
	[Combustivel] [nvarchar](20) NOT NULL,
	[Preco] [float] NOT NULL,
	[MediaURL] [nvarchar](225) NULL,
	[DataEntrada] [date] NULL, 
	[DataVenda] [date] NULL,

	FOREIGN KEY (IDUtilizador) REFERENCES Utilizador(ID),
	FOREIGN KEY (IDMarca) REFERENCES Marca(ID),
	FOREIGN KEY (IDModelo) REFERENCES Modelo(ID),

CONSTRAINT [PK_Automoveis] PRIMARY KEY CLUSTERED 
([ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

INSERT INTO [dbo].[Automoveis]
           ([ID], [IDUtilizador], [IDMarca], [IDModelo], [Ano], [KMS], [Condicao], [Portas], [Combustivel], [Preco], [MediaURL], [DataEntrada], [DataVenda])
     VALUES
		   (1, 123321, 5, 9, 1976, 100000, 'Usado', 3, 'Gasolina', 3500, '..\Images\automoveis\mini_andre.jpg', '2020-07-09', NULL),
		   (2, 123321, 4, 4, 1986, 101100, 'Usado', 3, 'Gasolina', 750, '..\Images\automoveis\corsa_tomas.jpg', '2020-07-09', NULL),
		   (3, 123321, 8, 11, 1999, 100000, 'Usado', 5, 'Gasolina', 3500, '..\Images\automoveis\golf_marcio.jpg', '2020-07-09', NULL),
		   (4, 123321, 7, 10, 2008, 100000, 'Usado', 3, 'Diesel', 15000, '..\Images\automoveis\tt_andre.jpeg', '2020-07-09', NULL),
           (8, 123321, 1, 1, 1991, 153000, 'Usado', 5, 'Gasolina', 949, '..\Images\automoveis\nissan_primera.jpg', '2020-02-02', NULL),
           (9, 321123, 2, 2, 2008, 50000, 'Usado', 3, 'Gasolina', 27000, '..\Images\automoveis\335i.jpg', '2020-02-02', NULL),
           (10, 123321, 3, 3, 1999, 43000, 'Usado', 3, 'Gasolina', 100000, '..\Images\automoveis\supra.jpg', '2020-02-02', NULL),
           (11, 321123, 4, 4, 1986, 101001, 'Usado', 3, 'Gasolina', 650, '..\Images\automoveis\corsa_opc.jpg', '2020-02-02', NULL),
           (12, 123321, 5, 5, 2010, 41000, 'Usado', 3, 'Gasolina', 15000, '..\Images\automoveis\mini_jcw.jpg', '2020-02-02', NULL),
           (13, 321123, 6, 6, 2001, 131000, 'Usado', 3, 'Gasolina', 3000, '..\Images\automoveis\civic.jpg', '2020-02-02', NULL),
		   (14, 123321, 1, 7, 2010, 100000, 'Usado', 5, 'Diesel', 10000, '..\Images\automoveis\qashqai.jpg', '2020-02-02', NULL),
		   (15, 321123, 1, 8, 2012, 90000, 'Usado', 5, 'Diesel', 10500, '..\Images\automoveis\qashqai.jpg', '2020-02-02', NULL),
		   (16, 321123, 1, 8, 2012, 90000, 'Usado', 5, 'Diesel', 10500, '..\Images\automoveis\qashqai.jpg', '2020-02-02', NULL),
		   (17, 321123, 1, 8, 2012, 90000, 'Usado', 5, 'Diesel', 10500, '..\Images\automoveis\qashqai.jpg', '2020-02-02', NULL),
		   (18, 321123, 1, 8, 2012, 90000, 'Usado', 5, 'Diesel', 10500, '..\Images\automoveis\qashqai.jpg', '2020-02-02', NULL),
		   (19, 321123, 1, 8, 2012, 90000, 'Usado', 5, 'Diesel', 10500, '..\Images\automoveis\qashqai.jpg', '2020-02-02', NULL),
		   (20, 321123, 1, 8, 2012, 90000, 'Usado', 5, 'Diesel', 10500, '..\Images\automoveis\qashqai.jpg', '2020-02-02', NULL),
		   (21, 321123, 1, 8, 2012, 90000, 'Usado', 5, 'Diesel', 10500, '..\Images\automoveis\qashqai.jpg', '2020-02-02', NULL),
		   (22, 321123, 1, 8, 2012, 90000, 'Usado', 5, 'Diesel', 10500, '..\Images\automoveis\qashqai.jpg', '2020-02-02', NULL),
		   (23, 321123, 1, 8, 1991, 234956, 'Usado', 5, 'Diesel', 10500, '..\Images\automoveis\qashqai.jpg', '2020-02-02', NULL),
		   (24, 321123, 1, 8, 1992, 234956, 'Usado', 5, 'Diesel', 10500, '..\Images\automoveis\qashqai.jpg', '2020-02-02', NULL)
GO

/* STORE PROCEDURES */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Eliminar_Todos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Eliminar_Todos]
GO

CREATE PROCEDURE [dbo].[Eliminar_Todos]
AS
DELETE FROM Automoveis;
GO

/*
SELECT * FROM Automoveis
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Guardar_Automovel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Guardar_Automovel]
GO

CREATE Procedure [dbo].[Guardar_Automovel]
@ID int,
@IDUtilizador int,
@IDMarca int,
@IDModelo int,
@Ano int,
@KMS int,
@Condicao nvarchar(15),
@Portas int,
@Combustivel nvarchar(20),
@Preco float,
@MediaURL nvarchar(225),
@DataEntrada date,
@DataVenda date = NULL

As 
Begin

Begin Transaction
If (Select Count(*) From Automoveis Where ID=@ID)=0
      Begin
         Insert Into Automoveis (ID, IDUtilizador, IDMarca, IDModelo, Ano, KMS, Condicao, Portas, Combustivel, Preco, MediaURL, DataEntrada, DataVenda)
         Values (@ID, @IDUtilizador, @IDMarca, @IDModelo, @Ano, @KMS, @Condicao, @Portas, @Combustivel, @Preco, @MediaURL, @DataEntrada, @DataVenda)

      End

	  Else
	  Begin
	  Update Automoveis
	  Set IDUtilizador=@IDUtilizador , IDMarca=@IDMarca, IDModelo=@IDModelo, Ano=@Ano, KMS=@KMS, Condicao=@Condicao, Portas=@Portas, Combustivel=@Combustivel, Preco=@Preco, MediaURL=@MediaURL, DataEntrada=@DataEntrada, DataVenda=@DataVenda
	  Where ID=@ID
	  
	  End
 
      If @@error <>0
            Begin
               Rollback transaction
            End
      Else
            Begin
               Commit Transaction
            End
End
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Obter_Automovel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Obter_Automovel]
GO

CREATE Procedure [dbo].[Obter_Automovel]
@ID int
As 
Begin

	SELECT Automoveis.ID, Automoveis.IDUtilizador, Automoveis.Ano, Automoveis.KMS, Automoveis.Condicao, Automoveis.Portas, Automoveis.Combustivel, Automoveis.Preco, Automoveis.MediaURL, 
	Automoveis.DataEntrada, Automoveis.DataVenda, Marca.Descricao, Modelo.Descricao
	FROM Automoveis, Marca, Modelo, Utilizador Where Automoveis.ID=@ID and Automoveis.IDModelo = Modelo.ID and Automoveis.IDMarca = Marca.ID and Automoveis.IDUtilizador = Utilizador.ID

End
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Obter_Automoveis]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Obter_Automoveis]
GO

CREATE Procedure [dbo].[Obter_Automoveis]
As 
Begin

	SELECT Automoveis.ID, Automoveis.IDUtilizador, Automoveis.IDMarca, Automoveis.IDModelo, Automoveis.Ano, Automoveis.KMS, Automoveis.Condicao, Automoveis.Portas, Automoveis.Combustivel, Automoveis.Preco, Automoveis.MediaURL, 
	Automoveis.DataEntrada, Automoveis.DataVenda, Marca.Descricao as DescricaoMarca, Modelo.Descricao as DescricaoModelo
	FROM Automoveis, Marca, Modelo, Utilizador Where Automoveis.IDMarca=Marca.ID and Automoveis.IDModelo=Modelo.ID and Automoveis.IDUtilizador = Utilizador.ID
	
End

GO

/* É NECESSÁRIO ELIMINAR A MEDIA DO AUTOMOVEL...? */
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Eliminar_Automovel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Eliminar_Automovel]
GO

CREATE Procedure [dbo].[Eliminar_Automovel]
@ID int
AS
Begin

Begin Transaction
      If (Select Count(*) From Automoveis Where ID=@ID)<>0
          Begin
              Delete from Automoveis
              Where ID=@ID
            End

       If @@error <>0
               Begin 
                  Rollback TRansaction
               End
       Else
            Begin
               Commit Transaction
            End

End
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Obter_Marca]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Obter_Marca]
GO

CREATE Procedure [dbo].[Obter_Marca]
@ID int
As 
Begin

	SELECT ID, Descricao
	FROM Marca Where Marca.ID=@ID

End
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Obter_Marcas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Obter_Marcas]
GO

CREATE Procedure [dbo].[Obter_Marcas]
As 
Begin

	SELECT ID, Descricao
	FROM Marca

End
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Obter_Modelo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Obter_Modelo]
GO

CREATE Procedure [dbo].[Obter_Modelo]
@ID int
As 
Begin

	SELECT Modelo.ID, Marca.ID, Modelo.Descricao
	FROM Modelo, Marca Where Modelo.ID=@ID

End
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Obter_Modelos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Obter_Modelos]
GO

CREATE Procedure [dbo].[Obter_Modelos]
As 
Begin

	SELECT ID, IDMarca, Descricao
	FROM Modelo

End
GO