INSERT INTO CodeTable VALUES
(1, 'Reward Type'),
(2, 'Characters');
GO

INSERT INTO CodeValue VALUES
(1, 101, 'Low (credits, regular lootboxes)', 0),
(1, 102, 'Medium (lootboxes and regen tokens)', 0),
(1, 103, 'High (platinum and Diamond lootboxes)', 0),
(1, 104, 'Character specific - Low (few rares, 1 epic)', 0),
(1, 105, 'Character specifig - High (multiple epics)', 0);
GO

INSERT INTO CodeValue VALUES
(2, 201, 'Aquaman', 0),
(2, 202, 'Atrocitus', 0),
(2, 203, 'Bane', 0),
(2, 204, 'Batman', 0),
(2, 205, 'Black Adam', 0),
(2, 206, 'Black Canary', 0),
(2, 207, 'Blue Beetle', 0),
(2, 208, 'Brainiac', 0),
(2, 209, 'Captain Cold', 0),
(2, 210, 'Catwoman', 0),
(2, 211, 'Cheetah', 0),
(2, 212, 'Cyborg', 0),
(2, 213, 'Darkseid', 0),
(2, 214, 'Deadshot', 0),
(2, 215, 'Doctor Fate', 0),
(2, 216, 'Firestorm', 0),
(2, 217, 'Flash', 0),
(2, 218, 'Gorilla Grodd', 0),
(2, 219, 'Green Arrow', 0),
(2, 220, 'Green Lantern', 0),
(2, 221, 'Harley Quinn', 0),
(2, 222, 'Joker', 0),
(2, 223, 'Poison Ivy', 0),
(2, 224, 'Robin', 0),
(2, 225, 'Scarecrow', 0),
(2, 226, 'Supergirl', 0),
(2, 227, 'Superman', 0),
(2, 228, 'Swamp Thing', 0),
(2, 229, 'Wonder Woman', 0)
GO

SELECT * FROM CodeTable
SELECT * FROM CodeValue