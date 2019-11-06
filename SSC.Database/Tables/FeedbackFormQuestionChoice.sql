CREATE TABLE FeedbackFormQuestionChoice
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	FeedbackFormQuestionId INT NOT NULL,
	ChoiceTitle NVARCHAR(100),

	CreatedBy INT NOT NULL,
	UpdatedBy INT NOT NULL,
	CreatedDate SMALLDATETIME DEFAULT(GETUTCDATE()),
	UpdatedDate SMALLDATETIME DEFAULT(GETUTCDATE())

	FOREIGN KEY (FeedbackFormQuestionId) REFERENCES FeedbackFormQuestion
)
