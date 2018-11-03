CREATE OR ALTER PROCEDURE dbo.sp_insert_player 
	@Email varchar(200)
AS

/*
----------------------------------------------------------------------------
-- Object Name: dbo.player
-- Project: Dunkme
-- Business Process: New player
-- Purpose: Insert a record into dbo.player
-- Detailed Description: .
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

INSERT INTO [dbo].[player]
           ([Email])
     VALUES
           (@Email);

SELECT CAST(SCOPE_IDENTITY() AS INT);

END
GO