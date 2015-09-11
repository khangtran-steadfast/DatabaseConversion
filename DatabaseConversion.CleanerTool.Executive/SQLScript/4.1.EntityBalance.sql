
ALTER TABLE dbo.entities DISABLE TRIGGER ALL

UPDATE T1 SET T1.ent_balance = (SELECT COALESCE(SUM(T2.bal_amount), 0) FROM balances T2 WHERE T2.bal_entity_id = T1.ent_id)
FROM dbo.entities T1;

ALTER TABLE dbo.entities ENABLE TRIGGER ALL
