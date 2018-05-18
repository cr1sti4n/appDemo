using demo.ui.Models;
using DEMO.LOGIC;
using DEMO.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo.ui.StudentFrm
{
    public partial class frmStudentNew : Form
    {
        public frmStudentNew()
        {
            InitializeComponent();
        }
        GeneralLogic logic;
        private void btnSave_Click(object sender, EventArgs e)
        {

            logic = new GeneralLogic();
            var obj = new Student();
            obj.name = txtName.Text.Trim();
            obj.lastname = txtLastname.Text.Trim();
            obj.phone = txtPhone.Text.Trim();
            obj.status = (cboStatus.SelectedItem as Estado).Value;
            if (logic.AddStudent(obj))
            {
                MessageBox.Show("Se agregó correctamente");
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

        private void frmStudentNew_Load(object sender, EventArgs e)
        {

            cboStatus.DataSource = new Estado().getEstados();
            cboStatus.DisplayMember = "Name";
            cboStatus.ValueMember = "Value";
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
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

        private void txtLastname_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtLastname.Text))
            {

                e.Cancel = true;
                txtLastname.Select(0, txtLastname.Text.Length);
                errorProvider1.SetError(txtLastname, "Debe ingresar Apelido");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtPhone.Text))
            {

                e.Cancel = true;
                txtPhone.Select(0, txtPhone.Text.Length);
                errorProvider1.SetError(txtPhone, "Debe ingresar Celular");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            int number;
            if (!int.TryParse(txtPhone.Text.Trim(), out number))
            {
                txtPhone.Text = "";
            }
        }
    }
}
