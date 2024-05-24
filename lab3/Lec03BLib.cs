using lab3.Lec03LibN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Lec03LibN
{


    //-----------------------------интерфейсы для классов-----------------------------


    public interface IBonus
    {
        float cost1hour { get; set; }
        float calc(float number_hours);
    }

    public interface IFactory
    {
        IBonus getA(float cost1hour);
        IBonus getB(float cost1hour, float x);
        IBonus getC(float cost1hour, float x, float y);
    }
    

    //---------------классы для вычисления вознаграждения сотрудников------------------


    internal class BonusCalcA1 : IBonus
    {
        public float cost1hour { get; set; }

        public BonusCalcA1(float costOneHour)
        {
            cost1hour = costOneHour;
        }

        public float calc(float number_hours)
        {
            return number_hours * cost1hour;
        }
    }

    internal class BonusCalcB1 : IBonus
    {
        public float cost1hour { get; set; }
        public float X { get; set; }

        public BonusCalcB1(float costOneHour, float x)
        {
            cost1hour = costOneHour;
            X = x;
        }

        public float calc(float number_hours)
        {
            return number_hours * cost1hour * X;
        }
    }

    internal class BonusCalcC1 : IBonus
    {
        public float cost1hour { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        public BonusCalcC1(float costOneHour, float x, float y)
        {
            cost1hour = costOneHour;
            X = x;
            Y = y;
        }

        public float calc(float number_hours)
        {
            return number_hours * cost1hour * X + Y;
        }
    }

    internal class BonusCalcA2 : IBonus
    {
        public float cost1hour { get; set; }
        public float A { get; set; }

        public BonusCalcA2(float costOneHour, float a)
        {
            cost1hour = costOneHour;
            A = a;
        }

        public float calc(float number_hours)
        {
            return (number_hours + A) * cost1hour;
        }
    }

    internal class BonusCalcB2 : IBonus
    {
        public float cost1hour { get; set; }
        public float A { get; set; }
        public float X { get; set; }

        public BonusCalcB2(float costOneHour, float a, float x)
        {
            cost1hour = costOneHour;
            A = a;
            X = x;
        }

        public float calc(float number_hours)
        {
            return (number_hours + A) * cost1hour * X;
        }
    }

    internal class BonusCalcC2 : IBonus
    {
        public float cost1hour { get; set; }
        public float A { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        public BonusCalcC2(float costOneHour, float a, float x, float y)
        {
            cost1hour = costOneHour;
            A = a;
            X = x;
            Y = y;
        }

        public float calc(float number_hours)
        {
            return (number_hours + A) * cost1hour * X + Y;
        }
    }

    internal class BonusCalcA3 : IBonus
    {
        public float cost1hour { get; set; }
        public float A { get; set; }
        public float B { get; set; }

        public BonusCalcA3(float costOneHour, float a, float b)
        {
            cost1hour = costOneHour;
            A = a;
            B = b;
        }

        public float calc(float number_hours)
        {
            return (number_hours + A) * (cost1hour + B);
        }
    }

    internal class BonusCalcB3 : IBonus
    {
        public float cost1hour { get; set; }
        public float A { get; set; }
        public float B { get; set; }
        public float X { get; set; }

        public BonusCalcB3(float costOneHour, float a, float b, float x)
        {
            cost1hour = costOneHour;
            A = a;
            B = b;
            X = x;
        }

        public float calc(float number_hours)
        {
            return (number_hours + A) * (cost1hour + B) * X;
        }
    }

    internal class BonusCalcC3 : IBonus
    {
        public float cost1hour { get; set; }
        public float A { get; set; }
        public float B { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        public BonusCalcC3(float costOneHour, float a, float b, float x, float y)
        {
            cost1hour = costOneHour;
            A = a;
            B = b;
            X = x;
            Y = y;
        }

        public float calc(float number_hours)
        {
            return (number_hours + A) * (cost1hour + B) * X + Y;
        }
    }


    //--------------------------реализация трёх фабрик-------------------------


    internal class Factory1 : IFactory
    {
        public IBonus getA(float costOneHour)
        {
            return new BonusCalcA1(costOneHour);
        }

        public IBonus getB(float costOneHour, float x)
        {
            return new BonusCalcB1(costOneHour, x);
        }

        public IBonus getC(float costOneHour, float x, float y)
        {
            return new BonusCalcC1(costOneHour, x, y);
        }
    }

    internal class Factory2 : IFactory
    {
        public float A { get; set; }

        public Factory2(float a)
        {
            A = a;
        }

        public IBonus getA(float costOneHour)
        {
            return new BonusCalcA2(costOneHour, A);
        }

        public IBonus getB(float costOneHour, float x)
        {
            return new BonusCalcB2(costOneHour, A, x);
        }

        public IBonus getC(float costOneHour, float x, float y)
        {
            return new BonusCalcC2(costOneHour, A, x, y);
        }
    }

    internal class Factory3 : IFactory
    {
        public float A { get; set; }
        public float B { get; set; }

        public Factory3(float a, float b)
        {
            A = a;
            B = b;
        }

        public IBonus getA(float costOneHour)
        {
            return new BonusCalcA3(costOneHour, A, B);
        }

        public IBonus getB(float costOneHour, float x)
        {
            return new BonusCalcB3(costOneHour, A, B, x);
        }

        public IBonus getC(float costOneHour, float x, float y)
        {
            return new BonusCalcC3(costOneHour, A, B, x, y);
        }
    }



    public static partial class Lec03BLib
    {
        public static IFactory getL1() => new Factory1();

        public static IFactory getL2(float a) => new Factory2(a);

        public static IFactory getL3(float a, float b) => new Factory3(a, b);
    }
}






















