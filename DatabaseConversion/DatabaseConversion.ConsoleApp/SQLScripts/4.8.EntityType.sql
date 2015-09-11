-- Mandatory fields
-- Document : https://steadfastgroup.sharepoint.com/teams/it/projects/boa/_layouts/15/WopiFrame2.aspx?sourcedoc={32549F3B-EC44-4E56-8D03-C4881AF2CE22}&file=BOA_Eclipse_Data_Conversion.docx&action=default
-- Section  : 4.8

UPDATE dbo.atura_roles SET atrol_name = 'Client' WHERE atrol_bit = 8

UPDATE dbo.atura_roles SET atrol_name = 'Authorised Insurer' WHERE atrol_bit = 16

UPDATE dbo.atura_roles SET atrol_name = 'Unauthorised Insurer' WHERE atrol_bit = 2048

UPDATE dbo.atura_roles SET atrol_name = 'Net Authorised Rep' WHERE atrol_bit = 536870912

UPDATE dbo.atura_roles SET atrol_name = 'Gross Authorised Rep' WHERE atrol_bit = 1073741824