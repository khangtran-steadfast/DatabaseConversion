
UPDATE dbo.general_insurance SET genins_current_policy =
 (SELECT MAX(pol_id) FROM dbo.policies WHERE pol_parent_id = dbo.general_insurance.genins_id AND pol_reversed IS NULL)
