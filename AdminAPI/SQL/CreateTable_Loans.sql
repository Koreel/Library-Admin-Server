SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE Loans (
                       LoanID INT PRIMARY KEY IDENTITY(1,1),
                       UserID INT NOT NULL,
                       CopyID INT NOT NULL,
                       BorrowedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
                       DueAt DATETIME2 NULL,
                       ReturnedAt DATETIME2 NULL,

                       CONSTRAINT FK_Loans_Users
                           FOREIGN KEY (UserID)
                               REFERENCES Users(UserID),

                       CONSTRAINT FK_Loans_BookCopies
                           FOREIGN KEY (CopyID)
                               REFERENCES BookCopies(CopyID)
);