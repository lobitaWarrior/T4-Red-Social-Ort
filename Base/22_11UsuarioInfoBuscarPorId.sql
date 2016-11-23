USE [RedSocialORT22AGrupo01]
GO

/****** Object:  StoredProcedure [dbo].[UsuarioInfoBuscarPorId]    Script Date: 22/11/2016 8:43:43 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[UsuarioInfoBuscarPorId]

@IDUsuario int

AS

SELECT US.UsuarioID	
	,US.UsuarioApellido
	, US.UsuarioNombre
	,US.UsuarioEmail
	,US.UsuarioFechaNacimiento
	, US.UsuarioSexo
	, IU.Estudia
	, IU.Trabajo
	, IU.Vive
	, IU.EstadoCivil
	, US.UsuarioFoto
FROM	InfoUsuario IU
INNER JOIN Usuario US ON US.UsuarioID=IU.UsuarioID
WHERE	US.UsuarioID = @IDUsuario


GO


