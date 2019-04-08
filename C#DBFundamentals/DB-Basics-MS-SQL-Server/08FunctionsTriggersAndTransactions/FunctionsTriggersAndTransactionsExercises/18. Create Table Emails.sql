CREATE TRIGGER tr_LogToEmail ON Logs AFTER INSERT
AS
BEGIN
INSERT INTO NotificationEmails(Recipient, Subject, Body)
SELECT AccountId,'Balance change for account: ' + CONVERT(VARCHAR(10), AccountId ), 'On ' + CONVERT(VARCHAR(30), GETDATE()) + ' your balance was changed from ' + CONVERT(VARCHAR(30), OldSum ) + ' to ' + CONVERT(VARCHAR(30), NewSum ) FROM Logs 
END