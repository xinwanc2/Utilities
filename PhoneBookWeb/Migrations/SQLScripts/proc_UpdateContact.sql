DROP PROCEDURE IF EXISTS [dbo].[proc_UpdateContact]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_UpdateContact]
	@Id      INT,
	@Name    VARCHAR(50),
	@PhoneNo VARCHAR(11),
	@Address VARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS (
		SELECT 1
		FROM t_contact WITH (NOLOCK)
		WHERE f_phone_no = @PhoneNo
		AND f_deleted = 0
	)
	BEGIN
		SELECT 2;
		RETURN;
	END 

	UPDATE t_contact WITH (ROWLOCK) 
	SET f_name = @Name,
	    f_phone_no = @PhoneNo,
		f_address = @Address
	WHERE id = @Id
	AND f_deleted = 0;

	IF @@ROWCOUNT = 0
	BEGIN
		SELECT 1;
		RETURN;
	END
END
GO