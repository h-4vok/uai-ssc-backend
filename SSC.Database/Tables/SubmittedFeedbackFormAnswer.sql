CREATE TABLE SubmittedFeedbackFormAnswer
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	FeedbackFormQuestionId INT NOT NULL,
	FeedbackFormQuestionChoiceId INT NOT NULL,
	SubmittedFeedbackFormId INT NOT NULL,

	FOREIGN KEY (FeedbackFormQuestionId) REFERENCES FeedbackFormQuestion,
	FOREIGN KEY (FeedbackFormQuestionChoiceId) REFERENCES FeedbackFormQuestionChoice,
	FOREIGN KEY (SubmittedFeedbackFormId) REFERENCES SubmittedFeedbackForm
)
