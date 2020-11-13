CREATE OR ALTER PROCEDURE GetArticle
( @Id INTEGER = 0
)
AS
BEGIN

  SET NOCOUNT ON;

  SELECT Id
       , CreatedOn
       , Title
	   , Text
	   , Likes
   FROM Article 
  WHERE Id = @Id OR @Id = 0
  ORDER BY CreatedOn DESC;

END;

