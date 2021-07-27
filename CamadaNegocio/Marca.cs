using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio
{
    public class Marca
    {

        //Classe Marca


        #region Construtores

            //Contrutores da classe Marca

        public Marca()
        {
            this.marcaID = 0;
            this.DescricaoMarca = string.Empty;
        }

        public Marca(
                   int marcaID,
                   string descricaoMarca
                   ) : this()
        {
            this.marcaID = marcaID;
            this.descricaoMarca = descricaoMarca;
        }

        #endregion

        #region Propriedades

        //Propriedades da Claase Marca

        private int marcaID;
        public int IdMarca
        {
            get { return this.marcaID; }
            set
            {
                this.marcaID = value;
            }
        }

        private string descricaoMarca;
        public string DescricaoMarca
        {
            get { return this.descricaoMarca; }
            set { this.descricaoMarca = value; }
        }

        #endregion

        #region Metodos

        //Métodos da classe Marca

        public static DataTable ObterMarcas()
        {
            return CamadaDados.Marca.ObterMarcas();
        }

        public static MarcaCollection ObterListaMarcas()
        {
            DataTable dataTable = Marca.ObterMarcas();

            MarcaCollection marcas = new MarcaCollection(dataTable);

            return marcas;
        }

        #endregion
    }
}
