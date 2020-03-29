using System;
using System.Drawing;
using System.Windows.Forms;

namespace DecisionSupport
{
    public partial class NameInputForm : Form
    {
        private int index;
        private string msg;
        private bool enterCrit; 

        public NameInputForm(int index, bool enterCrit)
        {
            InitializeComponent();

            this.index = index;
            this.enterCrit = enterCrit;

            if (enterCrit)
            {
                Text = $"Критерий {index + 1}";
                msg = $"Введите имя для критерия {index + 1}";
            }
            else
            {
                Text = $"Альтернатива {index + 1}";
                msg = $"Введите имя для альтернативы {index + 1}";
            }

            textBox1.ForeColor = SystemColors.GrayText;
            textBox1.Text = msg;
            textBox1.Leave += new EventHandler(textBox1_Leave);
            textBox1.Enter += new EventHandler(textBox1_Enter);

        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                textBox1.Text = msg;
                textBox1.ForeColor = SystemColors.GrayText;
            }
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == msg)
            {
                textBox1.Text = "";
                textBox1.ForeColor = SystemColors.WindowText;
            }
        }
        private void Accept_Click(object sender, EventArgs e)
        {
            var mainForm = Owner as MainForm;

            string name = textBox1.Text;

            if(name.Length < 1 || name == msg)
            {
                MessageBox.Show("Введите имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (enterCrit)
                {
                    mainForm.criterionsNames[index] = name;
                }
                else
                {
                    mainForm.varsNames[index] = name;
                }
                DialogResult = DialogResult.OK;
                Close();
            }
        
        }
    }
}
