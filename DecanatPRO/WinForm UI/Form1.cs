using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_UI
{
    public partial class Form1 : Form
    {
        private Logic _logic = new Logic();
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _logic.Students; 
        }

        

        private void UpdateChart()
        {
            chart1.Series[0].Points.Clear();

            var counts = new System.Collections.Generic.Dictionary<string, int>();

            foreach (var student in _logic.Students)
            {
                if (counts.ContainsKey(student.Speciality))
                    counts[student.Speciality]++;
                else
                    counts[student.Speciality] = 1;
            }

            foreach (var pair in counts)
            {
                chart1.Series[0].Points.AddXY(pair.Key, pair.Value);
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            AddStudentForm addForm = new AddStudentForm();

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                _logic.AddStudent(addForm.StudentName, addForm.Speciality, addForm.Group);

                RefreshGrid();
                UpdateChart();
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                _logic.DeleteStudent(id);

                RefreshGrid();
                UpdateChart();
            }
        }
    }
}
