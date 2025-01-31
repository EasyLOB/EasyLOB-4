
-- EasyLOBActivityRole

DROP TRIGGER IF EXISTS TR_EasyLOBActivityRole_AIU

CREATE TRIGGER TR_EasyLOBActivityRole_AIU ON EasyLOBActivityRole
FOR INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON

    UPDATE EasyLOBActivityRole
    SET
        RoleX = COALESCE((SELECT TOP 1 Name FROM AspNetRoles WHERE Id = inserted.RoleId), '?')
	FROM
		EasyLOBActivityRole
		INNER JOIN inserted ON
			inserted.ActivityId = EasyLOBActivityRole.ActivityId
			AND inserted.RoleId = EasyLOBActivityRole.RoleId
END
GO
