-- Edit broker rep workbook
-- Document : https://steadfastgroup.sharepoint.com/teams/it/projects/boa/_layouts/15/WopiFrame2.aspx?sourcedoc={32549F3B-EC44-4E56-8D03-C4881AF2CE22}&file=BOA_Eclipse_Data_Conversion.docx&action=default
-- Section  : 4.6

INSERT INTO [SystemConfigOptions] ([strOption], [strOptionId])
SELECT [atconf_section], [atconf_value]
FROM [EclipseDatabase].dbo.[atura_config]
WHERE [atconf_section] = ' EditBrokerRepWorkbook'

