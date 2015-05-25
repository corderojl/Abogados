USE [db_velaychu]
GO
/****** Object:  StoredProcedure [dbo].[uspExpedienteTraer]    Script Date: 24/05/2015 17:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure uspExpedienteAdicionar
@CodigoExpediente int
           ,@NumeroExpediente varchar(50)
           ,@FechaRegistro date
           ,@CodigoCliente int
           ,@CodigoMateria int
           ,@CodigoJuzgado int
           ,@CodigoEspecialista int
           ,@CodigoSala int
           ,@Activo bit
as
INSERT INTO [dbo].[Expedientes]
           ([CodigoExpediente]
           ,[NumeroExpediente]
           ,[FechaRegistro]
           ,[CodigoCliente]
           ,[CodigoMateria]
           ,[CodigoJuzgado]
           ,[CodigoEspecialista]
           ,[CodigoSala]
           ,[Activo])
     VALUES
           (@CodigoExpediente 
           ,@NumeroExpediente 
           ,@FechaRegistro 
           ,@CodigoCliente 
           ,@CodigoMateria 
           ,@CodigoJuzgado 
           ,@CodigoEspecialista 
           ,@CodigoSala 
           ,@Activo)
  
  go
  
create procedure uspExpedienteActualizar
			@CodigoExpediente int
           ,@NumeroExpediente varchar(50)
           ,@FechaRegistro date
           ,@CodigoCliente int
           --,@CodigoMateria int
           ,@CodigoJuzgado int
           ,@CodigoEspecialista int
           ,@CodigoSala int
         
as
UPDATE [Expedientes]
   SET [NumeroExpediente] = @NumeroExpediente
      ,[FechaRegistro] = @FechaRegistro
     -- ,[CodigoCliente] = @CodigoCliente
      --,[CodigoMateria] = @CodigoMateria
      ,[CodigoJuzgado] = @CodigoJuzgado
      ,[CodigoEspecialista] = @CodigoEspecialista
      ,[CodigoSala] = @CodigoSala
  where CodigoExpediente=@CodigoExpediente
  go

 ALTER procedure [dbo].[uspBuscarContratoByExpediente]
@CodigoExpediente int
as
SELECT EC.[CodigoContrato]
,EC.CodigoExpedienteContrato
,C.DescripcionContrato
      ,'' as 'Porc'
  FROM [ExpedienteContrato] EC, Contrato C
Where EC.[CodigoContrato]=C.[CodigoContrato] 
and EC.CodigoExpediente = @CodigoExpediente
go

create procedure uspDocumentoClienteBuscarByExpedienteContrato
@CodigoExpedienteContrato int
as
SELECT [CodigoDocumentoCliente] ID
      --,[CodigoExpedienteContrato]
	  ,D.[DescripcionDocumento]
      ,[Presento]
  FROM [DocumentosCliente] DC, Documento D
Where  DC.[CodigoDocumento]=D.[CodigoDocumento]
and CodigoExpedienteContrato = @CodigoExpedienteContrato
Go
