CREATE TABLE [ResolverGroups] (
    [ResolverGroupId] int NOT NULL IDENTITY,
    [ResolverGroupName] nvarchar(max) NOT NULL,
    [Created] datetime2 NOT NULL,
    [Modified] datetime2 NOT NULL,
    CONSTRAINT [PK_ResolverGroups] PRIMARY KEY ([ResolverGroupId])
);
GO

CREATE TABLE [TaskAttachments] (
    [AttachmentId] int NOT NULL IDENTITY,
    [AttachmentType] nvarchar(max) NOT NULL,
    [AttchmentLocation] nvarchar(max) NOT NULL,
    [Created] datetime2 NOT NULL,
    [Modified] datetime2 NOT NULL,
    CONSTRAINT [PK_TaskAttachments] PRIMARY KEY ([AttachmentId])
);
GO

CREATE TABLE [TaskStatuses] (
    [StatusId] int NOT NULL IDENTITY,
    [Status] nvarchar(max) NOT NULL,
    [Created] datetime2 NOT NULL,
    [Modified] datetime2 NOT NULL,
    CONSTRAINT [PK_TaskStatuses] PRIMARY KEY ([StatusId])
);
GO

CREATE TABLE [ResolverGroupMembers] (
    [id] int NOT NULL IDENTITY,
    [ResolverGroupId] int NOT NULL,
    [EmployeeId] int NOT NULL,
    [Created] datetime2 NOT NULL,
    [Modified] datetime2 NOT NULL,
    CONSTRAINT [PK_ResolverGroupMembers] PRIMARY KEY ([id]),
    CONSTRAINT [FK_ResolverGroupMembers_ResolverGroups_ResolverGroupId] FOREIGN KEY ([ResolverGroupId]) REFERENCES [ResolverGroups] ([ResolverGroupId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ResolverGroupMembers_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([EmployeeId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Tasks] (
    [TaskId] int NOT NULL IDENTITY,
    [TaskName] nvarchar(max) NOT NULL,
    [TaskDescription] nvarchar(max) NOT NULL,
    [DueDate] datetime2 NOT NULL,
    [StatusId] int NOT NULL,
    [StatusReasonCode] nvarchar(max) NOT NULL,
    [AttachmentId] int NOT NULL,
    [ResolverGroupId] int NOT NULL,
    [CreatedBy] int NOT NULL,
    [AssignedTo] int NOT NULL,
    [Created] datetime2 NOT NULL,
    [Modified] datetime2 NOT NULL,
    CONSTRAINT [PK_Tasks] PRIMARY KEY ([TaskId]),
    CONSTRAINT [FK_Tasks_ResolverGroups_ResolverGroupId] FOREIGN KEY ([ResolverGroupId]) REFERENCES [ResolverGroups] ([ResolverGroupId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Tasks_TaskAttachments_AttachmentId] FOREIGN KEY ([AttachmentId]) REFERENCES [TaskAttachments] ([AttachmentId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Tasks_TaskStatuses_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [TaskStatuses] ([StatusId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Tasks_TaskStatuses_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [Employees]([EmployeeId]),
    CONSTRAINT [FK_Tasks_TaskStatuses_AssignedTo] FOREIGN KEY ([AssignedTo]) REFERENCES [Employees]([EmployeeId])
);
GO

CREATE TABLE [TaskComments] (
    [CommentID] int NOT NULL IDENTITY,
    [TaskId] int NOT NULL,
    [Comment] nvarchar(max) NOT NULL,
    [AttachmentId] int NOT NULL,
    [Created] datetime2 NOT NULL,
    [Modified] datetime2 NOT NULL,
    CONSTRAINT [PK_TaskComments] PRIMARY KEY ([CommentID]),
    CONSTRAINT [FK_TaskComments_TaskAttachments_AttachmentId] FOREIGN KEY ([AttachmentId]) REFERENCES [TaskAttachments] ([AttachmentId]) ON DELETE CASCADE,
    CONSTRAINT [FK_TaskComments_Tasks_TaskId] FOREIGN KEY ([TaskId]) REFERENCES [Tasks] ([TaskId])
);
GO

CREATE INDEX [IX_ResolverGroupMembers_ResolverGroupId] ON [ResolverGroupMembers] ([ResolverGroupId]);
GO

CREATE INDEX [IX_TaskComments_AttachmentId] ON [TaskComments] ([AttachmentId]);
GO

CREATE INDEX [IX_TaskComments_TaskId] ON [TaskComments] ([TaskId]);
GO

CREATE INDEX [IX_Tasks_AttachmentId] ON [Tasks] ([AttachmentId]);
GO

CREATE INDEX [IX_Tasks_ResolverGroupId] ON [Tasks] ([ResolverGroupId]);
GO

CREATE INDEX [IX_Tasks_StatusId] ON [Tasks] ([StatusId]);
GO

CREATE PROC AddEmp(@mgrid int, @e_name varchar(200), @email varchar(20),@isadmin bit)   
AS   
BEGIN  
   DECLARE @mOrgNode hierarchyid, @lc hierarchyid  
   SELECT @mOrgNode = OrgNode   
   FROM Employees   
   WHERE EmployeeID = @mgrid  
   SET TRANSACTION ISOLATION LEVEL SERIALIZABLE  
   BEGIN TRANSACTION  
      SELECT @lc = max(OrgNode)   
      FROM Employees 
      WHERE OrgNode.GetAncestor(1) =@mOrgNode ;  

      INSERT Employees (OrgNode, EmployeeName, EmployeeEmail,IsAdmin)  
      VALUES(@mOrgNode.GetDescendant(@lc, NULL), @e_name, @email,@isadmin)  
   COMMIT  
END ;  
GO  

INSERT Employees (OrgNode, EmployeeName, EmployeeEmail,IsAdmin) 
VALUES (hierarchyid::GetRoot(), 'Anubhav Purohit','anubahv@email.com',1) ;  
GO

