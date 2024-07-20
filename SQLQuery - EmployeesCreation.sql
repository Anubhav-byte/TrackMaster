USE TrackMaster;
GO

CREATE TABLE Employees(
	OrgNode hierarchyid PRIMARY KEY CLUSTERED,
	OrgLevel AS OrgNode.GetLevel(),
	EmployeeId INT UNIQUE NOT NULL,
	EmployeeName VARCHAR(200) NOT NULL,
	EmployeeEmail VARCHAR(200) NOT NULL,
	IsAdmin bit
);
GO 

CREATE UNIQUE INDEX EmployeesOrgNCI
ON Employees(OrgNode,OrgLevel);
GO