DROP PROCEDURE IF EXISTS [dbo].[proc_GetContacts]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_GetContacts]
	@Name    VARCHAR(50),
	@PhoneNo VARCHAR(11),
	@Address VARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @query        NVARCHAR(MAX) = ''
	DECLARE @extraCond	  NVARCHAR(MAX) = ''

	IF @Name <> ''
		SET @extraCond += 'AND f_name LIKE ''%'' + @Name + ''%'' '

	IF @PhoneNo <> ''
		SET @extraCond += 'AND f_phone_no LIKE ''%'' + @PhoneNo + ''%'' '

	IF @Address <> ''
		SET @extraCond += 'AND f_address LIKE ''%'' + @Address + ''%'' '

	SET @query = N'	SELECT	id AS Id,
							f_name AS Name,
							f_phone_no AS PhoneNo,
							f_address AS Address
					FROM t_contact WITH (NOLOCK) 
					WHERE f_deleted = 0 ' + 
					@extraCond
				
	EXEC sp_executesql	@query,
					N'	@Name		VARCHAR(50), 
						@PhoneNo    VARCHAR(11),
						@Address    VARCHAR(50) ',
						@Name,
						@PhoneNo,
						@Address
END
GO