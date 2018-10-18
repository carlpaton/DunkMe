CREATE PROCEDURE dbo.sp_insert_game_type 
	@Name varchar(45), 
	@Description varchar(200),
	@new_identity INT = NULL OUTPUT
AS

/*
----------------------------------------------------------------------------
-- Object Name: dbo.sp_insert_game_type
-- Project: Dunkme
-- Business Process: New game type
-- Purpose: Insert a record into dbo.game_type
-- Detailed Description: Insert a record into the dbo.Customer table
-- Database: dunkme
-- Dependent Objects: None
-- Called By: Ad-hoc
-- Upstream Systems: N\A
-- Downstream Systems: N\A
-- 
--------------------------------------------------------------------------------------
-- Rev | CMR | Date Modified | Developer  | Change Summary
--------------------------------------------------------------------------------------
-- 001 | N\A | 11.10.2018 | Carl Paton | Original code
--
*/

SET NOCOUNT ON

-- 1 - Declare variables

-- 2 - Initialize variables

-- 3 - Execute INSERT command
BEGIN
INSERT INTO [dbo].[game_type]
           ([name]
           ,[description])
     VALUES
           (@Name
           ,@Description)
    SET @new_identity = SCOPE_IDENTITY();
END
GO