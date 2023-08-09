using System.Collections.Generic;

namespace HomeBankingTest
{
    public class Pruebas
    {
        public int numero { get; set; }
        public string nombre { get; set; }
        public bool peligroso { get; set; }

        public Pruebas() { }
        public Pruebas(int numero, string nombre, bool peligroso)
        {
            this.numero = numero;
            this.nombre = nombre;
            this.peligroso = peligroso;
        }
    }

    public enum TipoDeDato
    {
        ENTERO,
        CADENA,
        BOOLEANO,
    }
    public enum TransactionType
    {
        CREDITO,
        DEBITO,
    }

    public static void Main1()
    {
        //Pruebas pruebas = new Pruebas();
        //pruebas.numero = 1;
        //pruebas.nombre = "Prueba";
        //pruebas.peligroso = true;

        //Pruebas pruebas2 = new Pruebas(3, "Hola", false);

        //bool miVariable = true;

        TipoDeDato miVariable2 = TipoDeDato.CADENA;

        string tipoDeDato = TipoDeDato.ENTERO.ToString();
        string transactionType = TransactionType.CREDITO.ToString();
    }
}
