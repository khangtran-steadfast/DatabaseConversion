
UPDATE journals SET jou_pol_id = pol_id
FROM journals  INNER JOIN policies ON jou_parent_id = pol_wor_id
