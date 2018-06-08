IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AppUser] (
    [Id] nvarchar(450) NOT NULL,
    [AccessFailedCount] int NOT NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [EmailConfirmed] bit NOT NULL,
    [FacebookId] bigint NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [LockoutEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [NormalizedEmail] nvarchar(max) NULL,
    [NormalizedUserName] nvarchar(max) NULL,
    [PasswordHash] nvarchar(max) NULL,
    [Phone] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [UserName] nvarchar(max) NULL,
    CONSTRAINT [PK_AppUser] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Customers] (
    [Id] int NOT NULL IDENTITY,
    [Gender] nvarchar(max) NULL,
    [IdentityId] nvarchar(450) NULL,
    [Locale] nvarchar(max) NULL,
    [Location] nvarchar(max) NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Customers_AppUser_IdentityId] FOREIGN KEY ([IdentityId]) REFERENCES [AppUser] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Customers_IdentityId] ON [Customers] ([IdentityId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180223071608_init', N'2.0.1-rtm-125');

GO

