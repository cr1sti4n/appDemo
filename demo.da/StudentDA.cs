using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEMO.MODEL;

namespace DEMO.DA
{
    public class StudentDA
    {
        public bool Add(Student obj)
        {
            DemoEntities Entitie = new DemoEntities();
            obj.createdAt = DateTime.Now;
            Entitie.Student.Add(obj);
            Entitie.SaveChanges();
            return true;

        }

        public bool Update(Student obj)
        {

            DemoEntities Entitie = new DemoEntities();
            var old = Entitie.Student.Where(z => z.id == obj.id).FirstOrDefault();
            old.name = obj.name;
            old.lastname = obj.lastname;
            old.phone = obj.phone;
            old.status = obj.status;
            old.updatedAt = DateTime.Now;
            Entitie.SaveChanges();
            return true;

        }

        public bool Delete(int id)
        {

            DemoEntities Entitie = new DemoEntities();
            var old = Entitie.Student.Where(z => z.id == id).FirstOrDefault();
            old.status = false;
            Entitie.SaveChanges();
            return true;

        }

        public List<Student> Listar()
        {
            DemoEntities Entitie = new DemoEntities();
            var lista = Entitie.Student.ToList();
            return lista;
        }

        public Student Get(int id)
        {
            DemoEntities Entitie = new DemoEntities();
            var obj = Entitie.Student.Where(z => z.id == id).FirstOrDefault();
            return obj;
        }
    }
}
