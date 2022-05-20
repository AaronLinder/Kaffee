using Caffee.Controllers;

namespace Caffee
{
    public class Kaffee
    {

        public double Wasser { get; private set; }
        public double Kaffeebohnen { get; private set; }

        public double gesamtMengeKaffeProduziert { get; private set; }

        public static double maxWasser = 2.5;

        public static double maxBohnen = 2.5;

        public Kaffee(double Wasser, double Kaffeebohnen, double gesamtMengeKaffeProduziert)
        {
            this.Wasser = Wasser;
            this.Kaffeebohnen = Kaffeebohnen;
            this.gesamtMengeKaffeProduziert = gesamtMengeKaffeProduziert;
        }


        public static double wasserAuffuellen(double menge)
        {
            if (menge + KaffeeController.kaffee.Wasser > maxWasser)
            {
                KaffeeController.kaffee.Wasser = maxWasser;
                return maxWasser;
            }

            KaffeeController.kaffee.Wasser =  KaffeeController.kaffee.Wasser + menge;
            return KaffeeController.kaffee.Wasser;
        }

        public static double bohnenAuffuellen(double menge)
        {
            if (menge + KaffeeController.kaffee.Kaffeebohnen > maxBohnen)
            {
                KaffeeController.kaffee.Kaffeebohnen = maxBohnen;
                return maxBohnen;
            }

            KaffeeController.kaffee.Kaffeebohnen = KaffeeController.kaffee.Kaffeebohnen + menge;
            return KaffeeController.kaffee.Kaffeebohnen;
        }

        public static bool macheKaffee(double menge, double verhaeltnisWasserBohnen)
        {
            if(verhaeltnisWasserBohnen == 1)
            {
                if(KaffeeController.kaffee.Wasser - menge/2 < 0 || KaffeeController.kaffee.Kaffeebohnen - menge/2 < 0)
                {
                    return false;
                }
                KaffeeController.kaffee.Wasser = KaffeeController.kaffee.Wasser - menge /2;
                KaffeeController.kaffee.Kaffeebohnen = KaffeeController.kaffee.Kaffeebohnen - menge /2;
                KaffeeController.kaffee.gesamtMengeKaffeProduziert = KaffeeController.kaffee.gesamtMengeKaffeProduziert  + menge;
                return true;
            }
            else if(verhaeltnisWasserBohnen > 1)
            {
                if (KaffeeController.kaffee.Wasser - menge* verhaeltnisWasserBohnen / (verhaeltnisWasserBohnen +1 ) < 0 || KaffeeController.kaffee.Kaffeebohnen - menge / (verhaeltnisWasserBohnen) < 0)
                {
                    return false;
                }
                KaffeeController.kaffee.Wasser = KaffeeController.kaffee.Wasser - menge *2 / 3;
                KaffeeController.kaffee.Kaffeebohnen = KaffeeController.kaffee.Kaffeebohnen - menge / 3;
                KaffeeController.kaffee.gesamtMengeKaffeProduziert = KaffeeController.kaffee.gesamtMengeKaffeProduziert + menge;
                return true;
            }
            else if(verhaeltnisWasserBohnen < 1)
            {
                if (KaffeeController.kaffee.Wasser - menge / verhaeltnisWasserBohnen < 0 || KaffeeController.kaffee.Kaffeebohnen - menge*verhaeltnisWasserBohnen / (verhaeltnisWasserBohnen+1) < 0)
                {
                    return false;
                }
                KaffeeController.kaffee.Wasser = KaffeeController.kaffee.Wasser - menge  / 3;
                KaffeeController.kaffee.Kaffeebohnen = KaffeeController.kaffee.Kaffeebohnen - menge *2 / 3;
                KaffeeController.kaffee.gesamtMengeKaffeProduziert = KaffeeController.kaffee.gesamtMengeKaffeProduziert  + menge;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
