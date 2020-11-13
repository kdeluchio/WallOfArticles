CREATE OR ALTER PROCEDURE LikedArticle
( @Id INTEGER 
)
AS
BEGIN
  
  SET NOCOUNT ON;

  UPDATE Article
     SET Likes = Likes + 1 
   WHERE Id = @Id ;

END;
