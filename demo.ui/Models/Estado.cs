using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.ui.Models
{
   public class Estado
    {
        public Boolean Value { get; set; }
        public string Name { get; set; }


        public List<Estado> getEstados()
        {
            var dataSource = new List<Estado>();
            dataSource.Add(new Estado() { Name = "HABILITADO", Value = true });
            dataSource.Add(new Estado() { Name = "DESHABILITADO", Value = false });
            return dataSource;
        }

    }
}
