CREATE TABLE [dbo].[tAccount] (
    [Id]                        INT            IDENTITY (1, 1) NOT NULL,
    [UserId]                    INT            NOT NULL,
    [ReceiveEmailNotifications] NVARCHAR (255) NOT NULL,
    [ReceivePushNotifications]  NVARCHAR (255) NOT NULL,
    [LastLogin]                 DATETIME       NOT NULL,
    [IsDeleted]                 INT            DEFAULT ((0)) NOT NULL,
    [CreatedBy]                 NVARCHAR (255) NOT NULL,
    [CreatedDate]               DATETIME       DEFAULT (getdate()) NOT NULL,
    [LastModifiedBy]            NVARCHAR (255) NULL,
    [LastModifiedDate]          DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

