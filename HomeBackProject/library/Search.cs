using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace HomeBackProject.library
{
    public class searchData
    {
        List<int> changeInt = new List<int>();
        public List<int> SquareMeters(int SquareMeters)
        {
            if (SquareMeters == 0)
            {
                this.changeInt.Add(0);
                this.changeInt.Add(10000000);
            }
            else if (SquareMeters == 1)
            {
                this.changeInt.Add(0);
                this.changeInt.Add(20);
            }
            else if (SquareMeters == 2)
            {
                this.changeInt.Add(20);
                this.changeInt.Add(30);
            }
            else if (SquareMeters == 3)
            {
                this.changeInt.Add(30);
                this.changeInt.Add(40);
            }
            else if (SquareMeters == 4)
            {
                this.changeInt.Add(40);
                this.changeInt.Add(50);
            }
            else if (SquareMeters == 5)
            {
                this.changeInt.Add(50);
                this.changeInt.Add(60);
            }
            else if (SquareMeters == 6)
            {
                this.changeInt.Add(60);
                this.changeInt.Add(1000000);
            }

            return this.changeInt;
        }
        public List<int> moneyGetData(int AllMoney)
        {
            //計算錢的
            if (AllMoney == 0)
            {
                this.changeInt.Add(0);
                this.changeInt.Add(10000000);
            }
            else if (AllMoney == 1)
            {
                this.changeInt.Add(0);
                this.changeInt.Add(900);
            }
            else if (AllMoney == 2)
            {
                this.changeInt.Add(900);
                this.changeInt.Add(1200);
            }
            else if (AllMoney == 3)
            {
                this.changeInt.Add(1200);
                this.changeInt.Add(1500);
            }
            else if (AllMoney == 4)
            {
                this.changeInt.Add(1500);
                this.changeInt.Add(2500);
            }
            else if (AllMoney == 5)
            {
                this.changeInt.Add(2500);
                this.changeInt.Add(4000);
            }
            else if (AllMoney == 6)
            {
                this.changeInt.Add(4000);
                this.changeInt.Add(5500);
            }
            else if (AllMoney == 7)
            {
                this.changeInt.Add(5500);
                this.changeInt.Add(10000000);
            }
            return this.changeInt;
        }

        public List<int> Flort(int HomeFlortDatas)
        {
            if (HomeFlortDatas == 0)
            {
                this.changeInt.Add(0);
                this.changeInt.Add(1000);
            }
            else if (HomeFlortDatas == 1)
            {
                this.changeInt.Add(0);
                this.changeInt.Add(1);
            }
            else if (HomeFlortDatas == 2)
            {
                this.changeInt.Add(2);
                this.changeInt.Add(6);
            }
            else if (HomeFlortDatas == 3)
            {
                this.changeInt.Add(7);
                this.changeInt.Add(12);
            }
            else if (HomeFlortDatas == 4)
            {
                this.changeInt.Add(13);
                this.changeInt.Add(1000);
            }
            return this.changeInt;
        }  
        
        public List<int> ageHome(int HomeAge)
        {
            if (HomeAge == 0)
            {
                this.changeInt.Add(0);
                this.changeInt.Add(10000);
            }
            else if (HomeAge == 1)
            {
                this.changeInt.Add(0);
                this.changeInt.Add(1);
            }
            else if (HomeAge == 2)
            {
                this.changeInt.Add(1);
                this.changeInt.Add(5);
            }
            else if (HomeAge == 3)
            {
                this.changeInt.Add(5);
                this.changeInt.Add(10);
            }
            else if (HomeAge == 4)
            {
                this.changeInt.Add(10);
                this.changeInt.Add(15);
            }
            else if (HomeAge == 5)
            {
                this.changeInt.Add(15);
                this.changeInt.Add(20);
            }
            else if (HomeAge == 6)
            {
                this.changeInt.Add(20);
                this.changeInt.Add(10000);
            }
            return this.changeInt;
        }

    }
}