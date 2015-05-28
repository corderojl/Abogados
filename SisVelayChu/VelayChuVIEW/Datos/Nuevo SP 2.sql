USE db_velaychu
GO

create procedure uspExpedienteContratoAdicionar
 @CodigoExpediente int
,@CodigoContrato int
as
INSERT INTO ExpedienteContrato
           (CodigoExpediente
           ,CodigoContrato)
     VALUES
           (@CodigoExpediente 
           ,@CodigoContrato )
DECLARE @MyVar int
SET @myvar = @@identity

  INSERT INTO DocumentosCliente
		(CodigoExpedienteContrato
           ,CodigoDocumento
		   ,Presento
           )
		SELECT @myvar, CodigoDocumento, 0 FROM ContratoDocumento where codigocontrato=@codigocontrato;  
select @myvar as CodigoExpedienteContrato
go


create procedure uspDocumentosClienteCambiar
 @CodigoDocumentoCliente int
,@presento bit
as
update DocumentosCliente
set Presento=@presento
where CodigoDocumentoCliente=@CodigoDocumentoCliente
go

ALTER procedure [dbo].[uspListarDetalleExpedienteByContrato]
@CodigoContrato int
as
SELECT  [CodigoDetalleExpediente] ID    
	  ,E.DescripcionEvento Evento    
	  ,ET.DescripcionEtapa Etapa
	  ,ET.Orden 
      ,[Fecha]
      ,[Estado]
	  ,U.NombreCompleto Especialista
	  ,E.ColorEvento Color
  FROM [DetalleExpediente] DE, Evento E, Etapa ET, Usuario U
  where DE.CodigoEvento=E.CodigoEvento
  and DE.CodigoEtapa=ET.CodigoEtapa
  and DE.CodigoUsuario=U.CodigoUsuario
  and CodigoContrato=@CodigoContrato
  GO

  
CREATE TABLE [dbo].[DetalleExpediente](
	[CodigoDetalleExpediente] [int] IDENTITY(1,1) NOT NULL,
	[CodigoContrato] [int] NOT NULL,
	[CodigoEvento] [int] NOT NULL,
	[CodigoEtapa] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Estado] [varchar](350) NULL,
	[CodigoUsuario] [int] NULL,
	[FechaImpulso] [date] NULL,
	[CodigoUsuarioImpulso] [int] NULL,
 CONSTRAINT [PK_DetalleExpediente_1] PRIMARY KEY CLUSTERED 
(
	[CodigoDetalleExpediente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[DetalleExpediente]  WITH CHECK ADD  CONSTRAINT [FK_DetalleExpediente_Contrato] FOREIGN KEY([CodigoContrato])
REFERENCES [dbo].[Contrato] ([CodigoContrato])
GO

ALTER TABLE [dbo].[DetalleExpediente] CHECK CONSTRAINT [FK_DetalleExpediente_Contrato]
GO

ALTER TABLE [dbo].[DetalleExpediente]  WITH CHECK ADD  CONSTRAINT [FK_DetalleExpediente_Etapa] FOREIGN KEY([CodigoEtapa])
REFERENCES [dbo].[Etapa] ([CodigoEtapa])
GO

ALTER TABLE [dbo].[DetalleExpediente] CHECK CONSTRAINT [FK_DetalleExpediente_Etapa]
GO

ALTER TABLE [dbo].[DetalleExpediente]  WITH CHECK ADD  CONSTRAINT [FK_DetalleExpediente_Evento] FOREIGN KEY([CodigoEvento])
REFERENCES [dbo].[Evento] ([CodigoEvento])
GO

ALTER TABLE [dbo].[DetalleExpediente] CHECK CONSTRAINT [FK_DetalleExpediente_Evento]
GO

ALTER TABLE [dbo].[DetalleExpediente]  WITH CHECK ADD  CONSTRAINT [FK_DetalleExpediente_Usuario] FOREIGN KEY([CodigoUsuario])
REFERENCES [dbo].[Usuario] ([CodigoUsuario])
GO

ALTER TABLE [dbo].[DetalleExpediente] CHECK CONSTRAINT [FK_DetalleExpediente_Usuario]
GO

ALTER TABLE [dbo].[DetalleExpediente]  WITH CHECK ADD  CONSTRAINT [FK_DetalleExpediente_Usuario1] FOREIGN KEY([CodigoUsuarioImpulso])
REFERENCES [dbo].[Usuario] ([CodigoUsuario])
GO

ALTER TABLE [dbo].[DetalleExpediente] CHECK CONSTRAINT [FK_DetalleExpediente_Usuario1]
GO


