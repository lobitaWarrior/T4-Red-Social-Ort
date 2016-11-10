USE [RedSocialORT22AGrupo01]
GO
/****** Object:  StoredProcedure [dbo].[ModificarInfoUsuario]    Script Date: 9/11/2016 9:45:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ModificarInfoUsuario]
@Apellido varchar(100),
@Email nvarchar(100),
@FechaNacimiento datetime,
@Nombre nvarchar(100),
@Sexo	nchar(1),
@IDUsuario int,
@Trabaja varchar(150),
@Estudia varchar(200),
@Vive varchar(150),
@EstadoCivil varchar(50),
@IDUsuarioEstadoCivil int 

AS

UPDATE [dbo].Usuario
	SET [UsuarioApellido]=@Apellido,
		[UsuarioEmail]=@Email,
		[UsuarioFechaNacimiento]=@FechaNacimiento,
		[UsuarioNombre]=@Nombre,
		[UsuarioSexo]=@Sexo,
		[UsuarioFechaActualizacion]=GETDATE()
	WHERE UsuarioID=@IDUsuario
		

UPDATE [dbo].[InfoUsuario]
   SET [Trabajo] = @Trabaja, 
	   [Estudia] = @Estudia, 
	   [Vive] = @Vive,
       [EstadoCivil] = @EstadoCivil,
       [IDUsuarioEstadoCivil] = @IDUsuarioEstadoCivil
 WHERE UsuarioID = @IDUsuario
