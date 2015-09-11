
insert into SystemConfigOptions (strOption, strOptionId)
select	atconf_section, atconf_value
from	EclipseDatabase.dbo.atura_config
where	atconf_section = 'auto_policy_number'