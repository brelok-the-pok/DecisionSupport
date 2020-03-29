using System;
using System.Windows.Forms;

namespace DecisionSupport
{
    public partial class DataInputForm : Form
    {
        private int criterion;
        private int variable;
        public DataInputForm(string crit, string name1, string name2, int criterion, int variable)
        {
            InitializeComponent();

            textBox1.Text = $"Выберите для критерия {crit}\r\nво сколько раз \r\n{name1} предпочтительнее {name2}";

            this.criterion = criterion;
            this.variable = variable;
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            double value = (double)numericUpDown1.Value;

            if(value <= 0)
            {
                MessageBox.Show("Значение дольжно быть больше нуля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var mainForm = Owner as MainForm;
            mainForm.matrixA[criterion][0][variable] = value;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
