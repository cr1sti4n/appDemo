using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEMO.MODEL;

namespace DEMO.DA
{
    public class CourseDA
    {
        
        public bool Add(Course obj)
        {
             DemoEntities Entitie = new DemoEntities();
             obj.createdAt = DateTime.Now;
             Entitie.Course.Add(obj);
             Entitie.SaveChanges();
            return true;
      
        }

        public bool Update(Course obj)
        {
       
                DemoEntities Entitie = new DemoEntities();
                var old = Entitie.Course.Where(z => z.id == obj.id).FirstOrDefault();
                old.name = obj.name;
                old.desc = obj.desc;
                old.status = obj.status;
                old.updatedAt = DateTime.Now; 
                Entitie.SaveChanges();
                return true;
           
        }

        public bool Delete(int id)
        {

            DemoEntities Entitie = new DemoEntities();
            var old = Entitie.Course.Where(z => z.id == id).FirstOrDefault();
            old.status = false;
            Entitie.SaveChanges();
            return true;

        }

        public List<Course> Listar()
        {
            DemoEntities Entitie = new DemoEntities();
            var lista = Entitie.Course.ToList();
            return lista;
        }
        public Course Get(int id)
        {
            DemoEntities Entitie = new DemoEntities();
            var obj = Entitie.Course.Where(z => z.id == id).FirstOrDefault();
            return obj;
        }
    }
}
