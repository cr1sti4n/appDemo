using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DEMO.LOGIC;
using DEMO.MODEL;


namespace demo.ui.CourseFrm
{
    public partial class frmListaCourse : Form
    {

        GeneralLogic logic;
        frmCourseNew frmCourse;
        frmCourseUpdate frmUpdate;
        public frmListaCourse()
        {
            InitializeComponent();
        }

        private void frmListaCourse_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        public void cargarDatos()
        {
            logic = new GeneralLogic();
          
            dgvCurso.CellContentClick += new DataGridViewCellEventHandler(dgv_btnUpdate);
            dgvCurso.AutoGenerateColumns = false;
            dgvCurso.DataSource = logic.ListCourse();     

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "id";
            column.Name = "ID";
            dgvCurso.Columns.Add(column);

            DataGridViewColumn column2 = new DataGridViewTextBoxColumn();
            column2.DataPropertyName = "name";
            column2.Name = "Nombre";
            dgvCurso.Columns.Add(column2);

            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.DataPropertyName = "desc";
            column3.Name = "Descripcion";
            dgvCurso.Columns.Add(column3);

            DataGridViewColumn column4 = new DataGridViewTextBoxColumn();
            column4.DataPropertyName = "status";
            column4.Name = "Estado";
            dgvCurso.Columns.Add(column4);

            DataGridViewColumn column5 = new DataGridViewTextBoxColumn();
            column5.DataPropertyName = "createdAt";
            column5.Name = "Fecha Registro";
            dgvCurso.Columns.Add(column5);

            DataGridViewColumn column6 = new DataGridViewTextBoxColumn();
            column6.DataPropertyName = "updatedAt";
            column6.Name = "Fecha Actualizacion";
            dgvCurso.Columns.Add(column6);

            dgvCurso.Columns.Add(CreateButton());
        }
        DataGridViewButtonColumn CreateButton()
        {
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();

            button.DataPropertyName = "id";
            button.Name = "Update";
            button.Text = "Update";
            button.UseColumnTextForButtonValue = true;


            return button;
        }
        private void dgv_btnUpdate(object sender, DataGridViewCellEventArgs e)
        {

            int IDRegistro = Convert.ToInt32(dgvCurso.CurrentRow.Cells[0].Value);

            if (frmUpdate == null)
            {
                frmUpdate = new frmCourseUpdate(IDRegistro);
                frmUpdate.MdiParent = this.MdiParent;
                frmUpdate.Dock = DockStyle.Fill;
                frmUpdate.FormClosed += new FormClosedEventHandler(courseupdate_FormClosed);
                frmUpdate.Show();
            }
            else
            {
                frmCourse.Activate();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if (frmCourse == null)
            {      
                frmCourse = new frmCourseNew();
                frmCourse.MdiParent = this.MdiParent;
                frmCourse.Dock = DockStyle.Fill;
                frmCourse.FormClosed += new FormClosedEventHandler(coursenew_FormClosed);
                frmCourse.Show();
            }
            else
            {
                frmCourse.Activate();
            }
            
        }

        private void coursenew_FormClosed(object sender, EventArgs e)
        {
            frmCourse = null;
        }

        private void courseupdate_FormClosed(object sender, EventArgs e)
        {
            frmUpdate = null;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            logic = new GeneralLogic();
            dgvCurso.DataSource = logic.ListCourse();

        }
    }
}
