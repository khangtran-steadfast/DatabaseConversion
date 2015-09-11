-- Update policies table
-- Document : https://steadfastgroup.sharepoint.com/teams/it/projects/boa/_layouts/15/WopiFrame2.aspx?sourcedoc={32549F3B-EC44-4E56-8D03-C4881AF2CE22}&file=BOA_Eclipse_Data_Conversion.docx&action=default
-- Section  : 3.2.4

-- Disable all table constraints

-- Disable all table constraints

ALTER TABLE policies NOCHECK CONSTRAINT ALL

ALTER TABLE policies DISABLE TRIGGER ALL

update policies

set pol_insurer = CONVERT(int, attv_value)

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_insurer'

update policies

set pol_transaction_type = CONVERT(int, attv_value)

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_transaction_type'

update policies

set pol_date_from = CONVERT(smalldatetime, attv_value)

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_date_from'

update policies

set pol_date_to = CONVERT(smalldatetime, attv_value)

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_date_to'

update policies

set pol_date_effective = CONVERT(smalldatetime, attv_value)

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_date_effective'

update policies

set pol_sum_insured = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_sum_insured'

update policies

set pol_insured = attv_value

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_insured'

update policies

set pol_total_base_premium = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_total_base_premium'

update policies

set pol_total_levies = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_total_levies'

update policies

set pol_total_duties = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_total_duties'

update policies

set pol_total_fees = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_total_fees'

update policies

set pol_total_gross_premium = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_total_gross_premium'

update policies

set pol_total_commission = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_total_commission'

update policies

set pol_comm_net_gst = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_comm_net_gst'

update policies

set pol_comm_net_gst = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_comm_net_gst'

update policies

set pol_total_net_premium = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_total_net_premium'

update policies

set pol_base_premium = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_base_premium'

update policies

set pol_uw_fee_net_gst = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_uw_fee_net_gst'

update policies

set pol_uw_fee_gst = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_uw_fee_gst'

update policies

set pol_fee_gst = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_fee_gst'

update policies

set pol_fee_net_gst = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_fee_net_gst'

update policies

set pol_insurer_gst = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_insurer_gst'

update policies

set pol_policy_number = attv_value

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_policy_number'

update policies

set pol_hvi_value = CONVERT(bigint, attv_value)

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_hvi_value'

update policies

set pol_limited_exemption = CONVERT(int, attv_value)

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_limited_exemption'

update policies

set pol_exemption_type = CONVERT(int, attv_value)

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_exemption_type'

update policies

set pol_cover_note_number = attv_value

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_cover_note_number'

update policies

set pol_location = attv_value

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_location'

update policies

set pol_comm_gst = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_comm_gst'

update policies

set pol_comm_net_gst = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_comm_net_gst'

update policies

set pol_sub_agent_comm_payable_gst = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_sub_agent_comm_payable_gst'

update policies

set pol_sub_agent_comm_pay_net_gst = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_sub_agent_comm_pay_net_gst'

update policies

set pol_sub_agent_fee_payable_gst = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_sub_agent_fee_payable_gst'

update policies

set pol_sub_agent_fee_pay_net_gst = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_sub_agent_fee_pay_net_gst'

update policies

set pol_uw_fee_net_gst = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_uw_fee_net_gst'

update policies

set pol_uw_fee_gst = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_uw_fee_gst'

update policies

set pol_sub_agent_comm_payable = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_sub_agent_comm_payable'

update policies

set pol_sub_agent_fee_payable = CONVERT(money, coalesce(attv_value,'0.00'))

from policies

join atura_tagvalue on attv_row_id = pol_wor_id

where pol_duration = -1 AND attv_tag = 'pol_sub_agent_fee_payable'

-- Now prepare variables to allow us to update any text columns.

-- This is done by UPDATE instead of INSERT as text columns may have >255 characters

-- and we cannot declare a @variable to hold all the data.

declare @pol_id int

declare @wor_id int

DECLARE @text_index INT

DECLARE @text_ptr VARBINARY(16)

DECLARE @text_value VARCHAR(255)

declare workbook_cursor cursor for

select pol_id, pol_wor_id

from policies

where pol_duration = -1

order by pol_id

open workbook_cursor

fetch next from workbook_cursor into @pol_id, @wor_id

while (@@FETCH_STATUS = 0)

begin

DECLARE text_cursor CURSOR FOR

SELECT attv_index, attv_value

FROM atura_tagvalue

WHERE attv_row_id = @wor_id

AND attv_tag = 'pol_other_parties'

ORDER BY attv_index

OPEN text_cursor

FETCH NEXT FROM text_cursor INTO @text_index, @text_value

-- If there is any data for pol_other_parties in atura_tagvalue,

-- initialise the pol_other_parties column so we can get a pointer to it.

IF (@@FETCH_STATUS=0)

BEGIN

UPDATE policies

SET pol_other_parties = NULL

WHERE pol_id = @pol_id

SELECT @text_ptr=TEXTPTR(pol_other_parties)

FROM policies

WHERE pol_id = @pol_id

END

WHILE (@@FETCH_STATUS<>-1)

BEGIN

IF (@@FETCH_STATUS<>-2)

BEGIN

UPDATETEXT policies.pol_other_parties @text_ptr NULL 0 @text_value

END

FETCH NEXT FROM text_cursor INTO @text_index, @text_value

END

CLOSE text_cursor

DEALLOCATE text_cursor

DECLARE @parent_id int

SELECT @parent_id = pol_parent_id FROM dbo.policies WHERE pol_id = @pol_id

-- Third party billing: retrieve debtor_id from profile table if there, otherwise default to entity_id

DECLARE @debtor_id int

SELECT @debtor_id = prof_usual_debtor

FROM profile INNER JOIN (entities INNER JOIN general_insurance ON ent_id = genins_parent_id) ON prof_parent_id = ent_id

WHERE genins_id = @parent_id

IF (@debtor_id IS NULL)

SELECT @debtor_id = genins_parent_id FROM general_insurance WHERE genins_id = @parent_id

UPDATE dbo.policies SET pol_debtor = @debtor_id WHERE pol_id = @pol_id

fetch next from workbook_cursor into @pol_id, @wor_id

end

close workbook_cursor

deallocate workbook_cursor

-- Enable all table constraints

ALTER TABLE policies ENABLE TRIGGER ALL

ALTER TABLE policies CHECK CONSTRAINT ALL

-- Reset pol_duration value to zero

update policies set pol_duration = 0 where pol_duration = -1