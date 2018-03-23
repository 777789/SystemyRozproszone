using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    class Program
    {
        static void Main(string[] args)
        {
            int numerKonta;
            int pin;
            int opcjaWyboru;
            int kwotaWyplacana;

            List<Konto> listaKont = new List<Konto>();

            Konto k1 = new Konto(123456789, 1111, 2000);
            Konto k2 = new Konto(987654321, 1234, 100);
            listaKont.Add(k1);
            listaKont.Add(k2);

            for (; ; )
            {
                try
                {
                    Console.WriteLine("Podaj numer konta");
                    numerKonta = Convert.ToInt32(Console.ReadLine());

                    foreach (Konto konto in listaKont)
                    {
                        if (numerKonta == konto.numer)
                        {
                            try
                            {
                                Console.WriteLine("Podaj pin");
                                pin = Convert.ToInt32(Console.ReadLine());
                                if (konto.pinn == pin)
                                {
                                    Console.WriteLine("1. Stan środków na koncie");
                                    Console.WriteLine("2. Wypłać pieniądze");

                                    opcjaWyboru = Convert.ToInt32(Console.ReadLine());

                                    switch (opcjaWyboru)
                                    {
                                        case 1:
                                            Console.WriteLine($"Stan konta: {konto.stanKonta}");
                                            break;
                                        case 2:
                                            Console.WriteLine($"Ile chcesz wypłacić pieniędzy?");
                                            kwotaWyplacana = Convert.ToInt32(Console.ReadLine());
                                            if (kwotaWyplacana <= konto.stanKonta)
                                            {
                                                Console.WriteLine($"Wypłacono {kwotaWyplacana}, pozostało {konto.stanKonta - kwotaWyplacana}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Nie masz tyle środków na koncie");
                                            }
                                            break;
                                        default:
                                            Console.WriteLine("Nie ma takiej opcji");
                                            break;
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Niepoprawny pin");
                                    break;
                                }

                            }
                            catch
                            {
                                Console.WriteLine("Niepoprawny Pin");
                                break;
                            }
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Niepoprawna wprowadzona wartość");
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    public class Konto
    {
        public int numer;
        public int pinn;
        public int stanKonta;

        public Konto(int numerKonta, int pin, int stan)
        {
            numer = numerKonta;
            pinn = pin;
            stanKonta = stan;
        }
    }
}
