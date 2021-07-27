using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio
{
    public class ModeloCollection : Collection<Modelo>
    {

        //Class responsável pela Collection dos Modelos
        public ModeloCollection()
        {

        }

        public ModeloCollection(DataTable dataTable)
        {
            if (dataTable == null)
            {
                return;
            }

            foreach (DataRow dataRow in dataTable.AsEnumerable())
            {
                Modelo modelo = new Modelo();

                modelo.IdModelo = dataRow.Field<int>("ID");
                modelo.IdMarca = dataRow.Field<int>("IDMarca");
                modelo.DescricaoModelo = dataRow.Field<string>("Descricao");

                this.Add(modelo);
            }
        }
    }
}
