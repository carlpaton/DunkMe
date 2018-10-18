CREATE TABLE game_type (
  id int IDENTITY(1,1) PRIMARY KEY,
  name VARCHAR(45) NULL,
  description VARCHAR(200) NULL,
  insert_date DATETIME DEFAULT GETDATE());