-- Update policies table
-- Document : https://steadfastgroup.sharepoint.com/teams/it/projects/boa/_layouts/15/WopiFrame2.aspx?sourcedoc={32549F3B-EC44-4E56-8D03-C4881AF2CE22}&file=BOA_Eclipse_Data_Conversion.docx&action=default
-- Section  : 3.2.6

UPDATE dbo.Workbook_Notes SET wor_not_parent_id = pol_id

FROM dbo.Workbook_Notes INNER JOIN policies ON wor_not_wor_id = pol_wor_id