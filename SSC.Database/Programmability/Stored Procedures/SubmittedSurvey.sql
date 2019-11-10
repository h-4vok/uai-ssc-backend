﻿CREATE TABLE [dbo].[SubmittedSurvey]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	SurveyFormId INT NOT NULL,
	SurveyChoiceId INT NOT NULL,
	CreatedDate SMALLDATETIME NOT NULL DEFAULT(GETUTCDATE()),

	FOREIGN KEY (SurveyFormId) REFERENCES SurveyForm,
	FOREIGN KEY (SurveyChoiceId) REFERENCES SurveyChoice
)
