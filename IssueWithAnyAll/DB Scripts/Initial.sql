CREATE TABLE [dbo].[RequestStatuses] (
    [Id]           INT                IDENTITY (1, 1) NOT NULL,
    [Title]        NVARCHAR (1024)    NULL,
    [IsDeleted]    BIT                NULL,
    [RowVersion]   ROWVERSION         NULL,
    [CreatedById]  INT                NULL,
    [ModifiedById] INT                NULL,
    CONSTRAINT [PK_RequestStatuses] PRIMARY KEY CLUSTERED ([Id] DESC),
);

CREATE TABLE [dbo].[RequestTypes] (
    [Id]           INT                IDENTITY (1, 1) NOT NULL,
    [Title]        NVARCHAR (1024)    NULL,
    [DisplayTitle] NVARCHAR (1024)    NULL,
    [ShowOrder]    INT                NULL DEFAULT 999,
    [IsDeleted]    BIT                NULL,
    [RowVersion]   ROWVERSION         NULL,
    [CreatedById]  INT                NULL,
    [ModifiedById] INT                NULL,
    [Format]       NVARCHAR (1024)    NULL,
    [Flags]        INT                NULL,
    CONSTRAINT [PK_RequestTypes] PRIMARY KEY CLUSTERED ([Id] DESC),
);


CREATE TABLE [dbo].[Requests] (
    [Id]                            INT                IDENTITY (1, 1) NOT NULL,
    [Title]                         NVARCHAR (1024)    NULL,
    [IsDeleted]                     BIT                NULL,
    [RowVersion]                    ROWVERSION         NULL,
    [CreatedById]                   INT                NULL,
    [ModifiedById]                  INT                NULL,
    [TypeId]                        INT                NULL,
    [StatusId]                      INT                NULL,
    

    CONSTRAINT [PK_Requests] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Requests_RequestStatuses] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[RequestStatuses] ([Id]),
    CONSTRAINT [FK_Requests_RequestTypes] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[RequestTypes] ([Id])    
);