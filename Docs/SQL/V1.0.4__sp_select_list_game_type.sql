CREATE OR ALTER PROCEDURE dbo.sp_select_list_game_type 

AS

/*
----------------------------------------------------------------------------
-- Object Name: dbo.sp_select_list_game_type
-- Project: Dunkme
-- Business Process: Select all game types
-- Purpose: Selects all records from dbo.game_type
-- Detailed Description:
-- Database: dunkme
-- Dependent Objects: None
-- Called By: Ad-hoc
-- Upstream Systems: N\A
-- Downstream Systems: N\A
-- 
--------------------------------------------------------------------------------------
-- Rev | CMR | Date Modified | Developer  | Change Summary
--------------------------------------------------------------------------------------
-- 001 | N\A | 01.11.2018 | Carl Paton | Original code
--
*/

SET NOCOUNT ON

-- 1 - Declare variables

-- 2 - Initialize variables

-- 3 - Execute INSERT command
BEGIN

SELECT * FROM [dbo].[game_type];

END
GO