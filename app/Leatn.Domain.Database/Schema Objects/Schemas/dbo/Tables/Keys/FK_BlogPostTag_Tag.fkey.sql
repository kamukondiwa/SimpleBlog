ALTER TABLE [dbo].[BlogPostTag] 
WITH CHECK ADD CONSTRAINT [FK_BlogPostTag_Tag] 
FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([Id]) 