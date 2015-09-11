-- Update policy insured
-- Document : https://steadfastgroup.sharepoint.com/teams/it/projects/boa/_layouts/15/WopiFrame2.aspx?sourcedoc={32549F3B-EC44-4E56-8D03-C4881AF2CE22}&file=BOA_Eclipse_Data_Conversion.docx&action=default
-- Section  : 4.3

UPDATE dbo.general_insurance SET genins_insured = dbo.entities.ent_name
FROM dbo.general_insurance INNER JOIN dbo.entities ON entities.ent_id = general_insurance.genins_parent_id

UPDATE dbo.general_insurance SET genins_insured = dbo.policies.pol_insured
FROM dbo.general_insurance INNER JOIN dbo.policies ON policies.pol_parent_id = general_insurance.genins_id
