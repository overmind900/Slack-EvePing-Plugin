IF NOT EXISTS (SELECT * FROM sys.tables WHERE [object_id] = OBJECT_ID('[dbo].[UserMapping]'))
BEGIN
	CREATE TABLE [dbo].[UserMapping](
		[UserID] [nvarchar](100) NOT NULL,
		[KeyID] [nvarchar](100) NULL,
		[vCode] [nvarchar](1000) NULL,
		[KeyType] [nvarchar](50) NULL
	 CONSTRAINT [PK_UserMapping_UserID] PRIMARY KEY CLUSTERED ([UserID] ASC)
	)
END

IF NOT EXISTS (SELECT * FROM sys.tables WHERE [object_id] = OBJECT_ID('[dbo].[Log]'))
BEGIN
	CREATE TABLE [dbo].[Log](
		[DateTime] [datetime2](7) NOT NULL,
		[Message] [nvarchar](max) NOT NULL,
		CONSTRAINT [PK_Log_DateTime] PRIMARY KEY CLUSTERED ([DateTime] ASC)
	)
END
