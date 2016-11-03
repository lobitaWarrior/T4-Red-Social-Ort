USE [RedSocialORT22AGrupo01]
GO
/****** Object:  StoredProcedure [dbo].[MuroInfoBuscarPorUserId]    Script Date: 2/11/2016 9:14:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[MuroInfoBuscarPorUserId]

@IDUsuario int

AS

SELECT TOP 10 (SELECT usu.UsuarioNombre + ' ' + usu.UsuarioApellido 
				FROM Usuario usu 
					WHERE usu.UsuarioID=mu.IDUsuarioRemitente) as Remitente
			,mu.Mensaje
			, mu.Fecha
			, us.UsuarioFoto as RemitenteFoto
FROM Muro mu
INNER JOIN Usuario us on us.UsuarioID=mu.IDUsuario
WHERE IDUsuario = @IDUsuario
ORDER BY Fecha Desc
