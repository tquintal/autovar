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
    public class Modelo
    {

        //Class Modelo

        #region Construtores

        //Construtores da Classe Modelo
        public Modelo()
        {
            this.marcaID = 0;
            this.DescricaoModelo = string.Empty;
        }

        public Modelo(
                   int modeloID,
                   int marcaID,
                   string descricaoModelo
                   ) : this()
        {
            this.modeloID = modeloID;
            this.marcaID = marcaID;
            this.descricaoModelo = descricaoModelo;
        }

        #endregion

        #region Propriedades

        //Propriedades da Classe Modelo

        private int modeloID;
        public int IdModelo
        {
            get { return this.modeloID; }
            set
            {
                this.modeloID = value;
            }
        }

        private int marcaID;
        public int IdMarca
        {
            get { return this.marcaID; }
            set
            {
                this.marcaID = value;
            }
        }

        private string descricaoModelo;
        public string DescricaoModelo
        {
            get { return this.descricaoModelo; }
            set { this.descricaoModelo = value; }
        }

        #endregion

        #region Metodos

        //Métodos da Classe Modelo

        public static DataTable ObterModelos()
        {
            return CamadaDados.Modelo.ObterModelos();
        }

        public static ModeloCollection ObterListaModelos()
        {
            DataTable dataTable = Modelo.ObterModelos();

            ModeloCollection modelos = new ModeloCollection(dataTable);

            return modelos;
        }

        #endregion
    }
}
