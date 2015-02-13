using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlackEvePingPlugin {
	internal static partial class DataLayer {
	private const string UserMappingSQL =
	@"
IF NOT EXISTS(SELECT * FROM sys.tables WHERE [object_id] = OBJECT_ID('[dbo].[UserMapping]'))
BEGIN

	CREATE TABLE [dbo].[UserMapping](
		[UserID] [nvarchar](100) NOT NULL,
		[KeyID] [nvarchar](100) NULL,
		[vCode] [nvarchar](1000) NULL,
		[LastPing] [datetime2] NULL
	 CONSTRAINT [PK_UserMapping_UserID] PRIMARY KEY CLUSTERED ([UserID] ASC)
	)

	CREATE INDEX IDX_UserMapping_LastPing ON [dbo].[UserMapping](LastPing)
END
	";

	}
}
