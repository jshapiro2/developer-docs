﻿using System;
using MWRefundVault.MWCredit;

namespace MWRefundVault
{
    public class Program
    {
        private static void Main(string[] args)
        {
            // Create Soap Client
            CreditSoapClient soapClient = new CreditSoapClient("CreditSoap");
            // Create MerchantCredentails object
            MerchantCredentials merchantCredentials = new MerchantCredentials
            {
                MerchantName = "MLTEST",
                MerchantSiteId = "XXXXXXXX",
                MerchantKey = "XXXXX-XXXXX-XXXXX-XXXXX-XXXXX"
            };
            // Create PaymentData object
            PaymentData paymentData = new PaymentData
            {
                Source = "Vault",
                VaultToken = "100000100ABCDE123456",
            };
            // Create RefundRequest Object
            RefundRequest refundRequest = new RefundRequest
            {
                Amount = "1.01",
                InvoiceNumber = "1234",
                CardAcceptorTerminalId = "01"
            };
            // Run Refund
            TransactionResponse45 refundResponse = soapClient.Refund(merchantCredentials, paymentData, refundRequest);
            // Print Results
            Console.WriteLine("Refund Response: {0} Token: {1} Amount: ${2}", refundResponse.ApprovalStatus, refundResponse.Token, refundResponse.Amount);
            Console.WriteLine("Press Any Key to Close");
            Console.ReadKey();
        }
    }
}
