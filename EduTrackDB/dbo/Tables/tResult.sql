CREATE TABLE [dbo].[tResult] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [UserId]           INT            NOT NULL,
    [CourseId]         INT            NOT NULL,
    [SubjectId]        INT            NOT NULL,
    [AssessmentId]     INT            NOT NULL,
    [Mark]             DECIMAL (5, 2) NULL,
    [FinalMark]        DECIMAL (5, 2) NULL,
    [Predicate]        NVARCHAR (50)  NULL,
    [IsDeleted]        BIT            DEFAULT ((0)) NOT NULL,
    [CreatedBy]        NVARCHAR (255) NULL,
    [CreatedDate]      DATETIME       DEFAULT (getdate()) NOT NULL,
    [LastModifiedBy]   NVARCHAR (255) NULL,
    [LastModifiedDate] DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AssessmentId]) REFERENCES [dbo].[tAssessment] ([Id]),
    FOREIGN KEY ([CourseId]) REFERENCES [dbo].[tCourse] ([Id]),
    FOREIGN KEY ([SubjectId]) REFERENCES [dbo].[tSubject] ([Id]),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[tUser] ([Id])
);

