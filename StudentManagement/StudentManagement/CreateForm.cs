using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class CreateForm : Form
    {
        private StudentManagement Business;
        public CreateForm()
        {
            InitializeComponent();
            this.Business = new StudentManagement();
            this.btnCancel.Click += btnCancel_Click;
            this.btnSave.Click += btnSave_Click;
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            var code = this.txtCode.Text;
            var name = this.txtName.Text;
            var gender = false;
            if (rdbMale.Checked == true)
            {
                gender = true;
            }
            var hometown = this.rtbHometown.Text;

            this.Business.AddStudent(code, name, gender, hometown);
            MessageBox.Show("Them sinh vien thanh cong ");
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
