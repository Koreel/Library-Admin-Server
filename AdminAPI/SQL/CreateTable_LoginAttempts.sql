SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE LoginAttempts (
                               LoginAttemptID INT PRIMARY KEY IDENTITY(1,1),
                               UserID INT NULL,
                               Username VARCHAR(50) NOT NULL,
                               AttemptedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
                               WasSuccessful BIT NOT NULL,
                               IPAddress VARCHAR(45) NULL
);