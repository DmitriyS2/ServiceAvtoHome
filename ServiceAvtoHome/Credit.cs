using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAvtoHome
{
    internal class Credit
    {
        public int sumCredit; // кредит=цена авто минус перв взнос
        public int totalCredit; // сумма кредита с учетом процентов
        public string? bankName;
        public int firstPayment; // первоначальный взнос, %
        public int rate; // процентная ставка, %
        public int payment; // платеж, $
        public int periodCredit; // срок кредита, мес

        public string CreditComposition()
        {
            return "\nБанк " + bankName + "\nПервоначальный взнос " + firstPayment*10 + "%\nСрок кредита "+(periodCredit*12)+ "мес.\nПроцентная ставка " + rate + "%\nЕжемесячный платеж "+ payment+"$";
        }

        public string CreditAnswer (int choice)
        {
            return "\nПроходите в " + (choice + 2) + " кабинет. Там находится представитель " + SimpleData.credits[choice - 1].bankName;
        }
    }
}

