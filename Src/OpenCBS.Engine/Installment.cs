﻿using System;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine
{
    public class Installment : IInstallment
    {
        public int Number { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime RepaymentDate { get; set; }

        public decimal Principal { get; set; }

        public decimal Interest { get; set; }

        public decimal Olb { get; set; }

        public decimal PaidPrincipal { get; set; }

        public decimal PaidInterest { get; set; }

        public DateTime? LastPaymentDate { get; set; }

        public bool Repaid
        {
            get { return Principal == PaidPrincipal && Interest == PaidInterest; }
        }

        public decimal Penalty { get; set; }

        public decimal PaidPenalty { get; set; }

        public decimal CancelledPenalty { get; set; }
    }
}
