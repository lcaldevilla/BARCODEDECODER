using System;
using System.Collections.Generic;
using System.Text;

namespace WAREHOUSEREADER.LIB
{
    class GS1
    {
        // Definicion GS1
        private struct Gs1St
        {
            public string GTIN, Serie, Caducidad, Lote;
        }
        Gs1St gs1Code = new Gs1St();
        /// <summary>
        /// Parsea el GS1-128
        /// </summary>
        /// <param name="gs1"></param>
        public bool ParseGS1(string gs1)
        {
            String[] arrayGs1 = gs1.Split('('); // indica que comienza un identificador de campo.
            String codigo, valor;
            int codigoOk = 0; // si codigook=4 el codigo esta ok (4 campos necesarios)

            // recorremos el array de identificadores.
            for (int i = 1; i < arrayGs1.Length; i++)
            {
                codigo = arrayGs1[i].Substring(0, 2);
                valor = arrayGs1[i].Substring(3, arrayGs1[i].Length - 3);

                switch (codigo)
                {
                    case "01":
                        codigoOk += 1;
                        gs1Code.GTIN = valor;
                        break;
                    case "10":
                        codigoOk += 1;
                        gs1Code.Lote = valor;
                        break;
                    case "17":
                        codigoOk += 1;
                        gs1Code.Caducidad = valor;
                        break;
                    case "21":
                        codigoOk += 1;
                        gs1Code.Serie = valor;
                        break;
                }
            }
            if (codigoOk == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetGTIN()
        {
            return gs1Code.GTIN;
        }

        public string GetLote()
        {
            return gs1Code.Lote;
        }

        public string GetCaducidad()
        {
            return gs1Code.Caducidad;
        }

        public string GetSerie()
        {
            return gs1Code.Serie;
        }
    }
}

