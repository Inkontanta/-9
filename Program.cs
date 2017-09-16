using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_9
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 16;
            int sumchet=0, sumnechet =0;
            Point2 beg = MakeList2(size);
            Console.WriteLine("Список: ");
            ShowList2(beg);
            Podchet(beg, ref  sumchet, ref sumnechet);
            Console.WriteLine("Сумма четных " + sumchet);
            Console.WriteLine("Сумма нечетных " + sumnechet);
            sumnechet = sumchet - sumnechet;
            Console.WriteLine("Разность сумм четных и нечетных: " + sumnechet);

            Console.ReadKey();
        }

        class Point2
        {
            public int data2;
            public Point2 next2, //адрес следующего элемента
                          pred2; //адрес предыдущего элемента
            public Point2()
            {
                data2 = 0;
                next2 = null;
                pred2 = null;
            }
            public Point2(int d)
            {
                data2 = d;
                next2 = null;
                pred2 = null;
            }
            public override string ToString()
            {
                return data2 + " ";
            }
        }

        static Point2 MakePoint2(int d)
        {
            Point2 p = new Point2(d);
            return p;
        }

        static Point2 MakeList2(int size) //добавление в начало
        {
            if (size == 0)
            {
                Console.WriteLine("Список пуст.");
                return null;
            }
            Random rnd = new Random();
            int info = rnd.Next(0, 11);
            Point2 beg = MakePoint2(info);
            for (int i = 1; i < size; i++)
            {
                info = rnd.Next(0, 11);
                Point2 p = MakePoint2(info);
                p.next2 = beg;
                beg.pred2 = p;
                beg = p;
            }
            return beg;
        }

        static void ShowList2(Point2 beg)
        {
            //проверка наличия элементов в списке
            if (beg == null)
            {
                Console.WriteLine("Список стал пустым");
                return;
            }
            Point2 p = beg;
            while (p != null)
            {
                Console.Write(p);
                p = p.next2;//переход к следующему элементу
            }
            Console.WriteLine();
        }

        static Point2 Podchet(Point2 beg, ref int sumchet, ref int sumnechet)
        {
            if (beg == null)//пустой список
            {
                Console.WriteLine("Список пуст");
                return null;
            }
            Point2 p = beg;
            Point2 b = p.pred2;

            while (p != null && b == null)
            {
                if (p.data2 % 2 != 0)
                {
                    sumchet = sumchet + p.data2;
                }
                else
                {
                    sumnechet = sumnechet + p.data2;
                }
                p = p.next2;
            }

            while (p != null)
            {
                if (p.data2 % 2 != 0)
                {
                    Point2 k = b;
                    b = b.next2;
                    Point2 l = MakePoint2(p.data2);
                    b = l;
                    b.pred2 = k;
                    b.pred2.next2 = b;
                    b.next2 = null;
                }
                p = p.next2;
            }

            if (b != null)
                while (b.pred2 != null)
                {
                    b = b.pred2;
                }

            beg = b;

            return beg;
        }

    }
}
