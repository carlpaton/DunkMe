CREATE OR ALTER PROCEDURE dbo.sp_select_list_player 

AS

/*
----------------------------------------------------------------------------
-- Object Name: dbo.sp_select_list_player
-- Project: Dunkme
-- Business Process: Select all players
-- Purpose: Selects all records from dbo.player
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
-- 001 | N\A | 03.11.2018 | Carl Paton | Original code
--
*/

SET NOCOUNT ON

-- 1 - Declare variables

-- 2 - Initialize variables

-- 3 - Execute SELECT command
BEGIN

SELECT * FROM [dbo].[player];

END
GO