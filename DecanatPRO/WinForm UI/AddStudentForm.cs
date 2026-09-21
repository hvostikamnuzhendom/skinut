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
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }
        public string StudentName => textBoxName.Text;
        public string Group => textBoxGroup.Text;
        public string Speciality => textBoxSpec.Text;
    }
}
