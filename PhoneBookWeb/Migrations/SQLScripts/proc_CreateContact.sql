DROP PROCEDURE IF EXISTS [dbo].[proc_CreateContact]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_CreateContact]
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
		RETURN;
	END

	INSERT INTO t_contact
	(
		f_name,
		f_phone_no,
		f_address,
		f_deleted
	)
	VALUES
	(
		@Name,
		@PhoneNo,
		@Address,
		0
	)

	SELECT 1;
END
GO