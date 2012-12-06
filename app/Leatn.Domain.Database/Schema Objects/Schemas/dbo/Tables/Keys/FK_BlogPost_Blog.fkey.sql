ALTER TABLE [dbo].[BlogPost] 
WITH CHECK ADD CONSTRAINT [FK_BlogPost_Blog] 
FOREIGN KEY([BlogId])
REFERENCES [dbo].[Blog] ([Id]) 