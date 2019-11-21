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
    public partial class IndexForm : Form
    {
        private StudentManagement Business;
        public IndexForm()
        {
            InitializeComponent();
            this.Business = new StudentManagement();
            this.Load += IndexForm_Load;
            this.btnCreate.Click += btnCreate_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.DoubleClick += IndexForm_DoubleClick;
        }

        void IndexForm_DoubleClick(object sender, EventArgs e)
        {
            var @class = (PM14008)this.grdStudents.SelectedRows[0].DataBoundItem;
            var updateForm = new UpdateForm(@class.id);
            updateForm.ShowDialog();
            this.LoadAllClasses();
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.grdStudents.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Do you want to delete this?", "Confirm",
                    MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    var @class = (PM14008)this.grdStudents.SelectedRows[0].DataBoundItem;
                    this.Business.DeleteStudent(@class.id);
                    MessageBox.Show("Delete class successfully!");
                    this.LoadAllClasses();
                }
            }
        }

        void btnCreate_Click(object sender, EventArgs e)
        {
            var createForm = new CreateForm();
            createForm.ShowDialog();
            this.LoadAllClasses();
        }

        void IndexForm_Load(object sender, EventArgs e)
        {
            this.LoadAllClasses();
        }

        private void LoadAllClasses()
        {
            var classes = this.Business.GetClasses();
            this.grdStudents.DataSource = classes;
        }
    }
}
