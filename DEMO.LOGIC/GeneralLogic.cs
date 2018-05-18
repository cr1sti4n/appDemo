using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEMO.MODEL;
using DEMO.DA;

namespace DEMO.LOGIC
{
    public class GeneralLogic
    {

        private CourseDA oCourseData = new CourseDA();
        private StudentDA oStudentData = new StudentDA();

        #region Course
        public List<Course> ListCourse()
        {
           var Lista = new List<Course>();
            try
            {
                Lista = oCourseData.Listar();
            }
            catch (Exception e)
            {

            }
            return Lista;
        }
        public Boolean AddCourse(Course obj)
        {
            var exito = true;
            try
            {
                oCourseData.Add(obj);

            }
            catch (Exception)
            {
              exito = false;
            }

            return exito;
        }
        public Course GetCourse(int id)
        {
           
            try
            {
                return  oCourseData.Get(id);
            }
            catch (Exception e)
            {
                return null;
            }
            
        }
        public bool UpdateCourse(Course obj)
        {
            var exito = true;
            try
            {
                oCourseData.Update(obj);

            }
            catch (Exception)
            {
                exito = false;
            }

            return exito;
        }
        #endregion





        #region Course
        public Boolean AddStudent(Student obj)
        {
            var exito = true;
            try
            {
                oStudentData.Add(obj);

            }
            catch (Exception)
            {
                exito = false;
            }

            return exito;
        }
        public List<Student> ListaStudent()
        {
            var Lista = new List<Student>();
            try
            {
                Lista = oStudentData.Listar();
            }
            catch (Exception)
            {

            }
            return Lista;
        }
        public Student GetStudent(int id)
        {
            try
            {
                return oStudentData.Get(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool UpdateStudent(Student obj)
        {
            var exito = true;
            try
            {
                oStudentData.Update(obj);

            }
            catch (Exception)
            {
                exito = false;
            }

            return exito;
        }
        #endregion



    }
}
