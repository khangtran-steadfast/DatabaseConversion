-- Add new fields to eClipse database
-- Document : https://steadfastgroup.sharepoint.com/teams/it/projects/boa/_layouts/15/WopiFrame2.aspx?sourcedoc={32549F3B-EC44-4E56-8D03-C4881AF2CE22}&file=BOA_Eclipse_Data_Conversion.docx&action=default
-- Section  : 3.2.2

ALTER TABLE [dbo].[policies] ADD

[pol_balance] [money] NULL,

[RowVersion] [timestamp] NULL,

[pol_terrorism_levy] [money] NULL,

[pol_invoice_comments] [varchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

[pol_holding_insurer] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

[pol_interested_parties] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

[pol_closing_comments] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

[pol_schedule_blob_pointer] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

[pol_scope_of_advice] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

[pol_recommendations] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

[pol_notice1] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

[pol_notice2] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

[pol_notice3] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

[pol_funding_notice_sent] [bit] NULL,

[pol_binder_notice_sent] [bit] NULL,

[pol_date_fsg_supplied] [smalldatetime] NULL,

[pol_auth_rep_notice_sent] [bit] NULL,

[pol_pds_supplied] [bit] NULL,

[pol_fsg_version_supplied] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

[pol_coinsurance] [bit] NULL,

[pol_cancellation_reason] [int] NULL,

[pol_cancellation_notes] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

[pol_cancellation_type] [int] NULL,

[pol_step] [int] NULL

ALTER TABLE [dbo].[journals] ADD

[jou_pol_id] [int] NULL

ALTER TABLE [dbo].[Workbook_Notes] ADD

[wor_not_parent_id] [int] NULL