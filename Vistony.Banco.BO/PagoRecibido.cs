//#define AD_BO

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.Banco.BO
{
    public class PaymentReceived
    {
        public string DocType { get; set; }
        public string DocDate { get; set; }
        public string CardCode { get; set; }
        public string HandWritten { get; set; }
        public string TransferAccount { get; set; }
        public decimal TransferSum { get; set; }
        public string TransferDate { get; set; }
        public string TransferReference { get; set; }
        public string PaymentType { get; set; }
        public string Remarks { get; set; }
        public string CounterReference { get; set; }
#if AD_BO 
        public string U_ORIGIN { get; set; }
#endif
        public List<PaymentReceivedDetail> PaymentInvoices { get; set; }
    }
    public class PaymentReceivedDetail
    {
        public string LineNum { get; set; }
        public string DocEntry { get; set; }
        public string SumApplied { get; set; }
        public string AppliedFC { get; set; }
        public string DocRate { get; set; }
        public string DocLine { get; set; }
        public string InvoiceType { get; set; }
        public string DiscountPercent { get; set; }
        public string PaidSum { get; set; }
        public string InstallmentId { get; set; }
        public string WitholdingTaxApplied { get; set; }
        public string WitholdingTaxAppliedFC { get; set; }
        public string WitholdingTaxAppliedSC { get; set; }
        public string LinkDate { get; set; }
        public string DistributionRule { get; set; }
        public string DistributionRule2 { get; set; }
        public string DistributionRule3 { get; set; }
        public string DistributionRule4 { get; set; }
        public string DistributionRule5 { get; set; }
        public string TotalDiscount { get; set; }
        public string TotalDiscountFC { get; set; }
        public string TotalDiscountSC { get; set; }
    }
    public class ListPaymentReceived
    {
        public List<PaymentReceived> PaymentsReceived { get; set; }
    }
    public class ResponsePayment
    {
        public string DocEntry { get; set; }
        public string NumDocumento { get; set; }
        public DateTime Fecha { get; set; }
        public string Deposito { get; set; }
        public string Cliente { get; set; }
        public decimal Monto { get; set; }
        public string Tipo { get; set; }
    }

    public class ResponseError
    {
        public string Recibo { get; set; }
        public string CodCliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Error { get; set; }
        public decimal Monto { get; set; }
        public string Documento { get; set; }
    }
}
