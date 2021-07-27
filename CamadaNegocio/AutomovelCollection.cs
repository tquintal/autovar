using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio
{
    public class AutomovelCollection : Collection<Automovel>
    {

        public AutomovelCollection()
        {

        }

        //metodo que recebe todos os registos e divide os registos 1 por 1 consoante o formato da classe Automovel

        public AutomovelCollection(IEnumerable<Automovel> automoveis)
        {
            foreach (Automovel automovel in automoveis)
            {
                this.Add(automovel);
            }
        }

        //Cria a collection automovel (atribui a posição de cada parametro de cada automovel que vem da BD á sua variável correspondente

        public AutomovelCollection(DataTable dataTable)
            : this()
        {
            if (dataTable == null)
            {
                return;
            }

            foreach (DataRow dataRow in dataTable.AsEnumerable())
            {
                Automovel automovel = new Automovel();

                automovel.IdAutomovel = dataRow.Field<int>("ID");
                automovel.IdUtilizador = dataRow.Field<int>("IdUtilizador");
                automovel.Ano = dataRow.Field<int>("Ano");
                automovel.KMS = dataRow.Field<int>("KMS");
                automovel.Condicao = dataRow.Field<string>("Condicao");
                automovel.Portas = dataRow.Field<int>("Portas");
                automovel.Combustivel = dataRow.Field<string>("Combustivel");
                automovel.Preco = (float)dataRow.Field<double>("Preco");
                automovel.MediaURL = dataRow.Field<string>("MediaURL");
                automovel.DataEntrada = dataRow.Field<DateTime>("DataEntrada");

                if (!dataRow.IsNull("DataVenda"))
                {
                    automovel.DataVenda = dataRow.Field<DateTime>("DataVenda");
                }

                automovel.DescricaoMarca = dataRow.Field<string>("DescricaoMarca");
                automovel.DescricaoModelo = dataRow.Field<string>("DescricaoModelo");
                automovel.IdMarca = dataRow.Field<int>("IdMarca");
                automovel.IdModelo = dataRow.Field<int>("IdModelo");


                this.Add(automovel);
            }
        }

        //Filtragem de automovel --- **ainda em teste**

        public AutomovelCollection Filtrar(string textoFiltro)
        {
            AutomovelCollection automoveis;

            if (string.IsNullOrEmpty(textoFiltro))
            {
                automoveis = this;
            }
            else
            {
                IEnumerable<Automovel> filtroAutomomveis = from Automovel element in this
                                                           where element.DentroFiltro(textoFiltro)
                                                           select element;

                automoveis = new AutomovelCollection(filtroAutomomveis);
            }

            return automoveis;

        }

    }

}
