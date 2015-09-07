-- Create policy records
-- Document : https://steadfastgroup.sharepoint.com/teams/it/projects/boa/_layouts/15/WopiFrame2.aspx?sourcedoc={32549F3B-EC44-4E56-8D03-C4881AF2CE22}&file=BOA_Eclipse_Data_Conversion.docx&action=default
-- Section  : 3.2.3

ALTER TABLE policies NOCHECK CONSTRAINT ALL

INSERT INTO dbo.policies

( pol_parent_id ,

pol_created_who ,

pol_created_when ,

pol_updated_who ,

pol_updated_when ,

pol_duration ,

pol_closed ,

pol_insurer ,

pol_date_from ,

pol_date_to ,

pol_date_effective ,

pol_cover_note_number ,

pol_policy_number ,

pol_sum_insured ,

pol_sub_agent ,

pol_location ,

pol_total_base_premium ,

pol_total_levies ,

pol_total_duties ,

pol_total_fees ,

pol_total_gross_premium ,

pol_total_commission ,

pol_other_parties ,

pol_insured ,

pol_total_net_premium ,

pol_wor_id ,

pol_locked ,

pol_posted_when ,

pol_billing_when ,

pol_closing_when ,

pol_transaction_type ,

pol_tran_id ,

pol_sub_agent_comm_payable ,

pol_debtor ,

pol_insurer_gst ,

pol_date_due ,

pol_sub_agent_fee_payable ,

pol_sub_agent_total_payable ,

pol_date_remitted ,

pol_amount_remitted ,

pol_date_remitted_sub ,

pol_amount_remitted_sub ,

pol_fee_gst ,

pol_comm_gst ,

pol_sub_agent_fee_payable_gst ,

pol_sub_agent_comm_payable_gst ,

pol_total_gst ,

pol_fee_net_gst ,

pol_comm_net_gst ,

pol_sub_agent_fee_pay_net_gst ,

pol_sub_agent_comm_pay_net_gst ,

pol_invoice_total ,

pol_base_premium ,

pol_uw_fee_gst ,

pol_uw_fee_net_gst ,

pol_reversed ,

pol_br_net_com_writeoff ,

pol_net_br_adjustment ,

pol_hvi_value ,

pol_limited_exemption ,

pol_exemption_type ,

pol_posted_who

)

select wor_parent_id , -- pol_parent_id - int

wor_created_who , -- pol_created_who - varchar(30)

wor_created_when , -- pol_created_when - smalldatetime

wor_updated_who , -- pol_updated_who - varchar(30)

wor_updated_when , -- pol_updated_when - smalldatetime

0 , -- pol_duration - int

0 , -- pol_closed - bit

null , -- pol_insurer - int

'20100101' , -- pol_date_from - smalldatetime

'20100101' , -- pol_date_to - smalldatetime

'20100101' , -- pol_date_effective - smalldatetime

'' , -- pol_cover_note_number - varchar(30)

'' , -- pol_policy_number - varchar(30)

0 , -- pol_sum_insured - money

null , -- pol_sub_agent - int

'' , -- pol_location - varchar(255)

0 , -- pol_total_base_premium - money

0 , -- pol_total_levies - money

0 , -- pol_total_duties - money

0 , -- pol_total_fees - money

0 , -- pol_total_gross_premium - money

0 , -- pol_total_commission - money

'' , -- pol_other_parties - text

'' , -- pol_insured - varchar(255)

0 , -- pol_total_net_premium - money

wor_id , -- pol_wor_id - int

0 , -- pol_locked - tinyint

NULL , -- pol_posted_when - smalldatetime

NULL , -- pol_billing_when - smalldatetime

NULL , -- pol_closing_when - smalldatetime

3 , -- pol_transaction_type - int

null , -- pol_tran_id - int

0 , -- pol_sub_agent_comm_payable - money

null , -- pol_debtor - int

0 , -- pol_insurer_gst - money

'20100101' , -- pol_date_due - smalldatetime

0 , -- pol_sub_agent_fee_payable - money

0 , -- pol_sub_agent_total_payable - money

NULL , -- pol_date_remitted - smalldatetime

NULL , -- pol_amount_remitted - money

NULL , -- pol_date_remitted_sub - smalldatetime

NULL , -- pol_amount_remitted_sub - money

0 , -- pol_fee_gst - money

0 , -- pol_comm_gst - money

0 , -- pol_sub_agent_fee_payable_gst - money

0 , -- pol_sub_agent_comm_payable_gst - money

0 , -- pol_total_gst - money

0 , -- pol_fee_net_gst - money

0 , -- pol_comm_net_gst - money

0 , -- pol_sub_agent_fee_pay_net_gst - money

0 , -- pol_sub_agent_comm_pay_net_gst - money

0 , -- pol_invoice_total - money

0 , -- pol_base_premium - money

0 , -- pol_uw_fee_gst - money

0 , -- pol_uw_fee_net_gst - money

'' , -- pol_reversed - varchar(250)

NULL , -- pol_br_net_com_writeoff - bit

0 , -- pol_net_br_adjustment - int

0 , -- pol_hvi_value - bigint

null , -- pol_limited_exemption - int

null , -- pol_exemption_type - int

'' -- pol_posted_who - varchar(30)

FROM dbo.workbooks

LEFT JOIN dbo.policies ON policies.pol_wor_id = workbooks.wor_id

WHERE pol_id IS NULL

ALTER TABLE policies CHECK CONSTRAINT ALL