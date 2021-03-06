USE db_velaychu
GO
			
create procedure uspDetalleExpedienteAdicionar
			@CodigoContrato int
           ,@CodigoEvento int
           ,@CodigoEtapa int
           ,@Fecha date
           ,@Estado varchar(350)
           ,@CodigoUsuario int
           ,@FechaImpulso date
           ,@CodigoUsuarioImpulso int
as
INSERT INTO DetalleExpediente
           (CodigoContrato
           ,CodigoEvento
           ,CodigoEtapa
           ,Fecha
           ,Estado
           ,CodigoUsuario
           ,FechaImpulso
           ,CodigoUsuarioImpulso)
     VALUES
           (@CodigoContrato 
           ,@CodigoEvento 
           ,@CodigoEtapa 
           ,@Fecha 
           ,@Estado 
           ,@CodigoUsuario 
           ,@FechaImpulso 
           ,@CodigoUsuarioImpulso)
GO

create procedure uspDetalleExpedienteActualizar
			@CodigoDetalleExpediente int
		   ,@CodigoContrato int
           ,@CodigoEvento int
           ,@CodigoEtapa int
           ,@Fecha date
           ,@Estado varchar(350)
           ,@CodigoUsuario int
           ,@FechaImpulso date
           ,@CodigoUsuarioImpulso int
as
UPDATE dbo.DetalleExpediente
   SET CodigoContrato = @CodigoContrato
      ,CodigoEvento = @CodigoEvento
      ,CodigoEtapa = @CodigoEtapa
      ,Fecha = @Fecha
      ,Estado = @Estado
      ,CodigoUsuario = @CodigoUsuario
      ,FechaImpulso = @FechaImpulso
      ,CodigoUsuarioImpulso = @CodigoUsuarioImpulso
 WHERE CodigoDetalleExpediente=@CodigoDetalleExpediente
GO

create procedure uspDetalleExpedienteTraer
@CodigoDetalleExpediente int
as
SELECT CodigoDetalleExpediente
      ,CodigoContrato
      ,CodigoEvento
      ,CodigoEtapa
      ,Fecha
      ,Estado
      ,CodigoUsuario
      ,FechaImpulso
      ,CodigoUsuarioImpulso
  FROM DetalleExpediente
  where @CodigoDetalleExpediente=CodigoDetalleExpediente

  Go