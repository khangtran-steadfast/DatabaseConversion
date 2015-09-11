
UPDATE dbo.general_insurance SET genins_insured = dbo.entities.ent_name
FROM dbo.general_insurance INNER JOIN dbo.entities ON entities.ent_id = general_insurance.genins_parent_id

UPDATE dbo.general_insurance SET genins_insured = dbo.policies.pol_insured
FROM dbo.general_insurance INNER JOIN dbo.policies ON policies.pol_parent_id = general_insurance.genins_id
