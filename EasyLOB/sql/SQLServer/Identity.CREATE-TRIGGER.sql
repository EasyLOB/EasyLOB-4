
/*
UPDATE AspNetUsers SET EmailConfirmed = 0 
SELECT EmailConfirmed FROM AspNetUsers 
*/

-- AspNetUsers

DROP TRIGGER IF EXISTS TR_AspNetUsers_AIU
GO

CREATE TRIGGER TR_AspNetUsers_AIU ON AspNetUsers
FOR INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON

    UPDATE AspNetUsers
    SET
        EmailConfirmed = 1
	FROM
		AspNetUsers
		INNER JOIN inserted ON
			inserted.Id = AspNetUsers.Id
END
GO
