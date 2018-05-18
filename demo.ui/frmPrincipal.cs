using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using demo.ui.CourseFrm;
using demo.ui.StudentFrm;

namespace demo.ui
{
    public partial class frmPrincipal : Form
    {
        frmListaCourse frmCourse;
        frmListaStudent frmStudent;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            

            if (frmStudent == null)
            {
                frmStudent = new frmListaStudent();       
                frmStudent.MdiParent = this;
                frmStudent.Dock = DockStyle.Fill;
                frmStudent.FormClosed += new FormClosedEventHandler(student_FormClosed);
                frmStudent.Show();
            }
            else
            {
                frmStudent.Activate();
            }


        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(frmCourse == null)
            {
                frmCourse = new frmListaCourse();
                frmCourse.MdiParent = this;
                frmCourse.Dock = DockStyle.Fill;
                frmCourse.FormClosed += new FormClosedEventHandler(course_FormClosed);
                frmCourse.Show();
            }
            else
            {
                frmCourse.Activate();
            }
          

        }
        private void student_FormClosed(object sender, EventArgs e)
        {
            frmStudent = null;
        }

        private void course_FormClosed(object sender, EventArgs e)
        {
            frmCourse = null;
        }
    }
}
