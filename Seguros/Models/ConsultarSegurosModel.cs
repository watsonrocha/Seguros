using Seguros.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Seguros.Models
{
    public class ConsultarSegurosModel
    {
      
        public int ID { get; set; }
        public string Valor_Veiculo { get; set; }
        public string Valor_Seguro { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Idade { get; set; }

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Digite um e-mail válido")]
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Nacionalidade { get; set; }

      
        public void RegistrarSeguros(string TxtValor_Veiculo)
        {
          
            var Taxa_de_Risco = (5 * Convert.ToInt32(TxtValor_Veiculo) / (2 * Convert.ToInt32(TxtValor_Veiculo)));
            var Premio_de_Risco = (Taxa_de_Risco * Convert.ToInt32(TxtValor_Veiculo));
            var Premio_Puro = (Premio_de_Risco * (1 + 0.03));
            var Premio_Comercial = (0.5 * Premio_Puro);

            string sql = $"INSERT INTO orcamento (ID, NOME, IDADE, CPF, EMAIL, TELEFONE, MARCA, MODELO, VALOR_VEICULO) VALUES('{ID}','{Nome}','{Idade}','{CPF}','{Email}','{Telefone}','{Marca}','{Modelo}','{Premio_Comercial}')";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }
        

        public List<ConsultarSegurosModel> ListaSaldo()
        {
            List<ConsultarSegurosModel> Lista = new List<ConsultarSegurosModel>();
            ConsultarSegurosModel item;          
            string sql = $"SELECT  valor_veiculo AS total ,Nome,CPF,Idade, Marca,Modelo  FROM orcamento ";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ConsultarSegurosModel();
                item.Valor_Seguro = dt.Rows[i]["total"].ToString();
                item.Nome = dt.Rows[i]["Nome"].ToString();
                item.CPF = dt.Rows[i]["CPF"].ToString();
                item.Idade = dt.Rows[i]["Idade"].ToString();
                item.Marca = dt.Rows[i]["Marca"].ToString();
                item.Modelo = dt.Rows[i]["Modelo"].ToString();

                Lista.Add(item);
            }

            return Lista;

        }


    }
}
