using Caliburn.Micro;
using FinancialEquations;
using System;
using System.Collections.Generic;
using System.Text;
using WPFUI.Enums;

namespace WPFUI.ViewModels
{
    public class RefianceViewModel : Screen
    {
        private decimal _currentMonthlyPayment;
        private decimal _newMonthlyPayment;
        private decimal _savings;
        private MorgageType _morgageType;

        public decimal CurrentMonthlyPayment
        {
            get 
            { 
                return _currentMonthlyPayment; 
            }
            set 
            { 
                _currentMonthlyPayment = value;
                NotifyOfPropertyChange(() => CurrentMonthlyPayment);
            }
        }

        public decimal NewMonthlyPayment
        {
            get 
            { 
                return _newMonthlyPayment; 
            }
            set 
            { 
                _newMonthlyPayment = value;
                NotifyOfPropertyChange(() => NewMonthlyPayment);
            }
        }

        public decimal Savings
        {
            get 
            { 
                return _savings; 
            }
            set 
            { 
                _savings = value;
                NotifyOfPropertyChange(() => Savings);
            }
        }

        public MorgageType MorgageType
        {
            get
            {
                return _morgageType;
            }
            set
            {
                _morgageType = value;
                NotifyOfPropertyChange(() => MorgageType);
            }
        }

        public void Calculate(decimal loanAmount, int remainingPayments, double currentInterestRatePercent, double newInterestRatePercent, decimal refianceCost, int monthsUntilSelling)
        {

            CurrentMonthlyPayment = MorgageEquations.MorgagePayment(loanAmount, remainingPayments, currentInterestRatePercent / 100);

            int numberOfNewPayments = 0;

            switch (MorgageType)
            {
                case MorgageType.ThirtyYearFixed:
                    numberOfNewPayments = 360;
                    break;
                case MorgageType.FifteenYearFixed:
                    numberOfNewPayments = 180;
                    break;
            }

            NewMonthlyPayment = MorgageEquations.MorgagePayment(loanAmount, numberOfNewPayments, newInterestRatePercent / 100);

            if (monthsUntilSelling == 0)
                monthsUntilSelling = -1;

            decimal currentTotalPayment = MorgageEquations.TotalPayement(loanAmount, CurrentMonthlyPayment, currentInterestRatePercent / 100, monthsUntilSelling);
            decimal newTotalPayment = MorgageEquations.TotalPayement(loanAmount, NewMonthlyPayment, newInterestRatePercent / 100, monthsUntilSelling);

            Savings = currentTotalPayment - (newTotalPayment + refianceCost);
        }
    }
}
