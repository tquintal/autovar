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
    public class Automovel: Notifier
    {

        //Classe de 1 Automóvel

        #region Construtores

        //Definir os construtores com as respetivas variáveis inicializadas a 0 / vazias 
        // posteriormente recebem os valores pelas propriedades

        public Automovel()
        {
            this.idAutomovel = 0;
            this.idUtilizador = 0;
            this.idMarca = 0;
            this.idModelo = 0;
            this.descricaoMarca = string.Empty;
            this.descricaoModelo = string.Empty;
            this.ano = 0;
            this.kms = 0;
            this.condicao = string.Empty;
            this.portas = 0;
            this.combustivel = string.Empty;
            this.preco = 0;
            this.mediaURL = string.Empty;
            this.dataEntrada = DateTime.Today;
            this.dataVenda = null;
            this.nomeUtilizador = string.Empty;
        }

        public Automovel(
                   int idAutomovel,
                   int idUtilizador,
                   int idMarca,
                   int idModelo,
                   string descricaoMarca,
                   string descricaoModelo,
                   int ano,
                   int kms,
                   string condicao,
                   int portas,
                   string combustivel,
                   float preco,
                   string mediaURL,
                   DateTime dataEntrada,
                   DateTime? dataVenda,
                   string nomeUtilizador
                   ) : this()
        {
            this.idAutomovel = idAutomovel;
            this.idUtilizador = idUtilizador;
            this.idMarca = idMarca;
            this.idModelo = idModelo;
            this.descricaoMarca = descricaoMarca;
            this.descricaoModelo = descricaoModelo;
            this.ano = ano;
            this.kms = kms;
            this.condicao = condicao;
            this.portas = portas;
            this.combustivel = combustivel;
            this.preco = preco;
            this.mediaURL = mediaURL;
            this.dataEntrada = dataEntrada;
            this.dataVenda = dataVenda;
            this.nomeUtilizador = nomeUtilizador;
        }

        #endregion

        #region Propriedades

        //Zona das propriedades com parametros de detectar mudanças na variável publica 

        private int idAutomovel;
        public int IdAutomovel
        {
            get { return this.idAutomovel; }
            set { this.idAutomovel = value;
                  this.OnPropertyChanged("IdAutomovel");
                }
        }

        private int idUtilizador;
        public int IdUtilizador
        {
            get { return this.idUtilizador; }
            set { this.idUtilizador = value;
                  this.OnPropertyChanged("IdUtilizador");
                }
        }


        private int idMarca;
        public int IdMarca
        {
            get { return this.idMarca; }
            set { this.idMarca = value;
                this.OnPropertyChanged("IdMarca");
                }
        }

        private int idModelo;
        public int IdModelo
        {
            get { return this.idModelo; }
            set { this.idModelo = value;
                  this.OnPropertyChanged("IdModelo");
                }
        }

        private string descricaoMarca;
        public string DescricaoMarca
        {
            get { return this.descricaoMarca; }
            set { this.descricaoMarca = value; }
        }

        private string descricaoModelo;
        public string DescricaoModelo
        {
            get { return this.descricaoModelo; }
            set { this.descricaoModelo = value; }
        }

        private int ano;
        public int Ano
        {
            get { return ano; }
            set { ano = value;
                  this.OnPropertyChanged("Ano");
                }
        }

        private int kms;
        public int KMS
        {
            get { return kms; }
            set { kms = value;
                  this.OnPropertyChanged("KMS");
                }
        }

        private string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value;
                  this.OnPropertyChanged("Condicao");
                }
        }

        private int portas;
        public int Portas
        {
            get { return portas; }
            set { portas = value;
                  this.OnPropertyChanged("Portas");
                }
        }

        private string combustivel;
        public string Combustivel
        {
            get { return combustivel; }
            set { combustivel = value;
                  this.OnPropertyChanged("Combustivel");
                }
        }

        private float preco;
        public float Preco
        {
            get { return preco; }
            set { preco = value;
                  this.OnPropertyChanged("Preco");
                }
        }

        private string mediaURL;
        public string MediaURL
        {
            get { return mediaURL; }
            set { mediaURL = value;
                  this.OnPropertyChanged("MediaURL");
                }
        }

        private DateTime dataEntrada;
        public DateTime DataEntrada
        {
            get { return dataEntrada; }
            set { dataEntrada = value;
                  this.OnPropertyChanged("DataEntrada");
                }
        }

        private DateTime? dataVenda;
        public DateTime? DataVenda
        {
            get { return dataVenda; }
            set { dataVenda = value;
                  this.OnPropertyChanged("DataVenda");
                }
        }

        private string nomeUtilizador;
        public string NomeUtilizador
        {
            get { return nomeUtilizador; }
            set
            {
                nomeUtilizador = value;
                this.OnPropertyChanged("NomeUtilizador");
            }
        }

        #endregion

        #region Métodos

        // Zona dos Métodos para serem usados
        //integração com a camada de dados

        public static DataTable ObterAutomoveis()
        {
            return CamadaDados.Automovel.ObterAutomoveis();
        }

        public static AutomovelCollection ObterListaAutomoveis()
        {
            DataTable dataTable = Automovel.ObterAutomoveis();

            AutomovelCollection automoveis = new AutomovelCollection(dataTable);

            return automoveis;
        }

        //método novo, limpa todos os dados dos campos  

        public void Novo()
        {
            this.IdAutomovel = 0;
            this.IdUtilizador = 0;
            this.IdMarca = 0;
            this.IdModelo = 0;
            this.Ano = 0;
            this.KMS = 0;
            this.Condicao = string.Empty;
            this.Portas = 0;
            this.Combustivel = string.Empty;
            this.Preco = 0;
            this.MediaURL = string.Empty;
            this.DataEntrada = DateTime.Today;
            this.DataVenda = null;
        }

        //método gravar, passar os dados da camada de dados para a classe Automóvel da camada de dados 
        public bool Gravar(ref string mensagemErro, ref string caminhoErro)
        {
            return CamadaDados.Automovel.GuardarAutomovel(
                this.idAutomovel,
                this.idUtilizador,
                this.idMarca,
                this.idModelo,
                this.ano,
                this.kms,
                this.condicao,
                this.portas,
                this.combustivel,
                this.preco,
                this.mediaURL,
                this.dataEntrada,
                this.dataVenda,
                out mensagemErro,
                out caminhoErro);
        }

        //método eliminar, passa o parametro idAutomovel para o método EliminarAutomovel presente na classe Automovel da camada de Dados

        public bool Eliminar(ref string mensagemErro, ref string caminhoErro)
        {
            return CamadaDados.Automovel.EliminarAutomovel(this.idAutomovel, out mensagemErro, out caminhoErro);
        }

        //método filtrar da lista --- **ainda em teste**

        internal bool DentroFiltro(string textoFiltro)
        {
            bool isDentro = false;

            int numeroTexto = 0;
            if (int.TryParse(textoFiltro, out numeroTexto))
            {
                if (this.IdAutomovel == numeroTexto)
                {
                    isDentro = true;
                }
            }
            if (!isDentro)
            {
                if (this.DescricaoMarca.ToUpper().Contains(textoFiltro.ToUpper()))
                {
                    isDentro = true;
                }
            }
            return isDentro;
        }

        #endregion
    }

}