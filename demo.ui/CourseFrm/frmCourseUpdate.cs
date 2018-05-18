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
using demo.ui.Models;

namespace demo.ui.CourseFrm
{
    public partial class frmCourseUpdate : Form
    {

        int IdAlumno;
        public frmCourseUpdate(int idAlumno)
        {
            InitializeComponent();
            IdAlumno = idAlumno;
        }

        GeneralLogic logic;

        private void frmCourseUpdate_Load(object sender, EventArgs e)
        {
           
            cboStatus.DataSource = new Estado().getEstados();
            cboStatus.DisplayMember = "Name";
            cboStatus.ValueMember = "Value";
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cargaDatos(IdAlumno);

        }

        public void cargaDatos(int id)
        {
            logic = new GeneralLogic();
            var datos = logic.GetCourse(id);
            txtName.Text = datos.name;
            txtDescripcion.Text = datos.desc;
            cboStatus.SelectedValue = datos.status;
            txtId.Text = id.ToString();
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text))
            {
              
                e.Cancel = true;
                txtName.Select(0, txtName.Text.Length);

               
                errorProvider1.SetError(txtName, "Debe ingresar nombre");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtDescripcion_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
               
                e.Cancel = true;
                txtDescripcion.Select(0, txtDescripcion.Text.Length);            
                errorProvider1.SetError(txtDescripcion, "Debe ingresar descripcion");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var objeto = new Course();
            objeto.id = Convert.ToInt16(txtId.Text);
            objeto.name = txtName.Text;
            objeto.desc = txtDescripcion.Text;
            objeto.status = (cboStatus.SelectedItem as Estado).Value;
            logic = new GeneralLogic();
            if (logic.UpdateCourse(objeto))
            {
                MessageBox.Show("Se guardo correctamente");
                
            }
            else
            {
                MessageBox.Show("Sucedio un error");
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            this.Close();
        }
    }
}
