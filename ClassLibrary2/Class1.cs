using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
namespace ClassLibrary2
{

    public enum MoneyTypeEnum
    {
        Bill = 1,
        Coin = 2 
    }

    public enum ProductEnum
    {
        Coke,
        Pepsi,
        Soda,
        ChocolateBar,
        ChewingGum,
        BottledWater,
        Other
    }


    public class VendingMachine
    {
        private Dictionary<ProductEnum, double>  productPriceDictionary;

        public VendingMachine()
        {

            productPriceDictionary = new Dictionary<ProductEnum, double>
            {
                { ProductEnum.Coke, 25 },
                { ProductEnum.Pepsi, 35 },
                { ProductEnum.Soda, 45 },
                { ProductEnum.ChocolateBar, 20.25 },
                { ProductEnum.ChewingGum, 10.5 },
                { ProductEnum.BottledWater, 15 },
            }
            ;
        }

        public bool ProcessBillOrCoin(int v, MoneyTypeEnum type)
        {
            var arrBills = new int[] { 100, 50, 20 };
            var arrCoins = new int[] { 1,5,10,25,50 };
            if ( type== MoneyTypeEnum.Bill && !arrBills.Contains((v)))
            {
                return false;
            }
            else if (type == MoneyTypeEnum.Coin && !arrCoins.Contains((v)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool SelectProduct(ProductEnum product)
        {
            if (product == ProductEnum.Other)
                return false;
            else
            {
                return true;
            }
        }

        public double CancelOrder(double v)
        {
            return v;
        }

        public ProductEnum GetProduct(ProductEnum product)
        {
            return product;
        }

        public double GetChange(ProductEnum product, double paidAmount)
        {
            foreach (var key in productPriceDictionary.Keys)
            {
                if (product == key)
                {
                    return paidAmount - productPriceDictionary[key];
                }
            }
            return 0;
        }

        public bool IsPaidAmountSufficient(ProductEnum product, double totalPaid)
        {
            foreach (var key in productPriceDictionary.Keys)
            {
                if (product == key)
                {
                    if (productPriceDictionary[key] > totalPaid)
                        return false;
                    else
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }

}
