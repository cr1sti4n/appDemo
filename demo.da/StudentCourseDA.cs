using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEMO.MODEL;

namespace DEMO.DA
{
    public class StudentStudentCourseDA
    {

        public bool Add(StudentCourse obj)
        {
            DemoEntities Entitie = new DemoEntities();
            obj.createdAt = DateTime.Now;
            Entitie.StudentCourse.Add(obj);
            Entitie.SaveChanges();
            return true;

        }


        public bool Delete(int idStudent, int idCourse)
        {

            DemoEntities Entitie = new DemoEntities();
            var old = Entitie.StudentCourse.Where(z=>z.idstudent == idStudent && z.idcourse == idCourse).FirstOrDefault();
            Entitie.StudentCourse.Remove(old);
            return true;

        }

        public List<StudentCourse> listarxStudent(int idStudent)
        {
            DemoEntities Entitie = new DemoEntities();
            var lista = Entitie.StudentCourse.Where(x=>x.idstudent == idStudent).ToList();
            return lista;
        }

    }
}
