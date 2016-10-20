USE [RedSocialOrt]
GO
/****** Object:  StoredProcedure [dbo].[AmigosBuscarPorUserId]    Script Date: 19/10/2016 10:11:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[AmigosBuscarPorUserId]

@IDUsuario int

AS

SELECT TOP 4 am.UsuarioIDAmigo,
			 am.FechaAlta, 
			 us.UsuarioNombre,
			 us.UsuarioApellido,
			 us.UsuarioEmail,
			 us.UsuarioFoto,
			 us.UsuarioFechaNacimiento,
			 us.UsuarioTrabajo,
			 us.UsuarioProvincia,
			 us.UsuarioSexo
FROM Amigo am
INNER JOIN Usuario us ON us.UsuarioID= am.UsuarioID
where am.UsuarioID = @IDUsuario
ORDER BY RAND()
