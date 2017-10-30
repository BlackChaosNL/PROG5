-- Clear the tables
-- TRUNCATE TABLE [dbo].[EquipmentSet];
-- TRUNCATE TABLE [dbo].[EquipmentTypeSet];
-- TODO: Microshit cant even implement FKs or truncate commands properly.

-- Add equipment types
INSERT INTO [dbo].[EquipmentTypeSet] VALUES
(N'Weapon'),
(N'Armor - Head'),
(N'Armor - Chest'),
(N'Armor - Legs'),
(N'Armor - Feet'),
(N'Armor - Hands')
;

-- Add equipment
INSERT INTO [dbo].[EquipmentSet] (Int, Str, Agi, Gold, Name, EquipmentType_Id) VALUES
(100, 100, 100, 5000, N'The Sword of a Thousand Truths', 1),
(1, 1, 4, 400, N'Simple ninja sword', 1),
(1, 1, 2, 150, N'Simple ninja mask', 2),
(1, 1, 3, 250, N'Simple ninja outfit', 3),
(1, 1, 2, 150, N'Simple ninja pants', 4),
(1, 1, 2, 150, N'Simple ninja shoes', 5),
(1, 1, 2, 150, N'Simple ninja gloves', 6)
;