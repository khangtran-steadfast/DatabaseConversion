
UPDATE dbo.Workbook_Notes SET wor_not_parent_id = pol_id
FROM dbo.Workbook_Notes  INNER JOIN policies ON wor_not_wor_id = pol_wor_id
