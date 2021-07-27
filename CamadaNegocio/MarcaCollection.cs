using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio
{
    public class MarcaCollection : Collection<Marca>
    {

        //Class responsável pela Collection das Marcas

        public MarcaCollection()
        {

        }

        public MarcaCollection(DataTable dataTable)
        {
            if (dataTable == null)
            {
                return;
            }

            foreach (DataRow dataRow in dataTable.AsEnumerable())
            {
                Marca marca = new Marca();

                marca.IdMarca = dataRow.Field<int>("ID");
                marca.DescricaoMarca = dataRow.Field<string>("Descricao");

                this.Add(marca);
            }
        }
    }
}
