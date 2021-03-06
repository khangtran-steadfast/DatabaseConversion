﻿-- Update policy balance
-- Document : https://steadfastgroup.sharepoint.com/teams/it/projects/boa/_layouts/15/WopiFrame2.aspx?sourcedoc={32549F3B-EC44-4E56-8D03-C4881AF2CE22}&file=BOA_Eclipse_Data_Conversion.docx&action=default
-- Section  : 4.2

UPDATE T1 SET T1.pol_balance = (SELECT COALESCE(SUM(T2.bal_amount), 0) FROM dbo.transactions T3 LEFT JOIN balances T2 
ON T2.bal_tran_id = T3.tran_id AND T2.bal_led_id = 1 WHERE T3.tran_id = T1.pol_tran_id)
FROM dbo.policies T1;
