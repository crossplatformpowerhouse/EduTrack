CREATE TABLE [dbo].[tSubject] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CourseId]         INT            NOT NULL,
    [Code]             NVARCHAR (5)   NOT NULL,
    [Description]      NVARCHAR (255) NOT NULL,
    [AcademicYear]     INT            NOT NULL,
    [PassMark]         DECIMAL (5, 2) NOT NULL,
    [IsDeleted]        BIT            DEFAULT ((0)) NOT NULL,
    [CreatedBy]        NVARCHAR (255) NULL,
    [CreatedDate]      DATETIME       DEFAULT (getdate()) NOT NULL,
    [LastModifiedBy]   NVARCHAR (255) NULL,
    [LastModifiedDate] DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CourseId]) REFERENCES [dbo].[tCourse] ([Id])
);

