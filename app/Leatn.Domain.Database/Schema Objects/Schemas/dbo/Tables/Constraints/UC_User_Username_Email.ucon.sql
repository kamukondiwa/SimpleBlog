ALTER TABLE [dbo].[User] 
ADD CONSTRAINT [UC_User] UNIQUE ([Username],[Email])