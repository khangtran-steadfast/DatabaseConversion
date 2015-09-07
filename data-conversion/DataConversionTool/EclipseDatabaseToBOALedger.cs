using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversion
{
    public class EclipseDatabaseToBOALedger : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "EclipseDatabaseToBOALedger";
            }
        }

        protected override void Configure()
        {
            #region MAPPING BETWEEN TABLES DO NOT CHANGE

            Mapper.CreateMap<EclipseDataAccess.UserConfig, BOALedgerDataAccess.UserConfig>();
            Mapper.CreateMap<EclipseDataAccess.ClaimPaymentTypes, BOALedgerDataAccess.ClaimPaymentTypes>();
            Mapper.CreateMap<EclipseDataAccess.sunrise_instalment_insurer_payments, BOALedgerDataAccess.sunrise_instalment_insurer_payments>();
            Mapper.CreateMap<EclipseDataAccess.gl_acc_months, BOALedgerDataAccess.gl_acc_months>();
            Mapper.CreateMap<EclipseDataAccess.occupation_types, BOALedgerDataAccess.occupation_types>();
            Mapper.CreateMap<EclipseDataAccess.temp_banking_summary2, BOALedgerDataAccess.temp_banking_summary2>();
            Mapper.CreateMap<EclipseDataAccess.PoliciesNotPosted, BOALedgerDataAccess.PoliciesNotPosted>();
            Mapper.CreateMap<EclipseDataAccess.temp_report_sunrise_import_policies, BOALedgerDataAccess.temp_report_sunrise_import_policies>();
            Mapper.CreateMap<EclipseDataAccess.apra_class_of_business, BOALedgerDataAccess.apra_class_of_business>();
            Mapper.CreateMap<EclipseDataAccess.profile_referrer, BOALedgerDataAccess.profile_referrer>();
            Mapper.CreateMap<EclipseDataAccess.client_classifications, BOALedgerDataAccess.client_classifications>();
            Mapper.CreateMap<EclipseDataAccess.gen_ins_wor_doc_types, BOALedgerDataAccess.gen_ins_wor_doc_types>();
            Mapper.CreateMap<EclipseDataAccess.turnoverdetail, BOALedgerDataAccess.turnoverdetail>();
            Mapper.CreateMap<EclipseDataAccess.MenuItems, BOALedgerDataAccess.MenuItems>();
            Mapper.CreateMap<EclipseDataAccess.unallocated_cash_return_v, BOALedgerDataAccess.unallocated_cash_return_v>();
            Mapper.CreateMap<EclipseDataAccess.pay_direct, BOALedgerDataAccess.pay_direct>();
            Mapper.CreateMap<EclipseDataAccess.cancellation_reason, BOALedgerDataAccess.cancellation_reason>();
            Mapper.CreateMap<EclipseDataAccess.premium_funding, BOALedgerDataAccess.premium_funding>();
            Mapper.CreateMap<EclipseDataAccess.remittance_advice_formats, BOALedgerDataAccess.remittance_advice_formats>();
            Mapper.CreateMap<EclipseDataAccess.vims_asic_iba, BOALedgerDataAccess.vims_asic_iba>();
            Mapper.CreateMap<EclipseDataAccess.claim_status_types, BOALedgerDataAccess.claim_status_types>();
            Mapper.CreateMap<EclipseDataAccess.vims_broker_rep_liability, BOALedgerDataAccess.vims_broker_rep_liability>();
            Mapper.CreateMap<EclipseDataAccess.Insurers_Category2, BOALedgerDataAccess.Insurers_Category2>();
            Mapper.CreateMap<EclipseDataAccess.vims_trans_enquiry, BOALedgerDataAccess.vims_trans_enquiry>();
            Mapper.CreateMap<EclipseDataAccess.anzic_divisions, BOALedgerDataAccess.anzic_divisions>();
            Mapper.CreateMap<EclipseDataAccess.claim_results, BOALedgerDataAccess.claim_results>();
            Mapper.CreateMap<EclipseDataAccess.sysdiagrams, BOALedgerDataAccess.sysdiagrams>();
            Mapper.CreateMap<EclipseDataAccess.financial_institution, BOALedgerDataAccess.financial_institution>();
            Mapper.CreateMap<EclipseDataAccess.BrokerFeeDefaultWorkbookType, BOALedgerDataAccess.BrokerFeeDefaultWorkbookType>();
            Mapper.CreateMap<EclipseDataAccess.tables, BOALedgerDataAccess.tables>();
            Mapper.CreateMap<EclipseDataAccess.atura_audit, BOALedgerDataAccess.atura_audit>();
            Mapper.CreateMap<EclipseDataAccess.cash_receipt_reversal, BOALedgerDataAccess.cash_receipt_reversal>();
            Mapper.CreateMap<EclipseDataAccess.SystemConfigOptions, BOALedgerDataAccess.SystemConfigOptions>();
            Mapper.CreateMap<EclipseDataAccess.atura_roles, BOALedgerDataAccess.atura_roles>();
            Mapper.CreateMap<EclipseDataAccess.class_of_business_category, BOALedgerDataAccess.class_of_business_category>();
            Mapper.CreateMap<EclipseDataAccess.BrokerReps_Category1, BOALedgerDataAccess.BrokerReps_Category1>();
            Mapper.CreateMap<EclipseDataAccess.claim_documents, BOALedgerDataAccess.claim_documents>();
            Mapper.CreateMap<EclipseDataAccess.monthly_frequency, BOALedgerDataAccess.monthly_frequency>();
            Mapper.CreateMap<EclipseDataAccess.claim_task_types, BOALedgerDataAccess.claim_task_types>();
            Mapper.CreateMap<EclipseDataAccess.DEFTPredefinedErrors, BOALedgerDataAccess.DEFTPredefinedErrors>();
            Mapper.CreateMap<EclipseDataAccess.address_types, BOALedgerDataAccess.address_types>();
            Mapper.CreateMap<EclipseDataAccess.business_category_types, BOALedgerDataAccess.business_category_types>();
            Mapper.CreateMap<EclipseDataAccess.ClientDetails_Category3, BOALedgerDataAccess.ClientDetails_Category3>();
            Mapper.CreateMap<EclipseDataAccess.class_of_business_classification, BOALedgerDataAccess.class_of_business_classification>();
            Mapper.CreateMap<EclipseDataAccess.personnel_types, BOALedgerDataAccess.personnel_types>();
            Mapper.CreateMap<EclipseDataAccess.gl_rule_sets, BOALedgerDataAccess.gl_rule_sets>();
            Mapper.CreateMap<EclipseDataAccess.EmailTemplates, BOALedgerDataAccess.EmailTemplates>();
            Mapper.CreateMap<EclipseDataAccess.BrokerReps_Category3, BOALedgerDataAccess.BrokerReps_Category3>();
            Mapper.CreateMap<EclipseDataAccess.ClientDetails_Category4, BOALedgerDataAccess.ClientDetails_Category4>();
            Mapper.CreateMap<EclipseDataAccess.confirmation_of_cover, BOALedgerDataAccess.confirmation_of_cover>();
            Mapper.CreateMap<EclipseDataAccess.gl_sl_entities, BOALedgerDataAccess.gl_sl_entities>();
            Mapper.CreateMap<EclipseDataAccess.PolicyHeader_Category2, BOALedgerDataAccess.PolicyHeader_Category2>();
            Mapper.CreateMap<EclipseDataAccess.account_types, BOALedgerDataAccess.account_types>();
            Mapper.CreateMap<EclipseDataAccess.write_off, BOALedgerDataAccess.write_off>();
            Mapper.CreateMap<EclipseDataAccess.ClientDetails_Category5, BOALedgerDataAccess.ClientDetails_Category5>();
            Mapper.CreateMap<EclipseDataAccess.states, BOALedgerDataAccess.states>();
            Mapper.CreateMap<EclipseDataAccess.related_entity_types, BOALedgerDataAccess.related_entity_types>();
            Mapper.CreateMap<EclipseDataAccess.AdvAutoPolNoGenerationItems, BOALedgerDataAccess.AdvAutoPolNoGenerationItems>();
            Mapper.CreateMap<EclipseDataAccess.ClientDetails_Category1, BOALedgerDataAccess.ClientDetails_Category1>();
            Mapper.CreateMap<EclipseDataAccess.AutoRoundingValues, BOALedgerDataAccess.AutoRoundingValues>();
            Mapper.CreateMap<EclipseDataAccess.policy_task_status_types, BOALedgerDataAccess.policy_task_status_types>();
            Mapper.CreateMap<EclipseDataAccess.BrokerFeeDefaultsBasis, BOALedgerDataAccess.BrokerFeeDefaultsBasis>();
            Mapper.CreateMap<EclipseDataAccess.CCFeeTransactions, BOALedgerDataAccess.CCFeeTransactions>();
            Mapper.CreateMap<EclipseDataAccess.COBMappings, BOALedgerDataAccess.COBMappings>();
            Mapper.CreateMap<EclipseDataAccess.claim_subjects, BOALedgerDataAccess.claim_subjects>();
            Mapper.CreateMap<EclipseDataAccess.transaction_types, BOALedgerDataAccess.transaction_types>();
            Mapper.CreateMap<EclipseDataAccess.Client_Notes, BOALedgerDataAccess.Client_Notes>();
            Mapper.CreateMap<EclipseDataAccess.Creditors_ageing_v, BOALedgerDataAccess.Creditors_ageing_v>();
            Mapper.CreateMap<EclipseDataAccess.claim_causes, BOALedgerDataAccess.claim_causes>();
            Mapper.CreateMap<EclipseDataAccess.DEFTNotes, BOALedgerDataAccess.DEFTNotes>();
            Mapper.CreateMap<EclipseDataAccess.Entity_Modification, BOALedgerDataAccess.Entity_Modification>();
            Mapper.CreateMap<EclipseDataAccess.client_account_types, BOALedgerDataAccess.client_account_types>();
            Mapper.CreateMap<EclipseDataAccess.GLSl_Balances, BOALedgerDataAccess.GLSl_Balances>();
            Mapper.CreateMap<EclipseDataAccess.transactions, BOALedgerDataAccess.transactions>();
            Mapper.CreateMap<EclipseDataAccess.sunrise_server_codes, BOALedgerDataAccess.sunrise_server_codes>();
            Mapper.CreateMap<EclipseDataAccess.Insurers_Category1, BOALedgerDataAccess.Insurers_Category1>();
            Mapper.CreateMap<EclipseDataAccess.SQLUserConfigTable, BOALedgerDataAccess.SQLUserConfigTable>();
            Mapper.CreateMap<EclipseDataAccess.Total_Earnings, BOALedgerDataAccess.Total_Earnings>();
            Mapper.CreateMap<EclipseDataAccess.UserConfigOptions, BOALedgerDataAccess.UserConfigOptions>();
            Mapper.CreateMap<EclipseDataAccess.sources_of_business, BOALedgerDataAccess.sources_of_business>();
            Mapper.CreateMap<EclipseDataAccess.finance_types, BOALedgerDataAccess.finance_types>();
            Mapper.CreateMap<EclipseDataAccess.sunrise_mapping, BOALedgerDataAccess.sunrise_mapping>();
            Mapper.CreateMap<EclipseDataAccess.UserWebServiceLogin, BOALedgerDataAccess.UserWebServiceLogin>();
            Mapper.CreateMap<EclipseDataAccess.ClientDetails_Category2, BOALedgerDataAccess.ClientDetails_Category2>();
            Mapper.CreateMap<EclipseDataAccess.areas, BOALedgerDataAccess.areas>();
            Mapper.CreateMap<EclipseDataAccess.WebClientSummaryHeaderFields, BOALedgerDataAccess.WebClientSummaryHeaderFields>();
            Mapper.CreateMap<EclipseDataAccess.limited_exemptions, BOALedgerDataAccess.limited_exemptions>();
            Mapper.CreateMap<EclipseDataAccess.gen_ins_transaction_types, BOALedgerDataAccess.gen_ins_transaction_types>();
            Mapper.CreateMap<EclipseDataAccess.WebLocker, BOALedgerDataAccess.WebLocker>();
            Mapper.CreateMap<EclipseDataAccess.dofi_types, BOALedgerDataAccess.dofi_types>();
            Mapper.CreateMap<EclipseDataAccess.Webclient_master_list, BOALedgerDataAccess.Webclient_master_list>();
            Mapper.CreateMap<EclipseDataAccess.contact_methods, BOALedgerDataAccess.contact_methods>();
            Mapper.CreateMap<EclipseDataAccess.report_parameters, BOALedgerDataAccess.report_parameters>();
            Mapper.CreateMap<EclipseDataAccess.asicadp106, BOALedgerDataAccess.asicadp106>();
            Mapper.CreateMap<EclipseDataAccess.currency, BOALedgerDataAccess.currency>();
            Mapper.CreateMap<EclipseDataAccess.atura_super_users, BOALedgerDataAccess.atura_super_users>();
            Mapper.CreateMap<EclipseDataAccess.banking_section, BOALedgerDataAccess.banking_section>();
            Mapper.CreateMap<EclipseDataAccess.BrokerReps_Category2, BOALedgerDataAccess.BrokerReps_Category2>();
            Mapper.CreateMap<EclipseDataAccess.gl_amounts, BOALedgerDataAccess.gl_amounts>();
            Mapper.CreateMap<EclipseDataAccess.branch_permissions, BOALedgerDataAccess.branch_permissions>();
            Mapper.CreateMap<EclipseDataAccess.gl_accounts, BOALedgerDataAccess.gl_accounts>();
            Mapper.CreateMap<EclipseDataAccess.Insurers_Category3, BOALedgerDataAccess.Insurers_Category3>();
            Mapper.CreateMap<EclipseDataAccess.industry_types, BOALedgerDataAccess.industry_types>();
            Mapper.CreateMap<EclipseDataAccess.draw_earn, BOALedgerDataAccess.draw_earn>();
            Mapper.CreateMap<EclipseDataAccess.PolicyHeader_Category3, BOALedgerDataAccess.PolicyHeader_Category3>();
            Mapper.CreateMap<EclipseDataAccess.expiry_register, BOALedgerDataAccess.expiry_register>();
            Mapper.CreateMap<EclipseDataAccess.expiry_register_coins, BOALedgerDataAccess.expiry_register_coins>();
            Mapper.CreateMap<EclipseDataAccess.DocumentRepository, BOALedgerDataAccess.DocumentRepository>();
            Mapper.CreateMap<EclipseDataAccess.general_insurance_workbooks, BOALedgerDataAccess.general_insurance_workbooks>();
            Mapper.CreateMap<EclipseDataAccess.gen_ins_journal_types, BOALedgerDataAccess.gen_ins_journal_types>();
            Mapper.CreateMap<EclipseDataAccess.expiry_register_portfolio_analysis, BOALedgerDataAccess.expiry_register_portfolio_analysis>();
            Mapper.CreateMap<EclipseDataAccess.client_insurance_portfolio, BOALedgerDataAccess.client_insurance_portfolio>();
            Mapper.CreateMap<EclipseDataAccess.organisation_structures, BOALedgerDataAccess.organisation_structures>();
            Mapper.CreateMap<EclipseDataAccess.form_settings, BOALedgerDataAccess.form_settings>();
            Mapper.CreateMap<EclipseDataAccess.claim_task_status_types, BOALedgerDataAccess.claim_task_status_types>();
            Mapper.CreateMap<EclipseDataAccess.category_types, BOALedgerDataAccess.category_types>();
            Mapper.CreateMap<EclipseDataAccess.insurer_master_itemised, BOALedgerDataAccess.insurer_master_itemised>();
            Mapper.CreateMap<EclipseDataAccess.insurer_masterlist, BOALedgerDataAccess.insurer_masterlist>();
            Mapper.CreateMap<EclipseDataAccess.ufi_country_codes, BOALedgerDataAccess.ufi_country_codes>();
            Mapper.CreateMap<EclipseDataAccess.mandatory_fields, BOALedgerDataAccess.mandatory_fields>();
            Mapper.CreateMap<EclipseDataAccess.gen_ins_documents, BOALedgerDataAccess.gen_ins_documents>();
            Mapper.CreateMap<EclipseDataAccess.profile_status, BOALedgerDataAccess.profile_status>();
            Mapper.CreateMap<EclipseDataAccess.payment_methods, BOALedgerDataAccess.payment_methods>();
            Mapper.CreateMap<EclipseDataAccess.ageing_units, BOALedgerDataAccess.ageing_units>();
            Mapper.CreateMap<EclipseDataAccess.period_renewals, BOALedgerDataAccess.period_renewals>();
            Mapper.CreateMap<EclipseDataAccess.fund_status, BOALedgerDataAccess.fund_status>();
            Mapper.CreateMap<EclipseDataAccess.policies_monthly, BOALedgerDataAccess.policies_monthly>();
            Mapper.CreateMap<EclipseDataAccess.policy_master, BOALedgerDataAccess.policy_master>();
            Mapper.CreateMap<EclipseDataAccess.PolicyHeader_Category1, BOALedgerDataAccess.PolicyHeader_Category1>();
            Mapper.CreateMap<EclipseDataAccess.portfolio_analysis_register, BOALedgerDataAccess.portfolio_analysis_register>();
            Mapper.CreateMap<EclipseDataAccess.gl_journal, BOALedgerDataAccess.gl_journal>();
            Mapper.CreateMap<EclipseDataAccess.refunds, BOALedgerDataAccess.refunds>();
            Mapper.CreateMap<EclipseDataAccess.task_types, BOALedgerDataAccess.task_types>();
            Mapper.CreateMap<EclipseDataAccess.task_status_types, BOALedgerDataAccess.task_status_types>();
            Mapper.CreateMap<EclipseDataAccess.task_documents, BOALedgerDataAccess.task_documents>();
            Mapper.CreateMap<EclipseDataAccess.reversed_payments, BOALedgerDataAccess.reversed_payments>();
            Mapper.CreateMap<EclipseDataAccess.soa_clauses, BOALedgerDataAccess.soa_clauses>();
            // Mapper.CreateMap<EclipseDataAccess.statements, BOALedgerDataAccess.statements>();
            // Mapper.CreateMap<EclipseDataAccess.tmpPortfolioAnalysis, BOALedgerDataAccess.tmpPortfolioAnalysis>();
            // Mapper.CreateMap<EclipseDataAccess.turnover, BOALedgerDataAccess.turnover>();
            // Mapper.CreateMap<EclipseDataAccess.view_DofiReport_Table1, BOALedgerDataAccess.view_DofiReport_Table1>();
            // Mapper.CreateMap<EclipseDataAccess.view_DofiReport_Table2, BOALedgerDataAccess.view_DofiReport_Table2>();
            // Mapper.CreateMap<EclipseDataAcess.view_earnings2, BOALedgerDataAccess.view_earnings2>();
            // Mapper.CreateMap<EclipseDataAccess.view_earnings, BOALedgerDataAccess.view_earnings>();
            // Mapper.CreateMap<EclipseDataAccess.view_inspay, BOALedgerDataAccess.view_inspay>();
            // Mapper.CreateMap<EclipseDataAccess.vims_EarningsDiff, BOALedgerDataAccess.vims_EarningsDiff>();
            // Mapper.CreateMap<EclipseDataAccess.vims_unallocated_csh_credits, BOALedgerDataAccess.vims_unallocated_csh_credits>();
            // Mapper.CreateMap<EclipseDataAccess.DEFTStatuses, BOALedgerDataAccess.DEFTStatuses>();
            // Mapper.CreateMap<EclipseDataAccess.AnzsicCode, BOALedgerDataAccess.AnzsicCode>();
            // Mapper.CreateMap<EclipseDataAccess.priorities, BOALedgerDataAccess.priorities>();
            // Mapper.CreateMap<EclipseDataAccess.Cash_Receipt_Lock, BOALedgerDataAccess.Cash_Receipt_Lock>();
            // Mapper.CreateMap<EclipseDataAccess.clauses, BOALedgerDataAccess.clauses>();
            // Mapper.CreateMap<EclipseDataAccess.IBA, BOALedgerDataAccess.IBA>();
            // Mapper.CreateMap<EclipseDataAccess.ProductLicenses, BOALedgerDataAccess.ProductLicenses>();
            // Mapper.CreateMap<EclipseDataAccess.ageing_debtors_v, BOALedgerDataAccess.ageing_debtors_v>();
            // Mapper.CreateMap<EclipseDataAccess.atura_identity, BOALedgerDataAccess.atura_identity>();
            // Mapper.CreateMap<EclipseDataAccess.expiry_register_particulars_t, BOALedgerDataAccess.expiry_register_particulars_t>();
            // Mapper.CreateMap<EclipseDataAccess.glsl_Transactions, BOALedgerDataAccess.glsl_Transactions>();
            // Mapper.CreateMap<EclipseDataAccess.period_renewals_particulars_t, BOALedgerDataAccess.period_renewals_particulars_t>();
            // Mapper.CreateMap<EclipseDataAccess.renewal_retention_report, BOALedgerDataAccess.renewal_retention_report>();

            #endregion

            #region MANUAL MAPPING FOR TABLE HAS FOREIGN KEY

            Mapper.CreateMap<EclipseDataAccess.gl_sub_ledgers, BOALedgerDataAccess.gl_sub_ledgers>()
                  .ForMember(des => des.gl_journal_items, source => source.MapFrom(s => s.gl_journal_items));



            #endregion
        }
    }
}
