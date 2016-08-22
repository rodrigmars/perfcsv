using LumenWorks.Framework.IO.Csv;
using perfcsv.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

namespace perfcsv
{
    class Program
    {
        static CultureInfo culture { get; set; }
        static ICollection<Estoque> listaEstoque { get; set; }

        static void Main(string[] args)
        {
            culture = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentCulture = culture;

            //TestStreamReader();
            var sw = new Stopwatch();

            sw.Restart();

            BindCsv();

            sw.Stop();

            Console.WriteLine("Processo finalizado em {0}, total de registros {1}", sw.Elapsed.ToString(), listaEstoque.Count());

            Console.ReadLine();
        }

        private static void BindCsv()
        {
            listaEstoque = new List<Estoque>();


            using (var csv = new CsvReader(new StreamReader("estoque.csv"), true))
            {
                int fieldCount = csv.FieldCount;

                //string[] headers = csv.GetFieldHeaders();

                //while (csv.ReadNextRecord())
                //{
                //    for (int i = 0; i < fieldCount; i++)
                //    {
                //        Console.Write(string.Format("{0} = {1};", headers[i], csv[i]));
                //        Console.WriteLine();

                //    }
                //}

                while (csv.ReadNextRecord())
                {
                    //for (int i = 0; i < fieldCount; i++)
                    //{
                    //    Console.WriteLine(string.Format("{0}", csv[i]));
                    //}

                    listaEstoque.Add(new Estoque
                    {
                        Data = DateTime.Parse(csv[0], culture),
                        ProdutoCod = int.Parse(csv[1]),
                        Title = csv[2],
                        Unidade = csv[3],
                        NotaFiscal = int.Parse(csv[4]),
                        Fornecedor = csv[5],
                        Quantidade = int.Parse(csv[6]),
                        ValorUnitario = decimal.Parse(csv[7].ToUpper().Trim().Replace("R$", ""), culture),
                        ValorTotal = (csv[8] == "") ? 0.0m : decimal.Parse(csv[8].ToUpper().Trim().Replace("R$", ""), culture)
                    });
                }
            }
        }

    


    }

    //private static void TestStreamReader()
    //{
    //    try
    //    {

    //        var culture = new CultureInfo("pt-BR");

    //        var file = AppDomain.CurrentDomain.BaseDirectory + @"estoque.csv";

    //        var reader = new StreamReader(File.OpenRead(file), Encoding.GetEncoding(culture.TextInfo.ANSICodePage));

    //        //var lista = new List<Estoque>();

    //        //var estoque = new Estoque();

    //        string[] valor = new string[8];

    //        while (!reader.EndOfStream)
    //        {
    //            var line = reader.ReadLine();

    //            valor = line.Split(',');

    //            Console.WriteLine(valor[0]);
    //            Console.WriteLine(valor[1]);
    //            Console.WriteLine(valor[2]);
    //            Console.WriteLine(valor[3]);
    //            Console.WriteLine(valor[4]);
    //            Console.WriteLine(valor[5]);
    //            Console.WriteLine(valor[6]);
    //            Console.WriteLine(valor[7]);
    //            Console.WriteLine(valor[8]);

    //            //estoque.ProdutoCod = values;

    //            //estoque.Title = values;

    //            //estoque.Unidade = values;

    //            //estoque.NotaFiscal = values;

    //            //estoque.Fornecedor = values;

    //            //estoque.Quantidade = values;

    //            //estoque.ValorUnitario = values;

    //            //estoque.ValorTotal = values;

    //            //estoque.Data = values;
    //        }

    //        Console.ReadLine();

    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine("Error: ", ex.Message);
    //    }
    //}
}

