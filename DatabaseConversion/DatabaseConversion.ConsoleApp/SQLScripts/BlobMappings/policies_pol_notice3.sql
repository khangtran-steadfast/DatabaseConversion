select pol.pol_id, soa.ws_notice3
from Workbook_SOA soa 
	 join workbooks wor on soa.ws_parent_id = wor.wor_id
	 join policies pol on wor.wor_id = pol.pol_wor_id