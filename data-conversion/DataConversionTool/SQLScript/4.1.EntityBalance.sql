-- Update entity balance
-- Document : https://steadfastgroup.sharepoint.com/teams/it/projects/boa/_layouts/15/WopiFrame2.aspx?sourcedoc={32549F3B-EC44-4E56-8D03-C4881AF2CE22}&file=BOA_Eclipse_Data_Conversion.docx&action=default
-- Section  : 4.1

ALTER TABLE dbo.entities DISABLE TRIGGER ALL

UPDATE T1 SET T1.ent_balance = (SELECT COALESCE(SUM(T2.bal_amount), 0) FROM balances T2 WHERE T2.bal_entity_id = T1.ent_id)
FROM dbo.entities T1;

ALTER TABLE dbo.entities ENABLE TRIGGER ALL
