-- Update journals table
-- Document : https://steadfastgroup.sharepoint.com/teams/it/projects/boa/_layouts/15/WopiFrame2.aspx?sourcedoc={32549F3B-EC44-4E56-8D03-C4881AF2CE22}&file=BOA_Eclipse_Data_Conversion.docx&action=default
-- Section  : 3.2.5

ALTER TABLE journals DISABLE TRIGGER ALL

UPDATE journals SET jou_pol_id = pol_id

FROM journals INNER JOIN policies ON jou_parent_id = pol_wor_id

ALTER TABLE journals ENABLE TRIGGER ALL