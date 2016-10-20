
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerUsuariosYSiEsMiAmigo]

@IDUsuario int
AS
	
SELECT us.UsuarioNombre + ' ' + us.UsuarioApellido as UsuarioNombreApellido
	 , us.UsuarioFoto
	 , CASE 
		WHEN EXISTS (SELECT *
					  FROM Amigo 
					   WHERE UsuarioID = @IDUsuario AND UsuarioIDAmigo = US.UsuarioID) THEN 1
		ELSE 0
	  END AS EsAmigo
FROM Usuario us
WHERE us.UsuarioID <> @IDUsuario

