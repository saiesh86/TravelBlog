
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[mp_UserProperties]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
DROP TABLE [dbo].[mp_UserProperties]
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[mp_UserProperties]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[mp_UserProperties](
	[PropertyID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_mp_UserProperties_PropertyID]  DEFAULT (newid()),
	[UserGuid] [uniqueidentifier] NOT NULL,
	[PropertyName] [nvarchar](255) NULL,
	[PropertyValueString] [ntext] NULL,
	[PropertyValueBinary] [image] NULL,
	[LastUpdatedDate] [datetime] NOT NULL CONSTRAINT [DF_mp_UserProperties_LastUpdatedDate]  DEFAULT (getdate()),
	[IsLazyLoaded] [bit] NOT NULL CONSTRAINT [DF_mp_UserProperties_IsLazyLoaded]  DEFAULT ((0)),
 CONSTRAINT [PK_mp_UserProperties] PRIMARY KEY CLUSTERED 
(
	[PropertyID] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE id=OBJECT_ID('tempdb..#tmpErrors')) DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRANSACTION
GO
PRINT N'Altering [dbo].[mp_Pages]'
GO
ALTER TABLE [dbo].[mp_Pages] ADD
[PageTitle] [nvarchar] (255)  NULL,
[AllowBrowserCache] [bit] NOT NULL CONSTRAINT [DF_mp_Pages_AllowBrowserCache] DEFAULT ((1))
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT 'The database update succeeded'
COMMIT TRANSACTION
END
ELSE PRINT 'The database update failed'
GO
DROP TABLE #tmpErrors
GO


SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE id=OBJECT_ID('tempdb..#tmpErrors')) DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRANSACTION
GO
PRINT N'Altering [dbo].[mp_ModuleDefinitions]'
GO
ALTER TABLE [dbo].[mp_ModuleDefinitions] ADD
[DefaultCacheTime] [int] NOT NULL CONSTRAINT [DF_mp_ModuleDefinitions_DefaultCacheTime] DEFAULT ((0))
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT 'The database update succeeded'
COMMIT TRANSACTION
END
ELSE PRINT 'The database update failed'
GO
DROP TABLE #tmpErrors
GO




