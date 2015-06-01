USE [db_velaychu]

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
and EC.Activo=1
Go

 create procedure uspExpedienteContratoEliminar
@CodigoExpedienteContrato int
as
update ExpedienteContrato set
Activo=0
Where CodigoExpedienteContrato = @CodigoExpedienteContrato
Go

CREATE TABLE [dbo].[ExpedienteContrato](
	[CodigoExpedienteContrato] [int] IDENTITY(1,1) NOT NULL,
	[CodigoExpediente] [int] NOT NULL,
	[CodigoContrato] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_ExpedienteContrato] PRIMARY KEY CLUSTERED 
(
	[CodigoExpedienteContrato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ExpedienteContrato] ADD  CONSTRAINT [DF_ExpedienteContrato_Activo]  DEFAULT ((1)) FOR [Activo]
GO

ALTER TABLE [dbo].[ExpedienteContrato]  WITH CHECK ADD  CONSTRAINT [FK_ExpedienteContrato_Contrato] FOREIGN KEY([CodigoContrato])
REFERENCES [dbo].[Contrato] ([CodigoContrato])
GO

ALTER TABLE [dbo].[ExpedienteContrato] CHECK CONSTRAINT [FK_ExpedienteContrato_Contrato]
GO

ALTER TABLE [dbo].[ExpedienteContrato]  WITH CHECK ADD  CONSTRAINT [FK_ExpedienteContrato_Expedientes] FOREIGN KEY([CodigoExpediente])
REFERENCES [dbo].[Expedientes] ([CodigoExpediente])
GO

ALTER TABLE [dbo].[ExpedienteContrato] CHECK CONSTRAINT [FK_ExpedienteContrato_Expedientes]
GO


