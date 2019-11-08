CREATE TABLE SubmittedFeedbackFormAnswer
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	FeedbackFormQuestionId INT NOT NULL,
	FeedbackFormQuestionChoiceId INT NOT NULL,
	SubmittedFeedbackFormId INT NOT NULL,

	CreatedBy INT NOT NULL,
	UpdatedBy INT NOT NULL,
	CreatedDate SMALLDATETIME DEFAULT(GETUTCDATE()),
	UpdatedDate SMALLDATETIME DEFAULT(GETUTCDATE())

	FOREIGN KEY (FeedbackFormQuestionId) REFERENCES FeedbackFormQuestion,
	FOREIGN KEY (FeedbackFormQuestionChoiceId) REFERENCES FeedbackFormQuestionChoice,
	FOREIGN KEY (SubmittedFeedbackFormId) REFERENCES SubmittedFeedbackForm
)
