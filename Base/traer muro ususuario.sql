USE [RedSocialOrt]
GO
/****** Object:  StoredProcedure [dbo].[MuroInfoBuscarPorUserId]    Script Date: 19/10/2016 10:06:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[MuroInfoBuscarPorUserId]

@IDUsuario int

AS

SELECT TOP 10 us.UsuarioNombre + ' ' + us.UsuarioApellido as Remitente
			,mu.Mensaje
			, mu.Fecha
			, us.UsuarioFoto as RemitenteFoto
FROM Muro mu
INNER JOIN Usuario us on us.UsuarioID=mu.IDUsuario
WHERE IDUsuario = @IDUsuario
ORDER BY Fecha Desc
