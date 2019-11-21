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
    public partial class UpdateForm : Form
    {
        private int StudentID;
        private StudentManagement Business;
        public UpdateForm(int id)
        {
            InitializeComponent();
            this.StudentID = id;
            this.Business = new StudentManagement();
            this.btnCancel.Click += btnCancel_Click;
            this.btnSave.Click += btnSave_Click;
            this.Load += UpdateForm_Load;
        }

        void UpdateForm_Load(object sender, EventArgs e)
        {
            var @student = this.Business.GetStudents(this.StudentID);
            this.txtCode.Text = @student.Code;
            this.txtName.Text = @student.Name;
            this.rtbHometown.Text = @student.Hometown;
            if(@student.Gender == true)
            {
                this.rdbMale.Checked = true;
            }
            else
            {
                this.rdbFemale.Checked = true;
            }
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
