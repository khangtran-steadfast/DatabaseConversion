-- Populate current policy
-- Document : https://steadfastgroup.sharepoint.com/teams/it/projects/boa/_layouts/15/WopiFrame2.aspx?sourcedoc={32549F3B-EC44-4E56-8D03-C4881AF2CE22}&file=BOA_Eclipse_Data_Conversion.docx&action=default
-- Section  : 3.2.7

UPDATE dbo.general_insurance SET genins_current_policy =

(SELECT MAX(pol_id) FROM dbo.policies WHERE pol_parent_id = dbo.general_insurance.genins_id AND pol_reversed IS NULL)