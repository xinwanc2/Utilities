DROP PROCEDURE IF EXISTS [dbo].[proc_GetContactById]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_GetContactById]
	@Id INT
AS
BEGIN

	SET NOCOUNT ON;

	SELECT id AS Id,
           f_name AS Name,
           f_phone_no AS PhoneNo,
           f_address AS Address
	FROM t_contact WITH (NOLOCK)
	WHERE id = @Id
END
GO