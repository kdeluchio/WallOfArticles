CREATE OR ALTER PROCEDURE RemoveArticle
( @Id INTEGER 
)
AS
BEGIN
  
  SET NOCOUNT ON;

  DELETE
    FROM Article 
   WHERE Id = @Id OR @Id = 0;

END;
