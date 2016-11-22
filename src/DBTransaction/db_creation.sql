CREATE TABLE [dbo].[TRANSACTION_LOG_1](
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Key] UNIQUEIDENTIFIER NOT NULL,
	[CreationDate] DATETIME NOT NULL DEFAULT GETDATE()
)

CREATE TABLE [dbo].[TRANSACTION_LOG_2](
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Key] UNIQUEIDENTIFIER NOT NULL,
	[CreationDate] DATETIME NOT NULL DEFAULT GETDATE()
)