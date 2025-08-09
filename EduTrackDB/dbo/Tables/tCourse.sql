CREATE TABLE [dbo].[tCourse] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CourseTypeId]     INT            NOT NULL,
    [Code]             NVARCHAR (20)  NOT NULL,
    [Description]      NVARCHAR (255) NOT NULL,
    [Duration]         INT            NULL,
    [IsDeleted]        INT            DEFAULT ((0)) NOT NULL,
    [CreatedBy]        NVARCHAR (255) NULL,
    [CreatedDate]      DATETIME       DEFAULT (getdate()) NOT NULL,
    [LastModifiedBy]   NVARCHAR (255) NULL,
    [LastModifiedDate] DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

