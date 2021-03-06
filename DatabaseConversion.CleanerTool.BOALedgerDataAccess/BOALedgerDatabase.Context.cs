﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseConversion.CleanerTool.BOALedgerDataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BOALedgerEntities : DbContext
    {
        public BOALedgerEntities()
            : base("name=BOALedgerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<account_types> account_types { get; set; }
        public virtual DbSet<address_types> address_types { get; set; }
        public virtual DbSet<addresses> addresses { get; set; }
        public virtual DbSet<AdvAutoPolNoGenerationItems> AdvAutoPolNoGenerationItems { get; set; }
        public virtual DbSet<ageing_units> ageing_units { get; set; }
        public virtual DbSet<anzic_classes> anzic_classes { get; set; }
        public virtual DbSet<anzic_divisions> anzic_divisions { get; set; }
        public virtual DbSet<anzic_groups> anzic_groups { get; set; }
        public virtual DbSet<anzic_subdivisions> anzic_subdivisions { get; set; }
        public virtual DbSet<AnzsicCodes> AnzsicCodes { get; set; }
        public virtual DbSet<apra_class_of_business> apra_class_of_business { get; set; }
        public virtual DbSet<areas> areas { get; set; }
        public virtual DbSet<atura_audit> atura_audit { get; set; }
        public virtual DbSet<atura_roles> atura_roles { get; set; }
        public virtual DbSet<atura_super_users> atura_super_users { get; set; }
        public virtual DbSet<atura_tagrangevalue> atura_tagrangevalue { get; set; }
        public virtual DbSet<atura_tagvalue> atura_tagvalue { get; set; }
        public virtual DbSet<AutoRoundingValues> AutoRoundingValues { get; set; }
        public virtual DbSet<BackgroundJobs> BackgroundJobs { get; set; }
        public virtual DbSet<banking> banking { get; set; }
        public virtual DbSet<branch_permissions> branch_permissions { get; set; }
        public virtual DbSet<branches> branches { get; set; }
        public virtual DbSet<BrokerFeeDefaults> BrokerFeeDefaults { get; set; }
        public virtual DbSet<BrokerFeeDefaultsBasis> BrokerFeeDefaultsBasis { get; set; }
        public virtual DbSet<BrokerFeeDefaultWorkbookType> BrokerFeeDefaultWorkbookType { get; set; }
        public virtual DbSet<BrokerReps_Category1> BrokerReps_Category1 { get; set; }
        public virtual DbSet<BrokerReps_Category2> BrokerReps_Category2 { get; set; }
        public virtual DbSet<BrokerReps_Category3> BrokerReps_Category3 { get; set; }
        public virtual DbSet<cancellation_reason> cancellation_reason { get; set; }
        public virtual DbSet<cash_payment_applications> cash_payment_applications { get; set; }
        public virtual DbSet<cash_payments> cash_payments { get; set; }
        public virtual DbSet<cash_receipt_application> cash_receipt_application { get; set; }
        public virtual DbSet<cash_receipt_reversal> cash_receipt_reversal { get; set; }
        public virtual DbSet<cash_receipts> cash_receipts { get; set; }
        public virtual DbSet<categories> categories { get; set; }
        public virtual DbSet<category_types> category_types { get; set; }
        public virtual DbSet<claim_causes> claim_causes { get; set; }
        public virtual DbSet<claim_documents> claim_documents { get; set; }
        public virtual DbSet<Claim_Notes> Claim_Notes { get; set; }
        public virtual DbSet<claim_results> claim_results { get; set; }
        public virtual DbSet<claim_status_types> claim_status_types { get; set; }
        public virtual DbSet<claim_sub_tasks> claim_sub_tasks { get; set; }
        public virtual DbSet<claim_subjects> claim_subjects { get; set; }
        public virtual DbSet<claim_task_status_types> claim_task_status_types { get; set; }
        public virtual DbSet<claim_task_types> claim_task_types { get; set; }
        public virtual DbSet<claim_tasks> claim_tasks { get; set; }
        public virtual DbSet<ClaimPaymentDetails> ClaimPaymentDetails { get; set; }
        public virtual DbSet<ClaimPaymentTypes> ClaimPaymentTypes { get; set; }
        public virtual DbSet<claims> claims { get; set; }
        public virtual DbSet<class_of_business> class_of_business { get; set; }
        public virtual DbSet<class_of_business_category> class_of_business_category { get; set; }
        public virtual DbSet<class_of_business_classification> class_of_business_classification { get; set; }
        public virtual DbSet<ClausePermissions> ClausePermissions { get; set; }
        public virtual DbSet<clauses> clauses { get; set; }
        public virtual DbSet<client_account_types> client_account_types { get; set; }
        public virtual DbSet<client_classifications> client_classifications { get; set; }
        public virtual DbSet<client_insurance_portfolio> client_insurance_portfolio { get; set; }
        public virtual DbSet<Client_Task_Notes> Client_Task_Notes { get; set; }
        public virtual DbSet<ClientDetails_Category1> ClientDetails_Category1 { get; set; }
        public virtual DbSet<ClientDetails_Category2> ClientDetails_Category2 { get; set; }
        public virtual DbSet<ClientDetails_Category3> ClientDetails_Category3 { get; set; }
        public virtual DbSet<ClientDetails_Category4> ClientDetails_Category4 { get; set; }
        public virtual DbSet<ClientDetails_Category5> ClientDetails_Category5 { get; set; }
        public virtual DbSet<coinsurance> coinsurance { get; set; }
        public virtual DbSet<columns> columns { get; set; }
        public virtual DbSet<confirmation_of_cover> confirmation_of_cover { get; set; }
        public virtual DbSet<contact_methods> contact_methods { get; set; }
        public virtual DbSet<currency> currency { get; set; }
        public virtual DbSet<DEFTItems> DEFTItems { get; set; }
        public virtual DbSet<DEFTItemsInError_Custom> DEFTItemsInError_Custom { get; set; }
        public virtual DbSet<DEFTItemsInError_Predefined> DEFTItemsInError_Predefined { get; set; }
        public virtual DbSet<DEFTPredefinedErrors> DEFTPredefinedErrors { get; set; }
        public virtual DbSet<DEFTStatementIds> DEFTStatementIds { get; set; }
        public virtual DbSet<DEFTStatuses> DEFTStatuses { get; set; }
        public virtual DbSet<documentmapping> documentmapping { get; set; }
        public virtual DbSet<DocumentRepository> DocumentRepository { get; set; }
        public virtual DbSet<dofi_types> dofi_types { get; set; }
        public virtual DbSet<EmailTemplates> EmailTemplates { get; set; }
        public virtual DbSet<entities> entities { get; set; }
        public virtual DbSet<entities_a> entities_a { get; set; }
        public virtual DbSet<Entity_Modification> Entity_Modification { get; set; }
        public virtual DbSet<exemption_types> exemption_types { get; set; }
        public virtual DbSet<finance_types> finance_types { get; set; }
        public virtual DbSet<financial_institution> financial_institution { get; set; }
        public virtual DbSet<form_settings> form_settings { get; set; }
        public virtual DbSet<fund_policies2> fund_policies2 { get; set; }
        public virtual DbSet<fund_status> fund_status { get; set; }
        public virtual DbSet<gen_ins_classes_of_business> gen_ins_classes_of_business { get; set; }
        public virtual DbSet<gen_ins_documents> gen_ins_documents { get; set; }
        public virtual DbSet<gen_ins_journal_types> gen_ins_journal_types { get; set; }
        public virtual DbSet<gen_ins_transaction_types> gen_ins_transaction_types { get; set; }
        public virtual DbSet<gen_ins_wor_doc_types> gen_ins_wor_doc_types { get; set; }
        public virtual DbSet<gen_ins_wor_documents> gen_ins_wor_documents { get; set; }
        public virtual DbSet<general_insurance> general_insurance { get; set; }
        public virtual DbSet<general_insurance_workbooks> general_insurance_workbooks { get; set; }
        public virtual DbSet<gl_acc_months> gl_acc_months { get; set; }
        public virtual DbSet<gl_accounts> gl_accounts { get; set; }
        public virtual DbSet<gl_amounts> gl_amounts { get; set; }
        public virtual DbSet<gl_journal> gl_journal { get; set; }
        public virtual DbSet<gl_journal_items> gl_journal_items { get; set; }
        public virtual DbSet<gl_ledgers> gl_ledgers { get; set; }
        public virtual DbSet<gl_movements> gl_movements { get; set; }
        public virtual DbSet<gl_mtd_balances> gl_mtd_balances { get; set; }
        public virtual DbSet<gl_rule_sets> gl_rule_sets { get; set; }
        public virtual DbSet<gl_rules> gl_rules { get; set; }
        public virtual DbSet<gl_sl_entities> gl_sl_entities { get; set; }
        public virtual DbSet<gl_sub_ledgers> gl_sub_ledgers { get; set; }
        public virtual DbSet<gl_transactions> gl_transactions { get; set; }
        public virtual DbSet<iclose_insurers> iclose_insurers { get; set; }
        public virtual DbSet<iclose_products> iclose_products { get; set; }
        public virtual DbSet<ICloseWorkbookHeader> ICloseWorkbookHeader { get; set; }
        public virtual DbSet<industry_types> industry_types { get; set; }
        public virtual DbSet<insurer_profiles> insurer_profiles { get; set; }
        public virtual DbSet<Insurers_Category1> Insurers_Category1 { get; set; }
        public virtual DbSet<Insurers_Category2> Insurers_Category2 { get; set; }
        public virtual DbSet<Insurers_Category3> Insurers_Category3 { get; set; }
        public virtual DbSet<journal_sub_tasks> journal_sub_tasks { get; set; }
        public virtual DbSet<journals> journals { get; set; }
        public virtual DbSet<limited_exemptions> limited_exemptions { get; set; }
        public virtual DbSet<mandatory_fields> mandatory_fields { get; set; }
        public virtual DbSet<menu_permissions> menu_permissions { get; set; }
        public virtual DbSet<MenuItems> MenuItems { get; set; }
        public virtual DbSet<monthly_frequency> monthly_frequency { get; set; }
        public virtual DbSet<notes> notes { get; set; }
        public virtual DbSet<occupation_types> occupation_types { get; set; }
        public virtual DbSet<organisation_structures> organisation_structures { get; set; }
        public virtual DbSet<pay_direct> pay_direct { get; set; }
        public virtual DbSet<payment_batch> payment_batch { get; set; }
        public virtual DbSet<personnel> personnel { get; set; }
        public virtual DbSet<personnel_types> personnel_types { get; set; }
        public virtual DbSet<policies> policies { get; set; }
        public virtual DbSet<Policy_Notes> Policy_Notes { get; set; }
        public virtual DbSet<policy_task_status_types> policy_task_status_types { get; set; }
        public virtual DbSet<policy_transaction_documents> policy_transaction_documents { get; set; }
        public virtual DbSet<PolicyHeader_Category1> PolicyHeader_Category1 { get; set; }
        public virtual DbSet<PolicyHeader_Category2> PolicyHeader_Category2 { get; set; }
        public virtual DbSet<PolicyHeader_Category3> PolicyHeader_Category3 { get; set; }
        public virtual DbSet<premium_funding> premium_funding { get; set; }
        public virtual DbSet<priorities> priorities { get; set; }
        public virtual DbSet<ProductLicenses> ProductLicenses { get; set; }
        public virtual DbSet<profile> profile { get; set; }
        public virtual DbSet<profile_referrer> profile_referrer { get; set; }
        public virtual DbSet<profile_status> profile_status { get; set; }
        public virtual DbSet<related_entities> related_entities { get; set; }
        public virtual DbSet<related_entity_types> related_entity_types { get; set; }
        public virtual DbSet<remittance_advice_formats> remittance_advice_formats { get; set; }
        public virtual DbSet<report_parameters> report_parameters { get; set; }
        public virtual DbSet<sales_teams> sales_teams { get; set; }
        public virtual DbSet<service_teams> service_teams { get; set; }
        public virtual DbSet<soa_classes_of_business> soa_classes_of_business { get; set; }
        public virtual DbSet<soa_clauses> soa_clauses { get; set; }
        public virtual DbSet<sources_of_business> sources_of_business { get; set; }
        public virtual DbSet<SQLUserConfigTable> SQLUserConfigTable { get; set; }
        public virtual DbSet<states> states { get; set; }
        public virtual DbSet<steadfast_uw_codes> steadfast_uw_codes { get; set; }
        public virtual DbSet<sub_agent_amounts> sub_agent_amounts { get; set; }
        public virtual DbSet<sub_agent_profile> sub_agent_profile { get; set; }
        public virtual DbSet<sunrise_instalment> sunrise_instalment { get; set; }
        public virtual DbSet<sunrise_instalment_insurer_payments> sunrise_instalment_insurer_payments { get; set; }
        public virtual DbSet<sunrise_instalment_payments> sunrise_instalment_payments { get; set; }
        public virtual DbSet<sunrise_insurers> sunrise_insurers { get; set; }
        public virtual DbSet<sunrise_mapping> sunrise_mapping { get; set; }
        public virtual DbSet<sunrise_policies> sunrise_policies { get; set; }
        public virtual DbSet<sunrise_products> sunrise_products { get; set; }
        public virtual DbSet<sunrise_server_codes> sunrise_server_codes { get; set; }
        public virtual DbSet<sunrise_workbooks> sunrise_workbooks { get; set; }
        public virtual DbSet<SystemConfigOptions> SystemConfigOptions { get; set; }
        public virtual DbSet<tables> tables { get; set; }
        public virtual DbSet<task_documents> task_documents { get; set; }
        public virtual DbSet<task_status_types> task_status_types { get; set; }
        public virtual DbSet<task_types> task_types { get; set; }
        public virtual DbSet<tasks> tasks { get; set; }
        public virtual DbSet<tasks_sub_tasks> tasks_sub_tasks { get; set; }
        public virtual DbSet<temp_banking_summary2> temp_banking_summary2 { get; set; }
        public virtual DbSet<transaction_reasons> transaction_reasons { get; set; }
        public virtual DbSet<transaction_set_items> transaction_set_items { get; set; }
        public virtual DbSet<transaction_sets> transaction_sets { get; set; }
        public virtual DbSet<transaction_types> transaction_types { get; set; }
        public virtual DbSet<transactions> transactions { get; set; }
        public virtual DbSet<ufi_country_codes> ufi_country_codes { get; set; }
        public virtual DbSet<UserConfig> UserConfig { get; set; }
        public virtual DbSet<UserConfigOptions> UserConfigOptions { get; set; }
        public virtual DbSet<UserWebServiceLogin> UserWebServiceLogin { get; set; }
        public virtual DbSet<vims_trans_enquiry> vims_trans_enquiry { get; set; }
        public virtual DbSet<WebClientSummaryHeaderFields> WebClientSummaryHeaderFields { get; set; }
        public virtual DbSet<WebLocker> WebLocker { get; set; }
        public virtual DbSet<Workbook_Notes> Workbook_Notes { get; set; }
        public virtual DbSet<Workbook_SOA> Workbook_SOA { get; set; }
        public virtual DbSet<WorkbookHeader> WorkbookHeader { get; set; }
        public virtual DbSet<workbooks> workbooks { get; set; }
        public virtual DbSet<write_off> write_off { get; set; }
        public virtual DbSet<asicadp106> asicadp106 { get; set; }
        public virtual DbSet<balances> balances { get; set; }
        public virtual DbSet<banking_section> banking_section { get; set; }
        public virtual DbSet<CCFeeTransactions> CCFeeTransactions { get; set; }
        public virtual DbSet<Client_Notes> Client_Notes { get; set; }
        public virtual DbSet<COBMappings> COBMappings { get; set; }
        public virtual DbSet<Creditors_ageing_v> Creditors_ageing_v { get; set; }
        public virtual DbSet<DEFTNotes> DEFTNotes { get; set; }
        public virtual DbSet<draw_earn> draw_earn { get; set; }
        public virtual DbSet<expiry_register> expiry_register { get; set; }
        public virtual DbSet<expiry_register_coins> expiry_register_coins { get; set; }
        public virtual DbSet<expiry_register_portfolio_analysis> expiry_register_portfolio_analysis { get; set; }
        public virtual DbSet<GLSl_Balances> GLSl_Balances { get; set; }
        public virtual DbSet<insurer_master_itemised> insurer_master_itemised { get; set; }
        public virtual DbSet<insurer_masterlist> insurer_masterlist { get; set; }
        public virtual DbSet<PaidInvoices> PaidInvoices { get; set; }
        public virtual DbSet<payment_methods> payment_methods { get; set; }
        public virtual DbSet<period_renewals> period_renewals { get; set; }
        public virtual DbSet<policies_monthly> policies_monthly { get; set; }
        public virtual DbSet<PoliciesNotPosted> PoliciesNotPosted { get; set; }
        public virtual DbSet<policy_master> policy_master { get; set; }
        public virtual DbSet<portfolio_analysis_register> portfolio_analysis_register { get; set; }
        public virtual DbSet<refunds> refunds { get; set; }
        public virtual DbSet<reversed_payments> reversed_payments { get; set; }
        public virtual DbSet<statements_generated_ID> statements_generated_ID { get; set; }
        public virtual DbSet<temp_report_sunrise_import_policies> temp_report_sunrise_import_policies { get; set; }
        public virtual DbSet<Total_Earnings> Total_Earnings { get; set; }
        public virtual DbSet<transaction_items> transaction_items { get; set; }
        public virtual DbSet<turnoverdetail> turnoverdetail { get; set; }
        public virtual DbSet<unallocated_cash_return_v> unallocated_cash_return_v { get; set; }
        public virtual DbSet<vims_asic_iba> vims_asic_iba { get; set; }
        public virtual DbSet<vims_broker_rep_liability> vims_broker_rep_liability { get; set; }
        public virtual DbSet<Webclient_master_list> Webclient_master_list { get; set; }
    }
}
