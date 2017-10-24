INSERT INTO Event
(Name, Character_Cd, EndTime, RewardType_Cd)
Values
('Test Event 23', 202, DATEADD(HOUR, 3, GETDATE()), 102)

SELECT * FROM Event