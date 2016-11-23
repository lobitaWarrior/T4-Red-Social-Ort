USE [RedSocialORT22AGrupo01]
GO

/****** Object:  StoredProcedure [dbo].[AmigosBuscarPorUserId]    Script Date: 22/11/2016 8:49:30 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[AmigosBuscarPorUserId]

@IDUsuario int

AS

SELECT TOP 4 am.UsuarioIDAmigo
			,usu.UsuarioNombre
			,usu.UsuarioApellido
			,usu.UsuarioEmail
			,usu.UsuarioFoto
			,usu.UsuarioFechaNacimiento
			,iu.Trabajo AS UsuarioTrabajo
			,iu.Vive AS UsuarioProvincia
			,usu.UsuarioFoto
			,usu.UsuarioSexo
FROM Amigo am
INNER JOIN Usuario usu ON usu.UsuarioID= am.UsuarioIDAmigo
LEFT JOIN InfoUsuario iu ON iu.UsuarioID = usu.UsuarioID
WHERE am.UsuarioID = @IDUsuario
ORDER BY RAND()

GO


