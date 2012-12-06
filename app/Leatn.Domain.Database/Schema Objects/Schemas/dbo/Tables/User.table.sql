CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Forename] [nvarchar](100) NULL,
	[Surname] [nvarchar](100) NULL,
	[Username] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[PasswordHash] [nvarchar](100) NULL,
	[PasswordSalt] [nvarchar](100) NULL,
	[IsActive] [bit] NOT NULL
)