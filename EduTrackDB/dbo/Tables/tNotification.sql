CREATE TABLE [dbo].[tNotification] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [UserId]           INT            NOT NULL,
    [Message]          NVARCHAR (500) NOT NULL,
    [NotificationType] NVARCHAR (50)  NOT NULL,
    [CreatedDate]      DATETIME       DEFAULT (getdate()) NOT NULL,
    [IsRead]           BIT            DEFAULT ((0)) NOT NULL,
    [IsDeleted]        BIT            DEFAULT ((0)) NOT NULL,
    [CreatedBy]        NVARCHAR (255) NULL,
    [LastModifiedBy]   NVARCHAR (255) NULL,
    [LastModifiedDate] DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[tUser] ([Id])
);

