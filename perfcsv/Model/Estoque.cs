using System;

namespace perfcsv.Model
{
    public class Estoque
    {
        public int EstoqueId { get; set; }

        public int ProdutoCod { get; set; }

        public string Title { get; set; }

        public string Unidade { get; set; }

        public int NotaFiscal { get; set; }

        public string Fornecedor { get; set; }

        public int Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }

        public decimal ValorTotal { get; set; }

        public DateTime Data { get; set; }
    }
}
