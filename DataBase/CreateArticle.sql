CREATE OR ALTER PROCEDURE CreateArticle
( @Title NVARCHAR(50)
, @Text  NVARCHAR(MAX)
)
AS
BEGIN

  SET NOCOUNT ON;
						
  INSERT INTO Article ( Title        
                  	  , Text      
                      , CreatedOn      
				      )
  VALUES ( @Title
         , @Text
		 , GETDATE()
         )
  
  SELECT @@IDENTITY AS 'Id'

END;

