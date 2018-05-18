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
    public partial class frmCourseNew : Form
    {
        public frmCourseNew()
        {
            InitializeComponent();
            
        }


        GeneralLogic logic;

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            logic = new GeneralLogic();
            var obj = new Course();
            obj.name = txtName.Text.Trim();
            obj.desc = txtDescripcion.Text.Trim();
            obj.status = (cboStatus.SelectedItem as Estado).Value;
            if ( logic.AddCourse(obj))
            {
                MessageBox.Show("Se agregó correctamente");           
            }
            else
            {
                MessageBox.Show("Sucedio un error");
            }
            


        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
          
            
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
                errorProvider1.Clear();
            }
        }

        private void frmCourseNew_Load(object sender, EventArgs e)
        {
        
            cboStatus.DataSource = new Estado().getEstados();
            cboStatus.DisplayMember = "Name";
            cboStatus.ValueMember = "Value";
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            this.Close();
        }

        private void txtName_Validated(object sender, EventArgs e)
        {

        }
    }
}
