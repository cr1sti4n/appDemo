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

namespace demo.ui.StudentFrm
{
    public partial class frmListaStudent : Form
    {
        public frmListaStudent()
        {
            InitializeComponent();
        }
        GeneralLogic logic;
        frmStudentNew frmNew;
        frmStudentUpdate frmUpdate;
        private void frmListaStudent_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        public void cargarDatos()
        {
            logic = new GeneralLogic();

            dgv.CellContentClick += new DataGridViewCellEventHandler(dgv_btnUpdate);
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = logic.ListaStudent();

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "id";
            column.Name = "ID";
            dgv.Columns.Add(column);

            DataGridViewColumn column2 = new DataGridViewTextBoxColumn();
            column2.DataPropertyName = "name";
            column2.Name = "Nombre";
            dgv.Columns.Add(column2);

            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.DataPropertyName = "lastname";
            column3.Name = "Apellido";
            dgv.Columns.Add(column3);

            DataGridViewColumn column4 = new DataGridViewTextBoxColumn();
            column4.DataPropertyName = "phone";
            column4.Name = "Celular";
            dgv.Columns.Add(column4);

            DataGridViewColumn column7 = new DataGridViewTextBoxColumn();
            column7.DataPropertyName = "phone";
            column7.Name = "Celular";
            dgv.Columns.Add(column7);

            DataGridViewColumn column5 = new DataGridViewTextBoxColumn();
            column5.DataPropertyName = "createdAt";
            column5.Name = "Fecha Registro";
            dgv.Columns.Add(column5);

            DataGridViewColumn column6 = new DataGridViewTextBoxColumn();
            column6.DataPropertyName = "updatedAt";
            column6.Name = "Fecha Actualizacion";
            dgv.Columns.Add(column6);

            dgv.Columns.Add(CreateButton());
        }

        private void dgv_btnUpdate(object sender, DataGridViewCellEventArgs e)
        {

            int IDRegistro = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);

            if (frmUpdate == null)
            {
                frmUpdate = new frmStudentUpdate(IDRegistro);
                frmUpdate.MdiParent = this.MdiParent;
                frmUpdate.Dock = DockStyle.Fill;
                frmUpdate.FormClosed += new FormClosedEventHandler(studentupdate_FormClosed);
                frmUpdate.Show();
            }
            else
            {
                frmUpdate.Activate();
            }

        }

        private void studentupdate_FormClosed(object sender, EventArgs e)
        {
            frmUpdate = null;
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (frmNew == null)
            {
                frmNew = new frmStudentNew();
                frmNew.MdiParent = this.MdiParent;
                frmNew.Dock = DockStyle.Fill;
                frmNew.FormClosed += new FormClosedEventHandler(studentnew_FormClosed);
                frmNew.Show();
            }
            else
            {
                frmNew.Activate();
            }
        }
        private void studentnew_FormClosed(object sender, EventArgs e)
        {
            frmNew = null;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            logic = new GeneralLogic();
            dgv.DataSource = logic.ListaStudent();
        }
    }
}
