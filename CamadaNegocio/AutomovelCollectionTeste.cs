using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio
{
    public class AutomovelCollectionTeste : Collection<Automovel>
    {

        public AutomovelCollectionTeste()
        {

        }

        public AutomovelCollectionTeste(DataTable dataTable)
        {
            if (dataTable == null)
            {
                return;
            }

            foreach (DataRow dataRow in dataTable.AsEnumerable())
            {
                Automovel automovel = new Automovel();

                automovel.IdAutomovel = dataRow.Field<int>("ID");

                this.Add(automovel);
            }
        }
    }
}
