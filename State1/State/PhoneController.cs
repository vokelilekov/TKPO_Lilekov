using System;

namespace StatePatternPhoneApp
{
    public class PhoneController
    {
        private readonly Phone phone;

        public PhoneController(Phone phone)
        {
            this.phone = phone;
        }

        public string GetStateName() => phone.GetStateName();

        public double GetBalance() => phone.Balance;

        public void Call()
        {
            phone.Call();
        }

        public void AnswerCall()
        {
            phone.AnswerCall();
        }

        public void EndCall()
        {
            phone.EndCall();
        }

        public void Recharge(string amountInput)
        {
            if (double.TryParse(amountInput, out double amount))
            {
                phone.Recharge(amount);
            }
            else
            {
                throw new ArgumentException("Некорректная сумма пополнения.");
            }
        }
    }
}
