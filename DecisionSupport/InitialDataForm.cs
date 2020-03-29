using System;
using System.Windows.Forms;

namespace DecisionSupport
{
    public partial class InitialDataForm : Form
    {
        public InitialDataForm()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        private void ShowSecondForm(object sender, EventArgs e)
        {
            var mainForm = Owner as MainForm;

            int criterions = (int)numericUpDownCriterions.Value;
            int variables = (int)numericUpDownX.Value;

            if(criterions < 2)
            {
                MessageBox.Show("Число альтернатив указано неверно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (variables < 2)
            {
                MessageBox.Show("Число переменных указано неверно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mainForm.criterions = criterions;
            mainForm.variables = variables;

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
