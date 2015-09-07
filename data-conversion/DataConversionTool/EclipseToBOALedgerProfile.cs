using AutoMapper;
using DataConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataConversionTool
{
    public class EclipseToBOALedgerProfile : Profile
    {
        #region CONSTRUCTOR, INITIALIZE

        /// <summary>
        /// Create AutoMapper profile to config
        /// Mappping between BOALedger and Eclipse
        /// </summary>
        public EclipseToBOALedgerProfile()
        {
        }


        #endregion


        #region METHODS


        /// <summary>
        /// Profile Name
        /// </summary>
        public override string ProfileName
        {
            get
            {
                return "EclipseToBOALedgerProfile";
            }
        }

        /// <summary>
        /// Config auto mapper
        /// This function is generated automatically by this function
        /// BOALedgerDatabase -> GenereteCodeForAutoMapper
        /// </summary>
        protected override void Configure()
        {
            Mapper.CreateMap<EclipseDataAccess.ProductLicenses, BOALedgerDataAccess.ProductLicenses>().ConvertUsing(CustomMapper_ProductLicenses);
            Mapper.CreateMap<EclipseDataAccess.cash_receipt_application, BOALedgerDataAccess.cash_receipt_application>().ConvertUsing(CustomMapper_cash_receipt_application);
            Mapper.CreateMap<EclipseDataAccess.DEFTStatementIds, BOALedgerDataAccess.DEFTStatementIds>().ConvertUsing(CustomMapper_DEFTStatementIds);
            Mapper.CreateMap<EclipseDataAccess.BrokerReps_Category2, BOALedgerDataAccess.BrokerReps_Category2>().ConvertUsing(CustomMapper_BrokerReps_Category2);
            Mapper.CreateMap<EclipseDataAccess.SQLUserConfigTable, BOALedgerDataAccess.SQLUserConfigTable>().ConvertUsing(CustomMapper_SQLUserConfigTable);
            Mapper.CreateMap<EclipseDataAccess.category_types, BOALedgerDataAccess.category_types>().ConvertUsing(CustomMapper_category_types);
            Mapper.CreateMap<EclipseDataAccess.cash_payments, BOALedgerDataAccess.cash_payments>().ConvertUsing(CustomMapper_cash_payments);
            Mapper.CreateMap<EclipseDataAccess.ClientDetails_Category2, BOALedgerDataAccess.ClientDetails_Category2>().ConvertUsing(CustomMapper_ClientDetails_Category2);
            Mapper.CreateMap<EclipseDataAccess.Total_Earnings, BOALedgerDataAccess.Total_Earnings>().ConvertUsing(CustomMapper_Total_Earnings);
            Mapper.CreateMap<EclipseDataAccess.sunrise_instalment_payments, BOALedgerDataAccess.sunrise_instalment_payments>().ConvertUsing(CustomMapper_sunrise_instalment_payments);
            Mapper.CreateMap<EclipseDataAccess.UserConfigOptions, BOALedgerDataAccess.UserConfigOptions>().ConvertUsing(CustomMapper_UserConfigOptions);
            Mapper.CreateMap<EclipseDataAccess.gl_mtd_balances, BOALedgerDataAccess.gl_mtd_balances>().ConvertUsing(CustomMapper_gl_mtd_balances);
            Mapper.CreateMap<EclipseDataAccess.Client_Task_Notes, BOALedgerDataAccess.Client_Task_Notes>().ConvertUsing(CustomMapper_Client_Task_Notes);
            Mapper.CreateMap<EclipseDataAccess.payment_batch, BOALedgerDataAccess.payment_batch>().ConvertUsing(CustomMapper_payment_batch);
            Mapper.CreateMap<EclipseDataAccess.policies, BOALedgerDataAccess.policies>().ConvertUsing(CustomMapper_policies);
            Mapper.CreateMap<EclipseDataAccess.DEFTItems, BOALedgerDataAccess.DEFTItems>().ConvertUsing(CustomMapper_DEFTItems);
            Mapper.CreateMap<EclipseDataAccess.task_documents, BOALedgerDataAccess.task_documents>().ConvertUsing(CustomMapper_task_documents);
            Mapper.CreateMap<EclipseDataAccess.cash_payment_applications, BOALedgerDataAccess.cash_payment_applications>().ConvertUsing(CustomMapper_cash_payment_applications);
            Mapper.CreateMap<EclipseDataAccess.UserWebServiceLogin, BOALedgerDataAccess.UserWebServiceLogin>().ConvertUsing(CustomMapper_UserWebServiceLogin);
            Mapper.CreateMap<EclipseDataAccess.ClientDetails_Category4, BOALedgerDataAccess.ClientDetails_Category4>().ConvertUsing(CustomMapper_ClientDetails_Category4);
            Mapper.CreateMap<EclipseDataAccess.WebClientSummaryHeaderFields, BOALedgerDataAccess.WebClientSummaryHeaderFields>().ConvertUsing(CustomMapper_WebClientSummaryHeaderFields);
            Mapper.CreateMap<EclipseDataAccess.priorities, BOALedgerDataAccess.priorities>().ConvertUsing(CustomMapper_priorities);
            Mapper.CreateMap<EclipseDataAccess.categories, BOALedgerDataAccess.categories>().ConvertUsing(CustomMapper_categories);
            Mapper.CreateMap<EclipseDataAccess.BrokerReps_Category1, BOALedgerDataAccess.BrokerReps_Category1>().ConvertUsing(CustomMapper_BrokerReps_Category1);
            Mapper.CreateMap<EclipseDataAccess.areas, BOALedgerDataAccess.areas>().ConvertUsing(CustomMapper_areas);
            Mapper.CreateMap<EclipseDataAccess.WebLocker, BOALedgerDataAccess.WebLocker>().ConvertUsing(CustomMapper_WebLocker);
            Mapper.CreateMap<EclipseDataAccess.Webclient_master_list, BOALedgerDataAccess.Webclient_master_list>().ConvertUsing(CustomMapper_Webclient_master_list);
            Mapper.CreateMap<EclipseDataAccess.asicadp106, BOALedgerDataAccess.asicadp106>().ConvertUsing(CustomMapper_asicadp106);
            Mapper.CreateMap<EclipseDataAccess.ledgers, BOALedgerDataAccess.gl_ledgers>().ConvertUsing(CustomMapper_gl_ledgers);
            Mapper.CreateMap<EclipseDataAccess.sunrise_products, BOALedgerDataAccess.sunrise_products>().ConvertUsing(CustomMapper_sunrise_products);
            Mapper.CreateMap<EclipseDataAccess.ClientDetails_Category1, BOALedgerDataAccess.ClientDetails_Category1>().ConvertUsing(CustomMapper_ClientDetails_Category1);
            Mapper.CreateMap<EclipseDataAccess.gen_ins_classes_of_business, BOALedgerDataAccess.gen_ins_classes_of_business>().ConvertUsing(CustomMapper_gen_ins_classes_of_business);
            Mapper.CreateMap<EclipseDataAccess.atura_super_users, BOALedgerDataAccess.atura_super_users>().ConvertUsing(CustomMapper_atura_super_users);
            Mapper.CreateMap<EclipseDataAccess.occupation_types, BOALedgerDataAccess.occupation_types>().ConvertUsing(CustomMapper_occupation_types);
            Mapper.CreateMap<EclipseDataAccess.MenuItems, BOALedgerDataAccess.MenuItems>().ConvertUsing(CustomMapper_MenuItems);
            Mapper.CreateMap<EclipseDataAccess.workbooks, BOALedgerDataAccess.workbooks>().ConvertUsing(CustomMapper_workbooks);
            Mapper.CreateMap<EclipseDataAccess.banking_section, BOALedgerDataAccess.banking_section>().ConvertUsing(CustomMapper_banking_section);
            Mapper.CreateMap<EclipseDataAccess.draw_earn, BOALedgerDataAccess.draw_earn>().ConvertUsing(CustomMapper_draw_earn);
            Mapper.CreateMap<EclipseDataAccess.claim_sub_tasks, BOALedgerDataAccess.claim_sub_tasks>().ConvertUsing(CustomMapper_claim_sub_tasks);
            Mapper.CreateMap<EclipseDataAccess.industry_types, BOALedgerDataAccess.industry_types>().ConvertUsing(CustomMapper_industry_types);
            Mapper.CreateMap<EclipseDataAccess.expiry_register, BOALedgerDataAccess.expiry_register>().ConvertUsing(CustomMapper_expiry_register);
            Mapper.CreateMap<EclipseDataAccess.expiry_register_coins, BOALedgerDataAccess.expiry_register_coins>().ConvertUsing(CustomMapper_expiry_register_coins);
            Mapper.CreateMap<EclipseDataAccess.clauses, BOALedgerDataAccess.clauses>().ConvertUsing(CustomMapper_clauses);
            Mapper.CreateMap<EclipseDataAccess.sunrise_insurers, BOALedgerDataAccess.sunrise_insurers>().ConvertUsing(CustomMapper_sunrise_insurers);
            Mapper.CreateMap<EclipseDataAccess.task_types, BOALedgerDataAccess.task_types>().ConvertUsing(CustomMapper_task_types);
            Mapper.CreateMap<EclipseDataAccess.expiry_register_portfolio_analysis, BOALedgerDataAccess.expiry_register_portfolio_analysis>().ConvertUsing(CustomMapper_expiry_register_portfolio_analysis);
            Mapper.CreateMap<EclipseDataAccess.insurer_profiles, BOALedgerDataAccess.insurer_profiles>().ConvertUsing(CustomMapper_insurer_profiles);
            Mapper.CreateMap<EclipseDataAccess.vims_broker_rep_liability, BOALedgerDataAccess.vims_broker_rep_liability>().ConvertUsing(CustomMapper_vims_broker_rep_liability);
            Mapper.CreateMap<EclipseDataAccess.form_settings, BOALedgerDataAccess.form_settings>().ConvertUsing(CustomMapper_form_settings);
            Mapper.CreateMap<EclipseDataAccess.unallocated_cash_return_v, BOALedgerDataAccess.unallocated_cash_return_v>().ConvertUsing(CustomMapper_unallocated_cash_return_v);
            Mapper.CreateMap<EclipseDataAccess.policy_task_status_types, BOALedgerDataAccess.policy_task_status_types>().ConvertUsing(CustomMapper_policy_task_status_types);
            Mapper.CreateMap<EclipseDataAccess.sub_agent_amounts, BOALedgerDataAccess.sub_agent_amounts>().ConvertUsing(CustomMapper_sub_agent_amounts);
            Mapper.CreateMap<EclipseDataAccess.insurer_master_itemised, BOALedgerDataAccess.insurer_master_itemised>().ConvertUsing(CustomMapper_insurer_master_itemised);
            Mapper.CreateMap<EclipseDataAccess.insurer_masterlist, BOALedgerDataAccess.insurer_masterlist>().ConvertUsing(CustomMapper_insurer_masterlist);
            Mapper.CreateMap<EclipseDataAccess.sunrise_policies, BOALedgerDataAccess.sunrise_policies>().ConvertUsing(CustomMapper_sunrise_policies);
            Mapper.CreateMap<EclipseDataAccess.mandatory_fields, BOALedgerDataAccess.mandatory_fields>().ConvertUsing(CustomMapper_mandatory_fields);
            Mapper.CreateMap<EclipseDataAccess.steadfast_uw_codes, BOALedgerDataAccess.steadfast_uw_codes>().ConvertUsing(CustomMapper_steadfast_uw_codes);
            Mapper.CreateMap<EclipseDataAccess.class_of_business, BOALedgerDataAccess.class_of_business>().ConvertUsing(CustomMapper_class_of_business);
            Mapper.CreateMap<EclipseDataAccess.states, BOALedgerDataAccess.states>().ConvertUsing(CustomMapper_states);
            Mapper.CreateMap<EclipseDataAccess.currency, BOALedgerDataAccess.currency>().ConvertUsing(CustomMapper_currency);
            Mapper.CreateMap<EclipseDataAccess.sources_of_business, BOALedgerDataAccess.sources_of_business>().ConvertUsing(CustomMapper_sources_of_business);
            Mapper.CreateMap<EclipseDataAccess.payment_methods, BOALedgerDataAccess.payment_methods>().ConvertUsing(CustomMapper_payment_methods);
            Mapper.CreateMap<EclipseDataAccess.service_teams, BOALedgerDataAccess.service_teams>().ConvertUsing(CustomMapper_service_teams);
            Mapper.CreateMap<EclipseDataAccess.journals, BOALedgerDataAccess.journals>().ConvertUsing(CustomMapper_journals);
            Mapper.CreateMap<EclipseDataAccess.gl_movements, BOALedgerDataAccess.gl_movements>().ConvertUsing(CustomMapper_gl_movements);
            Mapper.CreateMap<EclipseDataAccess.policies_monthly, BOALedgerDataAccess.policies_monthly>().ConvertUsing(CustomMapper_policies_monthly);
            Mapper.CreateMap<EclipseDataAccess.policy_master, BOALedgerDataAccess.policy_master>().ConvertUsing(CustomMapper_policy_master);
            Mapper.CreateMap<EclipseDataAccess.portfolio_analysis_register, BOALedgerDataAccess.portfolio_analysis_register>().ConvertUsing(CustomMapper_portfolio_analysis_register);
            Mapper.CreateMap<EclipseDataAccess.DocumentRepository, BOALedgerDataAccess.DocumentRepository>().ConvertUsing(CustomMapper_DocumentRepository);
            Mapper.CreateMap<EclipseDataAccess.period_renewals, BOALedgerDataAccess.period_renewals>().ConvertUsing(CustomMapper_period_renewals);
            Mapper.CreateMap<EclipseDataAccess.iclose_insurers, BOALedgerDataAccess.iclose_insurers>().ConvertUsing(CustomMapper_iclose_insurers);
            Mapper.CreateMap<EclipseDataAccess.soa_clauses, BOALedgerDataAccess.soa_clauses>().ConvertUsing(CustomMapper_soa_clauses);
            Mapper.CreateMap<EclipseDataAccess.client_account_types, BOALedgerDataAccess.client_account_types>().ConvertUsing(CustomMapper_client_account_types);
            Mapper.CreateMap<EclipseDataAccess.confirmation_of_cover, BOALedgerDataAccess.confirmation_of_cover>().ConvertUsing(CustomMapper_confirmation_of_cover);
            Mapper.CreateMap<EclipseDataAccess.cancellation_reason, BOALedgerDataAccess.cancellation_reason>().ConvertUsing(CustomMapper_cancellation_reason);
            Mapper.CreateMap<EclipseDataAccess.Creditors_ageing_v, BOALedgerDataAccess.Creditors_ageing_v>().ConvertUsing(CustomMapper_Creditors_ageing_v);
            Mapper.CreateMap<EclipseDataAccess.sales_teams, BOALedgerDataAccess.sales_teams>().ConvertUsing(CustomMapper_sales_teams);
            Mapper.CreateMap<EclipseDataAccess.PaidInvoices, BOALedgerDataAccess.PaidInvoices>().ConvertUsing(CustomMapper_PaidInvoices);
            Mapper.CreateMap<EclipseDataAccess.branch_permissions, BOALedgerDataAccess.branch_permissions>().ConvertUsing(CustomMapper_branch_permissions);
            Mapper.CreateMap<EclipseDataAccess.sunrise_instalment_insurer_payments, BOALedgerDataAccess.sunrise_instalment_insurer_payments>().ConvertUsing(CustomMapper_sunrise_instalment_insurer_payments);
            Mapper.CreateMap<EclipseDataAccess.SystemConfigOptions, BOALedgerDataAccess.SystemConfigOptions>().ConvertUsing(CustomMapper_SystemConfigOptions);
            Mapper.CreateMap<EclipseDataAccess.temp_banking_summary2, BOALedgerDataAccess.temp_banking_summary2>().ConvertUsing(CustomMapper_temp_banking_summary2);
            Mapper.CreateMap<EclipseDataAccess.premium_funding, BOALedgerDataAccess.premium_funding>().ConvertUsing(CustomMapper_premium_funding);
            Mapper.CreateMap<EclipseDataAccess.claim_documents, BOALedgerDataAccess.claim_documents>().ConvertUsing(CustomMapper_claim_documents);
            Mapper.CreateMap<EclipseDataAccess.temp_report_sunrise_import_policies, BOALedgerDataAccess.temp_report_sunrise_import_policies>().ConvertUsing(CustomMapper_temp_report_sunrise_import_policies);
            Mapper.CreateMap<EclipseDataAccess.UserConfig, BOALedgerDataAccess.UserConfig>().ConvertUsing(CustomMapper_UserConfig);
            Mapper.CreateMap<EclipseDataAccess.soa_classes_of_business, BOALedgerDataAccess.soa_classes_of_business>().ConvertUsing(CustomMapper_soa_classes_of_business);
            Mapper.CreateMap<EclipseDataAccess.iclose_products, BOALedgerDataAccess.iclose_products>().ConvertUsing(CustomMapper_iclose_products);
            Mapper.CreateMap<EclipseDataAccess.turnoverdetail, BOALedgerDataAccess.turnoverdetail>().ConvertUsing(CustomMapper_turnoverdetail);
            Mapper.CreateMap<EclipseDataAccess.gl_acc_months, BOALedgerDataAccess.gl_acc_months>().ConvertUsing(CustomMapper_gl_acc_months);
            Mapper.CreateMap<EclipseDataAccess.addresses, BOALedgerDataAccess.addresses>().ConvertUsing(CustomMapper_addresses);
            Mapper.CreateMap<EclipseDataAccess.ufi_country_codes, BOALedgerDataAccess.ufi_country_codes>().ConvertUsing(CustomMapper_ufi_country_codes);
            Mapper.CreateMap<EclipseDataAccess.profile, BOALedgerDataAccess.profile>().ConvertUsing(CustomMapper_profile);
            Mapper.CreateMap<EclipseDataAccess.vims_asic_iba, BOALedgerDataAccess.vims_asic_iba>().ConvertUsing(CustomMapper_vims_asic_iba);
            Mapper.CreateMap<EclipseDataAccess.vims_trans_enquiry, BOALedgerDataAccess.vims_trans_enquiry>().ConvertUsing(CustomMapper_vims_trans_enquiry);
            Mapper.CreateMap<EclipseDataAccess.journal_sub_tasks, BOALedgerDataAccess.journal_sub_tasks>().ConvertUsing(CustomMapper_journal_sub_tasks);
            Mapper.CreateMap<EclipseDataAccess.Claim_Notes, BOALedgerDataAccess.Claim_Notes>().ConvertUsing(CustomMapper_Claim_Notes);
            Mapper.CreateMap<EclipseDataAccess.gen_ins_documents, BOALedgerDataAccess.gen_ins_documents>().ConvertUsing(CustomMapper_gen_ins_documents);
            Mapper.CreateMap<EclipseDataAccess.client_classifications, BOALedgerDataAccess.client_classifications>().ConvertUsing(CustomMapper_client_classifications);
            Mapper.CreateMap<EclipseDataAccess.EmailTemplates, BOALedgerDataAccess.EmailTemplates>().ConvertUsing(CustomMapper_EmailTemplates);
            Mapper.CreateMap<EclipseDataAccess.address_types, BOALedgerDataAccess.address_types>().ConvertUsing(CustomMapper_address_types);
            Mapper.CreateMap<EclipseDataAccess.general_insurance, BOALedgerDataAccess.general_insurance>().ConvertUsing(CustomMapper_general_insurance);
            Mapper.CreateMap<EclipseDataAccess.gl_transactions, BOALedgerDataAccess.gl_transactions>().ConvertUsing(CustomMapper_gl_transactions);
            Mapper.CreateMap<EclipseDataAccess.limited_exemptions, BOALedgerDataAccess.limited_exemptions>().ConvertUsing(CustomMapper_limited_exemptions);
            Mapper.CreateMap<EclipseDataAccess.finance_types, BOALedgerDataAccess.finance_types>().ConvertUsing(CustomMapper_finance_types);
            Mapper.CreateMap<EclipseDataAccess.client_insurance_portfolio, BOALedgerDataAccess.client_insurance_portfolio>().ConvertUsing(CustomMapper_client_insurance_portfolio);
            Mapper.CreateMap<EclipseDataAccess.ClientDetails_Category3, BOALedgerDataAccess.ClientDetails_Category3>().ConvertUsing(CustomMapper_ClientDetails_Category3);
            Mapper.CreateMap<EclipseDataAccess.remittance_advice_formats, BOALedgerDataAccess.remittance_advice_formats>().ConvertUsing(CustomMapper_remittance_advice_formats);
            Mapper.CreateMap<EclipseDataAccess.gl_sub_ledgers, BOALedgerDataAccess.gl_sub_ledgers>().ConvertUsing(CustomMapper_gl_sub_ledgers);
            Mapper.CreateMap<EclipseDataAccess.gen_ins_transaction_types, BOALedgerDataAccess.gen_ins_transaction_types>().ConvertUsing(CustomMapper_gen_ins_transaction_types);
            Mapper.CreateMap<EclipseDataAccess.atura_tagvalue, BOALedgerDataAccess.atura_tagvalue>().ConvertUsing(CustomMapper_atura_tagvalue);
            Mapper.CreateMap<EclipseDataAccess.atura_tagrangevalue, BOALedgerDataAccess.atura_tagrangevalue>().ConvertUsing(CustomMapper_atura_tagrangevalue);
            Mapper.CreateMap<EclipseDataAccess.gl_sl_entities, BOALedgerDataAccess.gl_sl_entities>().ConvertUsing(CustomMapper_gl_sl_entities);
            Mapper.CreateMap<EclipseDataAccess.columns, BOALedgerDataAccess.columns>().ConvertUsing(CustomMapper_columns);
            Mapper.CreateMap<EclipseDataAccess.exemption_types, BOALedgerDataAccess.exemption_types>().ConvertUsing(CustomMapper_exemption_types);
            Mapper.CreateMap<EclipseDataAccess.sunrise_server_codes, BOALedgerDataAccess.sunrise_server_codes>().ConvertUsing(CustomMapper_sunrise_server_codes);
            Mapper.CreateMap<EclipseDataAccess.anzic_groups, BOALedgerDataAccess.anzic_groups>().ConvertUsing(CustomMapper_anzic_groups);
            Mapper.CreateMap<EclipseDataAccess.monthly_frequency, BOALedgerDataAccess.monthly_frequency>().ConvertUsing(CustomMapper_monthly_frequency);
            Mapper.CreateMap<EclipseDataAccess.anzic_classes, BOALedgerDataAccess.anzic_classes>().ConvertUsing(CustomMapper_anzic_classes);
            Mapper.CreateMap<EclipseDataAccess.ClaimPaymentTypes, BOALedgerDataAccess.ClaimPaymentTypes>().ConvertUsing(CustomMapper_ClaimPaymentTypes);
            Mapper.CreateMap<EclipseDataAccess.entities, BOALedgerDataAccess.entities>().ConvertUsing(CustomMapper_entities);
            Mapper.CreateMap<EclipseDataAccess.anzic_subdivisions, BOALedgerDataAccess.anzic_subdivisions>().ConvertUsing(CustomMapper_anzic_subdivisions);
            Mapper.CreateMap<EclipseDataAccess.related_entities, BOALedgerDataAccess.related_entities>().ConvertUsing(CustomMapper_related_entities);
            Mapper.CreateMap<EclipseDataAccess.banking, BOALedgerDataAccess.banking>().ConvertUsing(CustomMapper_banking);
            Mapper.CreateMap<EclipseDataAccess.anzic_divisions, BOALedgerDataAccess.anzic_divisions>().ConvertUsing(CustomMapper_anzic_divisions);
            Mapper.CreateMap<EclipseDataAccess.PoliciesNotPosted, BOALedgerDataAccess.PoliciesNotPosted>().ConvertUsing(CustomMapper_PoliciesNotPosted);
            Mapper.CreateMap<EclipseDataAccess.dofi_types, BOALedgerDataAccess.dofi_types>().ConvertUsing(CustomMapper_dofi_types);
            Mapper.CreateMap<EclipseDataAccess.profile_status, BOALedgerDataAccess.profile_status>().ConvertUsing(CustomMapper_profile_status);
            Mapper.CreateMap<EclipseDataAccess.financial_institution, BOALedgerDataAccess.financial_institution>().ConvertUsing(CustomMapper_financial_institution);
            Mapper.CreateMap<EclipseDataAccess.organisation_structures, BOALedgerDataAccess.organisation_structures>().ConvertUsing(CustomMapper_organisation_structures);
            Mapper.CreateMap<EclipseDataAccess.gl_amounts, BOALedgerDataAccess.gl_amounts>().ConvertUsing(CustomMapper_gl_amounts);
            Mapper.CreateMap<EclipseDataAccess.account_types, BOALedgerDataAccess.account_types>().ConvertUsing(CustomMapper_account_types);
            Mapper.CreateMap<EclipseDataAccess.ClientDetails_Category5, BOALedgerDataAccess.ClientDetails_Category5>().ConvertUsing(CustomMapper_ClientDetails_Category5);
            Mapper.CreateMap<EclipseDataAccess.BrokerFeeDefaultWorkbookType, BOALedgerDataAccess.BrokerFeeDefaultWorkbookType>().ConvertUsing(CustomMapper_BrokerFeeDefaultWorkbookType);
            Mapper.CreateMap<EclipseDataAccess.sub_agent_profile, BOALedgerDataAccess.sub_agent_profile>().ConvertUsing(CustomMapper_sub_agent_profile);
            Mapper.CreateMap<EclipseDataAccess.BrokerFeeDefaults, BOALedgerDataAccess.BrokerFeeDefaults>().ConvertUsing(CustomMapper_BrokerFeeDefaults);
            Mapper.CreateMap<EclipseDataAccess.related_entity_types, BOALedgerDataAccess.related_entity_types>().ConvertUsing(CustomMapper_related_entity_types);
            Mapper.CreateMap<EclipseDataAccess.ClausePermissions, BOALedgerDataAccess.ClausePermissions>().ConvertUsing(CustomMapper_ClausePermissions);
            Mapper.CreateMap<EclipseDataAccess.apra_class_of_business, BOALedgerDataAccess.apra_class_of_business>().ConvertUsing(CustomMapper_apra_class_of_business);
            Mapper.CreateMap<EclipseDataAccess.personnel_types, BOALedgerDataAccess.personnel_types>().ConvertUsing(CustomMapper_personnel_types);
            Mapper.CreateMap<EclipseDataAccess.profile_referrer, BOALedgerDataAccess.profile_referrer>().ConvertUsing(CustomMapper_profile_referrer);
            Mapper.CreateMap<EclipseDataAccess.sunrise_mapping, BOALedgerDataAccess.sunrise_mapping>().ConvertUsing(CustomMapper_sunrise_mapping);
            Mapper.CreateMap<EclipseDataAccess.DEFTStatuses, BOALedgerDataAccess.DEFTStatuses>().ConvertUsing(CustomMapper_DEFTStatuses);
            Mapper.CreateMap<EclipseDataAccess.branches, BOALedgerDataAccess.branches>().ConvertUsing(CustomMapper_branches);
            Mapper.CreateMap<EclipseDataAccess.DEFTItemsInError_Custom, BOALedgerDataAccess.DEFTItemsInError_Custom>().ConvertUsing(CustomMapper_DEFTItemsInError_Custom);
            Mapper.CreateMap<EclipseDataAccess.tasks_sub_tasks, BOALedgerDataAccess.tasks_sub_tasks>().ConvertUsing(CustomMapper_tasks_sub_tasks);
            Mapper.CreateMap<EclipseDataAccess.tables, BOALedgerDataAccess.tables>().ConvertUsing(CustomMapper_tables);
            Mapper.CreateMap<EclipseDataAccess.DEFTItemsInError_Predefined, BOALedgerDataAccess.DEFTItemsInError_Predefined>().ConvertUsing(CustomMapper_DEFTItemsInError_Predefined);
            Mapper.CreateMap<EclipseDataAccess.tasks, BOALedgerDataAccess.tasks>().ConvertUsing(CustomMapper_tasks);
            Mapper.CreateMap<EclipseDataAccess.entities_a, BOALedgerDataAccess.entities_a>().ConvertUsing(CustomMapper_entities_a);
            Mapper.CreateMap<EclipseDataAccess.DEFTPredefinedErrors, BOALedgerDataAccess.DEFTPredefinedErrors>().ConvertUsing(CustomMapper_DEFTPredefinedErrors);
            Mapper.CreateMap<EclipseDataAccess.policy_transaction_documents, BOALedgerDataAccess.policy_transaction_documents>().ConvertUsing(CustomMapper_policy_transaction_documents);
            Mapper.CreateMap<EclipseDataAccess.WorkbookHeader, BOALedgerDataAccess.WorkbookHeader>().ConvertUsing(CustomMapper_WorkbookHeader);
            Mapper.CreateMap<EclipseDataAccess.gen_ins_wor_documents, BOALedgerDataAccess.gen_ins_wor_documents>().ConvertUsing(CustomMapper_gen_ins_wor_documents);
            Mapper.CreateMap<EclipseDataAccess.atura_roles, BOALedgerDataAccess.atura_roles>().ConvertUsing(CustomMapper_atura_roles);
            Mapper.CreateMap<EclipseDataAccess.ICloseWorkbookHeader, BOALedgerDataAccess.ICloseWorkbookHeader>().ConvertUsing(CustomMapper_ICloseWorkbookHeader);
            Mapper.CreateMap<EclipseDataAccess.balances, BOALedgerDataAccess.balances>().ConvertUsing(CustomMapper_balances);
            Mapper.CreateMap<EclipseDataAccess.Insurers_Category1, BOALedgerDataAccess.Insurers_Category1>().ConvertUsing(CustomMapper_Insurers_Category1);
            Mapper.CreateMap<EclipseDataAccess.claims, BOALedgerDataAccess.claims>().ConvertUsing(CustomMapper_claims);
            Mapper.CreateMap<EclipseDataAccess.menu_permissions, BOALedgerDataAccess.menu_permissions>().ConvertUsing(CustomMapper_menu_permissions);
            Mapper.CreateMap<EclipseDataAccess.Policy_Notes, BOALedgerDataAccess.Policy_Notes>().ConvertUsing(CustomMapper_Policy_Notes);
            Mapper.CreateMap<EclipseDataAccess.gl_journal_items, BOALedgerDataAccess.gl_journal_items>().ConvertUsing(CustomMapper_gl_journal_items);
            Mapper.CreateMap<EclipseDataAccess.transaction_set_items, BOALedgerDataAccess.transaction_set_items>().ConvertUsing(CustomMapper_transaction_set_items);
            Mapper.CreateMap<EclipseDataAccess.gl_accounts, BOALedgerDataAccess.gl_accounts>().ConvertUsing(CustomMapper_gl_accounts);
            Mapper.CreateMap<EclipseDataAccess.write_off, BOALedgerDataAccess.write_off>().ConvertUsing(CustomMapper_write_off);
            Mapper.CreateMap<EclipseDataAccess.sunrise_instalment, BOALedgerDataAccess.sunrise_instalment>().ConvertUsing(CustomMapper_sunrise_instalment);
            Mapper.CreateMap<EclipseDataAccess.gl_rules, BOALedgerDataAccess.gl_rules>().ConvertUsing(CustomMapper_gl_rules);
            Mapper.CreateMap<EclipseDataAccess.gl_rule_sets, BOALedgerDataAccess.gl_rule_sets>().ConvertUsing(CustomMapper_gl_rule_sets);
            Mapper.CreateMap<EclipseDataAccess.sunrise_workbooks, BOALedgerDataAccess.sunrise_workbooks>().ConvertUsing(CustomMapper_sunrise_workbooks);
            Mapper.CreateMap<EclipseDataAccess.gl_journal, BOALedgerDataAccess.gl_journal>().ConvertUsing(CustomMapper_gl_journal);
            Mapper.CreateMap<EclipseDataAccess.AnzsicCodes, BOALedgerDataAccess.AnzsicCodes>().ConvertUsing(CustomMapper_AnzsicCodes);
            Mapper.CreateMap<EclipseDataAccess.Insurers_Category3, BOALedgerDataAccess.Insurers_Category3>().ConvertUsing(CustomMapper_Insurers_Category3);
            Mapper.CreateMap<EclipseDataAccess.claim_subjects, BOALedgerDataAccess.claim_subjects>().ConvertUsing(CustomMapper_claim_subjects);
            Mapper.CreateMap<EclipseDataAccess.task_status_types, BOALedgerDataAccess.task_status_types>().ConvertUsing(CustomMapper_task_status_types);
            Mapper.CreateMap<EclipseDataAccess.ageing_units, BOALedgerDataAccess.ageing_units>().ConvertUsing(CustomMapper_ageing_units);
            Mapper.CreateMap<EclipseDataAccess.Workbook_Notes, BOALedgerDataAccess.Workbook_Notes>().ConvertUsing(CustomMapper_Workbook_Notes);
            Mapper.CreateMap<EclipseDataAccess.claim_task_status_types, BOALedgerDataAccess.claim_task_status_types>().ConvertUsing(CustomMapper_claim_task_status_types);
            Mapper.CreateMap<EclipseDataAccess.transactions, BOALedgerDataAccess.transactions>().ConvertUsing(CustomMapper_transactions);
            Mapper.CreateMap<EclipseDataAccess.Workbook_SOA, BOALedgerDataAccess.Workbook_SOA>().ConvertUsing(CustomMapper_Workbook_SOA);
            Mapper.CreateMap<EclipseDataAccess.fund_policies2, BOALedgerDataAccess.fund_policies2>().ConvertUsing(CustomMapper_fund_policies2);
            Mapper.CreateMap<EclipseDataAccess.transaction_sets, BOALedgerDataAccess.transaction_sets>().ConvertUsing(CustomMapper_transaction_sets);
            Mapper.CreateMap<EclipseDataAccess.class_of_business_classification, BOALedgerDataAccess.class_of_business_classification>().ConvertUsing(CustomMapper_class_of_business_classification);
            Mapper.CreateMap<EclipseDataAccess.cash_receipt_reversal, BOALedgerDataAccess.cash_receipt_reversal>().ConvertUsing(CustomMapper_cash_receipt_reversal);
            Mapper.CreateMap<EclipseDataAccess.transaction_items, BOALedgerDataAccess.transaction_items>().ConvertUsing(CustomMapper_transaction_items);
            Mapper.CreateMap<EclipseDataAccess.reversed_payments, BOALedgerDataAccess.reversed_payments>().ConvertUsing(CustomMapper_reversed_payments);
            Mapper.CreateMap<EclipseDataAccess.report_parameters, BOALedgerDataAccess.report_parameters>().ConvertUsing(CustomMapper_report_parameters);
            Mapper.CreateMap<EclipseDataAccess.atura_audit, BOALedgerDataAccess.atura_audit>().ConvertUsing(CustomMapper_atura_audit);
            Mapper.CreateMap<EclipseDataAccess.claim_status_types, BOALedgerDataAccess.claim_status_types>().ConvertUsing(CustomMapper_claim_status_types);
            Mapper.CreateMap<EclipseDataAccess.ClaimPaymentDetails, BOALedgerDataAccess.ClaimPaymentDetails>().ConvertUsing(CustomMapper_ClaimPaymentDetails);
            Mapper.CreateMap<EclipseDataAccess.contact_methods, BOALedgerDataAccess.contact_methods>().ConvertUsing(CustomMapper_contact_methods);
            Mapper.CreateMap<EclipseDataAccess.claim_task_types, BOALedgerDataAccess.claim_task_types>().ConvertUsing(CustomMapper_claim_task_types);
            Mapper.CreateMap<EclipseDataAccess.PolicyHeader_Category3, BOALedgerDataAccess.PolicyHeader_Category3>().ConvertUsing(CustomMapper_PolicyHeader_Category3);
            Mapper.CreateMap<EclipseDataAccess.AdvAutoPolNoGenerationItems, BOALedgerDataAccess.AdvAutoPolNoGenerationItems>().ConvertUsing(CustomMapper_AdvAutoPolNoGenerationItems);
            Mapper.CreateMap<EclipseDataAccess.documentmapping, BOALedgerDataAccess.documentmapping>().ConvertUsing(CustomMapper_documentmapping);
            Mapper.CreateMap<EclipseDataAccess.AutoRoundingValues, BOALedgerDataAccess.AutoRoundingValues>().ConvertUsing(CustomMapper_AutoRoundingValues);
            Mapper.CreateMap<EclipseDataAccess.claim_tasks, BOALedgerDataAccess.claim_tasks>().ConvertUsing(CustomMapper_claim_tasks);
            Mapper.CreateMap<EclipseDataAccess.claim_results, BOALedgerDataAccess.claim_results>().ConvertUsing(CustomMapper_claim_results);
            Mapper.CreateMap<EclipseDataAccess.refunds, BOALedgerDataAccess.refunds>().ConvertUsing(CustomMapper_refunds);
            Mapper.CreateMap<EclipseDataAccess.BrokerReps_Category3, BOALedgerDataAccess.BrokerReps_Category3>().ConvertUsing(CustomMapper_BrokerReps_Category3);
            Mapper.CreateMap<EclipseDataAccess.notes, BOALedgerDataAccess.notes>().ConvertUsing(CustomMapper_notes);
            Mapper.CreateMap<EclipseDataAccess.pay_direct, BOALedgerDataAccess.pay_direct>().ConvertUsing(CustomMapper_pay_direct);
            Mapper.CreateMap<EclipseDataAccess.PolicyHeader_Category2, BOALedgerDataAccess.PolicyHeader_Category2>().ConvertUsing(CustomMapper_PolicyHeader_Category2);
            Mapper.CreateMap<EclipseDataAccess.BrokerFeeDefaultsBasis, BOALedgerDataAccess.BrokerFeeDefaultsBasis>().ConvertUsing(CustomMapper_BrokerFeeDefaultsBasis);
            Mapper.CreateMap<EclipseDataAccess.gen_ins_wor_doc_types, BOALedgerDataAccess.gen_ins_wor_doc_types>().ConvertUsing(CustomMapper_gen_ins_wor_doc_types);
            Mapper.CreateMap<EclipseDataAccess.CCFeeTransactions, BOALedgerDataAccess.CCFeeTransactions>().ConvertUsing(CustomMapper_CCFeeTransactions);
            Mapper.CreateMap<EclipseDataAccess.class_of_business_category, BOALedgerDataAccess.class_of_business_category>().ConvertUsing(CustomMapper_class_of_business_category);
            Mapper.CreateMap<EclipseDataAccess.coinsurance, BOALedgerDataAccess.coinsurance>().ConvertUsing(CustomMapper_coinsurance);
            Mapper.CreateMap<EclipseDataAccess.COBMappings, BOALedgerDataAccess.COBMappings>().ConvertUsing(CustomMapper_COBMappings);
            Mapper.CreateMap<EclipseDataAccess.Insurers_Category2, BOALedgerDataAccess.Insurers_Category2>().ConvertUsing(CustomMapper_Insurers_Category2);
            Mapper.CreateMap<EclipseDataAccess.statements_generated_ID, BOALedgerDataAccess.statements_generated_ID>().ConvertUsing(CustomMapper_statements_generated_ID);
            Mapper.CreateMap<EclipseDataAccess.transaction_reasons, BOALedgerDataAccess.transaction_reasons>().ConvertUsing(CustomMapper_transaction_reasons);
            Mapper.CreateMap<EclipseDataAccess.Client_Notes, BOALedgerDataAccess.Client_Notes>().ConvertUsing(CustomMapper_Client_Notes);
            Mapper.CreateMap<EclipseDataAccess.PolicyHeader_Category1, BOALedgerDataAccess.PolicyHeader_Category1>().ConvertUsing(CustomMapper_PolicyHeader_Category1);
            Mapper.CreateMap<EclipseDataAccess.claim_causes, BOALedgerDataAccess.claim_causes>().ConvertUsing(CustomMapper_claim_causes);
            Mapper.CreateMap<EclipseDataAccess.DEFTNotes, BOALedgerDataAccess.DEFTNotes>().ConvertUsing(CustomMapper_DEFTNotes);
            Mapper.CreateMap<EclipseDataAccess.Entity_Modification, BOALedgerDataAccess.Entity_Modification>().ConvertUsing(CustomMapper_Entity_Modification);
            Mapper.CreateMap<EclipseDataAccess.personnel, BOALedgerDataAccess.personnel>().ConvertUsing(CustomMapper_personnel);
            Mapper.CreateMap<EclipseDataAccess.general_insurance_workbooks, BOALedgerDataAccess.general_insurance_workbooks>().ConvertUsing(CustomMapper_general_insurance_workbooks);
            Mapper.CreateMap<EclipseDataAccess.transaction_types, BOALedgerDataAccess.transaction_types>().ConvertUsing(CustomMapper_transaction_types);
            Mapper.CreateMap<EclipseDataAccess.GLSl_Balances, BOALedgerDataAccess.GLSl_Balances>().ConvertUsing(CustomMapper_GLSl_Balances);
            Mapper.CreateMap<EclipseDataAccess.cash_receipts, BOALedgerDataAccess.cash_receipts>().ConvertUsing(CustomMapper_cash_receipts);
            Mapper.CreateMap<EclipseDataAccess.fund_status, BOALedgerDataAccess.fund_status>().ConvertUsing(CustomMapper_fund_status);
            Mapper.CreateMap<EclipseDataAccess.gen_ins_journal_types, BOALedgerDataAccess.gen_ins_journal_types>().ConvertUsing(CustomMapper_gen_ins_journal_types);
        }


        #endregion


        #region AUTO MAPPER CUSTOM MAPPING


        /// <summary>
        /// Custom mapper function for GLSl_Balances table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.GLSl_Balances CustomMapper_GLSl_Balances(EclipseDataAccess.GLSl_Balances source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.GLSl_Balances destination = new BOALedgerDataAccess.GLSl_Balances();
            //
            // Set basic properties
            destination.Glac_num = source.Glac_num;
            destination.Glac_name = source.Glac_name;
            destination.Glac_Type = source.Glac_Type;
            destination.Glsl_id = source.Glsl_id;
            destination.Glsl_name = source.Glsl_name;
            destination.Glsl_balance = source.Glsl_balance;
            destination.Spid = source.Spid;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for cash_receipt_application table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.cash_receipt_application CustomMapper_cash_receipt_application(EclipseDataAccess.cash_receipt_application source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.cash_receipt_application destination = new BOALedgerDataAccess.cash_receipt_application();
            //
            // Set basic properties
            destination.Cra_id = source.Cra_id;
            destination.Cra_Rcpt_id = source.Cra_Rcpt_id;
            destination.Cra_Pol_Trans_id = source.Cra_Pol_Trans_id;
            destination.Cra_Applied_Amount = source.Cra_Applied_Amount;
            destination.cra_created_who = source.cra_created_who;
            destination.cra_created_when = source.cra_created_when;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for fund_status table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.fund_status CustomMapper_fund_status(EclipseDataAccess.fund_status source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.fund_status destination = new BOALedgerDataAccess.fund_status();
            //
            // Set basic properties
            destination.status_id = source.status_id;
            destination.status_desc = source.status_desc;
            destination.status_created_who = source.status_created_who;
            destination.status_created_when = source.status_created_when;
            destination.status_updated_who = source.status_updated_who;
            destination.status_updated_when = source.status_updated_when;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for gen_ins_journal_types table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.gen_ins_journal_types CustomMapper_gen_ins_journal_types(EclipseDataAccess.gen_ins_journal_types source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.gen_ins_journal_types destination = new BOALedgerDataAccess.gen_ins_journal_types();
            //
            // Set basic properties
            destination.genjouty_id = source.genjouty_id;
            destination.genjouty_created_who = source.genjouty_created_who;
            destination.genjouty_created_when = source.genjouty_created_when;
            destination.genjouty_updated_who = source.genjouty_updated_who;
            destination.genjouty_updated_when = source.genjouty_updated_when;
            destination.genjouty_name = source.genjouty_name;
            destination.genjouty_desc = source.genjouty_desc;
            destination.genjouty_inactive = source.genjouty_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for ProductLicenses table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.ProductLicenses CustomMapper_ProductLicenses(EclipseDataAccess.ProductLicenses source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.ProductLicenses destination = new BOALedgerDataAccess.ProductLicenses();
            //
            // Set basic properties
            destination.nId = source.nId;
            destination.strProduct = source.strProduct;
            destination.strKey = source.strKey;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for DEFTStatementIds table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.DEFTStatementIds CustomMapper_DEFTStatementIds(EclipseDataAccess.DEFTStatementIds source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.DEFTStatementIds destination = new BOALedgerDataAccess.DEFTStatementIds();
            //
            // Set basic properties
            destination.deftent_id = source.deftent_id;
            destination.deftent_ent_id = source.deftent_ent_id;
            destination.deftent_highest_statement_id = source.deftent_highest_statement_id;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for BrokerReps_Category2 table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.BrokerReps_Category2 CustomMapper_BrokerReps_Category2(EclipseDataAccess.BrokerReps_Category2 source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.BrokerReps_Category2 destination = new BOALedgerDataAccess.BrokerReps_Category2();
            //
            // Set basic properties
            destination.brcat2_id = source.brcat2_id;
            destination.brcat2_created_who = source.brcat2_created_who;
            destination.brcat2_created_when = source.brcat2_created_when;
            destination.brcat2_updated_who = source.brcat2_updated_who;
            destination.brcat2_updated_when = source.brcat2_updated_when;
            destination.brcat2_name = source.brcat2_name;
            destination.brcat2_desc = source.brcat2_desc;
            destination.brcat2_inactive = source.brcat2_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for SQLUserConfigTable table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.SQLUserConfigTable CustomMapper_SQLUserConfigTable(EclipseDataAccess.SQLUserConfigTable source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.SQLUserConfigTable destination = new BOALedgerDataAccess.SQLUserConfigTable();
            //
            // Set basic properties
            destination.dbname = source.dbname;
            destination.dbusername = source.dbusername;
            destination.dbrole = source.dbrole;
            destination.serverusername = source.serverusername;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for cash_payments table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.cash_payments CustomMapper_cash_payments(EclipseDataAccess.cash_payments source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.cash_payments destination = new BOALedgerDataAccess.cash_payments();
            //
            // Set basic properties
            destination.pay_id = source.pay_id;
            destination.pay_parent_id = source.pay_parent_id;
            destination.pay_paybat_id = source.pay_paybat_id;
            destination.pay_tran_id = source.pay_tran_id;
            destination.pay_amount = source.pay_amount;
            destination.pay_cheque_no = source.pay_cheque_no;
            destination.pay_particulars = source.pay_particulars;
            destination.pay_processed = source.pay_processed;
            destination.pay_processed_date = source.pay_processed_date;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for category_types table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.category_types CustomMapper_category_types(EclipseDataAccess.category_types source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.category_types destination = new BOALedgerDataAccess.category_types();
            //
            // Set basic properties
            destination.cattyp_id = source.cattyp_id;
            destination.cattyp_created_who = source.cattyp_created_who;
            destination.cattyp_created_when = source.cattyp_created_when;
            destination.cattyp_updated_who = source.cattyp_updated_who;
            destination.cattyp_updated_when = source.cattyp_updated_when;
            destination.cattyp_name = source.cattyp_name;
            destination.cattyp_desc = source.cattyp_desc;
            destination.cattyp_inactive = source.cattyp_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for payment_batch table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.payment_batch CustomMapper_payment_batch(EclipseDataAccess.payment_batch source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.payment_batch destination = new BOALedgerDataAccess.payment_batch();
            //
            // Set basic properties
            destination.paybat_id = source.paybat_id;
            destination.paybat_time = source.paybat_time;
            destination.paybat_status = source.paybat_status;
            destination.paybat_ledger = source.paybat_ledger;
            destination.paybat_entity_id = source.paybat_entity_id;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for ClientDetails_Category2 table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.ClientDetails_Category2 CustomMapper_ClientDetails_Category2(EclipseDataAccess.ClientDetails_Category2 source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.ClientDetails_Category2 destination = new BOALedgerDataAccess.ClientDetails_Category2();
            //
            // Set basic properties
            destination.cdcat2_id = source.cdcat2_id;
            destination.cdcat2_created_who = source.cdcat2_created_who;
            destination.cdcat2_created_when = source.cdcat2_created_when;
            destination.cdcat2_updated_who = source.cdcat2_updated_who;
            destination.cdcat2_updated_when = source.cdcat2_updated_when;
            destination.cdcat2_name = source.cdcat2_name;
            destination.cdcat2_desc = source.cdcat2_desc;
            destination.cdcat2_inactive = source.cdcat2_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for policies table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.policies CustomMapper_policies(EclipseDataAccess.policies source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.policies destination = new BOALedgerDataAccess.policies();
            //
            // Set basic properties
            destination.pol_id = source.pol_id;
            destination.pol_parent_id = source.pol_parent_id;
            destination.pol_created_who = source.pol_created_who;
            destination.pol_created_when = source.pol_created_when;
            destination.pol_updated_who = source.pol_updated_who;
            destination.pol_updated_when = source.pol_updated_when;
            destination.pol_duration = source.pol_duration;
            destination.pol_closed = source.pol_closed;
            destination.pol_insurer = source.pol_insurer;
            destination.pol_date_from = source.pol_date_from;
            destination.pol_date_to = source.pol_date_to;
            destination.pol_date_effective = source.pol_date_effective;
            destination.pol_cover_note_number = source.pol_cover_note_number;
            destination.pol_policy_number = source.pol_policy_number;
            destination.pol_sum_insured = source.pol_sum_insured;
            destination.pol_sub_agent = source.pol_sub_agent;
            destination.pol_location = source.pol_location;
            destination.pol_total_base_premium = source.pol_total_base_premium;
            destination.pol_total_levies = source.pol_total_levies;
            destination.pol_total_duties = source.pol_total_duties;
            destination.pol_total_fees = source.pol_total_fees;
            destination.pol_total_gross_premium = source.pol_total_gross_premium;
            destination.pol_total_commission = source.pol_total_commission;
            destination.pol_other_parties = source.pol_other_parties;
            destination.pol_insured = source.pol_insured;
            destination.pol_total_net_premium = source.pol_total_net_premium;
            destination.pol_wor_id = source.pol_wor_id;
            destination.pol_locked = source.pol_locked;
            destination.pol_posted_when = source.pol_posted_when;
            destination.pol_billing_when = source.pol_billing_when;
            destination.pol_closing_when = source.pol_closing_when;
            destination.pol_transaction_type = source.pol_transaction_type;
            destination.pol_tran_id = source.pol_tran_id;
            destination.pol_sub_agent_comm_payable = source.pol_sub_agent_comm_payable;
            destination.pol_debtor = source.pol_debtor;
            destination.pol_insurer_gst = source.pol_insurer_gst;
            destination.pol_date_due = source.pol_date_due;
            destination.pol_sub_agent_fee_payable = source.pol_sub_agent_fee_payable;
            destination.pol_sub_agent_total_payable = source.pol_sub_agent_total_payable;
            destination.pol_date_remitted = source.pol_date_remitted;
            destination.pol_amount_remitted = source.pol_amount_remitted;
            destination.pol_date_remitted_sub = source.pol_date_remitted_sub;
            destination.pol_amount_remitted_sub = source.pol_amount_remitted_sub;
            destination.pol_fee_gst = source.pol_fee_gst;
            destination.pol_comm_gst = source.pol_comm_gst;
            destination.pol_sub_agent_fee_payable_gst = source.pol_sub_agent_fee_payable_gst;
            destination.pol_sub_agent_comm_payable_gst = source.pol_sub_agent_comm_payable_gst;
            destination.pol_total_gst = source.pol_total_gst;
            destination.pol_fee_net_gst = source.pol_fee_net_gst;
            destination.pol_comm_net_gst = source.pol_comm_net_gst;
            destination.pol_sub_agent_fee_pay_net_gst = source.pol_sub_agent_fee_pay_net_gst;
            destination.pol_sub_agent_comm_pay_net_gst = source.pol_sub_agent_comm_pay_net_gst;
            destination.pol_invoice_total = source.pol_invoice_total;
            destination.pol_base_premium = source.pol_base_premium;
            destination.pol_uw_fee_gst = source.pol_uw_fee_gst;
            destination.pol_uw_fee_net_gst = source.pol_uw_fee_net_gst;
            destination.pol_reversed = source.pol_reversed;
            destination.pol_br_net_com_writeoff = source.pol_br_net_com_writeoff;
            destination.pol_net_br_adjustment = source.pol_net_br_adjustment;
            destination.pol_hvi_value = source.pol_hvi_value;
            destination.pol_limited_exemption = source.pol_limited_exemption;
            destination.pol_exemption_type = source.pol_exemption_type;
            destination.pol_posted_who = source.pol_posted_who;
            destination.pol_balance = source.pol_balance;
            destination.pol_terrorism_levy = source.pol_terrorism_levy;
            destination.pol_invoice_comments = source.pol_invoice_comments;
            destination.pol_holding_insurer = source.pol_holding_insurer;
            destination.pol_interested_parties = source.pol_interested_parties;
            destination.pol_closing_comments = source.pol_closing_comments;
            destination.pol_schedule_blob_pointer = source.pol_schedule_blob_pointer;
            destination.pol_scope_of_advice = source.pol_scope_of_advice;
            destination.pol_recommendations = source.pol_recommendations;
            destination.pol_notice1 = source.pol_notice1;
            destination.pol_notice2 = source.pol_notice2;
            destination.pol_notice3 = source.pol_notice3;
            destination.pol_funding_notice_sent = source.pol_funding_notice_sent;
            destination.pol_binder_notice_sent = source.pol_binder_notice_sent;
            destination.pol_date_fsg_supplied = source.pol_date_fsg_supplied;
            destination.pol_auth_rep_notice_sent = source.pol_auth_rep_notice_sent;
            destination.pol_pds_supplied = source.pol_pds_supplied;
            destination.pol_fsg_version_supplied = source.pol_fsg_version_supplied;
            destination.pol_coinsurance = source.pol_coinsurance;
            destination.pol_cancellation_reason = source.pol_cancellation_reason;
            destination.pol_cancellation_notes = source.pol_cancellation_notes;
            destination.pol_cancellation_type = source.pol_cancellation_type;
            destination.pol_step = source.pol_step;
            

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for Total_Earnings table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.Total_Earnings CustomMapper_Total_Earnings(EclipseDataAccess.Total_Earnings source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.Total_Earnings destination = new BOALedgerDataAccess.Total_Earnings();
            //
            // Set basic properties
            destination.GrossEarnings = source.GrossEarnings;
            destination.GSTOnBrokerEarnings = source.GSTOnBrokerEarnings;
            destination.NetBrokerRepEarnings = source.NetBrokerRepEarnings;
            destination.GSTOnBrokerRep = source.GSTOnBrokerRep;
            destination.PreviouslyPaid = source.PreviouslyPaid;
            destination.SPID = source.SPID;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for sunrise_instalment_payments table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.sunrise_instalment_payments CustomMapper_sunrise_instalment_payments(EclipseDataAccess.sunrise_instalment_payments source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.sunrise_instalment_payments destination = new BOALedgerDataAccess.sunrise_instalment_payments();
            //
            // Set basic properties
            destination.sip_id = source.sip_id;
            destination.sip_sunistal_id = source.sip_sunistal_id;
            destination.sip_pol_id = source.sip_pol_id;
            destination.sip_no = source.sip_no;
            destination.sip_due_date = source.sip_due_date;
            destination.sip_date_to = source.sip_date_to;
            destination.sip_status = source.sip_status;
            destination.sip_status_desc = source.sip_status_desc;
            destination.sip_total_due = source.sip_total_due;
            destination.sip_premium = source.sip_premium;
            destination.sip_levy = source.sip_levy;
            destination.sip_duty = source.sip_duty;
            destination.sip_tax = source.sip_tax;
            destination.sip_comm = source.sip_comm;
            destination.sip_comm_tax = source.sip_comm_tax;
            destination.sip_fee = source.sip_fee;
            destination.sip_fee_tax = source.sip_fee_tax;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for cash_payment_applications table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.cash_payment_applications CustomMapper_cash_payment_applications(EclipseDataAccess.cash_payment_applications source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.cash_payment_applications destination = new BOALedgerDataAccess.cash_payment_applications();
            //
            // Set basic properties
            destination.cpa_id = source.cpa_id;
            destination.cpa_paybat_id = source.cpa_paybat_id;
            destination.cpa_inc_id = source.cpa_inc_id;
            destination.cpa_amount = source.cpa_amount;
            destination.cpa_approved = source.cpa_approved;
            destination.cpa_ledger = source.cpa_ledger;
            destination.cpa_entity_id = source.cpa_entity_id;
            destination.cpa_orig_amount = source.cpa_orig_amount;
            destination.cpa_adjust = source.cpa_adjust;
            destination.cpa_earlier_paid = source.cpa_earlier_paid;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for UserConfigOptions table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.UserConfigOptions CustomMapper_UserConfigOptions(EclipseDataAccess.UserConfigOptions source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.UserConfigOptions destination = new BOALedgerDataAccess.UserConfigOptions();
            //
            // Set basic properties
            destination.nUserConfigOptionId = source.nUserConfigOptionId;
            destination.strUsername = source.strUsername;
            destination.strOption = source.strOption;
            destination.strOptionId = source.strOptionId;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for gl_mtd_balances table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.gl_mtd_balances CustomMapper_gl_mtd_balances(EclipseDataAccess.gl_mtd_balances source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.gl_mtd_balances destination = new BOALedgerDataAccess.gl_mtd_balances();
            //
            // Set basic properties
            destination.glmtd_id = source.glmtd_id;
            destination.glmtd_glm_month = source.glmtd_glm_month;
            destination.glmtd_glsl_id = source.glmtd_glsl_id;
            destination.glmtd_op_balance = source.glmtd_op_balance;
            destination.glmtd_cur_balance = source.glmtd_cur_balance;
            destination.glmtd_dr = source.glmtd_dr;
            destination.glmtd_cr = source.glmtd_cr;
            destination.glmtd_glmv_id = source.glmtd_glmv_id;
            destination.glmtd_created_who = source.glmtd_created_who;
            destination.glmtd_created_when = source.glmtd_created_when;
            destination.glmtd_updated_who = source.glmtd_updated_who;
            destination.glmtd_updated_when = source.glmtd_updated_when;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for Client_Task_Notes table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.Client_Task_Notes CustomMapper_Client_Task_Notes(EclipseDataAccess.Client_Task_Notes source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.Client_Task_Notes destination = new BOALedgerDataAccess.Client_Task_Notes();
            //
            // Set basic properties
            destination.Client_not_id = source.Client_not_id;
            destination.Client_not_parent_id = source.Client_not_parent_id;
            destination.Client_not_created_who = source.Client_not_created_who;
            destination.Client_not_created_when = source.Client_not_created_when;
            destination.Client_not_updated_who = source.Client_not_updated_who;
            destination.Client_not_updated_when = source.Client_not_updated_when;
            destination.Client_not_note = source.Client_not_note;
            destination.Client_not_Contact = source.Client_not_Contact;
            destination.Client_not_Subject = source.Client_not_Subject;
            destination.Client_not_phone = source.Client_not_phone;
            destination.Client_not_mobile = source.Client_not_mobile;
            destination.Client_not_email = source.Client_not_email;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for DEFTItems table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.DEFTItems CustomMapper_DEFTItems(EclipseDataAccess.DEFTItems source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.DEFTItems destination = new BOALedgerDataAccess.DEFTItems();
            //
            // Set basic properties
            destination.deft_id = source.deft_id;
            destination.deft_ent_id = source.deft_ent_id;
            destination.deft_pol_tran_id = source.deft_pol_tran_id;
            destination.deft_reference_number = source.deft_reference_number;
            destination.deft_status = source.deft_status;
            destination.deft_timestamp = source.deft_timestamp;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for task_documents table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.task_documents CustomMapper_task_documents(EclipseDataAccess.task_documents source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.task_documents destination = new BOALedgerDataAccess.task_documents();
            //
            // Set basic properties
            destination.tasdoc_id = source.tasdoc_id;
            destination.tasdoc_created_who = source.tasdoc_created_who;
            destination.tasdoc_created_when = source.tasdoc_created_when;
            destination.tasdoc_updated_who = source.tasdoc_updated_who;
            destination.tasdoc_updated_when = source.tasdoc_updated_when;
            destination.tasdoc_name = source.tasdoc_name;
            destination.tasdoc_desc = source.tasdoc_desc;
            destination.tasdoc_inactive = source.tasdoc_inactive;
            destination.tasdoc_branch = source.tasdoc_branch;
            destination.tasdoc_group = source.tasdoc_group;
            destination.tasdoc_exclude_as_template = source.tasdoc_exclude_as_template;
            destination.tasdoc_exclude_as_body = source.tasdoc_exclude_as_body;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for UserWebServiceLogin table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.UserWebServiceLogin CustomMapper_UserWebServiceLogin(EclipseDataAccess.UserWebServiceLogin source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.UserWebServiceLogin destination = new BOALedgerDataAccess.UserWebServiceLogin();
            //
            // Set basic properties
            destination.Id = source.Id;
            destination.UserName = source.UserName;
            destination.SvuUserName = source.SvuUserName;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for areas table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.areas CustomMapper_areas(EclipseDataAccess.areas source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.areas destination = new BOALedgerDataAccess.areas();
            //
            // Set basic properties
            destination.are_id = source.are_id;
            destination.are_created_who = source.are_created_who;
            destination.are_created_when = source.are_created_when;
            destination.are_updated_who = source.are_updated_who;
            destination.are_updated_when = source.are_updated_when;
            destination.are_name = source.are_name;
            destination.are_desc = source.are_desc;
            destination.are_inactive = source.are_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for ClientDetails_Category4 table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.ClientDetails_Category4 CustomMapper_ClientDetails_Category4(EclipseDataAccess.ClientDetails_Category4 source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.ClientDetails_Category4 destination = new BOALedgerDataAccess.ClientDetails_Category4();
            //
            // Set basic properties
            destination.cdcat4_id = source.cdcat4_id;
            destination.cdcat4_created_who = source.cdcat4_created_who;
            destination.cdcat4_created_when = source.cdcat4_created_when;
            destination.cdcat4_updated_who = source.cdcat4_updated_who;
            destination.cdcat4_updated_when = source.cdcat4_updated_when;
            destination.cdcat4_name = source.cdcat4_name;
            destination.cdcat4_desc = source.cdcat4_desc;
            destination.cdcat4_inactive = source.cdcat4_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for WebClientSummaryHeaderFields table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.WebClientSummaryHeaderFields CustomMapper_WebClientSummaryHeaderFields(EclipseDataAccess.WebClientSummaryHeaderFields source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.WebClientSummaryHeaderFields destination = new BOALedgerDataAccess.WebClientSummaryHeaderFields();
            //
            // Set basic properties
            destination.field_Id = source.field_Id;
            destination.field_name = source.field_name;
            destination.field_onlyclient = source.field_onlyclient;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for priorities table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.priorities CustomMapper_priorities(EclipseDataAccess.priorities source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.priorities destination = new BOALedgerDataAccess.priorities();
            //
            // Set basic properties
            destination.pri_id = source.pri_id;
            destination.pri_created_who = source.pri_created_who;
            destination.pri_created_when = source.pri_created_when;
            destination.pri_updated_who = source.pri_updated_who;
            destination.pri_updated_when = source.pri_updated_when;
            destination.pri_name = source.pri_name;
            destination.pri_desc = source.pri_desc;
            destination.pri_inactive = source.pri_inactive;
            destination.pri_colour = source.pri_colour;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for categories table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.categories CustomMapper_categories(EclipseDataAccess.categories source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.categories destination = new BOALedgerDataAccess.categories();
            //
            // Set basic properties
            destination.cat_id = source.cat_id;
            destination.cat_parent_id = source.cat_parent_id;
            destination.cat_created_who = source.cat_created_who;
            destination.cat_created_when = source.cat_created_when;
            destination.cat_updated_who = source.cat_updated_who;
            destination.cat_updated_when = source.cat_updated_when;
            destination.cat_duration = source.cat_duration;
            destination.cat_type = source.cat_type;
            destination.cat_applicable = source.cat_applicable;
            destination.cat_notes = source.cat_notes;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for BrokerReps_Category1 table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.BrokerReps_Category1 CustomMapper_BrokerReps_Category1(EclipseDataAccess.BrokerReps_Category1 source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.BrokerReps_Category1 destination = new BOALedgerDataAccess.BrokerReps_Category1();
            //
            // Set basic properties
            destination.brcat1_id = source.brcat1_id;
            destination.brcat1_created_who = source.brcat1_created_who;
            destination.brcat1_created_when = source.brcat1_created_when;
            destination.brcat1_updated_who = source.brcat1_updated_who;
            destination.brcat1_updated_when = source.brcat1_updated_when;
            destination.brcat1_name = source.brcat1_name;
            destination.brcat1_desc = source.brcat1_desc;
            destination.brcat1_inactive = source.brcat1_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for WebLocker table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.WebLocker CustomMapper_WebLocker(EclipseDataAccess.WebLocker source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.WebLocker destination = new BOALedgerDataAccess.WebLocker();
            //
            // Set basic properties
            destination.webLockId = source.webLockId;
            destination.Category = source.Category;
            destination.ID = source.ID;
            destination.LockID = source.LockID;
            destination.Username = source.Username;
            destination.Login_Time = source.Login_Time;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for Webclient_master_list table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.Webclient_master_list CustomMapper_Webclient_master_list(EclipseDataAccess.Webclient_master_list source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.Webclient_master_list destination = new BOALedgerDataAccess.Webclient_master_list();
            //
            // Set basic properties
            destination.ent_id = source.ent_id;
            destination.ent_name = source.ent_name;
            destination.ent_contact = source.ent_contact;
            destination.ent_telephone = source.ent_telephone;
            destination.ent_suburb = source.ent_suburb;
            destination.sta_name = source.sta_name;
            destination.ent_postcode = source.ent_postcode;
            destination.ent_address_1 = source.ent_address_1;
            destination.ent_address_2 = source.ent_address_2;
            destination.ent_address_3 = source.ent_address_3;
            destination.ent_status = source.ent_status;
            destination.prof_service_team = source.prof_service_team;
            destination.prof_sales_team = source.prof_sales_team;
            destination.prof_sub_agent = source.prof_sub_agent;
            destination.sertea_name = source.sertea_name;
            destination.saltea_name = source.saltea_name;
            destination.prof_area = source.prof_area;
            destination.sub_agent_name = source.sub_agent_name;
            destination.ent_roles = source.ent_roles;
            destination.pol_total_gross_premium = source.pol_total_gross_premium;
            destination.genins_id = source.genins_id;
            destination.prof_source_of_business = source.prof_source_of_business;
            destination.prof_branch = source.prof_branch;
            destination.spid = source.spid;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for gen_ins_classes_of_business table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.gen_ins_classes_of_business CustomMapper_gen_ins_classes_of_business(EclipseDataAccess.gen_ins_classes_of_business source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.gen_ins_classes_of_business destination = new BOALedgerDataAccess.gen_ins_classes_of_business();
            //
            // Set basic properties
            destination.gencob_id = source.gencob_id;
            destination.gencob_created_who = source.gencob_created_who;
            destination.gencob_created_when = source.gencob_created_when;
            destination.gencob_updated_who = source.gencob_updated_who;
            destination.gencob_updated_when = source.gencob_updated_when;
            destination.gencob_name = source.gencob_name;
            destination.gencob_desc = source.gencob_desc;
            destination.gencob_inactive = source.gencob_inactive;
            destination.gencob_category = source.gencob_category;
            destination.gencob_class_code = source.gencob_class_code;
            destination.gencob_class_code_2 = source.gencob_class_code_2;
            destination.gencob_class_code_3 = source.gencob_class_code_3;
            destination.gencob_apra_cob = source.gencob_apra_cob;
            destination.gencob_classification = source.gencob_classification;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for asicadp106 table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.asicadp106 CustomMapper_asicadp106(EclipseDataAccess.asicadp106 source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.asicadp106 destination = new BOALedgerDataAccess.asicadp106();
            //
            // Set basic properties
            destination.pol_tran_id = source.pol_tran_id;
            destination.ent_name = source.ent_name;
            destination.Payable = source.Payable;
            destination.Paid = source.Paid;
            destination.ASIC106 = source.ASIC106;
            destination.type = source.type;
            destination.spid = source.spid;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for gl_ledgers table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.gl_ledgers CustomMapper_gl_ledgers(EclipseDataAccess.ledgers source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.gl_ledgers destination = new BOALedgerDataAccess.gl_ledgers();
            //
            // Set basic properties
            destination.led_id = source.led_id;
            destination.led_created_who = source.led_created_who;
            destination.led_created_when = source.led_created_when;
            destination.led_updated_who = source.led_updated_who;
            destination.led_updated_when = source.led_updated_when;
            destination.led_name = source.led_name;
            destination.led_desc = source.led_desc;
            destination.led_inactive = source.led_inactive;
            destination.led_ageing_units = source.led_ageing_units;
            destination.led_period_0_caption = source.led_period_0_caption;
            destination.led_period_1_caption = source.led_period_1_caption;
            destination.led_period_2_caption = source.led_period_2_caption;
            destination.led_period_3_caption = source.led_period_3_caption;
            destination.led_period_4_caption = source.led_period_4_caption;
            destination.led_period_5_caption = source.led_period_5_caption;
            destination.led_period_1_units = source.led_period_1_units;
            destination.led_period_2_units = source.led_period_2_units;
            destination.led_period_3_units = source.led_period_3_units;
            destination.led_period_4_units = source.led_period_4_units;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for sunrise_products table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.sunrise_products CustomMapper_sunrise_products(EclipseDataAccess.sunrise_products source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.sunrise_products destination = new BOALedgerDataAccess.sunrise_products();
            //
            // Set basic properties
            destination.sunpro_id = source.sunpro_id;
            destination.sunpro_created_who = source.sunpro_created_who;
            destination.sunpro_created_when = source.sunpro_created_when;
            destination.sunpro_updated_who = source.sunpro_updated_who;
            destination.sunpro_updated_when = source.sunpro_updated_when;
            destination.sunpro_parent_id = source.sunpro_parent_id;
            destination.sunpro_name = source.sunpro_name;
            destination.sunpro_desc = source.sunpro_desc;
            destination.sunpro_inactive = source.sunpro_inactive;
            destination.sunpro_genins_wor_id = source.sunpro_genins_wor_id;
            destination.sunpro_server_code = source.sunpro_server_code;
            destination.sunpro_email_name = source.sunpro_email_name;
            destination.sunpro_email_address = source.sunpro_email_address;
            destination.sunpro_particulars_font = source.sunpro_particulars_font;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for ClientDetails_Category1 table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.ClientDetails_Category1 CustomMapper_ClientDetails_Category1(EclipseDataAccess.ClientDetails_Category1 source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.ClientDetails_Category1 destination = new BOALedgerDataAccess.ClientDetails_Category1();
            //
            // Set basic properties
            destination.cdcat1_id = source.cdcat1_id;
            destination.cdcat1_created_who = source.cdcat1_created_who;
            destination.cdcat1_created_when = source.cdcat1_created_when;
            destination.cdcat1_updated_who = source.cdcat1_updated_who;
            destination.cdcat1_updated_when = source.cdcat1_updated_when;
            destination.cdcat1_name = source.cdcat1_name;
            destination.cdcat1_desc = source.cdcat1_desc;
            destination.cdcat1_inactive = source.cdcat1_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for workbooks table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.workbooks CustomMapper_workbooks(EclipseDataAccess.workbooks source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.workbooks destination = new BOALedgerDataAccess.workbooks();
            //
            // Set basic properties
            destination.wor_id = source.wor_id;
            destination.wor_parent_id = source.wor_parent_id;
            destination.wor_created_who = source.wor_created_who;
            destination.wor_created_when = source.wor_created_when;
            destination.wor_updated_who = source.wor_updated_who;
            destination.wor_updated_when = source.wor_updated_when;
            destination.wor_duration = source.wor_duration;
            destination.wor_closed = source.wor_closed;
            destination.wor_contact = source.wor_contact;
            destination.wor_source_of_business = source.wor_source_of_business;
            destination.wor_transaction_type = source.wor_transaction_type;
            destination.wor_workbook = source.wor_workbook;
            destination.wor_notes = source.wor_notes;
            destination.wor_is_hidden = source.wor_is_hidden;
            destination.wor_pol_total_gross_premium = source.wor_pol_total_gross_premium;
            destination.wor_terrorism_levy = source.wor_terrorism_levy;
            destination.wor_invoice_comments = source.wor_invoice_comments;
            destination.wor_DetailsCopied = source.wor_DetailsCopied;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for atura_super_users table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.atura_super_users CustomMapper_atura_super_users(EclipseDataAccess.atura_super_users source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.atura_super_users destination = new BOALedgerDataAccess.atura_super_users();
            //
            // Set basic properties
            destination.atsup_uname = source.atsup_uname;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for occupation_types table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.occupation_types CustomMapper_occupation_types(EclipseDataAccess.occupation_types source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.occupation_types destination = new BOALedgerDataAccess.occupation_types();
            //
            // Set basic properties
            destination.occtyp_id = source.occtyp_id;
            destination.occtyp_created_who = source.occtyp_created_who;
            destination.occtyp_created_when = source.occtyp_created_when;
            destination.occtyp_updated_who = source.occtyp_updated_who;
            destination.occtyp_updated_when = source.occtyp_updated_when;
            destination.occtyp_name = source.occtyp_name;
            destination.occtyp_desc = source.occtyp_desc;
            destination.occtyp_inactive = source.occtyp_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for MenuItems table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.MenuItems CustomMapper_MenuItems(EclipseDataAccess.MenuItems source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.MenuItems destination = new BOALedgerDataAccess.MenuItems();
            //
            // Set basic properties
            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.ParentId = source.ParentId;
            destination.Order = source.Order;
            destination.IsSeparator = source.IsSeparator;
            destination.Command = source.Command;
            destination.Module = source.Module;
            destination.Icon = source.Icon;
            destination.MenuTag = source.MenuTag;
            destination.RequiresEntity = source.RequiresEntity;
            destination.Param1 = source.Param1;
            destination.Param2 = source.Param2;
            destination.Param3 = source.Param3;
            destination.Param4 = source.Param4;
            destination.Param5 = source.Param5;
            destination.Visible = source.Visible;
            destination.OnlyAdminUsers = source.OnlyAdminUsers;
            destination.Group = source.Group;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for industry_types table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.industry_types CustomMapper_industry_types(EclipseDataAccess.industry_types source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.industry_types destination = new BOALedgerDataAccess.industry_types();
            //
            // Set basic properties
            destination.indtyp_id = source.indtyp_id;
            destination.indtyp_created_who = source.indtyp_created_who;
            destination.indtyp_created_when = source.indtyp_created_when;
            destination.indtyp_updated_who = source.indtyp_updated_who;
            destination.indtyp_updated_when = source.indtyp_updated_when;
            destination.indtyp_name = source.indtyp_name;
            destination.indtyp_desc = source.indtyp_desc;
            destination.indtyp_inactive = source.indtyp_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for banking_section table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.banking_section CustomMapper_banking_section(EclipseDataAccess.banking_section source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.banking_section destination = new BOALedgerDataAccess.banking_section();
            //
            // Set basic properties
            destination.bansec_id = source.bansec_id;
            destination.bansec_name = source.bansec_name;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for draw_earn table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.draw_earn CustomMapper_draw_earn(EclipseDataAccess.draw_earn source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.draw_earn destination = new BOALedgerDataAccess.draw_earn();
            //
            // Set basic properties
            destination.pol_id = source.pol_id;
            destination.pol_insurer = source.pol_insurer;
            destination.pol_date_effective = source.pol_date_effective;
            destination.pol_policy_number = source.pol_policy_number;
            destination.pol_transaction_Type = source.pol_transaction_Type;
            destination.pol_sub_agent = source.pol_sub_agent;
            destination.pol_posted_when = source.pol_posted_when;
            destination.pol_parent_id = source.pol_parent_id;
            destination.pol_tran_id = source.pol_tran_id;
            destination.pol_debtor = source.pol_debtor;
            destination.pol_invoice_total = source.pol_invoice_total;
            destination.pol_total_net_premium = source.pol_total_net_premium;
            destination.pol_total_commission = source.pol_total_commission;
            destination.pol_total_fees = source.pol_total_fees;
            destination.pol_sub_agent_comm_payable = source.pol_sub_agent_comm_payable;
            destination.pol_sub_agent_fee_payable = source.pol_sub_agent_fee_payable;
            destination.pol_sub_agent_total_payable = source.pol_sub_agent_total_payable;
            destination.pol_broker_net_commission = source.pol_broker_net_commission;
            destination.NetBrokerCommGST = source.NetBrokerCommGST;
            destination.pol_broker_net_fees = source.pol_broker_net_fees;
            destination.NetFeeGst = source.NetFeeGst;
            destination.pol_total_broker_earnings = source.pol_total_broker_earnings;
            destination.debtor_unadjusted_balance = source.debtor_unadjusted_balance;
            destination.debtor_excess_payment = source.debtor_excess_payment;
            destination.debtor_short_payment = source.debtor_short_payment;
            destination.creditor_adjustments = source.creditor_adjustments;
            destination.received_amt = source.received_amt;
            destination.latest_receipt_date = source.latest_receipt_date;
            destination.Pol_sub_agent_Comm_pay_net_gst = source.Pol_sub_agent_Comm_pay_net_gst;
            destination.Pol_sub_agent_fee_pay_net_gst = source.Pol_sub_agent_fee_pay_net_gst;
            destination.Pol_sub_agent_fee_payable_gst = source.Pol_sub_agent_fee_payable_gst;
            destination.total_earnings = source.total_earnings;
            destination.short_payment_broker_poriton = source.short_payment_broker_poriton;
            destination.short_payment_broker_rep_poriton = source.short_payment_broker_rep_poriton;
            destination.broker_earnings = source.broker_earnings;
            destination.broker_rep_earnings = source.broker_rep_earnings;
            destination.earn_broker_comm = source.earn_broker_comm;
            destination.earn_broker_fee = source.earn_broker_fee;
            destination.earn_broker_rep_comm = source.earn_broker_rep_comm;
            destination.earn_broker_rep_fee = source.earn_broker_rep_fee;
            destination.earn_broker_comm_gst = source.earn_broker_comm_gst;
            destination.earn_broker_fee_gst = source.earn_broker_fee_gst;
            destination.earn_broker_rep_comm_gst = source.earn_broker_rep_comm_gst;
            destination.earn_broker_rep_fee_gst = source.earn_broker_rep_fee_gst;
            destination.genins_name = source.genins_name;
            destination.Ent_ID = source.Ent_ID;
            destination.pol_insured = source.pol_insured;
            destination.genins_class_of_business = source.genins_class_of_business;
            destination.Drawn_Amount = source.Drawn_Amount;
            destination.NetEarned = source.NetEarned;
            destination.SPID = source.SPID;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for claim_sub_tasks table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.claim_sub_tasks CustomMapper_claim_sub_tasks(EclipseDataAccess.claim_sub_tasks source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.claim_sub_tasks destination = new BOALedgerDataAccess.claim_sub_tasks();
            //
            // Set basic properties
            destination.clasubta_id = source.clasubta_id;
            destination.clasubta_parent_id = source.clasubta_parent_id;
            destination.clasubta_created_who = source.clasubta_created_who;
            destination.clasubta_created_when = source.clasubta_created_when;
            destination.clasubta_updated_who = source.clasubta_updated_who;
            destination.clasubta_updated_when = source.clasubta_updated_when;
            destination.clasubta_duration = source.clasubta_duration;
            destination.clasubta_date = source.clasubta_date;
            destination.clasubta_initiated_by = source.clasubta_initiated_by;
            destination.clasubta_brief_description = source.clasubta_brief_description;
            destination.clasubta_document = source.clasubta_document;
            destination.Fname = source.Fname;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for expiry_register table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.expiry_register CustomMapper_expiry_register(EclipseDataAccess.expiry_register source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.expiry_register destination = new BOALedgerDataAccess.expiry_register();
            //
            // Set basic properties
            destination.ent_id = source.ent_id;
            destination.ent_name = source.ent_name;
            destination.ent_contact = source.ent_contact;
            destination.ent_telephone = source.ent_telephone;
            destination.ent_suburb = source.ent_suburb;
            destination.ent_postcode = source.ent_postcode;
            destination.ent_address_1 = source.ent_address_1;
            destination.ent_address_2 = source.ent_address_2;
            destination.ent_address_3 = source.ent_address_3;
            destination.sta_name = source.sta_name;
            destination.prof_service_team = source.prof_service_team;
            destination.prof_sales_team = source.prof_sales_team;
            destination.sertea_name = source.sertea_name;
            destination.saltea_name = source.saltea_name;
            destination.prof_area = source.prof_area;
            destination.genins_id = source.genins_id;
            destination.genins_name = source.genins_name;
            destination.genins_class_of_business = source.genins_class_of_business;
            destination.gencob_name = source.gencob_name;
            destination.pol_id = source.pol_id;
            destination.pol_total_base_premium = source.pol_total_base_premium;
            destination.pol_base_premium = source.pol_base_premium;
            destination.pol_total_levies = source.pol_total_levies;
            destination.pol_total_duties = source.pol_total_duties;
            destination.pol_total_fees = source.pol_total_fees;
            destination.pol_sub_agent_fee_payable = source.pol_sub_agent_fee_payable;
            destination.pol_insurer_gst = source.pol_insurer_gst;
            destination.pol_total_gst = source.pol_total_gst;
            destination.pol_total_gross_premium = source.pol_total_gross_premium;
            destination.pol_total_commission = source.pol_total_commission;
            destination.pol_comm_net_gst = source.pol_comm_net_gst;
            destination.pol_comm_gst = source.pol_comm_gst;
            destination.pol_uw_fee_net_gst = source.pol_uw_fee_net_gst;
            destination.pol_uw_fee_gst = source.pol_uw_fee_gst;
            destination.pol_fee_net_gst = source.pol_fee_net_gst;
            destination.pol_fee_gst = source.pol_fee_gst;
            destination.pol_total_net_premium = source.pol_total_net_premium;
            destination.pol_policy_number = source.pol_policy_number;
            destination.pol_date_from = source.pol_date_from;
            destination.pol_date_to = source.pol_date_to;
            destination.pol_date_effective = source.pol_date_effective;
            destination.pol_insurer = source.pol_insurer;
            destination.insurer_name = source.insurer_name;
            destination.pol_sub_agent = source.pol_sub_agent;
            destination.sub_agent_name = source.sub_agent_name;
            destination.uw_paid = source.uw_paid;
            destination.client_paid = source.client_paid;
            destination.cla_count = source.cla_count;
            destination.pol_tran_id = source.pol_tran_id;
            destination.rpt_group = source.rpt_group;
            destination.SPID = source.SPID;
            destination.Coinsurers = source.Coinsurers;
            destination.pol_parent_id = source.pol_parent_id;
            destination.pol_sub_agent_fee_pay_net_gst = source.pol_sub_agent_fee_pay_net_gst;
            destination.pol_sub_agent_comm_pay_net_gst = source.pol_sub_agent_comm_pay_net_gst;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for expiry_register_coins table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.expiry_register_coins CustomMapper_expiry_register_coins(EclipseDataAccess.expiry_register_coins source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.expiry_register_coins destination = new BOALedgerDataAccess.expiry_register_coins();
            //
            // Set basic properties
            destination.pol_tran_id = source.pol_tran_id;
            destination.coins_parent_id = source.coins_parent_id;
            destination.coins_insurer_id = source.coins_insurer_id;
            destination.coinsurer_name = source.coinsurer_name;
            destination.SPID = source.SPID;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for clauses table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.clauses CustomMapper_clauses(EclipseDataAccess.clauses source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.clauses destination = new BOALedgerDataAccess.clauses();
            //
            // Set basic properties
            destination.clu_id = source.clu_id;
            destination.clu_created_who = source.clu_created_who;
            destination.clu_created_when = source.clu_created_when;
            destination.clu_updated_who = source.clu_updated_who;
            destination.clu_updated_when = source.clu_updated_when;
            destination.clu_name = source.clu_name;
            destination.clu_desc = source.clu_desc;
            destination.clu_inactive = source.clu_inactive;
            destination.clu_clause = source.clu_clause;
            destination.clu_ref = source.clu_ref;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for sunrise_insurers table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.sunrise_insurers CustomMapper_sunrise_insurers(EclipseDataAccess.sunrise_insurers source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.sunrise_insurers destination = new BOALedgerDataAccess.sunrise_insurers();
            //
            // Set basic properties
            destination.sunins_id = source.sunins_id;
            destination.sunins_created_who = source.sunins_created_who;
            destination.sunins_created_when = source.sunins_created_when;
            destination.sunins_updated_who = source.sunins_updated_who;
            destination.sunins_updated_when = source.sunins_updated_when;
            destination.sunins_name = source.sunins_name;
            destination.sunins_desc = source.sunins_desc;
            destination.sunins_inactive = source.sunins_inactive;
            destination.sunins_insurer_id = source.sunins_insurer_id;
            destination.sunins_transmission_code = source.sunins_transmission_code;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for vims_broker_rep_liability table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.vims_broker_rep_liability CustomMapper_vims_broker_rep_liability(EclipseDataAccess.vims_broker_rep_liability source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.vims_broker_rep_liability destination = new BOALedgerDataAccess.vims_broker_rep_liability();
            //
            // Set basic properties
            destination.ent_id = source.ent_id;
            destination.client_name = source.client_name;
            destination.saltea_id = source.saltea_id;
            destination.saltea_name = source.saltea_name;
            destination.sertea_id = source.sertea_id;
            destination.sertea_name = source.sertea_name;
            destination.gencob_id = source.gencob_id;
            destination.gencob_name = source.gencob_name;
            destination.pol_tran_id = source.pol_tran_id;
            destination.insurer_id = source.insurer_id;
            destination.insurer_name = source.insurer_name;
            destination.subagent_id = source.subagent_id;
            destination.sub_agent_name = source.sub_agent_name;
            destination.pol_policy_number = source.pol_policy_number;
            destination.pol_date_effective = source.pol_date_effective;
            destination.pol_invoice_total = source.pol_invoice_total;
            destination.pol_sub_agent_fee_payable_gst = source.pol_sub_agent_fee_payable_gst;
            destination.pol_sub_agent_comm_payable_gst = source.pol_sub_agent_comm_payable_gst;
            destination.pol_sub_agent_fee_pay_net_gst = source.pol_sub_agent_fee_pay_net_gst;
            destination.pol_sub_agent_comm_pay_net_Gst = source.pol_sub_agent_comm_pay_net_Gst;
            destination.debtor_paid = source.debtor_paid;
            destination.broker_rep_paid = source.broker_rep_paid;
            destination.broker_rep_payable = source.broker_rep_payable;
            destination.DebtorFullyPaid = source.DebtorFullyPaid;
            destination.spid = source.spid;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for unallocated_cash_return_v table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.unallocated_cash_return_v CustomMapper_unallocated_cash_return_v(EclipseDataAccess.unallocated_cash_return_v source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.unallocated_cash_return_v destination = new BOALedgerDataAccess.unallocated_cash_return_v();
            //
            // Set basic properties
            destination.Ent_Name = source.Ent_Name;
            destination.tran_id = source.tran_id;
            destination.tran_time = source.tran_time;
            destination.tran_type = source.tran_type;
            destination.particulars = source.particulars;
            destination.amount = source.amount;
            destination.bal_amount = source.bal_amount;
            destination.SPID = source.SPID;
            destination.Ent_ID = source.Ent_ID;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for task_types table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.task_types CustomMapper_task_types(EclipseDataAccess.task_types source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.task_types destination = new BOALedgerDataAccess.task_types();
            //
            // Set basic properties
            destination.tastyp_id = source.tastyp_id;
            destination.tastyp_created_who = source.tastyp_created_who;
            destination.tastyp_created_when = source.tastyp_created_when;
            destination.tastyp_updated_who = source.tastyp_updated_who;
            destination.tastyp_updated_when = source.tastyp_updated_when;
            destination.tastyp_name = source.tastyp_name;
            destination.tastyp_desc = source.tastyp_desc;
            destination.tastyp_inactive = source.tastyp_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for expiry_register_portfolio_analysis table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.expiry_register_portfolio_analysis CustomMapper_expiry_register_portfolio_analysis(EclipseDataAccess.expiry_register_portfolio_analysis source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.expiry_register_portfolio_analysis destination = new BOALedgerDataAccess.expiry_register_portfolio_analysis();
            //
            // Set basic properties
            destination.ent_id = source.ent_id;
            destination.ent_name = source.ent_name;
            destination.ent_contact = source.ent_contact;
            destination.ent_telephone = source.ent_telephone;
            destination.ent_suburb = source.ent_suburb;
            destination.ent_postcode = source.ent_postcode;
            destination.ent_address_1 = source.ent_address_1;
            destination.ent_address_2 = source.ent_address_2;
            destination.ent_address_3 = source.ent_address_3;
            destination.sta_name = source.sta_name;
            destination.prof_service_team = source.prof_service_team;
            destination.prof_sales_team = source.prof_sales_team;
            destination.sertea_name = source.sertea_name;
            destination.saltea_name = source.saltea_name;
            destination.prof_area = source.prof_area;
            destination.genins_id = source.genins_id;
            destination.genins_name = source.genins_name;
            destination.genins_class_of_business = source.genins_class_of_business;
            destination.gencob_name = source.gencob_name;
            destination.pol_id = source.pol_id;
            destination.pol_total_base_premium = source.pol_total_base_premium;
            destination.pol_base_premium = source.pol_base_premium;
            destination.pol_total_levies = source.pol_total_levies;
            destination.pol_total_duties = source.pol_total_duties;
            destination.pol_total_fees = source.pol_total_fees;
            destination.pol_sub_agent_fee_payable = source.pol_sub_agent_fee_payable;
            destination.pol_insurer_gst = source.pol_insurer_gst;
            destination.pol_total_gst = source.pol_total_gst;
            destination.pol_total_gross_premium = source.pol_total_gross_premium;
            destination.pol_total_commission = source.pol_total_commission;
            destination.pol_comm_net_gst = source.pol_comm_net_gst;
            destination.pol_comm_gst = source.pol_comm_gst;
            destination.pol_uw_fee_net_gst = source.pol_uw_fee_net_gst;
            destination.pol_uw_fee_gst = source.pol_uw_fee_gst;
            destination.pol_fee_net_gst = source.pol_fee_net_gst;
            destination.pol_fee_gst = source.pol_fee_gst;
            destination.pol_total_net_premium = source.pol_total_net_premium;
            destination.pol_policy_number = source.pol_policy_number;
            destination.pol_date_from = source.pol_date_from;
            destination.pol_date_to = source.pol_date_to;
            destination.pol_date_effective = source.pol_date_effective;
            destination.pol_insurer = source.pol_insurer;
            destination.insurer_name = source.insurer_name;
            destination.pol_sub_agent = source.pol_sub_agent;
            destination.sub_agent_name = source.sub_agent_name;
            destination.uw_paid = source.uw_paid;
            destination.client_paid = source.client_paid;
            destination.cla_count = source.cla_count;
            destination.pol_tran_id = source.pol_tran_id;
            destination.rpt_group = source.rpt_group;
            destination.SPID = source.SPID;
            destination.Coinsurers = source.Coinsurers;
            destination.pol_parent_id = source.pol_parent_id;
            destination.pol_sub_agent_fee_pay_net_gst = source.pol_sub_agent_fee_pay_net_gst;
            destination.pol_sub_agent_comm_pay_net_gst = source.pol_sub_agent_comm_pay_net_gst;
            destination.pol_cc_fee = source.pol_cc_fee;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for insurer_profiles table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.insurer_profiles CustomMapper_insurer_profiles(EclipseDataAccess.insurer_profiles source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.insurer_profiles destination = new BOALedgerDataAccess.insurer_profiles();
            //
            // Set basic properties
            destination.inspro_id = source.inspro_id;
            destination.inspro_parent_id = source.inspro_parent_id;
            destination.inspro_created_who = source.inspro_created_who;
            destination.inspro_created_when = source.inspro_created_when;
            destination.inspro_updated_who = source.inspro_updated_who;
            destination.inspro_updated_when = source.inspro_updated_when;
            destination.inspro_remittance_advice_format = source.inspro_remittance_advice_format;
            destination.inspro_include_printed_copy = source.inspro_include_printed_copy;
            destination.inspro_auto_payment = source.inspro_auto_payment;
            destination.inspro_exclude_man_payment = source.inspro_exclude_man_payment;
            destination.inspro_accept_part_payment = source.inspro_accept_part_payment;
            destination.inspro_remittance_email_address = source.inspro_remittance_email_address;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for form_settings table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.form_settings CustomMapper_form_settings(EclipseDataAccess.form_settings source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.form_settings destination = new BOALedgerDataAccess.form_settings();
            //
            // Set basic properties
            destination.username = source.username;
            destination.form_id = source.form_id;
            destination.var_name = source.var_name;
            destination.value = source.value;
            destination.id = source.id;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for sub_agent_amounts table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.sub_agent_amounts CustomMapper_sub_agent_amounts(EclipseDataAccess.sub_agent_amounts source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.sub_agent_amounts destination = new BOALedgerDataAccess.sub_agent_amounts();
            //
            // Set basic properties
            destination.saamt_id = source.saamt_id;
            destination.saamt_parent_id = source.saamt_parent_id;
            destination.saamt_created_who = source.saamt_created_who;
            destination.saamt_created_when = source.saamt_created_when;
            destination.saamt_updated_who = source.saamt_updated_who;
            destination.saamt_updated_when = source.saamt_updated_when;
            destination.saamt_duration = source.saamt_duration;
            destination.saamt_sub_agent_id = source.saamt_sub_agent_id;
            destination.saamt_comm_payable = source.saamt_comm_payable;
            destination.saamt_comm_payable_gst = source.saamt_comm_payable_gst;
            destination.saamt_fee_payable = source.saamt_fee_payable;
            destination.saamt_fee_payable_gst = source.saamt_fee_payable_gst;
            destination.saamt_total_payable = source.saamt_total_payable;
            destination.saamt_fee_payable_net_gst = source.saamt_fee_payable_net_gst;
            destination.saamt_comm_payable_net_gst = source.saamt_comm_payable_net_gst;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for policy_task_status_types table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.policy_task_status_types CustomMapper_policy_task_status_types(EclipseDataAccess.policy_task_status_types source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.policy_task_status_types destination = new BOALedgerDataAccess.policy_task_status_types();
            //
            // Set basic properties
            destination.poltst_id = source.poltst_id;
            destination.poltst_created_who = source.poltst_created_who;
            destination.poltst_created_when = source.poltst_created_when;
            destination.poltst_updated_who = source.poltst_updated_who;
            destination.poltst_updated_when = source.poltst_updated_when;
            destination.poltst_name = source.poltst_name;
            destination.poltst_desc = source.poltst_desc;
            destination.poltst_inactive = source.poltst_inactive;
            destination.poltst_closed = source.poltst_closed;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for sunrise_policies table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.sunrise_policies CustomMapper_sunrise_policies(EclipseDataAccess.sunrise_policies source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.sunrise_policies destination = new BOALedgerDataAccess.sunrise_policies();
            //
            // Set basic properties
            destination.sunpol_id = source.sunpol_id;
            destination.sunpol_parent_id = source.sunpol_parent_id;
            destination.sunpol_lastsavedon = source.sunpol_lastsavedon;
            destination.sunpol_contractstage = source.sunpol_contractstage;
            destination.sunpol_contractstatus = source.sunpol_contractstatus;
            destination.sunpol_processstatus = source.sunpol_processstatus;
            destination.sunpol_closetype = source.sunpol_closetype;
            destination.sunpol_supplierid = source.sunpol_supplierid;
            destination.sunpol_productid = source.sunpol_productid;
            destination.sunpol_reference_no = null;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for insurer_master_itemised table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.insurer_master_itemised CustomMapper_insurer_master_itemised(EclipseDataAccess.insurer_master_itemised source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.insurer_master_itemised destination = new BOALedgerDataAccess.insurer_master_itemised();
            //
            // Set basic properties
            destination.pol_created_when = source.pol_created_when;
            destination.pol_id = source.pol_id;
            destination.pol_tran_id = source.pol_tran_id;
            destination.pol_date_effective = source.pol_date_effective;
            destination.pol_date_from = source.pol_date_from;
            destination.pol_date_to = source.pol_date_to;
            destination.pol_policy_number = source.pol_policy_number;
            destination.pol_insured = source.pol_insured;
            destination.genins_class_of_business = source.genins_class_of_business;
            destination.gencob_id = source.gencob_id;
            destination.gencob_name = source.gencob_name;
            destination.coins_id = source.coins_id;
            destination.coinspercent = source.coinspercent;
            destination.base_premium = source.base_premium;
            destination.levies = source.levies;
            destination.commission = source.commission;
            destination.commission_gst = source.commission_gst;
            destination.gross_premium = source.gross_premium;
            destination.net_premium = source.net_premium;
            destination.policycharge = source.policycharge;
            destination.policychargegst = source.policychargegst;
            destination.othercharges = source.othercharges;
            destination.pol_posted_when = source.pol_posted_when;
            destination.pol_billing_when = source.pol_billing_when;
            destination.gentrans_name = source.gentrans_name;
            destination.insurer_id = source.insurer_id;
            destination.insurer_name = source.insurer_name;
            destination.duties = source.duties;
            destination.insurer_gst = source.insurer_gst;
            destination.spid = source.spid;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for PaidInvoices table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.PaidInvoices CustomMapper_PaidInvoices(EclipseDataAccess.PaidInvoices source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.PaidInvoices destination = new BOALedgerDataAccess.PaidInvoices();
            //
            // Set basic properties
            destination.tritm_tran_id = source.tritm_tran_id;
            destination.tritm_amount = source.tritm_amount;
            destination.Paid = source.Paid;
            destination.Remaining = source.Remaining;
            destination.tritm_inc_id = source.tritm_inc_id;
            destination.DatePaid = source.DatePaid;
            destination.spid = source.spid;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for insurer_masterlist table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.insurer_masterlist CustomMapper_insurer_masterlist(EclipseDataAccess.insurer_masterlist source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.insurer_masterlist destination = new BOALedgerDataAccess.insurer_masterlist();
            //
            // Set basic properties
            destination.ent_name = source.ent_name;
            destination.ent_address_1 = source.ent_address_1;
            destination.ent_address_2 = source.ent_address_2;
            destination.ent_address_3 = source.ent_address_3;
            destination.ent_suburb = source.ent_suburb;
            destination.ent_state = source.ent_state;
            destination.sta_name = source.sta_name;
            destination.ent_postcode = source.ent_postcode;
            destination.ent_contact = source.ent_contact;
            destination.ent_telephone = source.ent_telephone;
            destination.cob_days_credit = source.cob_days_credit;
            destination.cob_days_held_covered = source.cob_days_held_covered;
            destination.cob_commission = source.cob_commission;
            destination.gencob_name = source.gencob_name;
            destination.pol_sum_insured_MTD = source.pol_sum_insured_MTD;
            destination.pol_total_base_premium_MTD = source.pol_total_base_premium_MTD;
            destination.pol_total_levies_MTD = source.pol_total_levies_MTD;
            destination.pol_total_duties_MTD = source.pol_total_duties_MTD;
            destination.pol_total_fees_MTD = source.pol_total_fees_MTD;
            destination.pol_total_gross_premium_MTD = source.pol_total_gross_premium_MTD;
            destination.pol_total_commission_MTD = source.pol_total_commission_MTD;
            destination.pol_commission_MTD = source.pol_commission_MTD;
            destination.pol_commission_gst_MTD = source.pol_commission_gst_MTD;
            destination.pol_insurer_gst_MTD = source.pol_insurer_gst_MTD;
            destination.pol_uw_fee_MTD = source.pol_uw_fee_MTD;
            destination.pol_uw_fee_gst_MTD = source.pol_uw_fee_gst_MTD;
            destination.pol_othercharges_MTD = source.pol_othercharges_MTD;
            destination.pol_sub_agent_commission_MTD = source.pol_sub_agent_commission_MTD;
            destination.pol_total_net_premium_MTD = source.pol_total_net_premium_MTD;
            destination.pol_sum_insured = source.pol_sum_insured;
            destination.pol_total_base_premium = source.pol_total_base_premium;
            destination.pol_total_levies = source.pol_total_levies;
            destination.pol_total_duties = source.pol_total_duties;
            destination.pol_total_fees = source.pol_total_fees;
            destination.pol_total_gross_premium = source.pol_total_gross_premium;
            destination.pol_total_commission = source.pol_total_commission;
            destination.pol_commission = source.pol_commission;
            destination.pol_commission_gst = source.pol_commission_gst;
            destination.pol_insurer_gst = source.pol_insurer_gst;
            destination.pol_uw_fee = source.pol_uw_fee;
            destination.pol_uw_fee_gst = source.pol_uw_fee_gst;
            destination.pol_othercharges = source.pol_othercharges;
            destination.pol_sub_agent_commission = source.pol_sub_agent_commission;
            destination.pol_total_net_premium = source.pol_total_net_premium;
            destination.cla_paid_MTD = source.cla_paid_MTD;
            destination.cla_paid = source.cla_paid;
            destination.insurer_id = source.insurer_id;
            destination.gencob_id = source.gencob_id;
            destination.SPID = source.SPID;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for mandatory_fields table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.mandatory_fields CustomMapper_mandatory_fields(EclipseDataAccess.mandatory_fields source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.mandatory_fields destination = new BOALedgerDataAccess.mandatory_fields();
            //
            // Set basic properties
            destination.mandf_field_name = source.mandf_field_name;
            destination.mandf_role_name = source.mandf_role_name;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for steadfast_uw_codes table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.steadfast_uw_codes CustomMapper_steadfast_uw_codes(EclipseDataAccess.steadfast_uw_codes source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.steadfast_uw_codes destination = new BOALedgerDataAccess.steadfast_uw_codes();
            //
            // Set basic properties
            destination.suc_id = source.suc_id;
            destination.suc_insurer_id = source.suc_insurer_id;
            destination.suc_uw_code = source.suc_uw_code;
            destination.suc_description = source.suc_description;
            destination.suc_sp = source.suc_sp;
            destination.suc_created_who = source.suc_created_who;
            destination.suc_created_when = source.suc_created_when;
            destination.suc_updated_who = source.suc_updated_who;
            destination.suc_updated_when = source.suc_updated_when;
            destination.suc_sort = source.suc_sort;
            destination.suc_inactive = source.suc_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for class_of_business table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.class_of_business CustomMapper_class_of_business(EclipseDataAccess.class_of_business source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.class_of_business destination = new BOALedgerDataAccess.class_of_business();
            //
            // Set basic properties
            destination.cob_id = source.cob_id;
            destination.cob_parent_id = source.cob_parent_id;
            destination.cob_created_who = source.cob_created_who;
            destination.cob_created_when = source.cob_created_when;
            destination.cob_updated_who = source.cob_updated_who;
            destination.cob_updated_when = source.cob_updated_when;
            destination.cob_duration = source.cob_duration;
            destination.cob_notes = source.cob_notes;
            destination.cob_days_credit = source.cob_days_credit;
            destination.cob_days_held_covered = source.cob_days_held_covered;
            destination.cob_class_of_business = source.cob_class_of_business;
            destination.cob_commission = source.cob_commission;
            destination.cob_auto_pol_number = source.cob_auto_pol_number;
            destination.cob_pol_number_prefix = source.cob_pol_number_prefix;
            destination.cob_pol_number_suffix = source.cob_pol_number_suffix;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for currency table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.currency CustomMapper_currency(EclipseDataAccess.currency source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.currency destination = new BOALedgerDataAccess.currency();
            //
            // Set basic properties
            destination.cur_id = source.cur_id;
            destination.cur_created_who = source.cur_created_who;
            destination.cur_created_when = source.cur_created_when;
            destination.cur_updated_who = source.cur_updated_who;
            destination.cur_updated_when = source.cur_updated_when;
            destination.cur_name = source.cur_name;
            destination.cur_desc = source.cur_desc;
            destination.cur_inactive = source.cur_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for service_teams table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.service_teams CustomMapper_service_teams(EclipseDataAccess.service_teams source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.service_teams destination = new BOALedgerDataAccess.service_teams();
            //
            // Set basic properties
            destination.sertea_id = source.sertea_id;
            destination.sertea_created_who = source.sertea_created_who;
            destination.sertea_created_when = source.sertea_created_when;
            destination.sertea_updated_who = source.sertea_updated_who;
            destination.sertea_updated_when = source.sertea_updated_when;
            destination.sertea_name = source.sertea_name;
            destination.sertea_desc = source.sertea_desc;
            destination.sertea_inactive = source.sertea_inactive;
            destination.sertea_full_name = source.sertea_full_name;
            destination.sertea_branch_id = source.sertea_branch_id;
            destination.sertea_title = source.sertea_title;
            destination.sertea_address = source.sertea_address;
            destination.sertea_suburb = source.sertea_suburb;
            destination.sertea_state = source.sertea_state;
            destination.sertea_postcode = source.sertea_postcode;
            destination.sertea_phone = source.sertea_phone;
            destination.sertea_mobile = source.sertea_mobile;
            destination.sertea_email = source.sertea_email;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for states table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.states CustomMapper_states(EclipseDataAccess.states source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.states destination = new BOALedgerDataAccess.states();
            //
            // Set basic properties
            destination.sta_id = source.sta_id;
            destination.sta_created_who = source.sta_created_who;
            destination.sta_created_when = source.sta_created_when;
            destination.sta_updated_who = source.sta_updated_who;
            destination.sta_updated_when = source.sta_updated_when;
            destination.sta_name = source.sta_name;
            destination.sta_desc = source.sta_desc;
            destination.sta_inactive = source.sta_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for gl_movements table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.gl_movements CustomMapper_gl_movements(EclipseDataAccess.gl_movements source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.gl_movements destination = new BOALedgerDataAccess.gl_movements();
            //
            // Set basic properties
            destination.glmv_id = source.glmv_id;
            destination.glmv_date = source.glmv_date;
            destination.glmv_tran_type = source.glmv_tran_type;
            destination.glmv_glrs_set = source.glmv_glrs_set;
            destination.glmv_processed = source.glmv_processed;
            destination.glmv_glm_month = source.glmv_glm_month;
            destination.glmv_record_ref_id = source.glmv_record_ref_id;
            destination.glmv_created_who = source.glmv_created_who;
            destination.glmv_created_when = source.glmv_created_when;
            destination.glmv_updated_who = source.glmv_updated_who;
            destination.glmv_updated_when = source.glmv_updated_when;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for sources_of_business table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.sources_of_business CustomMapper_sources_of_business(EclipseDataAccess.sources_of_business source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.sources_of_business destination = new BOALedgerDataAccess.sources_of_business();
            //
            // Set basic properties
            destination.souofbus_id = source.souofbus_id;
            destination.souofbus_created_who = source.souofbus_created_who;
            destination.souofbus_created_when = source.souofbus_created_when;
            destination.souofbus_updated_who = source.souofbus_updated_who;
            destination.souofbus_updated_when = source.souofbus_updated_when;
            destination.souofbus_name = source.souofbus_name;
            destination.souofbus_desc = source.souofbus_desc;
            destination.souofbus_inactive = source.souofbus_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for payment_methods table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.payment_methods CustomMapper_payment_methods(EclipseDataAccess.payment_methods source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.payment_methods destination = new BOALedgerDataAccess.payment_methods();
            //
            // Set basic properties
            destination.paymet_id = source.paymet_id;
            destination.paymet_method = source.paymet_method;
            destination.paymet_banking_section = source.paymet_banking_section;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for journals table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.journals CustomMapper_journals(EclipseDataAccess.journals source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.journals destination = new BOALedgerDataAccess.journals();
            //
            // Set basic properties
            destination.jou_id = source.jou_id;
            destination.jou_parent_id = source.jou_parent_id;
            destination.jou_created_who = source.jou_created_who;
            destination.jou_created_when = source.jou_created_when;
            destination.jou_updated_who = source.jou_updated_who;
            destination.jou_updated_when = source.jou_updated_when;
            destination.jou_duration = source.jou_duration;
            destination.jou_closed = source.jou_closed;
            destination.jou_contact = source.jou_contact;
            destination.jou_method = source.jou_method;
            destination.jou_type = source.jou_type;
            destination.jou_brief_description = source.jou_brief_description;
            destination.jou_notes = source.jou_notes;
            destination.jou_document = source.jou_document;
            destination.jou_date = source.jou_date;
            destination.jou_initiated_by = source.jou_initiated_by;
            destination.jou_followup_date = source.jou_followup_date;
            destination.jou_followup_action = source.jou_followup_action;
            destination.jou_status = source.jou_status;
            destination.jou_priority = source.jou_priority;
            destination.jou_queue = source.jou_queue;
            destination.jou_re_open_Date = source.jou_re_open_Date;
            destination.jou_re_open_User = source.jou_re_open_User;
            destination.jou_original_que_person = source.jou_original_que_person;
            destination.jou_Draft = source.jou_Draft;
            destination.jou_poltran_doctype = source.jou_poltran_doctype;
            destination.jou_contact_phone = source.jou_contact_phone;
            destination.jou_contact_mobile = source.jou_contact_mobile;
            destination.jou_contact_email = source.jou_contact_email;
            destination.jou_parent_id = source.jou_parent_id;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for policies_monthly table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.policies_monthly CustomMapper_policies_monthly(EclipseDataAccess.policies_monthly source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.policies_monthly destination = new BOALedgerDataAccess.policies_monthly();
            //
            // Set basic properties
            destination.polmon_pol_id = source.polmon_pol_id;
            destination.polmon_wor_id = source.polmon_wor_id;
            destination.polmon_installment_no = source.polmon_installment_no;
            destination.polmon_installment_index = source.polmon_installment_index;
            destination.polmon_genins_id = source.polmon_genins_id;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for policy_master table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.policy_master CustomMapper_policy_master(EclipseDataAccess.policy_master source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.policy_master destination = new BOALedgerDataAccess.policy_master();
            //
            // Set basic properties
            destination.ent_id = source.ent_id;
            destination.ent_name = source.ent_name;
            destination.ent_contact = source.ent_contact;
            destination.ent_telephone = source.ent_telephone;
            destination.ent_suburb = source.ent_suburb;
            destination.ent_postcode = source.ent_postcode;
            destination.ent_address_1 = source.ent_address_1;
            destination.ent_address_2 = source.ent_address_2;
            destination.ent_address_3 = source.ent_address_3;
            destination.sta_name = source.sta_name;
            destination.prof_service_team = source.prof_service_team;
            destination.prof_sales_team = source.prof_sales_team;
            destination.sertea_name = source.sertea_name;
            destination.saltea_name = source.saltea_name;
            destination.prof_area = source.prof_area;
            destination.genins_id = source.genins_id;
            destination.genins_name = source.genins_name;
            destination.genins_class_of_business = source.genins_class_of_business;
            destination.gencob_name = source.gencob_name;
            destination.pol_id = source.pol_id;
            destination.pol_total_base_premium = source.pol_total_base_premium;
            destination.pol_base_premium = source.pol_base_premium;
            destination.pol_total_levies = source.pol_total_levies;
            destination.pol_total_duties = source.pol_total_duties;
            destination.pol_total_fees = source.pol_total_fees;
            destination.pol_sub_agent_fee_payable = source.pol_sub_agent_fee_payable;
            destination.pol_insurer_gst = source.pol_insurer_gst;
            destination.pol_total_gst = source.pol_total_gst;
            destination.pol_total_gross_premium = source.pol_total_gross_premium;
            destination.pol_total_commission = source.pol_total_commission;
            destination.pol_comm_net_gst = source.pol_comm_net_gst;
            destination.pol_comm_gst = source.pol_comm_gst;
            destination.pol_uw_fee_net_gst = source.pol_uw_fee_net_gst;
            destination.pol_uw_fee_gst = source.pol_uw_fee_gst;
            destination.pol_fee_net_gst = source.pol_fee_net_gst;
            destination.pol_fee_gst = source.pol_fee_gst;
            destination.pol_total_net_premium = source.pol_total_net_premium;
            destination.pol_policy_number = source.pol_policy_number;
            destination.pol_date_from = source.pol_date_from;
            destination.pol_date_to = source.pol_date_to;
            destination.pol_date_effective = source.pol_date_effective;
            destination.pol_insurer = source.pol_insurer;
            destination.insurer_name = source.insurer_name;
            destination.pol_sub_agent = source.pol_sub_agent;
            destination.sub_agent_name = source.sub_agent_name;
            destination.uw_paid = source.uw_paid;
            destination.client_paid = source.client_paid;
            destination.cla_count = source.cla_count;
            destination.pol_tran_id = source.pol_tran_id;
            destination.rpt_group = source.rpt_group;
            destination.SPID = source.SPID;
            destination.Coinsurers = source.Coinsurers;
            destination.pol_parent_id = source.pol_parent_id;
            destination.pol_sub_agent_fee_pay_net_gst = source.pol_sub_agent_fee_pay_net_gst;
            destination.pol_sub_agent_comm_pay_net_gst = source.pol_sub_agent_comm_pay_net_gst;
            destination.pol_CreditCard_fee = source.pol_CreditCard_fee;
            destination.pol_location = source.pol_location;
            destination.pol_other_parties = source.pol_other_parties;
            destination.pol_insured = source.pol_insured;
            destination.pol_particulars = source.pol_particulars;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for portfolio_analysis_register table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.portfolio_analysis_register CustomMapper_portfolio_analysis_register(EclipseDataAccess.portfolio_analysis_register source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.portfolio_analysis_register destination = new BOALedgerDataAccess.portfolio_analysis_register();
            //
            // Set basic properties
            destination.ent_id = source.ent_id;
            destination.ent_name = source.ent_name;
            destination.ent_contact = source.ent_contact;
            destination.ent_telephone = source.ent_telephone;
            destination.ent_suburb = source.ent_suburb;
            destination.ent_postcode = source.ent_postcode;
            destination.ent_address_1 = source.ent_address_1;
            destination.ent_address_2 = source.ent_address_2;
            destination.ent_address_3 = source.ent_address_3;
            destination.sta_name = source.sta_name;
            destination.prof_service_team = source.prof_service_team;
            destination.prof_sales_team = source.prof_sales_team;
            destination.sertea_name = source.sertea_name;
            destination.saltea_name = source.saltea_name;
            destination.prof_area = source.prof_area;
            destination.genins_id = source.genins_id;
            destination.genins_name = source.genins_name;
            destination.genins_class_of_business = source.genins_class_of_business;
            destination.gencob_name = source.gencob_name;
            destination.pol_id = source.pol_id;
            destination.pol_total_base_premium = source.pol_total_base_premium;
            destination.pol_base_premium = source.pol_base_premium;
            destination.pol_total_levies = source.pol_total_levies;
            destination.pol_total_duties = source.pol_total_duties;
            destination.pol_total_fees = source.pol_total_fees;
            destination.pol_sub_agent_fee_payable = source.pol_sub_agent_fee_payable;
            destination.pol_insurer_gst = source.pol_insurer_gst;
            destination.pol_total_gst = source.pol_total_gst;
            destination.pol_total_gross_premium = source.pol_total_gross_premium;
            destination.pol_total_commission = source.pol_total_commission;
            destination.pol_comm_net_gst = source.pol_comm_net_gst;
            destination.pol_comm_gst = source.pol_comm_gst;
            destination.pol_uw_fee_net_gst = source.pol_uw_fee_net_gst;
            destination.pol_uw_fee_gst = source.pol_uw_fee_gst;
            destination.pol_fee_net_gst = source.pol_fee_net_gst;
            destination.pol_fee_gst = source.pol_fee_gst;
            destination.pol_total_net_premium = source.pol_total_net_premium;
            destination.pol_policy_number = source.pol_policy_number;
            destination.pol_date_from = source.pol_date_from;
            destination.pol_date_to = source.pol_date_to;
            destination.pol_date_effective = source.pol_date_effective;
            destination.pol_insurer = source.pol_insurer;
            destination.insurer_name = source.insurer_name;
            destination.pol_sub_agent = source.pol_sub_agent;
            destination.sub_agent_name = source.sub_agent_name;
            destination.uw_paid = source.uw_paid;
            destination.client_paid = source.client_paid;
            destination.cla_count = source.cla_count;
            destination.pol_tran_id = source.pol_tran_id;
            destination.rpt_group = source.rpt_group;
            destination.SPID = source.SPID;
            destination.Coinsurers = source.Coinsurers;
            destination.pol_parent_id = source.pol_parent_id;
            destination.pol_sub_agent_fee_pay_net_gst = source.pol_sub_agent_fee_pay_net_gst;
            destination.pol_sub_agent_comm_pay_net_gst = source.pol_sub_agent_comm_pay_net_gst;
            destination.pol_cc_fee = source.pol_cc_fee;
            destination.pol_location = source.pol_location;
            destination.pol_other_parties = source.pol_other_parties;
            destination.pol_insured = source.pol_insured;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for DocumentRepository table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.DocumentRepository CustomMapper_DocumentRepository(EclipseDataAccess.DocumentRepository source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.DocumentRepository destination = new BOALedgerDataAccess.DocumentRepository();
            //
            // Set basic properties
            destination.dr_id = source.dr_id;
            destination.dr_name = source.dr_name;
            destination.dr_description = source.dr_description;
            destination.dr_filename = source.dr_filename;
            destination.dr_created_who = source.dr_created_who;
            destination.dr_created_when = source.dr_created_when;
            destination.dr_updated_who = source.dr_updated_who;
            destination.dr_updated_when = source.dr_updated_when;
            destination.dr_inactive = source.dr_inactive;
            destination.dr_insurer = source.dr_insurer;
            destination.dr_cob = source.dr_cob;
            destination.dr_sharing = source.dr_sharing;
            destination.dr_branch = source.dr_branch;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for iclose_insurers table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.iclose_insurers CustomMapper_iclose_insurers(EclipseDataAccess.iclose_insurers source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.iclose_insurers destination = new BOALedgerDataAccess.iclose_insurers();
            //
            // Set basic properties
            destination.icloseins_id = source.icloseins_id;
            destination.icloseins_created_who = source.icloseins_created_who;
            destination.icloseins_created_when = source.icloseins_created_when;
            destination.icloseins_updated_who = source.icloseins_updated_who;
            destination.icloseins_updated_when = source.icloseins_updated_when;
            destination.icloseins_name = source.icloseins_name;
            destination.icloseins_desc = source.icloseins_desc;
            destination.icloseins_inactive = source.icloseins_inactive;
            destination.icloseins_insurer_id = source.icloseins_insurer_id;
            destination.icloseins_receiver_id = source.icloseins_receiver_id;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for Creditors_ageing_v table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.Creditors_ageing_v CustomMapper_Creditors_ageing_v(EclipseDataAccess.Creditors_ageing_v source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.Creditors_ageing_v destination = new BOALedgerDataAccess.Creditors_ageing_v();
            //
            // Set basic properties
            destination.bal_entity_id = source.bal_entity_id;
            destination.ENT_NAME = source.ENT_NAME;
            destination.ClientID = source.ClientID;
            destination.ClientName = source.ClientName;
            destination.Gencob_Name = source.Gencob_Name;
            destination.InvoiceAmount = source.InvoiceAmount;
            destination.NetPremium = source.NetPremium;
            destination.tran_time = source.tran_time;
            destination.Pol_Effective_Date = source.Pol_Effective_Date;
            destination.tran_type = source.tran_type;
            destination.tran_id = source.tran_id;
            destination.BAL_AMOUNT = source.BAL_AMOUNT;
            destination.DAYS_BETWEEN = source.DAYS_BETWEEN;
            destination.pol_insurer = source.pol_insurer;
            destination.pol_debtor = source.pol_debtor;
            destination.pol_sub_agent = source.pol_sub_agent;
            destination.Type = source.Type;
            destination.spid = source.spid;
            destination.PROF_SALES_TEAM = source.PROF_SALES_TEAM;
            destination.saltea_name = source.saltea_name;
            destination.PROF_SERVICE_TEAM = source.PROF_SERVICE_TEAM;
            destination.sertea_name = source.sertea_name;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for sales_teams table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.sales_teams CustomMapper_sales_teams(EclipseDataAccess.sales_teams source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.sales_teams destination = new BOALedgerDataAccess.sales_teams();
            //
            // Set basic properties
            destination.saltea_id = source.saltea_id;
            destination.saltea_created_who = source.saltea_created_who;
            destination.saltea_created_when = source.saltea_created_when;
            destination.saltea_updated_who = source.saltea_updated_who;
            destination.saltea_updated_when = source.saltea_updated_when;
            destination.saltea_name = source.saltea_name;
            destination.saltea_desc = source.saltea_desc;
            destination.saltea_inactive = source.saltea_inactive;
            destination.saltea_full_name = source.saltea_full_name;
            destination.saltea_ar_no = source.saltea_ar_no;
            destination.saltea_branch_id = source.saltea_branch_id;
            destination.saltea_title = source.saltea_title;
            destination.saltea_address = source.saltea_address;
            destination.saltea_suburb = source.saltea_suburb;
            destination.saltea_state = source.saltea_state;
            destination.saltea_postcode = source.saltea_postcode;
            destination.saltea_phone = source.saltea_phone;
            destination.saltea_mobile = source.saltea_mobile;
            destination.saltea_email = source.saltea_email;
            destination.saltea_facsimile = source.saltea_facsimile;
            destination.saltea_company_name = source.saltea_company_name;
            destination.saltea_trading_as = source.saltea_trading_as;
            destination.saltea_address_2 = source.saltea_address_2;
            destination.saltea_address_3 = source.saltea_address_3;
            destination.saltea_web_site = source.saltea_web_site;
            destination.saltea_ABN = source.saltea_ABN;
            destination.saltea_ACN = source.saltea_ACN;
            destination.saltea_Use_Billing = source.saltea_Use_Billing;
            destination.saltea_Use_Closing = source.saltea_Use_Closing;
            destination.saltea_Use_other = source.saltea_Use_other;
            destination.saltea_Use_statement = source.saltea_Use_statement;
            destination.saltea_logo = source.saltea_logo;
            destination.saltea_Data1 = source.saltea_Data1;
            destination.saltea_Data2 = source.saltea_Data2;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for soa_clauses table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.soa_clauses CustomMapper_soa_clauses(EclipseDataAccess.soa_clauses source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.soa_clauses destination = new BOALedgerDataAccess.soa_clauses();
            //
            // Set basic properties
            destination.cob_id = source.cob_id;
            destination.nature_of_advice = source.nature_of_advice;
            destination.recommendations = source.recommendations;
            destination.optional_notice1 = source.optional_notice1;
            destination.optional_notice2 = source.optional_notice2;
            destination.optional_notice3 = source.optional_notice3;
            destination.soa_clauses_id = source.soa_clauses_id;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for client_account_types table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.client_account_types CustomMapper_client_account_types(EclipseDataAccess.client_account_types source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.client_account_types destination = new BOALedgerDataAccess.client_account_types();
            //
            // Set basic properties
            destination.cliaccty_id = source.cliaccty_id;
            destination.cliaccty_created_who = source.cliaccty_created_who;
            destination.cliaccty_created_when = source.cliaccty_created_when;
            destination.cliaccty_updated_who = source.cliaccty_updated_who;
            destination.cliaccty_updated_when = source.cliaccty_updated_when;
            destination.cliaccty_name = source.cliaccty_name;
            destination.cliaccty_desc = source.cliaccty_desc;
            destination.cliaccty_inactive = source.cliaccty_inactive;
            destination.cliaccty_close_on_billing = source.cliaccty_close_on_billing;
            destination.cliaccty_close_on_cash = source.cliaccty_close_on_cash;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for period_renewals table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.period_renewals CustomMapper_period_renewals(EclipseDataAccess.period_renewals source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.period_renewals destination = new BOALedgerDataAccess.period_renewals();
            //
            // Set basic properties
            destination.genins_id = source.genins_id;
            destination.client_name = source.client_name;
            destination.gencob_name = source.gencob_name;
            destination.insurer_name = source.insurer_name;
            destination.genins_policy_number = source.genins_policy_number;
            destination.sertea_name = source.sertea_name;
            destination.saltea_name = source.saltea_name;
            destination.br_name = source.br_name;
            destination.genins_dtfrom = source.genins_dtfrom;
            destination.genins_dtto = source.genins_dtto;
            destination.invoice_total = source.invoice_total;
            destination.spid = source.spid;
            destination.entity_id = source.entity_id;
            destination.gencob_id = source.gencob_id;
            destination.insurer_id = source.insurer_id;
            destination.sertea_id = source.sertea_id;
            destination.saltea_id = source.saltea_id;
            destination.br_id = source.br_id;
            destination.bra_id = source.bra_id;
            destination.bra_name = source.bra_name;
            destination.are_id = source.are_id;
            destination.are_name = source.are_name;
            destination.genins_name = source.genins_name;
            destination.base_premium = source.base_premium;
            destination.total_levies = source.total_levies;
            destination.insurer_gst = source.insurer_gst;
            destination.total_duties = source.total_duties;
            destination.uw_fee_net_gst = source.uw_fee_net_gst;
            destination.uw_fee_gst = source.uw_fee_gst;
            destination.fee_net_gst = source.fee_net_gst;
            destination.fee_gst = source.fee_gst;
            destination.comm_net_gst = source.comm_net_gst;
            destination.comm_gst = source.comm_gst;
            destination.total_net_premium = source.total_net_premium;
            destination.close_status = source.close_status;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for branch_permissions table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.branch_permissions CustomMapper_branch_permissions(EclipseDataAccess.branch_permissions source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.branch_permissions destination = new BOALedgerDataAccess.branch_permissions();
            //
            // Set basic properties
            destination.brp_bra_id = source.brp_bra_id;
            destination.brp_user_name = source.brp_user_name;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for confirmation_of_cover table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.confirmation_of_cover CustomMapper_confirmation_of_cover(EclipseDataAccess.confirmation_of_cover source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.confirmation_of_cover destination = new BOALedgerDataAccess.confirmation_of_cover();
            //
            // Set basic properties
            destination.coc_id = source.coc_id;
            destination.coc_name = source.coc_name;
            destination.coc_created_who = source.coc_created_who;
            destination.coc_created_when = source.coc_created_when;
            destination.coc_updated_who = source.coc_updated_who;
            destination.coc_updated_when = source.coc_updated_when;
            destination.coc_inactive = source.coc_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for cancellation_reason table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.cancellation_reason CustomMapper_cancellation_reason(EclipseDataAccess.cancellation_reason source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.cancellation_reason destination = new BOALedgerDataAccess.cancellation_reason();
            //
            // Set basic properties
            destination.cancreas_id = source.cancreas_id;
            destination.cancreas_created_who = source.cancreas_created_who;
            destination.cancreas_created_when = source.cancreas_created_when;
            destination.cancreas_updated_who = source.cancreas_updated_who;
            destination.cancreas_updated_when = source.cancreas_updated_when;
            destination.cancreas_name = source.cancreas_name;
            destination.cancreas_desc = source.cancreas_desc;
            destination.cancreas_inactive = source.cancreas_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for sunrise_instalment_insurer_payments table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.sunrise_instalment_insurer_payments CustomMapper_sunrise_instalment_insurer_payments(EclipseDataAccess.sunrise_instalment_insurer_payments source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.sunrise_instalment_insurer_payments destination = new BOALedgerDataAccess.sunrise_instalment_insurer_payments();
            //
            // Set basic properties
            destination.siip_id = source.siip_id;
            destination.siip_payer_ref = source.siip_payer_ref;
            destination.siip_policy_ref = source.siip_policy_ref;
            destination.siip_policy_no = source.siip_policy_no;
            destination.siip_instalment_no = source.siip_instalment_no;
            destination.siip_due_date = source.siip_due_date;
            destination.siip_status = source.siip_status;
            destination.siip_status_desc = source.siip_status_desc;
            destination.siip_total_due = source.siip_total_due;
            destination.siip_premium = source.siip_premium;
            destination.siip_levy = source.siip_levy;
            destination.siip_duty = source.siip_duty;
            destination.siip_tax = source.siip_tax;
            destination.siip_comm = source.siip_comm;
            destination.siip_comm_tax = source.siip_comm_tax;
            destination.siip_fee = source.siip_fee;
            destination.siip_fee_tax = source.siip_fee_tax;
            destination.siip_insurer_pay = source.siip_insurer_pay;
            destination.siip_processed = source.siip_processed;
            destination.siip_pol_tran_id = source.siip_pol_tran_id;
            destination.siip_supplier = source.siip_supplier;
            destination.siip_import_batch_id = source.siip_import_batch_id;
            destination.siip_processed_batch_id = source.siip_processed_batch_id;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for SystemConfigOptions table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.SystemConfigOptions CustomMapper_SystemConfigOptions(EclipseDataAccess.SystemConfigOptions source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.SystemConfigOptions destination = new BOALedgerDataAccess.SystemConfigOptions();
            //
            // Set basic properties
            destination.nSystemConfigOptionId = source.nSystemConfigOptionId;
            destination.strOption = source.strOption;
            destination.strOptionId = source.strOptionId;
            destination.sco_EncryptKey = source.sco_EncryptKey;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for temp_banking_summary2 table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.temp_banking_summary2 CustomMapper_temp_banking_summary2(EclipseDataAccess.temp_banking_summary2 source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.temp_banking_summary2 destination = new BOALedgerDataAccess.temp_banking_summary2();
            //
            // Set basic properties
            destination.sel_rcpt_tran_id = source.sel_rcpt_tran_id;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for premium_funding table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.premium_funding CustomMapper_premium_funding(EclipseDataAccess.premium_funding source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.premium_funding destination = new BOALedgerDataAccess.premium_funding();
            //
            // Set basic properties
            destination.prefun_id = source.prefun_id;
            destination.prefun_created_who = source.prefun_created_who;
            destination.prefun_created_when = source.prefun_created_when;
            destination.prefun_updated_who = source.prefun_updated_who;
            destination.prefun_updated_when = source.prefun_updated_when;
            destination.prefun_name = source.prefun_name;
            destination.prefun_desc = source.prefun_desc;
            destination.prefun_inactive = source.prefun_inactive;
            destination.prefun_url = source.prefun_url;
            destination.prefun_licence_expires_on = source.prefun_licence_expires_on;
            destination.prefun_number_of_users = source.prefun_number_of_users;
            destination.prefun_activation_key = source.prefun_activation_key;
            destination.prefun_standalone = source.prefun_standalone;
            destination.prefun_login = source.prefun_login;
            destination.prefun_password = source.prefun_password;
            destination.prefun_funder_code = source.prefun_funder_code;
            destination.prefun_interface = source.prefun_interface;
            destination.prefun_web_dev_stage = source.prefun_web_dev_stage;
            destination.prefun_payment = source.prefun_payment;
            destination.prefun_Attvest_Bank_File = source.prefun_Attvest_Bank_File;
            destination.prefun_Online_Quoting = source.prefun_Online_Quoting;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for claim_documents table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.claim_documents CustomMapper_claim_documents(EclipseDataAccess.claim_documents source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.claim_documents destination = new BOALedgerDataAccess.claim_documents();
            //
            // Set basic properties
            destination.cladoc_id = source.cladoc_id;
            destination.cladoc_created_who = source.cladoc_created_who;
            destination.cladoc_created_when = source.cladoc_created_when;
            destination.cladoc_updated_who = source.cladoc_updated_who;
            destination.cladoc_updated_when = source.cladoc_updated_when;
            destination.cladoc_name = source.cladoc_name;
            destination.cladoc_desc = source.cladoc_desc;
            destination.cladoc_inactive = source.cladoc_inactive;
            destination.cladoc_branch = source.cladoc_branch;
            destination.cladoc_group = source.cladoc_group;
            destination.cladoc_exclude_as_template = source.cladoc_exclude_as_template;
            destination.cladoc_exclude_as_body = source.cladoc_exclude_as_body;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for temp_report_sunrise_import_policies table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.temp_report_sunrise_import_policies CustomMapper_temp_report_sunrise_import_policies(EclipseDataAccess.temp_report_sunrise_import_policies source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.temp_report_sunrise_import_policies destination = new BOALedgerDataAccess.temp_report_sunrise_import_policies();
            //
            // Set basic properties
            destination.seq_no = source.seq_no;
            destination.supplier_id = source.supplier_id;
            destination.supplier_policy_no = source.supplier_policy_no;
            destination.version_no = source.version_no;
            destination.insured_name = source.insured_name;
            destination.product_id = source.product_id;
            destination.start_date = source.start_date;
            destination.end_date = source.end_date;
            destination.is_imported = source.is_imported;
            destination.server = source.server;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for UserConfig table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.UserConfig CustomMapper_UserConfig(EclipseDataAccess.UserConfig source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.UserConfig destination = new BOALedgerDataAccess.UserConfig();
            //
            // Set basic properties
            destination.nUserConfigId = source.nUserConfigId;
            destination.strUsername = source.strUsername;
            destination.nSalesTeam = source.nSalesTeam;
            destination.nSalesTeamOverride = source.nSalesTeamOverride;
            destination.nServiceTeam = source.nServiceTeam;
            destination.nServiceTeamOverride = source.nServiceTeamOverride;
            destination.nBrokerRep = source.nBrokerRep;
            destination.nBrokerRepOverride = source.nBrokerRepOverride;
            destination.nAccountType = source.nAccountType;
            destination.nAccountTypeOverride = source.nAccountTypeOverride;
            destination.nDefaultSearch = source.nDefaultSearch;
            destination.nNumPerPanelTasks = source.nNumPerPanelTasks;
            destination.nWithinDaysTasks = source.nWithinDaysTasks;
            destination.nPopupReminder = source.nPopupReminder;
            destination.nPopupFrequency = source.nPopupFrequency;
            destination.nShowPoliciesDue = source.nShowPoliciesDue;
            destination.nNumPerPanelPol = source.nNumPerPanelPol;
            destination.nWithinDaysPol = source.nWithinDaysPol;
            destination.nShowOutstandingDebt = source.nShowOutstandingDebt;
            destination.nNumPerPanelOD = source.nNumPerPanelOD;
            destination.nDaysOverdueOD = source.nDaysOverdueOD;
            destination.nEntityRole = source.nEntityRole;
            destination.nBranch = source.nBranch;
            destination.nClassification = source.nClassification;
            destination.nEntityRoleOverride = source.nEntityRoleOverride;
            destination.nBranchOverride = source.nBranchOverride;
            destination.nClassificationOverride = source.nClassificationOverride;
            destination.nShowTransactionsOutside = source.nShowTransactionsOutside;
            destination.nWithinDaysTranOut = source.nWithinDaysTranOut;
            destination.nAdvanceQueueManagement = source.nAdvanceQueueManagement;
            destination.nAllowReopeningTask = source.nAllowReopeningTask;
            destination.nAllowReopeningClaims = source.nAllowReopeningClaims;
            destination.nCloseTaskByWindow = source.nCloseTaskByWindow;
            destination.nCloseTaskByClose = source.nCloseTaskByClose;
            destination.nAccessBankDetails = source.nAccessBankDetails;
            destination.nAmendBankDetails = source.nAmendBankDetails;
            destination.nAllowUpdateClientTask = source.nAllowUpdateClientTask;
            destination.nAllowDeleteClientTask = source.nAllowDeleteClientTask;
            destination.nAllowReOpenClientTask = source.nAllowReOpenClientTask;
            destination.nAllowUpdateClientNotes = source.nAllowUpdateClientNotes;
            destination.nAllowUpdateClientDOC = source.nAllowUpdateClientDOC;
            destination.nAllowDeleteClientNotes = source.nAllowDeleteClientNotes;
            destination.nAllowDeleteClientDOC = source.nAllowDeleteClientDOC;
            destination.nAllowUpdateClaimTask = source.nAllowUpdateClaimTask;
            destination.nAllowDeleteClaimTask = source.nAllowDeleteClaimTask;
            destination.nAllowReOpenClaimTask = source.nAllowReOpenClaimTask;
            destination.nAllowUpdateClaimNotes = source.nAllowUpdateClaimNotes;
            destination.nAllowUpdateClaimDOC = source.nAllowUpdateClaimDOC;
            destination.nAllowDeleteClaimNotes = source.nAllowDeleteClaimNotes;
            destination.nAllowDeleteClaimDOC = source.nAllowDeleteClaimDOC;
            destination.nAllowUpdatePolicyTask = source.nAllowUpdatePolicyTask;
            destination.nAllowDeletePolicyTask = source.nAllowDeletePolicyTask;
            destination.nAllowReOpenPolicyTask = source.nAllowReOpenPolicyTask;
            destination.nAllowUpdatePolicyNotes = source.nAllowUpdatePolicyNotes;
            destination.nAllowUpdatePolicyDOC = source.nAllowUpdatePolicyDOC;
            destination.nAllowDeletePolicyNotes = source.nAllowDeletePolicyNotes;
            destination.nAllowDeletePolicyDOC = source.nAllowDeletePolicyDOC;
            destination.nSubBranchOverride = source.nSubBranchOverride;
            destination.nTaskFor = source.nTaskFor;
            destination.nDisplayIncome = source.nDisplayIncome;
            destination.nDisplayGrossIncome = source.nDisplayGrossIncome;
            destination.nDisplayNetIncome = source.nDisplayNetIncome;
            destination.nDisplayARIncome = source.nDisplayARIncome;
            destination.DefaultIncome = source.DefaultIncome;
            destination.nAllowCashReceiptClosingOption = source.nAllowCashReceiptClosingOption;
            destination.strSVUUsername = source.strSVUUsername;
            destination.nAllowPostedWorkbookUpdate = source.nAllowPostedWorkbookUpdate;
            destination.nValidateBankDetails = source.nValidateBankDetails;
            destination.nHideDueTasks = source.nHideDueTasks;
            destination.strUserDetailsName = source.strUserDetailsName;
            destination.strUserDetailsEmail = source.strUserDetailsEmail;
            destination.strTasksDefaultQueue = source.strTasksDefaultQueue;
            destination.nDisplayClaimTasks = source.nDisplayClaimTasks;
            destination.nDisplayClientTasks = source.nDisplayClientTasks;
            destination.nDisplayPolicyTasks = source.nDisplayPolicyTasks;
            destination.nShowOutstandingClaim = source.nShowOutstandingClaim;
            destination.nWithinDaysClaim = source.nWithinDaysClaim;
            destination.nShowWorkbooksNotPosted = source.nShowWorkbooksNotPosted;
            destination.nWithinDaysWorkbooksNotPosted = source.nWithinDaysWorkbooksNotPosted;
            destination.nTransTypeQuotation = source.nTransTypeQuotation;
            destination.nTransTypeCoverNotes = source.nTransTypeCoverNotes;
            destination.nTranTypeLapses = source.nTranTypeLapses;
            destination.nPanelOrderOutstandingTasks = source.nPanelOrderOutstandingTasks;
            destination.nPanelOrderOutstandingClaims = source.nPanelOrderOutstandingClaims;
            destination.nPanelOrderPoliciesForRenewal = source.nPanelOrderPoliciesForRenewal;
            destination.nPanelOrderOutstandingDebts = source.nPanelOrderOutstandingDebts;
            destination.nPanelOrderTransOutsideCreditTermDate = source.nPanelOrderTransOutsideCreditTermDate;
            destination.nPanelOrderWorkbooksNotPosted = source.nPanelOrderWorkbooksNotPosted;
            destination.nAllowDeleteEntity = source.nAllowDeleteEntity;
            destination.strVpnFileLocation = source.strVpnFileLocation;
            destination.strVpnProfileName = source.strVpnProfileName;
            destination.strVpnUserName = source.strVpnUserName;
            destination.strVpnPassword = source.strVpnPassword;
            destination.nAutoConnectVpn = source.nAutoConnectVpn;
            destination.nShowPriorityBackgroundColours = source.nShowPriorityBackgroundColours;
            destination.nAllowUpdateWorkbookNote = source.nAllowUpdateWorkbookNote;
            destination.nAllowDeleteWorkbookNote = source.nAllowDeleteWorkbookNote;
            destination.nClaimsUseAllSalesTeams = source.nClaimsUseAllSalesTeams;
            destination.nClaimsUseAllBrokerReps = source.nClaimsUseAllBrokerReps;
            destination.nClaimsUseAllServiceTeams = source.nClaimsUseAllServiceTeams;
            destination.nClaimsUseAllBranches = source.nClaimsUseAllBranches;
            destination.nPoliciesUseAllSalesTeams = source.nPoliciesUseAllSalesTeams;
            destination.nPoliciesUseAllBrokerReps = source.nPoliciesUseAllBrokerReps;
            destination.nPoliciesUseAllServiceTeams = source.nPoliciesUseAllServiceTeams;
            destination.nPoliciesUseAllBranches = source.nPoliciesUseAllBranches;
            destination.nDebtsUseAllSalesTeams = source.nDebtsUseAllSalesTeams;
            destination.nDebtsUseAllBrokerReps = source.nDebtsUseAllBrokerReps;
            destination.nDebtsUseAllServiceTeams = source.nDebtsUseAllServiceTeams;
            destination.nDebtsUseAllBranches = source.nDebtsUseAllBranches;
            destination.nInsurersUseAllInsurers = source.nInsurersUseAllInsurers;
            destination.nInsurersUseAllBranches = source.nInsurersUseAllBranches;
            destination.nTIMEnabled = source.nTIMEnabled;
            destination.nICloseEnabled = source.nICloseEnabled;
            destination.nShowPoliciesDueFilter = source.nShowPoliciesDueFilter;
            destination.nShowOutstandingTask = source.nShowOutstandingTask;
            destination.nDuePoliciesShowNoTrans = source.nDuePoliciesShowNoTrans;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for soa_classes_of_business table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.soa_classes_of_business CustomMapper_soa_classes_of_business(EclipseDataAccess.soa_classes_of_business source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.soa_classes_of_business destination = new BOALedgerDataAccess.soa_classes_of_business();
            //
            // Set basic properties
            destination.soacob_id = source.soacob_id;
            destination.soacob_created_who = source.soacob_created_who;
            destination.soacob_created_when = source.soacob_created_when;
            destination.soacob_updated_who = source.soacob_updated_who;
            destination.soacob_updated_when = source.soacob_updated_when;
            destination.soacob_name = source.soacob_name;
            destination.soacob_desc = source.soacob_desc;
            destination.soacob_inactive = source.soacob_inactive;
            destination.soacob_class_of_business = source.soacob_class_of_business;
            destination.soacob_transaction_type = source.soacob_transaction_type;
            destination.soacob_soa_document = source.soacob_soa_document;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for iclose_products table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.iclose_products CustomMapper_iclose_products(EclipseDataAccess.iclose_products source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.iclose_products destination = new BOALedgerDataAccess.iclose_products();
            //
            // Set basic properties
            destination.iclosepro_id = source.iclosepro_id;
            destination.iclosepro_created_who = source.iclosepro_created_who;
            destination.iclosepro_created_when = source.iclosepro_created_when;
            destination.iclosepro_updated_who = source.iclosepro_updated_who;
            destination.iclosepro_updated_when = source.iclosepro_updated_when;
            destination.iclosepro_parent_id = source.iclosepro_parent_id;
            destination.iclosepro_cob_id = source.iclosepro_cob_id;
            destination.iclosepro_name = source.iclosepro_name;
            destination.iclosepro_desc = source.iclosepro_desc;
            destination.iclosepro_inactive = source.iclosepro_inactive;
            destination.iclosepro_product_code = source.iclosepro_product_code;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for addresses table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.addresses CustomMapper_addresses(EclipseDataAccess.addresses source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.addresses destination = new BOALedgerDataAccess.addresses();
            //
            // Set basic properties
            destination.add_id = source.add_id;
            destination.add_parent_id = source.add_parent_id;
            destination.add_created_who = source.add_created_who;
            destination.add_created_when = source.add_created_when;
            destination.add_updated_who = source.add_updated_who;
            destination.add_updated_when = source.add_updated_when;
            destination.add_duration = source.add_duration;
            destination.add_primary_address = source.add_primary_address;
            destination.add_address_type = source.add_address_type;
            destination.add_address_1 = source.add_address_1;
            destination.add_address_2 = source.add_address_2;
            destination.add_address_3 = source.add_address_3;
            destination.add_suburb = source.add_suburb;
            destination.add_state = source.add_state;
            destination.add_postcode = source.add_postcode;
            destination.add_telephone = source.add_telephone;
            destination.add_telephone_2 = source.add_telephone_2;
            destination.add_facsimile = source.add_facsimile;
            destination.add_update_flag = source.add_update_flag;
            destination.add_latitude = source.add_latitude;
            destination.add_longitude = source.add_longitude;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for ufi_country_codes table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.ufi_country_codes CustomMapper_ufi_country_codes(EclipseDataAccess.ufi_country_codes source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.ufi_country_codes destination = new BOALedgerDataAccess.ufi_country_codes();
            //
            // Set basic properties
            destination.uficoco_id = source.uficoco_id;
            destination.uficoco_name = source.uficoco_name;
            destination.uficoco_code = source.uficoco_code;
            destination.uficoco_created_who = source.uficoco_created_who;
            destination.uficoco_created_when = source.uficoco_created_when;
            destination.uficoco_updated_who = source.uficoco_updated_who;
            destination.uficoco_updated_when = source.uficoco_updated_when;
            destination.uficoco_desc = source.uficoco_desc;
            destination.uficoco_inactive = source.uficoco_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for turnoverdetail table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.turnoverdetail CustomMapper_turnoverdetail(EclipseDataAccess.turnoverdetail source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.turnoverdetail destination = new BOALedgerDataAccess.turnoverdetail();
            //
            // Set basic properties
            destination.minval = source.minval;
            destination.maxval = source.maxval;
            destination.IndCounter = source.IndCounter;
            destination.OrgCounter = source.OrgCounter;
            destination.ent_id = source.ent_id;
            destination.ent_name = source.ent_name;
            destination.spid = source.spid;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for gl_acc_months table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.gl_acc_months CustomMapper_gl_acc_months(EclipseDataAccess.gl_acc_months source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.gl_acc_months destination = new BOALedgerDataAccess.gl_acc_months();
            //
            // Set basic properties
            destination.glm_month = source.glm_month;
            destination.glm_open = source.glm_open;
            destination.glm_created_who = source.glm_created_who;
            destination.glm_created_when = source.glm_created_when;
            destination.glm_updated_who = source.glm_updated_who;
            destination.glm_updated_when = source.glm_updated_when;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for profile table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.profile CustomMapper_profile(EclipseDataAccess.profile source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.profile destination = new BOALedgerDataAccess.profile();
            //
            // Set basic properties
            destination.prof_id = source.prof_id;
            destination.prof_parent_id = source.prof_parent_id;
            destination.prof_created_who = source.prof_created_who;
            destination.prof_created_when = source.prof_created_when;
            destination.prof_updated_who = source.prof_updated_who;
            destination.prof_updated_when = source.prof_updated_when;
            destination.prof_duration = source.prof_duration;
            destination.prof_acn = source.prof_acn;
            destination.prof_year_established = source.prof_year_established;
            destination.prof_structure = source.prof_structure;
            destination.prof_area = source.prof_area;
            destination.prof_nature_of_business = source.prof_nature_of_business;
            destination.prof_industry = source.prof_industry;
            destination.prof_annual_turnover = source.prof_annual_turnover;
            destination.prof_number_of_employees = source.prof_number_of_employees;
            destination.prof_occupation = source.prof_occupation;
            destination.prof_employer = source.prof_employer;
            destination.prof_year_commenced = source.prof_year_commenced;
            destination.prof_spouses_name = source.prof_spouses_name;
            destination.prof_dependants = source.prof_dependants;
            destination.prof_service_team = source.prof_service_team;
            destination.prof_sales_team = source.prof_sales_team;
            destination.prof_source_of_business = source.prof_source_of_business;
            destination.prof_usual_debtor = source.prof_usual_debtor;
            destination.prof_sub_agent = source.prof_sub_agent;
            destination.prof_branch = source.prof_branch;
            destination.prof_account_type = source.prof_account_type;
            destination.prof_classification = source.prof_classification;
            destination.prof_sub_agent_2 = source.prof_sub_agent_2;
            destination.prof_sub_agent_3 = source.prof_sub_agent_3;
            destination.prof_sub_agent_4 = source.prof_sub_agent_4;
            destination.prof_sub_agent_5 = source.prof_sub_agent_5;
            destination.prof_anzsic = source.prof_anzsic;
            destination.prof_referrer = source.prof_referrer;
            destination.prof_status = source.prof_status;
            destination.prof_spouses_DOB = source.prof_spouses_DOB;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for vims_asic_iba table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.vims_asic_iba CustomMapper_vims_asic_iba(EclipseDataAccess.vims_asic_iba source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.vims_asic_iba destination = new BOALedgerDataAccess.vims_asic_iba();
            //
            // Set basic properties
            destination.fld77 = source.fld77;
            destination.fld79 = source.fld79;
            destination.fld80 = source.fld80;
            destination.fld81 = source.fld81;
            destination.fld85 = source.fld85;
            destination.fld86 = source.fld86;
            destination.fld87a = source.fld87a;
            destination.fld87b = source.fld87b;
            destination.fld88 = source.fld88;
            destination.fld92 = source.fld92;
            destination.fld93 = source.fld93;
            destination.fld95 = source.fld95;
            destination.fld95chk = source.fld95chk;
            destination.diff = source.diff;
            destination.spid = source.spid;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for vims_trans_enquiry table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.vims_trans_enquiry CustomMapper_vims_trans_enquiry(EclipseDataAccess.vims_trans_enquiry source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.vims_trans_enquiry destination = new BOALedgerDataAccess.vims_trans_enquiry();
            //
            // Set basic properties
            destination.glmv_id = source.glmv_id;
            destination.glmv_tran_type = source.glmv_tran_type;
            destination.glmv_date = source.glmv_date;
            destination.glmv_created_when = source.glmv_created_when;
            destination.glmv_glrs_set = source.glmv_glrs_set;
            destination.glmv_record_Ref_id = source.glmv_record_Ref_id;
            destination.client = source.client;
            destination.insurer_sa = source.insurer_sa;
            destination.amount = source.amount;
            destination.tratyp_desc = source.tratyp_desc;
            destination.spid = source.spid;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for journal_sub_tasks table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.journal_sub_tasks CustomMapper_journal_sub_tasks(EclipseDataAccess.journal_sub_tasks source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.journal_sub_tasks destination = new BOALedgerDataAccess.journal_sub_tasks();
            //
            // Set basic properties
            destination.jousubta_id = source.jousubta_id;
            destination.jousubta_parent_id = source.jousubta_parent_id;
            destination.jousubta_created_who = source.jousubta_created_who;
            destination.jousubta_created_when = source.jousubta_created_when;
            destination.jousubta_updated_who = source.jousubta_updated_who;
            destination.jousubta_updated_when = source.jousubta_updated_when;
            destination.jousubta_duration = source.jousubta_duration;
            destination.jousubta_date = source.jousubta_date;
            destination.jousubta_initiated_by = source.jousubta_initiated_by;
            destination.jousubta_brief_description = source.jousubta_brief_description;
            destination.jousubta_document = source.jousubta_document;
            destination.Fname = source.Fname;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for Claim_Notes table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.Claim_Notes CustomMapper_Claim_Notes(EclipseDataAccess.Claim_Notes source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.Claim_Notes destination = new BOALedgerDataAccess.Claim_Notes();
            //
            // Set basic properties
            destination.Claim_not_id = source.Claim_not_id;
            destination.Claim_not_parent_id = source.Claim_not_parent_id;
            destination.Claim_not_created_who = source.Claim_not_created_who;
            destination.Claim_not_created_when = source.Claim_not_created_when;
            destination.Claim_not_updated_who = source.Claim_not_updated_who;
            destination.Claim_not_updated_when = source.Claim_not_updated_when;
            destination.Claim_not_note = source.Claim_not_note;
            destination.Claim_not_Contact = source.Claim_not_Contact;
            destination.Claim_not_Subject = source.Claim_not_Subject;
            destination.Claim_not_phone = source.Claim_not_phone;
            destination.Claim_not_mobile = source.Claim_not_mobile;
            destination.Claim_not_email = source.Claim_not_email;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for gen_ins_documents table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.gen_ins_documents CustomMapper_gen_ins_documents(EclipseDataAccess.gen_ins_documents source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.gen_ins_documents destination = new BOALedgerDataAccess.gen_ins_documents();
            //
            // Set basic properties
            destination.geninsdo_id = source.geninsdo_id;
            destination.geninsdo_created_who = source.geninsdo_created_who;
            destination.geninsdo_created_when = source.geninsdo_created_when;
            destination.geninsdo_updated_who = source.geninsdo_updated_who;
            destination.geninsdo_updated_when = source.geninsdo_updated_when;
            destination.geninsdo_name = source.geninsdo_name;
            destination.geninsdo_desc = source.geninsdo_desc;
            destination.geninsdo_inactive = source.geninsdo_inactive;
            destination.geninsdo_branch = source.geninsdo_branch;
            destination.geninsdo_group = source.geninsdo_group;
            destination.geninsdo_exclude_as_template = source.geninsdo_exclude_as_template;
            destination.geninsdo_exclude_as_body = source.geninsdo_exclude_as_body;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for client_classifications table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.client_classifications CustomMapper_client_classifications(EclipseDataAccess.client_classifications source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.client_classifications destination = new BOALedgerDataAccess.client_classifications();
            //
            // Set basic properties
            destination.clicla_id = source.clicla_id;
            destination.clicla_created_who = source.clicla_created_who;
            destination.clicla_created_when = source.clicla_created_when;
            destination.clicla_updated_who = source.clicla_updated_who;
            destination.clicla_updated_when = source.clicla_updated_when;
            destination.clicla_name = source.clicla_name;
            destination.clicla_desc = source.clicla_desc;
            destination.clicla_inactive = source.clicla_inactive;
            destination.clicla_colour = source.clicla_colour;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for EmailTemplates table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.EmailTemplates CustomMapper_EmailTemplates(EclipseDataAccess.EmailTemplates source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.EmailTemplates destination = new BOALedgerDataAccess.EmailTemplates();
            //
            // Set basic properties
            destination.et_id = source.et_id;
            destination.et_name = source.et_name;
            destination.et_description = source.et_description;
            destination.et_created_who = source.et_created_who;
            destination.et_created_when = source.et_created_when;
            destination.et_updated_who = source.et_updated_who;
            destination.et_updated_when = source.et_updated_when;
            destination.et_sharing = source.et_sharing;
            destination.et_branch = source.et_branch;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for address_types table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.address_types CustomMapper_address_types(EclipseDataAccess.address_types source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.address_types destination = new BOALedgerDataAccess.address_types();
            //
            // Set basic properties
            destination.addtyp_id = source.addtyp_id;
            destination.addtyp_created_who = source.addtyp_created_who;
            destination.addtyp_created_when = source.addtyp_created_when;
            destination.addtyp_updated_who = source.addtyp_updated_who;
            destination.addtyp_updated_when = source.addtyp_updated_when;
            destination.addtyp_name = source.addtyp_name;
            destination.addtyp_desc = source.addtyp_desc;
            destination.addtyp_inactive = source.addtyp_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for general_insurance table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.general_insurance CustomMapper_general_insurance(EclipseDataAccess.general_insurance source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.general_insurance destination = new BOALedgerDataAccess.general_insurance();
            //
            // Set basic properties
            destination.genins_id = source.genins_id;
            destination.genins_parent_id = source.genins_parent_id;
            destination.genins_created_who = source.genins_created_who;
            destination.genins_created_when = source.genins_created_when;
            destination.genins_updated_who = source.genins_updated_who;
            destination.genins_updated_when = source.genins_updated_when;
            destination.genins_duration = source.genins_duration;
            destination.genins_name = source.genins_name;
            destination.genins_description = source.genins_description;
            destination.genins_class_of_business = source.genins_class_of_business;
            destination.genins_date_effective = source.genins_date_effective;
            destination.genins_insurer = source.genins_insurer;
            destination.genins_is_hidden = source.genins_is_hidden;
            destination.genins_nStatus = source.genins_nStatus;
            destination.genins_nType = source.genins_nType;
            destination.genins_dtFrom = source.genins_dtFrom;
            destination.genins_dtTo = source.genins_dtTo;
            destination.genins_dtStatusChanged = source.genins_dtStatusChanged;
            destination.genins_policy_number = source.genins_policy_number;
            destination.genins_status_type = source.genins_status_type;
            destination.genins_monthly = source.genins_monthly;
            destination.genins_nopayments = source.genins_nopayments;
            destination.genins_nodeposit = source.genins_nodeposit;
            destination.genins_frequency = source.genins_frequency;
            destination.genins_bf_inc_deposit = source.genins_bf_inc_deposit;
            destination.genins_spread_ap = source.genins_spread_ap;
            destination.genins_spread_rp = source.genins_spread_rp;
            destination.genins_notes = source.genins_notes;
            destination.genins_underwriter_id = source.genins_underwriter_id;
            destination.genins_cancellation_reason = source.genins_cancellation_reason;
            destination.genins_Category1 = source.genins_Category1;
            destination.genins_Category2 = source.genins_Category2;
            destination.genins_Category3 = source.genins_Category3;
            destination.genins_svu_status = source.genins_svu_status;
            destination.genins_is_tim = source.genins_is_tim;
            destination.genins_anzic_code = source.genins_anzic_code;
            destination.genins_sunrise = source.genins_sunrise;
            destination.genins_is_iclose = source.genins_is_iclose;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for limited_exemptions table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.limited_exemptions CustomMapper_limited_exemptions(EclipseDataAccess.limited_exemptions source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.limited_exemptions destination = new BOALedgerDataAccess.limited_exemptions();
            //
            // Set basic properties
            destination.limex_id = source.limex_id;
            destination.limex_created_who = source.limex_created_who;
            destination.limex_created_when = source.limex_created_when;
            destination.limex_updated_who = source.limex_updated_who;
            destination.limex_updated_when = source.limex_updated_when;
            destination.limex_name = source.limex_name;
            destination.limex_desc = source.limex_desc;
            destination.limex_inactive = source.limex_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for gl_transactions table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.gl_transactions CustomMapper_gl_transactions(EclipseDataAccess.gl_transactions source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.gl_transactions destination = new BOALedgerDataAccess.gl_transactions();
            //
            // Set basic properties
            destination.gltr_id = source.gltr_id;
            destination.gltr_date = source.gltr_date;
            destination.gltr_glmv_id = source.gltr_glmv_id;
            destination.gltr_glsl_id = source.gltr_glsl_id;
            destination.gltr_amount = source.gltr_amount;
            destination.gltr_created_who = source.gltr_created_who;
            destination.gltr_created_when = source.gltr_created_when;
            destination.gltr_updated_who = source.gltr_updated_who;
            destination.gltr_updated_when = source.gltr_updated_when;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for finance_types table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.finance_types CustomMapper_finance_types(EclipseDataAccess.finance_types source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.finance_types destination = new BOALedgerDataAccess.finance_types();
            //
            // Set basic properties
            destination.fintyp_id = source.fintyp_id;
            destination.fintyp_created_who = source.fintyp_created_who;
            destination.fintyp_created_when = source.fintyp_created_when;
            destination.fintyp_updated_who = source.fintyp_updated_who;
            destination.fintyp_updated_when = source.fintyp_updated_when;
            destination.fintyp_name = source.fintyp_name;
            destination.fintyp_desc = source.fintyp_desc;
            destination.fintyp_inactive = source.fintyp_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for client_insurance_portfolio table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.client_insurance_portfolio CustomMapper_client_insurance_portfolio(EclipseDataAccess.client_insurance_portfolio source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.client_insurance_portfolio destination = new BOALedgerDataAccess.client_insurance_portfolio();
            //
            // Set basic properties
            destination.cip_id = source.cip_id;
            destination.cip_name = source.cip_name;
            destination.cip_created_who = source.cip_created_who;
            destination.cip_created_when = source.cip_created_when;
            destination.cip_updated_who = source.cip_updated_who;
            destination.cip_updated_when = source.cip_updated_when;
            destination.cip_inactive = source.cip_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for gen_ins_transaction_types table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.gen_ins_transaction_types CustomMapper_gen_ins_transaction_types(EclipseDataAccess.gen_ins_transaction_types source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.gen_ins_transaction_types destination = new BOALedgerDataAccess.gen_ins_transaction_types();
            //
            // Set basic properties
            destination.gentrans_id = source.gentrans_id;
            destination.gentrans_created_who = source.gentrans_created_who;
            destination.gentrans_created_when = source.gentrans_created_when;
            destination.gentrans_updated_who = source.gentrans_updated_who;
            destination.gentrans_updated_when = source.gentrans_updated_when;
            destination.gentrans_name = source.gentrans_name;
            destination.gentrans_desc = source.gentrans_desc;
            destination.gentrans_inactive = source.gentrans_inactive;
            destination.gentrans_current = source.gentrans_current;
            destination.gentrans_abbreviation = source.gentrans_abbreviation;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for ClientDetails_Category3 table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.ClientDetails_Category3 CustomMapper_ClientDetails_Category3(EclipseDataAccess.ClientDetails_Category3 source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.ClientDetails_Category3 destination = new BOALedgerDataAccess.ClientDetails_Category3();
            //
            // Set basic properties
            destination.cdcat3_id = source.cdcat3_id;
            destination.cdcat3_created_who = source.cdcat3_created_who;
            destination.cdcat3_created_when = source.cdcat3_created_when;
            destination.cdcat3_updated_who = source.cdcat3_updated_who;
            destination.cdcat3_updated_when = source.cdcat3_updated_when;
            destination.cdcat3_name = source.cdcat3_name;
            destination.cdcat3_desc = source.cdcat3_desc;
            destination.cdcat3_inactive = source.cdcat3_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for remittance_advice_formats table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.remittance_advice_formats CustomMapper_remittance_advice_formats(EclipseDataAccess.remittance_advice_formats source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.remittance_advice_formats destination = new BOALedgerDataAccess.remittance_advice_formats();
            //
            // Set basic properties
            destination.rafmt_id = source.rafmt_id;
            destination.rafmt_created_who = source.rafmt_created_who;
            destination.rafmt_created_when = source.rafmt_created_when;
            destination.rafmt_updated_who = source.rafmt_updated_who;
            destination.rafmt_updated_when = source.rafmt_updated_when;
            destination.rafmt_name = source.rafmt_name;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for gl_sub_ledgers table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.gl_sub_ledgers CustomMapper_gl_sub_ledgers(EclipseDataAccess.gl_sub_ledgers source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.gl_sub_ledgers destination = new BOALedgerDataAccess.gl_sub_ledgers();
            //
            // Set basic properties
            destination.glsl_id = source.glsl_id;
            destination.glsl_glac_num = source.glsl_glac_num;
            destination.glsl_name = source.glsl_name;
            destination.glsl_entity_id = source.glsl_entity_id;
            destination.glsl_active = source.glsl_active;
            destination.glsl_balance = source.glsl_balance;
            destination.glsl_created_who = source.glsl_created_who;
            destination.glsl_created_when = source.glsl_created_when;
            destination.glsl_updated_who = source.glsl_updated_who;
            destination.glsl_updated_when = source.glsl_updated_when;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for atura_tagvalue table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.atura_tagvalue CustomMapper_atura_tagvalue(EclipseDataAccess.atura_tagvalue source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.atura_tagvalue destination = new BOALedgerDataAccess.atura_tagvalue();
            //
            // Set basic properties
            destination.attv_id = source.attv_id;
            destination.attv_insert_id = source.attv_insert_id;
            destination.attv_column_id = source.attv_column_id;
            destination.attv_row_id = source.attv_row_id;
            destination.attv_tag = source.attv_tag;
            destination.attv_index = source.attv_index;
            destination.attv_value = source.attv_value;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for exemption_types table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.exemption_types CustomMapper_exemption_types(EclipseDataAccess.exemption_types source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.exemption_types destination = new BOALedgerDataAccess.exemption_types();
            //
            // Set basic properties
            destination.extyp_id = source.extyp_id;
            destination.extyp_parent_id = source.extyp_parent_id;
            destination.extyp_created_who = source.extyp_created_who;
            destination.extyp_created_when = source.extyp_created_when;
            destination.extyp_updated_who = source.extyp_updated_who;
            destination.extyp_updated_when = source.extyp_updated_when;
            destination.extyp_name = source.extyp_name;
            destination.extyp_desc = source.extyp_desc;
            destination.extyp_inactive = source.extyp_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for atura_tagrangevalue table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.atura_tagrangevalue CustomMapper_atura_tagrangevalue(EclipseDataAccess.atura_tagrangevalue source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.atura_tagrangevalue destination = new BOALedgerDataAccess.atura_tagrangevalue();
            //
            // Set basic properties
            destination.attrv_attv_id = source.attrv_attv_id;
            destination.attrv_row_id = source.attrv_row_id;
            destination.attrv_col_id = source.attrv_col_id;
            destination.attrv_index = source.attrv_index;
            destination.attrv_value = source.attrv_value;
            destination.attrv_id = source.attrv_id;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for gl_sl_entities table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.gl_sl_entities CustomMapper_gl_sl_entities(EclipseDataAccess.gl_sl_entities source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.gl_sl_entities destination = new BOALedgerDataAccess.gl_sl_entities();
            //
            // Set basic properties
            destination.gle_name = source.gle_name;
            destination.gle_move_ref_view = source.gle_move_ref_view;
            destination.gle_move_ref_column = source.gle_move_ref_column;
            destination.gle_sub_ledger_name = source.gle_sub_ledger_name;
            destination.gle_created_who = source.gle_created_who;
            destination.gle_created_when = source.gle_created_when;
            destination.gle_updated_who = source.gle_updated_who;
            destination.gle_updated_when = source.gle_updated_when;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for columns table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.columns CustomMapper_columns(EclipseDataAccess.columns source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.columns destination = new BOALedgerDataAccess.columns();
            //
            // Set basic properties
            destination.col_id = source.col_id;
            destination.col_created_who = source.col_created_who;
            destination.col_created_when = source.col_created_when;
            destination.col_updated_who = source.col_updated_who;
            destination.col_updated_when = source.col_updated_when;
            destination.col_parent_id = source.col_parent_id;
            destination.col_name = source.col_name;
            destination.col_desc = source.col_desc;
            destination.col_sort = source.col_sort;
            destination.col_inactive = source.col_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for sunrise_server_codes table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.sunrise_server_codes CustomMapper_sunrise_server_codes(EclipseDataAccess.sunrise_server_codes source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.sunrise_server_codes destination = new BOALedgerDataAccess.sunrise_server_codes();
            //
            // Set basic properties
            destination.sunserco_id = source.sunserco_id;
            destination.sunserco_created_who = source.sunserco_created_who;
            destination.sunserco_created_when = source.sunserco_created_when;
            destination.sunserco_updated_who = source.sunserco_updated_who;
            destination.sunserco_updated_when = source.sunserco_updated_when;
            destination.sunserco_name = source.sunserco_name;
            destination.sunserco_desc = source.sunserco_desc;
            destination.sunserco_inactive = source.sunserco_inactive;
            destination.sunserco_login = source.sunserco_login;
            destination.sunserco_password = source.sunserco_password;
            destination.sunserco_url = source.sunserco_url;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for anzic_groups table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.anzic_groups CustomMapper_anzic_groups(EclipseDataAccess.anzic_groups source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.anzic_groups destination = new BOALedgerDataAccess.anzic_groups();
            //
            // Set basic properties
            destination.anzgroup_id = source.anzgroup_id;
            destination.anzgroup_code = source.anzgroup_code;
            destination.anzgroup_name = source.anzgroup_name;
            destination.anzgroup_parent_id = source.anzgroup_parent_id;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for monthly_frequency table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.monthly_frequency CustomMapper_monthly_frequency(EclipseDataAccess.monthly_frequency source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.monthly_frequency destination = new BOALedgerDataAccess.monthly_frequency();
            //
            // Set basic properties
            destination.mf_id = source.mf_id;
            destination.mf_name = source.mf_name;
            destination.mf_datepart = source.mf_datepart;
            destination.mf_datenumber = source.mf_datenumber;
            destination.mf_created_who = source.mf_created_who;
            destination.mf_created_when = source.mf_created_when;
            destination.mf_updated_who = source.mf_updated_who;
            destination.mf_updated_when = source.mf_updated_when;
            destination.mf_default_no_of_payments = source.mf_default_no_of_payments;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for entities table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.entities CustomMapper_entities(EclipseDataAccess.entities source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.entities destination = new BOALedgerDataAccess.entities();
            //
            // Set basic properties
            destination.ent_id = source.ent_id;
            destination.ent_created_who = source.ent_created_who;
            destination.ent_created_when = source.ent_created_when;
            destination.ent_updated_who = source.ent_updated_who;
            destination.ent_updated_when = source.ent_updated_when;
            destination.ent_duration = source.ent_duration;
            destination.ent_caption_switch = source.ent_caption_switch;
            destination.ent_roles = source.ent_roles;
            destination.ent_name = source.ent_name;
            destination.ent_contact = source.ent_contact;
            destination.ent_job_title = source.ent_job_title;
            destination.ent_salutation = source.ent_salutation;
            destination.ent_address_1 = source.ent_address_1;
            destination.ent_address_2 = source.ent_address_2;
            destination.ent_address_3 = source.ent_address_3;
            destination.ent_suburb = source.ent_suburb;
            destination.ent_state = source.ent_state;
            destination.ent_postcode = source.ent_postcode;
            destination.ent_telephone = source.ent_telephone;
            destination.ent_telephone_2 = source.ent_telephone_2;
            destination.ent_mobile = source.ent_mobile;
            destination.ent_facsimile = source.ent_facsimile;
            destination.ent_email = source.ent_email;
            destination.ent_web_site = source.ent_web_site;
            destination.ent_trading_as = source.ent_trading_as;
            destination.ent_client_code = source.ent_client_code;
            destination.ent_update_flag = source.ent_update_flag;
            destination.ent_balance = source.ent_balance;
            destination.ent_abn = source.ent_abn;
            destination.ent_status = source.ent_status;
            destination.ent_status_updated_who = source.ent_status_updated_who;
            destination.ent_status_updated_when = source.ent_status_updated_when;
            destination.ent_account_name = source.ent_account_name;
            destination.ent_account_no = source.ent_account_no;
            destination.ent_bank_name = source.ent_bank_name;
            destination.ent_branch_name = source.ent_branch_name;
            destination.ent_bsb_no = source.ent_bsb_no;
            destination.ent_aba_file_gen = source.ent_aba_file_gen;
            destination.ent_asic_type = source.ent_asic_type;
            destination.ent_longitude = source.ent_longitude;
            destination.ent_latitude = source.ent_latitude;
            destination.ent_addressee = source.ent_addressee;
            destination.ent_code = source.ent_code;
            destination.ent_aba_ref_no = source.ent_aba_ref_no;
            destination.ent_ufi_country_code = source.ent_ufi_country_code;
            destination.ent_client_category1 = source.ent_client_category1;
            destination.ent_client_category2 = source.ent_client_category2;
            destination.ent_client_category3 = source.ent_client_category3;
            destination.ent_client_category4 = source.ent_client_category4;
            destination.ent_client_category5 = source.ent_client_category5;
            destination.ent_BrokerReps_category1 = source.ent_BrokerReps_category1;
            destination.ent_BrokerReps_category2 = source.ent_BrokerReps_category2;
            destination.ent_BrokerReps_category3 = source.ent_BrokerReps_category3;
            destination.ent_Insurers_category1 = source.ent_Insurers_category1;
            destination.ent_Insurers_category2 = source.ent_Insurers_category2;
            destination.ent_Insurers_category3 = source.ent_Insurers_category3;
            destination.ent_TIM_client_code = source.ent_TIM_client_code;
            destination.ent_folder_location = source.ent_folder_location;
            destination.ent_step = null;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for anzic_classes table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.anzic_classes CustomMapper_anzic_classes(EclipseDataAccess.anzic_classes source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.anzic_classes destination = new BOALedgerDataAccess.anzic_classes();
            //
            // Set basic properties
            destination.anzcla_id = source.anzcla_id;
            destination.anzcla_code = source.anzcla_code;
            destination.anzcla_name = source.anzcla_name;
            destination.anzcla_parent_id = source.anzcla_parent_id;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for ClaimPaymentTypes table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.ClaimPaymentTypes CustomMapper_ClaimPaymentTypes(EclipseDataAccess.ClaimPaymentTypes source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.ClaimPaymentTypes destination = new BOALedgerDataAccess.ClaimPaymentTypes();
            //
            // Set basic properties
            destination.clatype_id = source.clatype_id;
            destination.clatype_created_who = source.clatype_created_who;
            destination.clatype_created_when = source.clatype_created_when;
            destination.clatype_updated_who = source.clatype_updated_who;
            destination.clatype_updated_when = source.clatype_updated_when;
            destination.clatype_name = source.clatype_name;
            destination.clatype_desc = source.clatype_desc;
            destination.clatype_inactive = source.clatype_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for anzic_subdivisions table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.anzic_subdivisions CustomMapper_anzic_subdivisions(EclipseDataAccess.anzic_subdivisions source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.anzic_subdivisions destination = new BOALedgerDataAccess.anzic_subdivisions();
            //
            // Set basic properties
            destination.anzsubdiv_id = source.anzsubdiv_id;
            destination.anzsubdiv_code = source.anzsubdiv_code;
            destination.anzsubdiv_name = source.anzsubdiv_name;
            destination.anzsubdiv_parent_id = source.anzsubdiv_parent_id;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for related_entities table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.related_entities CustomMapper_related_entities(EclipseDataAccess.related_entities source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.related_entities destination = new BOALedgerDataAccess.related_entities();
            //
            // Set basic properties
            destination.relent_id = source.relent_id;
            destination.relent_parent_id = source.relent_parent_id;
            destination.relent_created_who = source.relent_created_who;
            destination.relent_created_when = source.relent_created_when;
            destination.relent_updated_who = source.relent_updated_who;
            destination.relent_updated_when = source.relent_updated_when;
            destination.relent_duration = source.relent_duration;
            destination.relent_related_entity_types = source.relent_related_entity_types;
            destination.relent_related_entity = source.relent_related_entity;
            destination.relent_notes = source.relent_notes;
            destination.relent_contact = source.relent_contact;
            destination.relent_telephone = source.relent_telephone;
            destination.relent_facsimile = source.relent_facsimile;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for banking table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.banking CustomMapper_banking(EclipseDataAccess.banking source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.banking destination = new BOALedgerDataAccess.banking();
            //
            // Set basic properties
            destination.bank_id = source.bank_id;
            destination.bank_time = source.bank_time;
            destination.bank_status = source.bank_status;
            destination.bank_financial_institution = source.bank_financial_institution;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for dofi_types table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.dofi_types CustomMapper_dofi_types(EclipseDataAccess.dofi_types source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.dofi_types destination = new BOALedgerDataAccess.dofi_types();
            //
            // Set basic properties
            destination.doftyp_id = source.doftyp_id;
            destination.doftyp_name = source.doftyp_name;
            destination.doftyp_code = source.doftyp_code;
            destination.doftyp_created_who = source.doftyp_created_who;
            destination.doftyp_created_when = source.doftyp_created_when;
            destination.doftyp_updated_who = source.doftyp_updated_who;
            destination.doftyp_updated_when = source.doftyp_updated_when;
            destination.doftyp_desc = source.doftyp_desc;
            destination.doftyp_inactive = source.doftyp_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for anzic_divisions table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.anzic_divisions CustomMapper_anzic_divisions(EclipseDataAccess.anzic_divisions source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.anzic_divisions destination = new BOALedgerDataAccess.anzic_divisions();
            //
            // Set basic properties
            destination.anzdiv_id = source.anzdiv_id;
            destination.anzdiv_code = source.anzdiv_code;
            destination.anzdiv_name = source.anzdiv_name;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for PoliciesNotPosted table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.PoliciesNotPosted CustomMapper_PoliciesNotPosted(EclipseDataAccess.PoliciesNotPosted source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.PoliciesNotPosted destination = new BOALedgerDataAccess.PoliciesNotPosted();
            //
            // Set basic properties
            destination.ent_name = source.ent_name;
            destination.genins_name = source.genins_name;
            destination.gentrans_name = source.gentrans_name;
            destination.saltea_name = source.saltea_name;
            destination.pol_invoice_total = source.pol_invoice_total;
            destination.pol_base_premium = source.pol_base_premium;
            destination.wor_created_when = source.wor_created_when;
            destination.pol_date_from = source.pol_date_from;
            destination.pol_date_to = source.pol_date_to;
            destination.Insurer = source.Insurer;
            destination.pol_policy_number = source.pol_policy_number;
            destination.tran_type = source.tran_type;
            destination.spid = source.spid;
            destination.wor_id = source.wor_id;
            destination.saletea_id = source.saletea_id;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for profile_status table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.profile_status CustomMapper_profile_status(EclipseDataAccess.profile_status source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.profile_status destination = new BOALedgerDataAccess.profile_status();
            //
            // Set basic properties
            destination.profstat_id = source.profstat_id;
            destination.profstat_created_who = source.profstat_created_who;
            destination.profstat_created_when = source.profstat_created_when;
            destination.profstat_updated_who = source.profstat_updated_who;
            destination.profstat_updated_when = source.profstat_updated_when;
            destination.profstat_name = source.profstat_name;
            destination.profstat_desc = source.profstat_desc;
            destination.profstat_inactive = source.profstat_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for financial_institution table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.financial_institution CustomMapper_financial_institution(EclipseDataAccess.financial_institution source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.financial_institution destination = new BOALedgerDataAccess.financial_institution();
            //
            // Set basic properties
            destination.finins_id = source.finins_id;
            destination.finins_name = source.finins_name;
            destination.finins_branch = source.finins_branch;
            destination.finins_acc_name = source.finins_acc_name;
            destination.finins_acc_bsb = source.finins_acc_bsb;
            destination.finins_acc_no = source.finins_acc_no;
            destination.finins_inactive = source.finins_inactive;
            destination.finins_created_who = source.finins_created_who;            
            destination.finins_updated_who = source.finins_updated_who;
            if (source.finins_created_when != null)
            {
                destination.finins_created_when = DateTime.Parse(source.finins_created_when);
            }
            else
            {
                destination.finins_created_when = DateTime.Now;
            }
            if (source.finins_updated_when != null)
            {
                destination.finins_updated_when = DateTime.Parse(source.finins_updated_when);
            }
            else
            {
                destination.finins_updated_when = null;
            }
            
            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for organisation_structures table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.organisation_structures CustomMapper_organisation_structures(EclipseDataAccess.organisation_structures source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.organisation_structures destination = new BOALedgerDataAccess.organisation_structures();
            //
            // Set basic properties
            destination.orgstr_id = source.orgstr_id;
            destination.orgstr_created_who = source.orgstr_created_who;
            destination.orgstr_created_when = source.orgstr_created_when;
            destination.orgstr_updated_who = source.orgstr_updated_who;
            destination.orgstr_updated_when = source.orgstr_updated_when;
            destination.orgstr_name = source.orgstr_name;
            destination.orgstr_desc = source.orgstr_desc;
            destination.orgstr_inactive = source.orgstr_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for gl_amounts table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.gl_amounts CustomMapper_gl_amounts(EclipseDataAccess.gl_amounts source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.gl_amounts destination = new BOALedgerDataAccess.gl_amounts();
            //
            // Set basic properties
            destination.glamt_code = source.glamt_code;
            destination.glamt_move_ref_view = source.glamt_move_ref_view;
            destination.glamt_move_ref_column = source.glamt_move_ref_column;
            destination.glamt_created_who = source.glamt_created_who;
            destination.glamt_created_when = source.glamt_created_when;
            destination.glamt_updated_who = source.glamt_updated_who;
            destination.glamt_updated_when = source.glamt_updated_when;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for account_types table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.account_types CustomMapper_account_types(EclipseDataAccess.account_types source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.account_types destination = new BOALedgerDataAccess.account_types();
            //
            // Set basic properties
            destination.acctyp_id = source.acctyp_id;
            destination.acctyp_created_who = source.acctyp_created_who;
            destination.acctyp_created_when = source.acctyp_created_when;
            destination.acctyp_updated_who = source.acctyp_updated_who;
            destination.acctyp_updated_when = source.acctyp_updated_when;
            destination.acctyp_name = source.acctyp_name;
            destination.acctyp_desc = source.acctyp_desc;
            destination.acctyp_inactive = source.acctyp_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for ClientDetails_Category5 table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.ClientDetails_Category5 CustomMapper_ClientDetails_Category5(EclipseDataAccess.ClientDetails_Category5 source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.ClientDetails_Category5 destination = new BOALedgerDataAccess.ClientDetails_Category5();
            //
            // Set basic properties
            destination.cdcat5_id = source.cdcat5_id;
            destination.cdcat5_created_who = source.cdcat5_created_who;
            destination.cdcat5_created_when = source.cdcat5_created_when;
            destination.cdcat5_updated_who = source.cdcat5_updated_who;
            destination.cdcat5_updated_when = source.cdcat5_updated_when;
            destination.cdcat5_name = source.cdcat5_name;
            destination.cdcat5_desc = source.cdcat5_desc;
            destination.cdcat5_inactive = source.cdcat5_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for BrokerFeeDefaultWorkbookType table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.BrokerFeeDefaultWorkbookType CustomMapper_BrokerFeeDefaultWorkbookType(EclipseDataAccess.BrokerFeeDefaultWorkbookType source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.BrokerFeeDefaultWorkbookType destination = new BOALedgerDataAccess.BrokerFeeDefaultWorkbookType();
            //
            // Set basic properties
            destination.bfdwt_id = source.bfdwt_id;
            destination.bfdwt_auto = source.bfdwt_auto;
            destination.bfdwt_percentage = source.bfdwt_percentage;
            destination.bfdwt_basisId = source.bfdwt_basisId;
            destination.bfdwt_default = source.bfdwt_default;
            destination.bfdwt_minimum = source.bfdwt_minimum;
            destination.bfdwt_maximum = source.bfdwt_maximum;
            destination.bfdwt_amend = source.bfdwt_amend;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for sub_agent_profile table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.sub_agent_profile CustomMapper_sub_agent_profile(EclipseDataAccess.sub_agent_profile source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.sub_agent_profile destination = new BOALedgerDataAccess.sub_agent_profile();
            //
            // Set basic properties
            destination.sap_id = source.sap_id;
            destination.sap_parent_id = source.sap_parent_id;
            destination.sap_created_who = source.sap_created_who;
            destination.sap_created_when = source.sap_created_when;
            destination.sap_updated_who = source.sap_updated_who;
            destination.sap_updated_when = source.sap_updated_when;
            destination.sap_duration = source.sap_duration;
            destination.sap_new_bus_commission = source.sap_new_bus_commission;
            destination.sap_renewal_commission = source.sap_renewal_commission;
            destination.sap_new_business_fee = source.sap_new_business_fee;
            destination.sap_renewal_fee = source.sap_renewal_fee;
            destination.sap_adjustment_commission = source.sap_adjustment_commission;
            destination.sap_adjustment_fee = source.sap_adjustment_fee;
            destination.sap_auto_payment = source.sap_auto_payment;
            destination.sap_exclude_man_payment = source.sap_exclude_man_payment;
            destination.sap_comm_calculated_on_base = source.sap_comm_calculated_on_base;
            destination.sap_user = source.sap_user;
            destination.sap_branch = source.sap_branch;
            destination.sap_logo = source.sap_logo;
            destination.sap_remittance_email_address = source.sap_remittance_email_address;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for BrokerFeeDefaults table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.BrokerFeeDefaults CustomMapper_BrokerFeeDefaults(EclipseDataAccess.BrokerFeeDefaults source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.BrokerFeeDefaults destination = new BOALedgerDataAccess.BrokerFeeDefaults();
            //
            // Set basic properties
            destination.bfd_id = source.bfd_id;
            destination.bfd_branchId = source.bfd_branchId;
            destination.bfd_brokerRepId = source.bfd_brokerRepId;
            destination.bfd_classOfBusinessId = source.bfd_classOfBusinessId;
            destination.bfd_newBusinessWorkbookTypeId = source.bfd_newBusinessWorkbookTypeId;
            destination.bfd_renewalWorkbookTypeId = source.bfd_renewalWorkbookTypeId;
            destination.bfd_renewalTransferWorkbookTypeId = source.bfd_renewalTransferWorkbookTypeId;
            destination.bfd_positiveEndorsementWorkbookTypeId = source.bfd_positiveEndorsementWorkbookTypeId;
            destination.bfd_negativeEndorsementWorkbookTypeId = source.bfd_negativeEndorsementWorkbookTypeId;
            destination.bfd_cancellationWorkbookTypeId = source.bfd_cancellationWorkbookTypeId;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for related_entity_types table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.related_entity_types CustomMapper_related_entity_types(EclipseDataAccess.related_entity_types source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.related_entity_types destination = new BOALedgerDataAccess.related_entity_types();
            //
            // Set basic properties
            destination.relentty_id = source.relentty_id;
            destination.relentty_created_who = source.relentty_created_who;
            destination.relentty_created_when = source.relentty_created_when;
            destination.relentty_updated_who = source.relentty_updated_who;
            destination.relentty_updated_when = source.relentty_updated_when;
            destination.relentty_name = source.relentty_name;
            destination.relentty_desc = source.relentty_desc;
            destination.relentty_inactive = source.relentty_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for apra_class_of_business table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.apra_class_of_business CustomMapper_apra_class_of_business(EclipseDataAccess.apra_class_of_business source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.apra_class_of_business destination = new BOALedgerDataAccess.apra_class_of_business();
            //
            // Set basic properties
            destination.apracob_id = source.apracob_id;
            destination.apracob_created_who = source.apracob_created_who;
            destination.apracob_created_when = source.apracob_created_when;
            destination.apracob_updated_who = source.apracob_updated_who;
            destination.apracob_updated_when = source.apracob_updated_when;
            destination.apracob_name = source.apracob_name;
            destination.apracob_desc = source.apracob_desc;
            destination.apracob_inactive = source.apracob_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for ClausePermissions table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.ClausePermissions CustomMapper_ClausePermissions(EclipseDataAccess.ClausePermissions source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.ClausePermissions destination = new BOALedgerDataAccess.ClausePermissions();
            //
            // Set basic properties
            destination.clause_permission_id = source.clause_permission_id;
            destination.clause_id = source.clause_id;
            destination.insurer_id = source.insurer_id;
            destination.COB_id = source.COB_id;
            destination.COBSection_name = source.COBSection_name;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for personnel_types table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.personnel_types CustomMapper_personnel_types(EclipseDataAccess.personnel_types source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.personnel_types destination = new BOALedgerDataAccess.personnel_types();
            //
            // Set basic properties
            destination.pertyp_id = source.pertyp_id;
            destination.pertyp_created_who = source.pertyp_created_who;
            destination.pertyp_created_when = source.pertyp_created_when;
            destination.pertyp_updated_who = source.pertyp_updated_who;
            destination.pertyp_updated_when = source.pertyp_updated_when;
            destination.pertyp_name = source.pertyp_name;
            destination.pertyp_desc = source.pertyp_desc;
            destination.pertyp_inactive = source.pertyp_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for profile_referrer table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.profile_referrer CustomMapper_profile_referrer(EclipseDataAccess.profile_referrer source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.profile_referrer destination = new BOALedgerDataAccess.profile_referrer();
            //
            // Set basic properties
            destination.profref_id = source.profref_id;
            destination.profref_created_who = source.profref_created_who;
            destination.profref_created_when = source.profref_created_when;
            destination.profref_updated_who = source.profref_updated_who;
            destination.profref_updated_when = source.profref_updated_when;
            destination.profref_name = source.profref_name;
            destination.profref_desc = source.profref_desc;
            destination.profref_inactive = source.profref_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for sunrise_mapping table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.sunrise_mapping CustomMapper_sunrise_mapping(EclipseDataAccess.sunrise_mapping source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.sunrise_mapping destination = new BOALedgerDataAccess.sunrise_mapping();
            //
            // Set basic properties
            destination.sunmap_id = source.sunmap_id;
            destination.sunmap_created_who = source.sunmap_created_who;
            destination.sunmap_created_when = source.sunmap_created_when;
            destination.sunmap_updated_who = source.sunmap_updated_who;
            destination.sunmap_updated_when = source.sunmap_updated_when;
            destination.sunmap_name = source.sunmap_name;
            destination.sunmap_desc = source.sunmap_desc;
            destination.sunmap_inactive = source.sunmap_inactive;
            destination.sunmap_local_name = source.sunmap_local_name;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for branches table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.branches CustomMapper_branches(EclipseDataAccess.branches source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.branches destination = new BOALedgerDataAccess.branches();
            //
            // Set basic properties
            destination.bra_id = source.bra_id;
            destination.bra_created_who = source.bra_created_who;
            destination.bra_created_when = source.bra_created_when;
            destination.bra_updated_who = source.bra_updated_who;
            destination.bra_updated_when = source.bra_updated_when;
            destination.bra_name = source.bra_name;
            destination.bra_desc = source.bra_desc;
            destination.bra_inactive = source.bra_inactive;
            destination.bra_address_1 = source.bra_address_1;
            destination.bra_address_2 = source.bra_address_2;
            destination.bra_address_3 = source.bra_address_3;
            destination.bra_suburb = source.bra_suburb;
            destination.bra_state = source.bra_state;
            destination.bra_postcode = source.bra_postcode;
            destination.bra_telephone = source.bra_telephone;
            destination.bra_telephone_2 = source.bra_telephone_2;
            destination.bra_mobile = source.bra_mobile;
            destination.bra_facsimile = source.bra_facsimile;
            destination.bra_email = source.bra_email;
            destination.bra_web_site = source.bra_web_site;
            destination.bra_trading_as = source.bra_trading_as;
            destination.bra_parent_branch = source.bra_parent_branch;
            destination.bra_asic_branch = source.bra_asic_branch;
            destination.bra_cr_closing_opt = source.bra_cr_closing_opt;
            destination.bra_cr_receipting_opt = source.bra_cr_receipting_opt;
            destination.bra_branch_id = source.bra_branch_id;
            destination.bra_company_name = source.bra_company_name;
            destination.bra_ABN = source.bra_ABN;
            destination.bra_logo = source.bra_logo;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for DEFTStatuses table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.DEFTStatuses CustomMapper_DEFTStatuses(EclipseDataAccess.DEFTStatuses source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.DEFTStatuses destination = new BOALedgerDataAccess.DEFTStatuses();
            //
            // Set basic properties
            destination.deftsta_id = source.deftsta_id;
            destination.deftsta_description = source.deftsta_description;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for DEFTItemsInError_Custom table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.DEFTItemsInError_Custom CustomMapper_DEFTItemsInError_Custom(EclipseDataAccess.DEFTItemsInError_Custom source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.DEFTItemsInError_Custom destination = new BOALedgerDataAccess.DEFTItemsInError_Custom();
            //
            // Set basic properties
            destination.deftiiec_id = source.deftiiec_id;
            destination.deftiiec_deft_item_id = source.deftiiec_deft_item_id;
            destination.deftiiec_description = source.deftiiec_description;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for tasks_sub_tasks table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.tasks_sub_tasks CustomMapper_tasks_sub_tasks(EclipseDataAccess.tasks_sub_tasks source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.tasks_sub_tasks destination = new BOALedgerDataAccess.tasks_sub_tasks();
            //
            // Set basic properties
            destination.tassubta_id = source.tassubta_id;
            destination.tassubta_parent_id = source.tassubta_parent_id;
            destination.tassubta_created_who = source.tassubta_created_who;
            destination.tassubta_created_when = source.tassubta_created_when;
            destination.tassubta_updated_who = source.tassubta_updated_who;
            destination.tassubta_updated_when = source.tassubta_updated_when;
            destination.tassubta_duration = source.tassubta_duration;
            destination.tassubta_date = source.tassubta_date;
            destination.tassubta_initiated_by = source.tassubta_initiated_by;
            destination.tassubta_brief_description = source.tassubta_brief_description;
            destination.tassubta_document = source.tassubta_document;
            destination.Fname = source.Fname;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for tables table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.tables CustomMapper_tables(EclipseDataAccess.tables source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.tables destination = new BOALedgerDataAccess.tables();
            //
            // Set basic properties
            destination.tab_id = source.tab_id;
            destination.tab_created_who = source.tab_created_who;
            destination.tab_created_when = source.tab_created_when;
            destination.tab_updated_who = source.tab_updated_who;
            destination.tab_updated_when = source.tab_updated_when;
            destination.tab_name = source.tab_name;
            destination.tab_desc = source.tab_desc;
            destination.tab_sort = source.tab_sort;
            destination.tab_inactive = source.tab_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for DEFTItemsInError_Predefined table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.DEFTItemsInError_Predefined CustomMapper_DEFTItemsInError_Predefined(EclipseDataAccess.DEFTItemsInError_Predefined source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.DEFTItemsInError_Predefined destination = new BOALedgerDataAccess.DEFTItemsInError_Predefined();
            //
            // Set basic properties
            destination.deftiiep_id = source.deftiiep_id;
            destination.deftiiep_deft_item_id = source.deftiiep_deft_item_id;
            destination.deftiiep_predefined_error_id = source.deftiiep_predefined_error_id;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for tasks table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.tasks CustomMapper_tasks(EclipseDataAccess.tasks source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.tasks destination = new BOALedgerDataAccess.tasks();
            //
            // Set basic properties
            destination.tas_id = source.tas_id;
            destination.tas_parent_id = source.tas_parent_id;
            destination.tas_created_who = source.tas_created_who;
            destination.tas_created_when = source.tas_created_when;
            destination.tas_updated_who = source.tas_updated_who;
            destination.tas_updated_when = source.tas_updated_when;
            destination.tas_duration = source.tas_duration;
            destination.tas_closed = source.tas_closed;
            destination.tas_initiated_by = source.tas_initiated_by;
            destination.tas_contact_person = source.tas_contact_person;
            destination.tas_contact_method = source.tas_contact_method;
            destination.tas_brief_description = source.tas_brief_description;
            destination.tas_priority = source.tas_priority;
            destination.tas_followup_date = source.tas_followup_date;
            destination.tas_followup_action = source.tas_followup_action;
            destination.tas_status = source.tas_status;
            destination.tas_notes = source.tas_notes;
            destination.tas_document_type = source.tas_document_type;
            destination.tas_date = source.tas_date;
            destination.tas_type = source.tas_type;
            destination.tas_queue = source.tas_queue;
            destination.tas_re_open_Date = source.tas_re_open_Date;
            destination.tas_re_open_User = source.tas_re_open_User;
            destination.tas_original_que_person = source.tas_original_que_person;
            destination.tas_contact_phone = source.tas_contact_phone;
            destination.tas_contact_mobile = source.tas_contact_mobile;
            destination.tas_contact_email = source.tas_contact_email;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for WorkbookHeader table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.WorkbookHeader CustomMapper_WorkbookHeader(EclipseDataAccess.WorkbookHeader source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.WorkbookHeader destination = new BOALedgerDataAccess.WorkbookHeader();
            //
            // Set basic properties
            destination.wor_id = source.wor_id;
            destination.Insurer = source.Insurer;
            destination.BasePremium = source.BasePremium;
            destination.FSL = source.FSL;
            destination.FSLPerc = source.FSLPerc;
            destination.Premium = source.Premium;
            destination.PremiumGST = source.PremiumGST;
            destination.StampDuty = source.StampDuty;
            destination.StampDutyPerc = source.StampDutyPerc;
            destination.UnderwriterFee = source.UnderwriterFee;
            destination.UnderwriterFeeGST = source.UnderwriterFeeGST;
            destination.GrossPremium = source.GrossPremium;
            destination.BrokerFee = source.BrokerFee;
            destination.BrokerFeeGST = source.BrokerFeeGST;
            destination.InvoiceTotal = source.InvoiceTotal;
            destination.Commission = source.Commission;
            destination.CommissionPerc = source.CommissionPerc;
            destination.CommissionGST = source.CommissionGST;
            destination.NetPremium = source.NetPremium;
            destination.TerrorismLevy = source.TerrorismLevy;
            destination.Posted = source.Posted;
            destination.OpportunityId = source.OpportunityId;
            destination.SVUStatus = source.SVUStatus;
            destination.OpportunityCategory = source.OpportunityCategory;
            destination.TransactionType = source.TransactionType;
            destination.SVURef = source.SVURef;
            destination.Bound = source.Bound;
            destination.Lapsed = source.Lapsed;
            destination.Closed = source.Closed;
            destination.SVUInsurerName = source.SVUInsurerName;
            destination.DateEffective = source.DateEffective;
            destination.DateFrom = source.DateFrom;
            destination.DateTo = source.DateTo;
            destination.ConversationId = source.ConversationId;
            destination.ParticularsDownloaded = source.ParticularsDownloaded;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for entities_a table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.entities_a CustomMapper_entities_a(EclipseDataAccess.entities_a source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.entities_a destination = new BOALedgerDataAccess.entities_a();
            //
            // Set basic properties
            destination.ent_aud_id = source.ent_aud_id;
            destination.ent_id = source.ent_id;
            destination.ent_created_who = source.ent_created_who;
            destination.ent_created_when = source.ent_created_when;
            destination.ent_updated_who = source.ent_updated_who;
            destination.ent_updated_when = source.ent_updated_when;
            destination.ent_duration = source.ent_duration;
            destination.ent_caption_switch = source.ent_caption_switch;
            destination.ent_roles = source.ent_roles;
            destination.ent_name = source.ent_name;
            destination.ent_contact = source.ent_contact;
            destination.ent_job_title = source.ent_job_title;
            destination.ent_salutation = source.ent_salutation;
            destination.ent_address_1 = source.ent_address_1;
            destination.ent_address_2 = source.ent_address_2;
            destination.ent_address_3 = source.ent_address_3;
            destination.ent_suburb = source.ent_suburb;
            destination.ent_state = source.ent_state;
            destination.ent_postcode = source.ent_postcode;
            destination.ent_telephone = source.ent_telephone;
            destination.ent_telephone_2 = source.ent_telephone_2;
            destination.ent_mobile = source.ent_mobile;
            destination.ent_facsimile = source.ent_facsimile;
            destination.ent_email = source.ent_email;
            destination.ent_web_site = source.ent_web_site;
            destination.ent_trading_as = source.ent_trading_as;
            destination.ent_client_code = source.ent_client_code;
            destination.ent_update_flag = source.ent_update_flag;
            destination.ent_general_client_notes = source.ent_general_client_notes;
            destination.ent_acn = source.ent_acn;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for DEFTPredefinedErrors table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.DEFTPredefinedErrors CustomMapper_DEFTPredefinedErrors(EclipseDataAccess.DEFTPredefinedErrors source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.DEFTPredefinedErrors destination = new BOALedgerDataAccess.DEFTPredefinedErrors();
            //
            // Set basic properties
            destination.deftpe_id = source.deftpe_id;
            destination.deftpe_description = source.deftpe_description;
            destination.deftpe_short_description = source.deftpe_short_description;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for policy_transaction_documents table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.policy_transaction_documents CustomMapper_policy_transaction_documents(EclipseDataAccess.policy_transaction_documents source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.policy_transaction_documents destination = new BOALedgerDataAccess.policy_transaction_documents();
            //
            // Set basic properties
            destination.poltrado_id = source.poltrado_id;
            destination.poltrado_created_who = source.poltrado_created_who;
            destination.poltrado_created_when = source.poltrado_created_when;
            destination.poltrado_updated_who = source.poltrado_updated_who;
            destination.poltrado_updated_when = source.poltrado_updated_when;
            destination.poltrado_parent_id = source.poltrado_parent_id;
            destination.poltrado_name = source.poltrado_name;
            destination.poltrado_desc = source.poltrado_desc;
            destination.poltrado_inactive = source.poltrado_inactive;
            destination.poltrado_type = source.poltrado_type;
            destination.HasMacros = source.HasMacros;
            destination.poltrado_email_template = source.poltrado_email_template;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for gen_ins_wor_documents table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.gen_ins_wor_documents CustomMapper_gen_ins_wor_documents(EclipseDataAccess.gen_ins_wor_documents source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.gen_ins_wor_documents destination = new BOALedgerDataAccess.gen_ins_wor_documents();
            //
            // Set basic properties
            destination.giwordoc_id = source.giwordoc_id;
            destination.giwordoc_created_who = source.giwordoc_created_who;
            destination.giwordoc_created_when = source.giwordoc_created_when;
            destination.giwordoc_updated_who = source.giwordoc_updated_who;
            destination.giwordoc_updated_when = source.giwordoc_updated_when;
            destination.giwordoc_parent_id = source.giwordoc_parent_id;
            destination.giwordoc_name = source.giwordoc_name;
            destination.giwordoc_desc = source.giwordoc_desc;
            destination.giwordoc_inactive = source.giwordoc_inactive;
            destination.giwordoc_document = source.giwordoc_document;
            destination.giwordoc_type = source.giwordoc_type;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for balances table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.balances CustomMapper_balances(EclipseDataAccess.balances source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.balances destination = new BOALedgerDataAccess.balances();
            //
            // Set basic properties
            destination.bal_tran_id = source.bal_tran_id;
            destination.bal_entity_id = source.bal_entity_id;
            destination.bal_led_id = source.bal_led_id;
            destination.bal_amount = source.bal_amount;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for atura_roles table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.atura_roles CustomMapper_atura_roles(EclipseDataAccess.atura_roles source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.atura_roles destination = new BOALedgerDataAccess.atura_roles();
            //
            // Set basic properties
            destination.atrol_bit = source.atrol_bit;
            destination.atrol_name = source.atrol_name;
            destination.atrol_created_who = source.atrol_created_who;
            destination.atrol_created_when = source.atrol_created_when;
            destination.atrol_updated_who = source.atrol_updated_who;
            destination.atrol_updated_when = source.atrol_updated_when;
            destination.atrol_desc = source.atrol_desc;
            destination.atrol_active = source.atrol_active;
            destination.atrol_mutexcl = source.atrol_mutexcl;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for claims table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.claims CustomMapper_claims(EclipseDataAccess.claims source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.claims destination = new BOALedgerDataAccess.claims();
            //
            // Set basic properties
            destination.cla_id = source.cla_id;
            destination.cla_parent_id = source.cla_parent_id;
            destination.cla_created_who = source.cla_created_who;
            destination.cla_created_when = source.cla_created_when;
            destination.cla_updated_who = source.cla_updated_who;
            destination.cla_updated_when = source.cla_updated_when;
            destination.cla_duration = source.cla_duration;
            destination.cla_closed = source.cla_closed;
            destination.cla_status = source.cla_status;
            destination.cla_date_of_loss = source.cla_date_of_loss;
            destination.cla_date_reported = source.cla_date_reported;
            destination.cla_insurer_reference = source.cla_insurer_reference;
            destination.cla_excess = source.cla_excess;
            destination.cla_estimate_of_loss = source.cla_estimate_of_loss;
            destination.cla_paid = source.cla_paid;
            destination.cla_subject_of_loss = source.cla_subject_of_loss;
            destination.cla_result_of_loss = source.cla_result_of_loss;
            destination.cla_cause_of_loss = source.cla_cause_of_loss;
            destination.cla_nature_of_loss = source.cla_nature_of_loss;
            destination.cla_insurer_notes = source.cla_insurer_notes;
            destination.cla_review_date = source.cla_review_date;
            destination.cla_review_action = source.cla_review_action;
            destination.cla_pol_id = source.cla_pol_id;
            destination.cla_subject = source.cla_subject;
            destination.cla_result = source.cla_result;
            destination.cla_cause = source.cla_cause;
            destination.cla_brief_description = source.cla_brief_description;
            destination.cla_close_date = source.cla_close_date;
            destination.cla_reopen_date = source.cla_reopen_date;
            destination.cla_sit_reg = source.cla_sit_reg;
            destination.cla_insurer_contact = source.cla_insurer_contact;
            destination.cla_insurer_phone = source.cla_insurer_phone;
            destination.cla_insurer_email = source.cla_insurer_email;
            destination.cla_assessor_contact = source.cla_assessor_contact;
            destination.cla_assessor_phone = source.cla_assessor_phone;
            destination.cla_assessor_email = source.cla_assessor_email;
            destination.cla_insurer_advised = source.cla_insurer_advised;
            destination.cla_insurer_advised_date = source.cla_insurer_advised_date;
            destination.cla_assessor_appro = source.cla_assessor_appro;
            destination.cla_assessor_appro_date = source.cla_assessor_appro_date;
            destination.cla_assessor_adv = source.cla_assessor_adv;
            destination.cla_assessor_req = source.cla_assessor_req;
            destination.cla_reopen_by = source.cla_reopen_by;
            destination.cla_closed_by = source.cla_closed_by;
            destination.cla_location_desc = source.cla_location_desc;
            destination.cla_renter = source.cla_renter;
            destination.cla_location = source.cla_location;
            destination.cla_location_state = source.cla_location_state;
            destination.cla_location_postcode = source.cla_location_postcode;
            destination.cla_driver = source.cla_driver;
            destination.cla_driver_age = source.cla_driver_age;
            destination.cla_licence_no = source.cla_licence_no;
            destination.cla_vehicle_desc1 = source.cla_vehicle_desc1;
            destination.cla_vehicle_desc2 = source.cla_vehicle_desc2;
            destination.cla_tp_driver = source.cla_tp_driver;
            destination.cla_tp_rego_no = source.cla_tp_rego_no;
            destination.cla_tp_driver_age = source.cla_tp_driver_age;
            destination.cla_tp_licence_no = source.cla_tp_licence_no;
            destination.cla_tp_reg_owner = source.cla_tp_reg_owner;
            destination.cla_tp_make = source.cla_tp_make;
            destination.cla_tp_model = source.cla_tp_model;
            destination.cla_tp_address_1 = source.cla_tp_address_1;
            destination.cla_tp_address_2 = source.cla_tp_address_2;
            destination.cla_tp_address_3 = source.cla_tp_address_3;
            destination.cla_tp_address_state = source.cla_tp_address_state;
            destination.cla_tp_address_postcode = source.cla_tp_address_postcode;
            destination.cla_tp_insurer_clm_no = source.cla_tp_insurer_clm_no;
            destination.cla_tp_phone_no = source.cla_tp_phone_no;
            destination.cla_tp_insurer_phone_no = source.cla_tp_insurer_phone_no;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for ICloseWorkbookHeader table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.ICloseWorkbookHeader CustomMapper_ICloseWorkbookHeader(EclipseDataAccess.ICloseWorkbookHeader source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.ICloseWorkbookHeader destination = new BOALedgerDataAccess.ICloseWorkbookHeader();
            //
            // Set basic properties
            destination.WorkbookHeaderId = source.WorkbookHeaderId;
            destination.wor_id = source.wor_id;
            destination.Insurer = source.Insurer;
            destination.UKI = source.UKI;
            destination.Bound = source.Bound;
            destination.Lapsed = source.Lapsed;
            destination.Closed = source.Closed;
            destination.ParticularsDownloaded = source.ParticularsDownloaded;
            destination.QuoteStatus = source.QuoteStatus;
            destination.QuoteNumberId = source.QuoteNumberId;
            destination.ContractStatus = source.ContractStatus;
            destination.UQI = source.UQI;
            destination.BindStatus = source.BindStatus;
            destination.PreviousUKI = source.PreviousUKI;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for Insurers_Category1 table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.Insurers_Category1 CustomMapper_Insurers_Category1(EclipseDataAccess.Insurers_Category1 source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.Insurers_Category1 destination = new BOALedgerDataAccess.Insurers_Category1();
            //
            // Set basic properties
            destination.incat1_id = source.incat1_id;
            destination.incat1_created_who = source.incat1_created_who;
            destination.incat1_created_when = source.incat1_created_when;
            destination.incat1_updated_who = source.incat1_updated_who;
            destination.incat1_updated_when = source.incat1_updated_when;
            destination.incat1_name = source.incat1_name;
            destination.incat1_desc = source.incat1_desc;
            destination.incat1_inactive = source.incat1_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for menu_permissions table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.menu_permissions CustomMapper_menu_permissions(EclipseDataAccess.menu_permissions source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.menu_permissions destination = new BOALedgerDataAccess.menu_permissions();
            //
            // Set basic properties
            destination.nMenuPerId = source.nMenuPerId;
            destination.strUsername = source.strUsername;
            destination.strMenuText = source.strMenuText;
            destination.strMenuTag = source.strMenuTag;
            destination.nCheckedState = source.nCheckedState;
            destination.MenuItemId = source.MenuItemId;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for write_off table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.write_off CustomMapper_write_off(EclipseDataAccess.write_off source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.write_off destination = new BOALedgerDataAccess.write_off();
            //
            // Set basic properties
            destination.wo_id = source.wo_id;
            destination.wo_inv_tran_id = source.wo_inv_tran_id;
            destination.wo_debtor_creditor = source.wo_debtor_creditor;
            destination.wo_entity_id = source.wo_entity_id;
            destination.wo_amount = source.wo_amount;
            destination.wo_gst = source.wo_gst;
            destination.wo_tran_id = source.wo_tran_id;
            destination.wo_Created_who = source.wo_Created_who;
            destination.wo_Created_when = source.wo_Created_when;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for Policy_Notes table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.Policy_Notes CustomMapper_Policy_Notes(EclipseDataAccess.Policy_Notes source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.Policy_Notes destination = new BOALedgerDataAccess.Policy_Notes();
            //
            // Set basic properties
            destination.jou_not_id = source.jou_not_id;
            destination.jou_not_parent_id = source.jou_not_parent_id;
            destination.jou_not_created_who = source.jou_not_created_who;
            destination.jou_not_created_when = source.jou_not_created_when;
            destination.jou_not_updated_who = source.jou_not_updated_who;
            destination.jou_not_updated_when = source.jou_not_updated_when;
            destination.jou_not_note = source.jou_not_note;
            destination.jou_not_Contact = source.jou_not_Contact;
            destination.jou_not_Subject = source.jou_not_Subject;
            destination.jou_not_phone = source.jou_not_phone;
            destination.jou_not_mobile = source.jou_not_mobile;
            destination.jou_not_email = source.jou_not_email;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for gl_journal_items table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.gl_journal_items CustomMapper_gl_journal_items(EclipseDataAccess.gl_journal_items source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.gl_journal_items destination = new BOALedgerDataAccess.gl_journal_items();
            //
            // Set basic properties
            destination.glji_id = source.glji_id;
            destination.glji_glj_id = source.glji_glj_id;
            destination.glji_glsl_id = source.glji_glsl_id;
            destination.glji_amount = source.glji_amount;
            destination.glji_notes = source.glji_notes;
            destination.glji_created_who = source.glji_created_who;
            destination.glji_created_when = source.glji_created_when;
            destination.glji_updated_who = source.glji_updated_who;
            destination.glji_updated_when = source.glji_updated_when;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for transaction_set_items table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.transaction_set_items CustomMapper_transaction_set_items(EclipseDataAccess.transaction_set_items source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.transaction_set_items destination = new BOALedgerDataAccess.transaction_set_items();
            //
            // Set basic properties
            destination.trasetit_id = source.trasetit_id;
            destination.trasetit_created_who = source.trasetit_created_who;
            destination.trasetit_created_when = source.trasetit_created_when;
            destination.trasetit_updated_who = source.trasetit_updated_who;
            destination.trasetit_updated_when = source.trasetit_updated_when;
            destination.trasetit_parent_id = source.trasetit_parent_id;
            destination.trasetit_name = source.trasetit_name;
            destination.trasetit_desc = source.trasetit_desc;
            destination.trasetit_inactive = source.trasetit_inactive;
            destination.trasetit_account_type = source.trasetit_account_type;
            destination.trasetit_control_account = source.trasetit_control_account;
            destination.trasetit_debit = source.trasetit_debit;
            destination.trasetit_source_table = source.trasetit_source_table;
            destination.trasetit_source_column = source.trasetit_source_column;
            destination.trasetit_ledger = source.trasetit_ledger;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for gl_accounts table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.gl_accounts CustomMapper_gl_accounts(EclipseDataAccess.gl_accounts source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.gl_accounts destination = new BOALedgerDataAccess.gl_accounts();
            //
            // Set basic properties
            destination.glac_num = source.glac_num;
            destination.glac_name = source.glac_name;
            destination.glac_type = source.glac_type;
            destination.glac_active = source.glac_active;
            destination.glac_created_who = source.glac_created_who;
            destination.glac_created_when = source.glac_created_when;
            destination.glac_updated_who = source.glac_updated_who;
            destination.glac_updated_when = source.glac_updated_when;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for sunrise_instalment table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.sunrise_instalment CustomMapper_sunrise_instalment(EclipseDataAccess.sunrise_instalment source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.sunrise_instalment destination = new BOALedgerDataAccess.sunrise_instalment();
            //
            // Set basic properties
            destination.suninstal_id = source.suninstal_id;
            destination.suninstal_wor_id = source.suninstal_wor_id;
            destination.suninstal_previous_wor_id = source.suninstal_previous_wor_id;
            destination.suninstal_frequency = source.suninstal_frequency;
            destination.suninstal_indicator_only = source.suninstal_indicator_only;
            destination.suninstal_no_of_instalments = source.suninstal_no_of_instalments;
            destination.suninstal_comm_payment_method = source.suninstal_comm_payment_method;
            destination.suninstal_cease_instalments = source.suninstal_cease_instalments;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for gl_rules table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.gl_rules CustomMapper_gl_rules(EclipseDataAccess.gl_rules source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.gl_rules destination = new BOALedgerDataAccess.gl_rules();
            //
            // Set basic properties
            destination.glr_id = source.glr_id;
            destination.glr_glrs_set = source.glr_glrs_set;
            destination.glr_glac_num = source.glr_glac_num;
            destination.glr_gle_name = source.glr_gle_name;
            destination.glr_dr_cr = source.glr_dr_cr;
            destination.glr_glamt_code = source.glr_glamt_code;
            destination.glr_created_who = source.glr_created_who;
            destination.glr_created_when = source.glr_created_when;
            destination.glr_updated_who = source.glr_updated_who;
            destination.glr_updated_when = source.glr_updated_when;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for gl_rule_sets table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.gl_rule_sets CustomMapper_gl_rule_sets(EclipseDataAccess.gl_rule_sets source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.gl_rule_sets destination = new BOALedgerDataAccess.gl_rule_sets();
            //
            // Set basic properties
            destination.glrs_set = source.glrs_set;
            destination.glrs_name = source.glrs_name;
            destination.glrs_created_who = source.glrs_created_who;
            destination.glrs_created_when = source.glrs_created_when;
            destination.glrs_updated_who = source.glrs_updated_who;
            destination.glrs_updated_when = source.glrs_updated_when;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for sunrise_workbooks table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.sunrise_workbooks CustomMapper_sunrise_workbooks(EclipseDataAccess.sunrise_workbooks source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.sunrise_workbooks destination = new BOALedgerDataAccess.sunrise_workbooks();
            //
            // Set basic properties
            destination.sunwor_id = source.sunwor_id;
            destination.sunwor_parent_id = source.sunwor_parent_id;
            destination.sunwor_lastsavedon = source.sunwor_lastsavedon;
            destination.sunwor_contractstage = source.sunwor_contractstage;
            destination.sunwor_contractstatus = source.sunwor_contractstatus;
            destination.sunwor_processstatus = source.sunwor_processstatus;
            destination.sunwor_closetype = source.sunwor_closetype;
            destination.sunwor_supplierid = source.sunwor_supplierid;
            destination.sunwor_productid = source.sunwor_productid;
            destination.sunwor_reference_no = source.sunwor_reference_no;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for gl_journal table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.gl_journal CustomMapper_gl_journal(EclipseDataAccess.gl_journal source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.gl_journal destination = new BOALedgerDataAccess.gl_journal();
            //
            // Set basic properties
            destination.glj_id = source.glj_id;
            destination.glj_date = source.glj_date;
            destination.glj_created_who = source.glj_created_who;
            destination.glj_created_when = source.glj_created_when;
            destination.glj_updated_who = source.glj_updated_who;
            destination.glj_updated_when = source.glj_updated_when;
            destination.glj_csh_id = source.glj_csh_id;
            destination.GLJ_TRAN_ID = source.GLJ_TRAN_ID;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for AnzsicCodes table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.AnzsicCodes CustomMapper_AnzsicCodes(EclipseDataAccess.AnzsicCodes source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.AnzsicCodes destination = new BOALedgerDataAccess.AnzsicCodes();
            //
            // Set basic properties
            destination.anz_id = source.anz_id;
            destination.anz_code = source.anz_code;
            destination.anz_name = source.anz_name;
            destination.anz_created_who = source.anz_created_who != null ? source.anz_created_who.ToString() : null;
            if (source.anz_created_when == null)
            {
                destination.anz_created_when = DateTime.Now;
            }
            else
            {
                destination.anz_created_when = source.anz_created_when.Value;
            }
            
            destination.anz_updated_who = source.anz_updated_who;
            destination.anz_updated_when = source.anz_updated_when;
            destination.anz_desc = source.anz_desc;
            destination.anz_inactive = source.anz_inactive;
            destination.Anz_Farm = source.Anz_Farm;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for Insurers_Category3 table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.Insurers_Category3 CustomMapper_Insurers_Category3(EclipseDataAccess.Insurers_Category3 source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.Insurers_Category3 destination = new BOALedgerDataAccess.Insurers_Category3();
            //
            // Set basic properties
            destination.incat3_id = source.incat3_id;
            destination.incat3_created_who = source.incat3_created_who;
            destination.incat3_created_when = source.incat3_created_when;
            destination.incat3_updated_who = source.incat3_updated_who;
            destination.incat3_updated_when = source.incat3_updated_when;
            destination.incat3_name = source.incat3_name;
            destination.incat3_desc = source.incat3_desc;
            destination.incat3_inactive = source.incat3_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for claim_subjects table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.claim_subjects CustomMapper_claim_subjects(EclipseDataAccess.claim_subjects source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.claim_subjects destination = new BOALedgerDataAccess.claim_subjects();
            //
            // Set basic properties
            destination.clasub_id = source.clasub_id;
            destination.clasub_created_who = source.clasub_created_who;
            destination.clasub_created_when = source.clasub_created_when;
            destination.clasub_updated_who = source.clasub_updated_who;
            destination.clasub_updated_when = source.clasub_updated_when;
            destination.clasub_name = source.clasub_name;
            destination.clasub_desc = source.clasub_desc;
            destination.clasub_inactive = source.clasub_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for task_status_types table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.task_status_types CustomMapper_task_status_types(EclipseDataAccess.task_status_types source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.task_status_types destination = new BOALedgerDataAccess.task_status_types();
            //
            // Set basic properties
            destination.tasstaty_id = source.tasstaty_id;
            destination.tasstaty_created_who = source.tasstaty_created_who;
            destination.tasstaty_created_when = source.tasstaty_created_when;
            destination.tasstaty_updated_who = source.tasstaty_updated_who;
            destination.tasstaty_updated_when = source.tasstaty_updated_when;
            destination.tasstaty_name = source.tasstaty_name;
            destination.tasstaty_desc = source.tasstaty_desc;
            destination.tasstaty_inactive = source.tasstaty_inactive;
            destination.tasstaty_closed = source.tasstaty_closed;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for transactions table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.transactions CustomMapper_transactions(EclipseDataAccess.transactions source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.transactions destination = new BOALedgerDataAccess.transactions();
            //
            // Set basic properties
            destination.tran_id = source.tran_id;
            destination.tran_time = source.tran_time;
            destination.tran_type = source.tran_type;
            destination.tran_particulars = source.tran_particulars;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for ageing_units table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.ageing_units CustomMapper_ageing_units(EclipseDataAccess.ageing_units source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.ageing_units destination = new BOALedgerDataAccess.ageing_units();
            //
            // Set basic properties
            destination.ageuni_id = source.ageuni_id;
            destination.ageuni_created_who = source.ageuni_created_who;
            destination.ageuni_created_when = source.ageuni_created_when;
            destination.ageuni_updated_who = source.ageuni_updated_who;
            destination.ageuni_updated_when = source.ageuni_updated_when;
            destination.ageuni_name = source.ageuni_name;
            destination.ageuni_desc = source.ageuni_desc;
            destination.ageuni_inactive = source.ageuni_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for Workbook_Notes table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.Workbook_Notes CustomMapper_Workbook_Notes(EclipseDataAccess.Workbook_Notes source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.Workbook_Notes destination = new BOALedgerDataAccess.Workbook_Notes();
            //
            // Set basic properties
            destination.wor_not_id = source.wor_not_id;
            destination.wor_not_wor_id = source.wor_not_wor_id;
            destination.wor_not_created_who = source.wor_not_created_who;
            destination.wor_not_created_when = source.wor_not_created_when;
            destination.wor_not_updated_who = source.wor_not_updated_who;
            destination.wor_not_updated_when = source.wor_not_updated_when;
            destination.wor_not_note = source.wor_not_note;
            destination.wor_not_contact = source.wor_not_contact;
            destination.wor_not_subject = source.wor_not_subject;
            destination.wor_not_phone = source.wor_not_phone;
            destination.wor_not_mobile = source.wor_not_mobile;
            destination.wor_not_email = source.wor_not_email;
            destination.wor_not_parent_id = source.wor_not_parent_id;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for claim_task_status_types table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.claim_task_status_types CustomMapper_claim_task_status_types(EclipseDataAccess.claim_task_status_types source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.claim_task_status_types destination = new BOALedgerDataAccess.claim_task_status_types();
            //
            // Set basic properties
            destination.clatst_id = source.clatst_id;
            destination.clatst_created_who = source.clatst_created_who;
            destination.clatst_created_when = source.clatst_created_when;
            destination.clatst_updated_who = source.clatst_updated_who;
            destination.clatst_updated_when = source.clatst_updated_when;
            destination.clatst_name = source.clatst_name;
            destination.clatst_desc = source.clatst_desc;
            destination.clatst_inactive = source.clatst_inactive;
            destination.clatst_closed = source.clatst_closed;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for Workbook_SOA table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.Workbook_SOA CustomMapper_Workbook_SOA(EclipseDataAccess.Workbook_SOA source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.Workbook_SOA destination = new BOALedgerDataAccess.Workbook_SOA();
            //
            // Set basic properties
            destination.ws_id = source.ws_id;
            destination.ws_parent_id = source.ws_parent_id;
            destination.ws_created_who = source.ws_created_who;
            destination.ws_created_when = source.ws_created_when;
            destination.ws_updated_who = source.ws_updated_who;
            destination.ws_updated_when = source.ws_updated_when;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for fund_policies2 table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.fund_policies2 CustomMapper_fund_policies2(EclipseDataAccess.fund_policies2 source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.fund_policies2 destination = new BOALedgerDataAccess.fund_policies2();
            //
            // Set basic properties
            destination.funpol_pol_id = source.funpol_pol_id;
            destination.funpol_funder_id = source.funpol_funder_id;
            destination.funpol_date_submitted = source.funpol_date_submitted;
            destination.funpol_status_id = source.funpol_status_id;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for transaction_sets table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.transaction_sets CustomMapper_transaction_sets(EclipseDataAccess.transaction_sets source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.transaction_sets destination = new BOALedgerDataAccess.transaction_sets();
            //
            // Set basic properties
            destination.traset_id = source.traset_id;
            destination.traset_created_who = source.traset_created_who;
            destination.traset_created_when = source.traset_created_when;
            destination.traset_updated_who = source.traset_updated_who;
            destination.traset_updated_when = source.traset_updated_when;
            destination.traset_name = source.traset_name;
            destination.traset_desc = source.traset_desc;
            destination.traset_inactive = source.traset_inactive;
            destination.traset_type = source.traset_type;
            destination.traset_currency = source.traset_currency;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for transaction_items table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.transaction_items CustomMapper_transaction_items(EclipseDataAccess.transaction_items source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.transaction_items destination = new BOALedgerDataAccess.transaction_items();
            //
            // Set basic properties
            destination.tritm_tran_id = source.tritm_tran_id;
            destination.tritm_entity_id = source.tritm_entity_id;
            destination.tritm_led_id = source.tritm_led_id;
            destination.tritm_inc_id = source.tritm_inc_id;
            destination.tritm_csh_id = source.tritm_csh_id;
            destination.tritm_amount = source.tritm_amount;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for class_of_business_classification table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.class_of_business_classification CustomMapper_class_of_business_classification(EclipseDataAccess.class_of_business_classification source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.class_of_business_classification destination = new BOALedgerDataAccess.class_of_business_classification();
            //
            // Set basic properties
            destination.cob_cl_id = source.cob_cl_id;
            destination.cob_cl_name = source.cob_cl_name;
            destination.cob_cl_description = source.cob_cl_description;
            destination.cob_cl_inactive = source.cob_cl_inactive;
            destination.cob_cl_created_who = "DataConversion";
            destination.cob_cl_created_when = DateTime.Now;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for reversed_payments table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.reversed_payments CustomMapper_reversed_payments(EclipseDataAccess.reversed_payments source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.reversed_payments destination = new BOALedgerDataAccess.reversed_payments();
            //
            // Set basic properties
            destination.pol_tran_id = source.pol_tran_id;
            destination.pay_entity_id = source.pay_entity_id;
            destination.paid_amount = source.paid_amount;
            destination.ledger = source.ledger;
            destination.pay_tran_id = source.pay_tran_id;
            destination.reversal_time = source.reversal_time;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for cash_receipt_reversal table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.cash_receipt_reversal CustomMapper_cash_receipt_reversal(EclipseDataAccess.cash_receipt_reversal source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.cash_receipt_reversal destination = new BOALedgerDataAccess.cash_receipt_reversal();
            //
            // Set basic properties
            destination.crr_id = source.crr_id;
            destination.crr_rcpt_id = source.crr_rcpt_id;
            destination.crr_amount = source.crr_amount;
            destination.crr_tran_id = source.crr_tran_id;
            destination.crr_Created_who = source.crr_Created_who;
            destination.crr_Created_when = source.crr_Created_when;
            destination.crr_reason = source.crr_reason;
            destination.crr_Banking_id = source.crr_Banking_id;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for report_parameters table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.report_parameters CustomMapper_report_parameters(EclipseDataAccess.report_parameters source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.report_parameters destination = new BOALedgerDataAccess.report_parameters();
            //
            // Set basic properties
            destination.reppar_id = source.reppar_id;
            destination.reppar_created_who = source.reppar_created_who;
            destination.reppar_created_when = source.reppar_created_when;
            destination.reppar_updated_who = source.reppar_updated_who;
            destination.reppar_updated_when = source.reppar_updated_when;
            destination.reppar_name = source.reppar_name;
            destination.reppar_desc = source.reppar_desc;
            destination.reppar_inactive = source.reppar_inactive;
            destination.reppar_section = source.reppar_section;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for claim_status_types table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.claim_status_types CustomMapper_claim_status_types(EclipseDataAccess.claim_status_types source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.claim_status_types destination = new BOALedgerDataAccess.claim_status_types();
            //
            // Set basic properties
            destination.clastaty_id = source.clastaty_id;
            destination.clastaty_created_who = source.clastaty_created_who;
            destination.clastaty_created_when = source.clastaty_created_when;
            destination.clastaty_updated_who = source.clastaty_updated_who;
            destination.clastaty_updated_when = source.clastaty_updated_when;
            destination.clastaty_name = source.clastaty_name;
            destination.clastaty_desc = source.clastaty_desc;
            destination.clastaty_inactive = source.clastaty_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for atura_audit table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.atura_audit CustomMapper_atura_audit(EclipseDataAccess.atura_audit source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.atura_audit destination = new BOALedgerDataAccess.atura_audit();
            //
            // Set basic properties
            destination.aud_id = source.aud_id;
            destination.aud_op_id = source.aud_op_id;
            destination.aud_syslogin = source.aud_syslogin;
            destination.aud_date_time = source.aud_date_time;
            destination.aud_tbl_id = source.aud_tbl_id;
            destination.aud_rec_id = source.aud_rec_id;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for ClaimPaymentDetails table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.ClaimPaymentDetails CustomMapper_ClaimPaymentDetails(EclipseDataAccess.ClaimPaymentDetails source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.ClaimPaymentDetails destination = new BOALedgerDataAccess.ClaimPaymentDetails();
            //
            // Set basic properties
            destination.cladet_id = source.cladet_id;
            destination.cladet_created_who = source.cladet_created_who;
            destination.cladet_created_when = source.cladet_created_when;
            destination.cladet_updated_who = source.cladet_updated_who;
            destination.cladet_updated_when = source.cladet_updated_when;
            destination.cladet_name = source.cladet_name;
            destination.cladet_desc = source.cladet_desc;
            destination.cladet_inactive = source.cladet_inactive;
            destination.cladet_claimtype = source.cladet_claimtype;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for contact_methods table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.contact_methods CustomMapper_contact_methods(EclipseDataAccess.contact_methods source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.contact_methods destination = new BOALedgerDataAccess.contact_methods();
            //
            // Set basic properties
            destination.conmet_id = source.conmet_id;
            destination.conmet_created_who = source.conmet_created_who;
            destination.conmet_created_when = source.conmet_created_when;
            destination.conmet_updated_who = source.conmet_updated_who;
            destination.conmet_updated_when = source.conmet_updated_when;
            destination.conmet_name = source.conmet_name;
            destination.conmet_desc = source.conmet_desc;
            destination.conmet_inactive = source.conmet_inactive;
            destination.conmet_default = source.conmet_default;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for claim_task_types table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.claim_task_types CustomMapper_claim_task_types(EclipseDataAccess.claim_task_types source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.claim_task_types destination = new BOALedgerDataAccess.claim_task_types();
            //
            // Set basic properties
            destination.clatasty_id = source.clatasty_id;
            destination.clatasty_created_who = source.clatasty_created_who;
            destination.clatasty_created_when = source.clatasty_created_when;
            destination.clatasty_updated_who = source.clatasty_updated_who;
            destination.clatasty_updated_when = source.clatasty_updated_when;
            destination.clatasty_name = source.clatasty_name;
            destination.clatasty_desc = source.clatasty_desc;
            destination.clatasty_inactive = source.clatasty_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for PolicyHeader_Category3 table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.PolicyHeader_Category3 CustomMapper_PolicyHeader_Category3(EclipseDataAccess.PolicyHeader_Category3 source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.PolicyHeader_Category3 destination = new BOALedgerDataAccess.PolicyHeader_Category3();
            //
            // Set basic properties
            destination.phcat3_id = source.phcat3_id;
            destination.phcat3_created_who = source.phcat3_created_who;
            destination.phcat3_created_when = source.phcat3_created_when;
            destination.phcat3_updated_who = source.phcat3_updated_who;
            destination.phcat3_updated_when = source.phcat3_updated_when;
            destination.phcat3_name = source.phcat3_name;
            destination.phcat3_desc = source.phcat3_desc;
            destination.phcat3_inactive = source.phcat3_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for AdvAutoPolNoGenerationItems table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.AdvAutoPolNoGenerationItems CustomMapper_AdvAutoPolNoGenerationItems(EclipseDataAccess.AdvAutoPolNoGenerationItems source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.AdvAutoPolNoGenerationItems destination = new BOALedgerDataAccess.AdvAutoPolNoGenerationItems();
            //
            // Set basic properties
            destination.advautopolno_id = source.advautopolno_id;
            destination.advautopolno_prefix = source.advautopolno_prefix;
            destination.advautopolno_suffix = source.advautopolno_suffix;
            destination.advautopolno_branch = source.advautopolno_branch;
            destination.advautopolno_brokerRep = source.advautopolno_brokerRep;
            destination.advautopolno_cob = source.advautopolno_cob;
            destination.advautopolno_insurer = source.advautopolno_insurer;
            destination.advautopolno_salesTeam = source.advautopolno_salesTeam;
            destination.advautopolno_serviceTeam = source.advautopolno_serviceTeam;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for documentmapping table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.documentmapping CustomMapper_documentmapping(EclipseDataAccess.documentmapping source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.documentmapping destination = new BOALedgerDataAccess.documentmapping();
            //
            // Set basic properties
            destination.doc_id = source.doc_id;
            destination.doc_created_who = source.doc_created_who;
            destination.doc_created_when = source.doc_created_when;
            destination.doc_updated_who = source.doc_updated_who;
            destination.doc_updated_when = source.doc_updated_when;
            destination.doc_name = source.doc_name;
            destination.doc_desc = source.doc_desc;
            destination.doc_inactive = source.doc_inactive;
            destination.doc_classofbusiness = source.doc_classofbusiness;
            destination.doc_bodydocumentid = source.doc_bodydocumentid;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for claim_results table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.claim_results CustomMapper_claim_results(EclipseDataAccess.claim_results source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.claim_results destination = new BOALedgerDataAccess.claim_results();
            //
            // Set basic properties
            destination.clares_id = source.clares_id;
            destination.clares_created_who = source.clares_created_who;
            destination.clares_created_when = source.clares_created_when;
            destination.clares_updated_who = source.clares_updated_who;
            destination.clares_updated_when = source.clares_updated_when;
            destination.clares_name = source.clares_name;
            destination.clares_desc = source.clares_desc;
            destination.clares_inactive = source.clares_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for refunds table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.refunds CustomMapper_refunds(EclipseDataAccess.refunds source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.refunds destination = new BOALedgerDataAccess.refunds();
            //
            // Set basic properties
            destination.ref_id = source.ref_id;
            destination.ref_type = source.ref_type;
            destination.ref_record_ref_id = source.ref_record_ref_id;
            destination.ref_pay_id = source.ref_pay_id;
            if (source.ref_created_who == null)
            {
                destination.ref_created_who = "DataConversion";
            }
            else
            {
                destination.ref_created_who = source.ref_created_who;
            }
            if (source.ref_created_when.HasValue == false)
            {
                destination.ref_created_when = DateTime.Now;
            }
            else
            {
                destination.ref_created_when = source.ref_created_when.Value;
            }
            destination.ref_updated_who = source.ref_updated_who;
            destination.ref_updated_when = source.ref_updated_when;
            destination.ref_Amount = source.ref_Amount;
            destination.ref_tran_id = source.ref_tran_id;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for AutoRoundingValues table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.AutoRoundingValues CustomMapper_AutoRoundingValues(EclipseDataAccess.AutoRoundingValues source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.AutoRoundingValues destination = new BOALedgerDataAccess.AutoRoundingValues();
            //
            // Set basic properties
            destination.arv_id = source.arv_id;
            destination.arv_value = source.arv_value;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for pay_direct table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.pay_direct CustomMapper_pay_direct(EclipseDataAccess.pay_direct source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.pay_direct destination = new BOALedgerDataAccess.pay_direct();
            //
            // Set basic properties
            destination.pd_id = source.pd_id;
            destination.pd_inv_trans_id = source.pd_inv_trans_id;
            destination.pd_insurer_id = source.pd_insurer_id;
            destination.pd_client_id = source.pd_client_id;
            destination.pd_amount = source.pd_amount;
            destination.pd_trans_id = source.pd_trans_id;
            destination.pd_created_who = source.pd_created_who;
            destination.pd_created_when = source.pd_created_when;
            destination.pd_updated_who = source.pd_updated_who;
            destination.pd_updated_when = source.pd_updated_when;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for claim_tasks table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.claim_tasks CustomMapper_claim_tasks(EclipseDataAccess.claim_tasks source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.claim_tasks destination = new BOALedgerDataAccess.claim_tasks();
            //
            // Set basic properties
            destination.clatas_id = source.clatas_id;
            destination.clatas_parent_id = source.clatas_parent_id;
            destination.clatas_created_who = source.clatas_created_who;
            destination.clatas_created_when = source.clatas_created_when;
            destination.clatas_updated_who = source.clatas_updated_who;
            destination.clatas_updated_when = source.clatas_updated_when;
            destination.clatas_duration = source.clatas_duration;
            destination.clatas_closed = source.clatas_closed;
            destination.clatas_initiated_by = source.clatas_initiated_by;
            destination.clatas_contact_person = source.clatas_contact_person;
            destination.clatas_contact_method = source.clatas_contact_method;
            destination.clatas_brief_description = source.clatas_brief_description;
            destination.clatas_priority = source.clatas_priority;
            destination.clatas_followup_date = source.clatas_followup_date;
            destination.clatas_followup_action = source.clatas_followup_action;
            destination.clatas_status = source.clatas_status;
            destination.clatas_notes = source.clatas_notes;
            destination.clatas_document_type = source.clatas_document_type;
            destination.clatas_type = source.clatas_type;
            destination.clatas_date = source.clatas_date;
            destination.clatas_queue = source.clatas_queue;
            destination.clatas_re_open_Date = source.clatas_re_open_Date;
            destination.clatas_re_open_User = source.clatas_re_open_User;
            destination.clatas_original_que_person = source.clatas_original_que_person;
            destination.clatas_contact_phone = source.clatas_contact_phone;
            destination.clatas_contact_mobile = source.clatas_contact_mobile;
            destination.clatas_contact_email = source.clatas_contact_email;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for BrokerReps_Category3 table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.BrokerReps_Category3 CustomMapper_BrokerReps_Category3(EclipseDataAccess.BrokerReps_Category3 source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.BrokerReps_Category3 destination = new BOALedgerDataAccess.BrokerReps_Category3();
            //
            // Set basic properties
            destination.brcat3_id = source.brcat3_id;
            destination.brcat3_created_who = source.brcat3_created_who;
            destination.brcat3_created_when = source.brcat3_created_when;
            destination.brcat3_updated_who = source.brcat3_updated_who;
            destination.brcat3_updated_when = source.brcat3_updated_when;
            destination.brcat3_name = source.brcat3_name;
            destination.brcat3_desc = source.brcat3_desc;
            destination.brcat3_inactive = source.brcat3_inactive;

            //
            // Return result
            return destination;
        }
        

        /// <summary>
        /// Custom mapper function for notes table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.notes CustomMapper_notes(EclipseDataAccess.notes source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.notes destination = new BOALedgerDataAccess.notes();
            //
            // Set basic properties
            destination.not_id = source.not_id;
            destination.not_parent_id = source.not_parent_id;
            destination.not_created_who = source.not_created_who;
            destination.not_created_when = source.not_created_when;
            destination.not_updated_who = source.not_updated_who;
            destination.not_updated_when = source.not_updated_when;
            destination.not_duration = source.not_duration;
            destination.not_note = source.not_note;
            destination.not_Contact = source.not_Contact;
            destination.not_Subject = source.not_Subject;
            destination.Fname = source.Fname;
            destination.not_phone = source.not_phone;
            destination.not_mobile = source.not_mobile;
            destination.not_email = source.not_email;
            destination.not_priority = source.not_priority;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for PolicyHeader_Category2 table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.PolicyHeader_Category2 CustomMapper_PolicyHeader_Category2(EclipseDataAccess.PolicyHeader_Category2 source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.PolicyHeader_Category2 destination = new BOALedgerDataAccess.PolicyHeader_Category2();
            //
            // Set basic properties
            destination.phcat2_id = source.phcat2_id;
            destination.phcat2_created_who = source.phcat2_created_who;
            destination.phcat2_created_when = source.phcat2_created_when;
            destination.phcat2_updated_who = source.phcat2_updated_who;
            destination.phcat2_updated_when = source.phcat2_updated_when;
            destination.phcat2_name = source.phcat2_name;
            destination.phcat2_desc = source.phcat2_desc;
            destination.phcat2_inactive = source.phcat2_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for BrokerFeeDefaultsBasis table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.BrokerFeeDefaultsBasis CustomMapper_BrokerFeeDefaultsBasis(EclipseDataAccess.BrokerFeeDefaultsBasis source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.BrokerFeeDefaultsBasis destination = new BOALedgerDataAccess.BrokerFeeDefaultsBasis();
            //
            // Set basic properties
            destination.bfdb_id = source.bfdb_id;
            destination.bfdb_name = source.bfdb_name;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for gen_ins_wor_doc_types table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.gen_ins_wor_doc_types CustomMapper_gen_ins_wor_doc_types(EclipseDataAccess.gen_ins_wor_doc_types source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.gen_ins_wor_doc_types destination = new BOALedgerDataAccess.gen_ins_wor_doc_types();
            //
            // Set basic properties
            destination.giwdtyp_id = source.giwdtyp_id;
            destination.giwdtyp_created_who = source.giwdtyp_created_who;
            destination.giwdtyp_created_when = source.giwdtyp_created_when;
            destination.giwdtyp_updated_who = source.giwdtyp_updated_who;
            destination.giwdtyp_updated_when = source.giwdtyp_updated_when;
            destination.giwdtyp_name = source.giwdtyp_name;
            destination.giwdtyp_desc = source.giwdtyp_desc;
            destination.giwdtyp_inactive = source.giwdtyp_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for coinsurance table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.coinsurance CustomMapper_coinsurance(EclipseDataAccess.coinsurance source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.coinsurance destination = new BOALedgerDataAccess.coinsurance();
            //
            // Set basic properties
            destination.coins_id = source.coins_id;
            destination.coins_parent_id = source.coins_parent_id;
            destination.coins_created_who = source.coins_created_who;
            destination.coins_created_when = source.coins_created_when;
            destination.coins_updated_who = source.coins_updated_who;
            destination.coins_updated_when = source.coins_updated_when;
            destination.coins_duration = source.coins_duration;
            destination.coins_sum_insured = source.coins_sum_insured;
            destination.coins_percent_insured = source.coins_percent_insured;
            destination.coins_base_premium = source.coins_base_premium;
            destination.coins_levies = source.coins_levies;
            destination.coins_duties = source.coins_duties;
            destination.coins_gross_premium = source.coins_gross_premium;
            destination.coins_commission = source.coins_commission;
            destination.coins_net_premium = source.coins_net_premium;
            destination.coins_insurer_id = source.coins_insurer_id;
            destination.coins_insurer_gst = source.coins_insurer_gst;
            destination.coins_comm_gst = source.coins_comm_gst;
            destination.coins_comm_net_gst = source.coins_comm_net_gst;
            destination.coins_uw_fee_net_gst = source.coins_uw_fee_net_gst;
            destination.coins_uw_fee_gst = source.coins_uw_fee_gst;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for CCFeeTransactions table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.CCFeeTransactions CustomMapper_CCFeeTransactions(EclipseDataAccess.CCFeeTransactions source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.CCFeeTransactions destination = new BOALedgerDataAccess.CCFeeTransactions();
            //
            // Set basic properties
            destination.nId = source.nId;
            destination.nCCFeeTranId = source.nCCFeeTranId;
            destination.nPolicyTranId = source.nPolicyTranId;
            destination.nCreditCardTranId = source.nCreditCardTranId;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for class_of_business_category table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.class_of_business_category CustomMapper_class_of_business_category(EclipseDataAccess.class_of_business_category source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.class_of_business_category destination = new BOALedgerDataAccess.class_of_business_category();
            //
            // Set basic properties
            destination.claofbus_id = source.claofbus_id;
            destination.claofbus_created_who = source.claofbus_created_who;
            destination.claofbus_created_when = source.claofbus_created_when;
            destination.claofbus_updated_who = source.claofbus_updated_who;
            destination.claofbus_updated_when = source.claofbus_updated_when;
            destination.claofbus_name = source.claofbus_name;
            destination.claofbus_desc = source.claofbus_desc;
            destination.claofbus_inactive = source.claofbus_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for COBMappings table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.COBMappings CustomMapper_COBMappings(EclipseDataAccess.COBMappings source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.COBMappings destination = new BOALedgerDataAccess.COBMappings();
            //
            // Set basic properties
            destination.nHolMapId = source.nHolMapId;
            destination.strProduct = source.strProduct;
            destination.strCOB = source.strCOB;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for claim_causes table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.claim_causes CustomMapper_claim_causes(EclipseDataAccess.claim_causes source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.claim_causes destination = new BOALedgerDataAccess.claim_causes();
            //
            // Set basic properties
            destination.clacau_id = source.clacau_id;
            destination.clacau_created_who = source.clacau_created_who;
            destination.clacau_created_when = source.clacau_created_when;
            destination.clacau_updated_who = source.clacau_updated_who;
            destination.clacau_updated_when = source.clacau_updated_when;
            destination.clacau_name = source.clacau_name;
            destination.clacau_desc = source.clacau_desc;
            destination.clacau_inactive = source.clacau_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for Insurers_Category2 table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.Insurers_Category2 CustomMapper_Insurers_Category2(EclipseDataAccess.Insurers_Category2 source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.Insurers_Category2 destination = new BOALedgerDataAccess.Insurers_Category2();
            //
            // Set basic properties
            destination.incat2_id = source.incat2_id;
            destination.incat2_created_who = source.incat2_created_who;
            destination.incat2_created_when = source.incat2_created_when;
            destination.incat2_updated_who = source.incat2_updated_who;
            destination.incat2_updated_when = source.incat2_updated_when;
            destination.incat2_name = source.incat2_name;
            destination.incat2_desc = source.incat2_desc;
            destination.incat2_inactive = source.incat2_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for statements_generated_ID table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.statements_generated_ID CustomMapper_statements_generated_ID(EclipseDataAccess.statements_generated_ID source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.statements_generated_ID destination = new BOALedgerDataAccess.statements_generated_ID();
            //
            // Set basic properties
            destination.sttran_id = source.sttran_id;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for transaction_reasons table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.transaction_reasons CustomMapper_transaction_reasons(EclipseDataAccess.transaction_reasons source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.transaction_reasons destination = new BOALedgerDataAccess.transaction_reasons();
            //
            // Set basic properties
            destination.trarea_id = source.trarea_id;
            destination.trarea_created_who = source.trarea_created_who;
            destination.trarea_created_when = source.trarea_created_when;
            destination.trarea_updated_who = source.trarea_updated_who;
            destination.trarea_updated_when = source.trarea_updated_when;
            destination.trarea_parent_id = source.trarea_parent_id;
            destination.trarea_name = source.trarea_name;
            destination.trarea_desc = source.trarea_desc;
            destination.trarea_inactive = source.trarea_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for Client_Notes table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.Client_Notes CustomMapper_Client_Notes(EclipseDataAccess.Client_Notes source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.Client_Notes destination = new BOALedgerDataAccess.Client_Notes();
            //
            // Set basic properties
            destination.ent_name = source.ent_name;
            destination.ent_address_1 = source.ent_address_1;
            destination.ent_address_2 = source.ent_address_2;
            destination.ent_address_3 = source.ent_address_3;
            destination.ent_suburb = source.ent_suburb;
            destination.ent_postcode = source.ent_postcode;
            destination.not_Contact = source.not_Contact;
            destination.not_Subject = source.not_Subject;
            destination.not_created_when = source.not_created_when;
            destination.not_created_who = source.not_created_who;
            destination.not_note = source.not_note;
            destination.not_id = source.not_id;
            destination.Doc = source.Doc;
            destination.State = source.State;
            destination.spid = source.spid;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for PolicyHeader_Category1 table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.PolicyHeader_Category1 CustomMapper_PolicyHeader_Category1(EclipseDataAccess.PolicyHeader_Category1 source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.PolicyHeader_Category1 destination = new BOALedgerDataAccess.PolicyHeader_Category1();
            //
            // Set basic properties
            destination.phcat1_id = source.phcat1_id;
            destination.phcat1_created_who = source.phcat1_created_who;
            destination.phcat1_created_when = source.phcat1_created_when;
            destination.phcat1_updated_who = source.phcat1_updated_who;
            destination.phcat1_updated_when = source.phcat1_updated_when;
            destination.phcat1_name = source.phcat1_name;
            destination.phcat1_desc = source.phcat1_desc;
            destination.phcat1_inactive = source.phcat1_inactive;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for personnel table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.personnel CustomMapper_personnel(EclipseDataAccess.personnel source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.personnel destination = new BOALedgerDataAccess.personnel();
            //
            // Set basic properties
            destination.per_id = source.per_id;
            destination.per_parent_id = source.per_parent_id;
            destination.per_created_who = source.per_created_who;
            destination.per_created_when = source.per_created_when;
            destination.per_updated_who = source.per_updated_who;
            destination.per_updated_when = source.per_updated_when;
            destination.per_duration = source.per_duration;
            destination.per_primary_contact = source.per_primary_contact;
            destination.per_personnel_type = source.per_personnel_type;
            destination.per_addressee = source.per_addressee;
            destination.per_salutation = source.per_salutation;
            destination.per_job_title = source.per_job_title;
            destination.per_telephone = source.per_telephone;
            destination.per_telephone_2 = source.per_telephone_2;
            destination.per_mobile = source.per_mobile;
            destination.per_facsimile = source.per_facsimile;
            destination.per_email = source.per_email;
            destination.per_newsletter = source.per_newsletter;
            destination.per_newsfax = source.per_newsfax;
            destination.per_update_flag = source.per_update_flag;
            destination.per_website = source.per_website;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for DEFTNotes table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.DEFTNotes CustomMapper_DEFTNotes(EclipseDataAccess.DEFTNotes source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.DEFTNotes destination = new BOALedgerDataAccess.DEFTNotes();
            //
            // Set basic properties
            destination.Deft_id = source.Deft_id;
            destination.Amount = source.Amount;
            destination.Notes = source.Notes;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for Entity_Modification table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.Entity_Modification CustomMapper_Entity_Modification(EclipseDataAccess.Entity_Modification source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.Entity_Modification destination = new BOALedgerDataAccess.Entity_Modification();
            //
            // Set basic properties
            destination.Ent_Modified_ID = source.Ent_Modified_ID;
            destination.Ent_ID = source.Ent_ID;
            destination.Field_name = source.Field_name;
            destination.OldValue = source.OldValue;
            destination.NewValue = source.NewValue;
            destination.ChangedDate = source.ChangedDate;
            destination.ent_updated_who = source.ent_updated_who;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for cash_receipts table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.cash_receipts CustomMapper_cash_receipts(EclipseDataAccess.cash_receipts source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.cash_receipts destination = new BOALedgerDataAccess.cash_receipts();
            //
            // Set basic properties
            destination.rcpt_id = source.rcpt_id;
            destination.rcpt_tran_id = source.rcpt_tran_id;
            destination.rcpt_paymeth = source.rcpt_paymeth;
            destination.rcpt_cheque_no = source.rcpt_cheque_no;
            destination.rcpt_name = source.rcpt_name;
            destination.rcpt_bank = source.rcpt_bank;
            destination.rcpt_branch = source.rcpt_branch;
            destination.rcpt_cardno = source.rcpt_cardno;
            destination.rcpt_cardholder = source.rcpt_cardholder;
            destination.rcpt_expiry = source.rcpt_expiry;
            destination.rcpt_auth = source.rcpt_auth;
            destination.rcpt_amexsec = source.rcpt_amexsec;
            destination.rcpt_banking_id = source.rcpt_banking_id;
            destination.rcpt_parent_id = source.rcpt_parent_id;
            destination.rcpt_amount = source.rcpt_amount;
            destination.rcpt_remarks = source.rcpt_remarks;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for general_insurance_workbooks table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.general_insurance_workbooks CustomMapper_general_insurance_workbooks(EclipseDataAccess.general_insurance_workbooks source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.general_insurance_workbooks destination = new BOALedgerDataAccess.general_insurance_workbooks();
            //
            // Set basic properties
            destination.geninswb_id = source.geninswb_id;
            destination.geninswb_created_who = source.geninswb_created_who;
            destination.geninswb_created_when = source.geninswb_created_when;
            destination.geninswb_updated_who = source.geninswb_updated_who;
            destination.geninswb_updated_when = source.geninswb_updated_when;
            destination.geninswb_name = source.geninswb_name;
            destination.geninswb_desc = source.geninswb_desc;
            destination.geninswb_inactive = source.geninswb_inactive;
            destination.geninswb_locking = source.geninswb_locking;
            destination.geninswb_multi_policy = source.geninswb_multi_policy;

            //
            // Return result
            return destination;
        }


        /// <summary>
        /// Custom mapper function for transaction_types table
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected BOALedgerDataAccess.transaction_types CustomMapper_transaction_types(EclipseDataAccess.transaction_types source)
        {
            //
            // Initialize result
            BOALedgerDataAccess.transaction_types destination = new BOALedgerDataAccess.transaction_types();
            //
            // Set basic properties
            destination.tratyp_id = source.tratyp_id;
            destination.tratyp_created_who = source.tratyp_created_who;
            destination.tratyp_created_when = source.tratyp_created_when;
            destination.tratyp_updated_who = source.tratyp_updated_who;
            destination.tratyp_updated_when = source.tratyp_updated_when;
            destination.tratyp_name = source.tratyp_name;
            destination.tratyp_desc = source.tratyp_desc;
            destination.tratyp_inactive = source.tratyp_inactive;

            //
            // Return result
            return destination;
        }


        #endregion
    }
}