using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace DecisionSupport
{
    public partial class MainForm : Form
    {
        public int criterions;//Число альтернатив
        public int variables;//Число переменных

        public string[] criterionsNames;
        public string[] varsNames;

        public double[][][] matrixA;
        public double[][][] matrixG;
        public double[] matrixD;

        private List<DataGridView> dataGridViewsA;
        private List<DataGridView> dataGridViewsG;
        private List<DataGridView> dataGridViewsD;
        private List<Label> labelsA;
        private List<Label> labelsG;
        private List<Label> labelsD;

        private bool matrixACreated;

        public MainForm()
        {
            InitializeComponent();

            Text = "Система помощи в принятии решений";
            StartPosition = FormStartPosition.CenterScreen;

            ToolStripMenuItem fileItem = new ToolStripMenuItem("Модель");
            ToolStripMenuItem aboutItem = new ToolStripMenuItem("О программе");

            ToolStripMenuItem createItem = new ToolStripMenuItem("Создать");
            ToolStripMenuItem saveItem = new ToolStripMenuItem("Сохранить");
            ToolStripMenuItem openItem = new ToolStripMenuItem("Открыть");

            fileItem.DropDownItems.Add(createItem);
            fileItem.DropDownItems.Add(saveItem);
            fileItem.DropDownItems.Add(openItem);

            createItem.Click += CreateItem_Clicked;
            saveItem.Click += SaveItem_Clicked;
            openItem.Click += OpenItem_Clicked;
            aboutItem.Click += AboutItem_Clicked;
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

            menuStrip1.Items.Add(fileItem);
            menuStrip1.Items.Add(aboutItem);

            matrixACreated = false;
        }


        //Обаботчики кнопоко верхнего меню
        private void AboutItem_Clicked(object sender, EventArgs e)
        {
            MessageBox.Show("" +
                "Данная программа является системой\r\n" +
                "поддержки принятия решений и была\r\n" +
                "создана в качестве семестровой работы\r\n" +
                "по предмету Системы Поддержки Принятия Решений\r\n" +
                "студентом третьего курса ВолгГТУ\r\n" +
                "Толочёк Юрием Юрьевичем",
                "О программе", MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
        }
        private void CreateItem_Clicked(object sender, EventArgs e)
        {
            var initialDataForm = new InitialDataForm();
            initialDataForm.Owner = this;

            if (initialDataForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            

            CreateFlowLayout(splitContainer1, out dataGridViewsA, out labelsA, criterions, variables, variables);

            criterionsNames = new string[criterions];
            varsNames = new string[variables];

            for (int i = 0; i < criterions; i++)
            {
                criterionsNames[i] = $"Критерий {i + 1}";

                for (int j = 0; j < variables; j++)
                {
                    dataGridViewsA[i].Columns[j].Name = $"Альтернатива {j + 1}";
                    dataGridViewsA[i].Rows[j].HeaderCell.Value = $"Альтернатива {j + 1}";
                    varsNames[j] = $"Альтернатива {j + 1}";
                }
            }
            matrixA = Initialize3DMatrix();
        }
        private void SaveItem_Clicked(object sender, EventArgs e)
        {
            if (!matrixACreated)
            {
                MessageBox.Show("Нет данных для сохранения", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "dss files(*.dss)|*.dss|All files(*.*)|*.*";
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                else
                {
                    string filename = saveFileDialog.FileName;

                    string allDatastring = CreateAllDataString();

                    File.WriteAllText(filename, allDatastring);
                }
            }
            catch (Exception exept)
            {
                MessageBox.Show("При сохранении произошла ошибка " + exept.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OpenItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "dss files(*.dss)|*.dss|All files(*.*)|*.*";
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                else
                {
                    string filename = openFileDialog.FileName;

                    string allDatastring = File.ReadAllText(filename);

                    ParseAllDataString(allDatastring);
                }
            }
            catch (Exception exept)
            {
                MessageBox.Show("При открытии файла произошла ошибка " + exept.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Вспомогательные функции для сохранения модели и её открытия
        private string CreateAllDataString()
        {
            string allDataSting = "";

            allDataSting += criterions.ToString() + "\n" + variables.ToString() + "\n";

            for (int i = 0; i < criterions; i++)//Вписываем матрицу
            {
                for (int j = 0; j < variables; j++)
                {
                    allDataSting += matrixA[i][0][j].ToString() + "\t";
                }
                allDataSting += "\v";
            }
            allDataSting += "\n";

            for (int i = 0; i < criterions; i++)
            {
                allDataSting += criterionsNames[i] + "\t";
            }

            allDataSting += "\n";

            for (int i = 0; i < variables; i++)
            {
                allDataSting += varsNames[i] + "\t";
            }

            return allDataSting;
        }
        private void ParseAllDataString(string allDatastring)
        {
            string[] splitedData = allDatastring.Split('\n');

            criterions = int.Parse(splitedData[0]);
            variables = int.Parse(splitedData[1]);

            matrixA = Initialize3DMatrix();

            string[] matrixAstrings = splitedData[2].Split('\v');
            for (int i = 0; i < criterions; i++)
            {
                string[] matrixRow = matrixAstrings[i].Split('\t');
                for (int j = 0; j < variables; j++)
                {
                    matrixA[i][0][j] = int.Parse(matrixRow[j]);
                }
            }

            matrixA = FillEmptySpaces(matrixA);

            CreateFlowLayout(splitContainer1, out dataGridViewsA, out labelsA, criterions, variables, variables);

            string[] criterionsString = splitedData[3].Split('\t');
            criterionsNames = new string[criterions];
            for (int i = 0; i < criterions; i++)
            {
                criterionsNames[i] = criterionsString[i];
            }

            string[] varsString = splitedData[4].Split('\t');
            varsNames = new string[variables];
            for (int i = 0; i < variables; i++)
            {
                varsNames[i] = varsString[i];
            }

            SetCriterionsNames(labelsA);
            SetVarsNames(dataGridViewsA);
            FillTablesWithValue(dataGridViewsA, matrixA);

            buttonCalc_Click(this, new EventArgs());

            matrixACreated = true;
        }

        //Обработчики боковых кнопок(Ввод названий альтернатив/переменных, ввод значений ячеек)
        private void ButtonFill_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < criterions; i++)
            {
                for (int j = 1; j < variables; j++)
                {
                    var dataInputForm = new DataInputForm(criterionsNames[i], varsNames[0], varsNames[j], i, j);
                    dataInputForm.Owner = this;

                    if (dataInputForm.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                }
            }

            matrixA = FillEmptySpaces(matrixA);

            FillTablesWithValue(dataGridViewsA, matrixA);

            buttonCalc.Visible = true;
            matrixACreated = true;
        }
        private void ButtonFillCrits_Click(object sender, EventArgs e)
        {
            criterionsNames = new string[criterions];

            for (int i = 0; i < criterions; i++)
            {
                var nameInputFomr = new NameInputForm(i, true);
                nameInputFomr.Owner = this;

                if (nameInputFomr.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            SetCriterionsNames(labelsA);
        }
        private void buttonFillVars_Click(object sender, EventArgs e)
        {
            varsNames = new string[variables];

            for (int i = 0; i < variables; i++)
            {
                var nameInputFomr = new NameInputForm(i, false);
                nameInputFomr.Owner = this;

                if (nameInputFomr.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            SetVarsNames(dataGridViewsA);
        }
        private void buttonCalc_Click(object sender, EventArgs e)
        {
            matrixG = CalculateG(matrixA);

            CreateFlowLayout(splitContainer2, out dataGridViewsG, out labelsG, matrixG.Length, matrixG[0].Length, matrixG[0][0].Length);

            SetCriterionsForG(labelsG);

            SetVarsNames(dataGridViewsG);

            FillTablesWithValue(dataGridViewsG, matrixG);

            matrixD = CalculateD(matrixG);

            CreateFlowLayout(splitContainer3, out dataGridViewsD, out labelsD, 1, 1, matrixD.Length);

            labelsD[0].Text = "Пересечение частных критериев\r\n(Нечёткое решение)";

            SetVarsNames(dataGridViewsD);

            for (int i = 0; i < matrixD.Length; i++)
            {
                dataGridViewsD[0][i, 0].Value = matrixD[i];
            }
        }

        //Функции для работы с грид таблицами (установка имён для колнок или строк, добавление данных внутрь ячеек)
        private void SetCriterionsNames(List<Label> labes)
        {
            for (int i = 0; i < labes.Count; i++)
            {
                labes[i].Text = "Матрица попарных сравнений\r\nдля " + criterionsNames[i] + " = ";
            }
        }
        private void SetCriterionsForG(List<Label> labes)
        {
            for (int i = 0; i < labes.Count; i++)
            {
                labes[i].Text = "Векторы приоритетов для\r\n" + criterionsNames[i] + " = ";
            }
        }
        private void SetVarsNames(List<DataGridView> dataGridViews)
        {
            for (int i = 0; i < dataGridViews.Count; i++)
            {
                for (int j = 0; j < dataGridViews[i].Columns.Count; j++)
                {
                    if (dataGridViews[i].Columns.Count == dataGridViews[i].Rows.Count)
                    {
                        dataGridViews[i].Rows[j].HeaderCell.Value = varsNames[j];
                    }
                    dataGridViews[i].Columns[j].Name = varsNames[j];
                }
            }
        }
        private void FillTablesWithValue(List<DataGridView> dataGridViews, double[][][] matrix3d)
        {

            for (int i = 0; i < criterions; i++)
            {
                for (int j = 0; j < dataGridViews[i].RowCount; j++)
                {
                    for (int k = 0; k < dataGridViews[i].ColumnCount; k++)
                    {
                        dataGridViews[i][k, j].Value = matrix3d[i][j][k];
                    }
                }
            }

        }

        //Функции для работы с 3д массивами и для их расчёта
        private double[][][] CalculateG(double[][][] matrixA)
        {
            int criterions = matrixA.Length;
            int size = matrixA[0].Length;
            double[][][] matrixG = new double[criterions][][];
            for (int i = 0; i < matrixA.Length; i++)
            {

                matrixG[i] = new double[1][];
                for (int j = 0; j < matrixA[i].Length; j++)
                {
                    matrixG[i][0] = new double[size];
                }
            }

            for (int i = 0; i < matrixA.Length; i++)
            {
                double[] coll = Matrix2DFindRowSum(matrixA[i]);
                double sum = coll.Sum();
                for (int j = 0; j < coll.Length; j++)
                {
                    matrixG[i][0][j] = coll[j] / sum;
                }
            }


            return matrixG;
        }
        private double[] Matrix2DFindRowSum(double[][] matrix2d)
        {
            double[] sumnColl = new double[matrix2d.Length];

            for (int i = 0; i < matrix2d.Length; i++)
            {
                sumnColl[i] = matrix2d[i].Sum();
            }

            return sumnColl;
        }
        private double[] CalculateD(double[][][] matrixG)
        {

            double[] D = new double[matrixG[0][0].Length];

            for (int i = 0; i < matrixG[0][0].Length; i++)
            {
                double min = matrixG[0][0][i];
                for (int j = 0; j < matrixG.Length; j++)
                {
                    double curr = matrixG[j][0][i];
                    if (min > curr)
                        min = curr;
                }
                D[i] = min;
            }
            return D;
        }
        private double[][][] Initialize3DMatrix()
        {
            double[][][] matrix3D = new double[criterions][][];
            for (int i = 0; i < matrix3D.Length; i++)
            {
                matrix3D[i] = new double[variables][];
                for (int j = 0; j < matrix3D[i].Length; j++)
                {
                    matrix3D[i][j] = new double[variables];
                }
            }
            return matrix3D;
        }
        private double[][][] FillEmptySpaces(double[][][] matrix3d)
        {
            foreach (double[][] matrix2d in matrix3d)
            {
                for (int i = 0; i < matrix2d.Length; i++)
                {
                    for (int j = 0; j < matrix2d[i].Length; j++)
                    {
                        if (i == j)
                        {
                            matrix2d[i][j] = 1;
                        }
                    }
                }


                for (int i = 0; i < matrix2d.Length - 1; i++)
                {
                    for (int j = i + 1; j < matrix2d[i].Length; j++)
                    {
                        if (i > 0) matrix2d[i][j] = matrix2d[i - 1][j] / matrix2d[i - 1][j - 1];
                        matrix2d[j][i] = 1.0 / matrix2d[i][j];
                    }
                }
            }
            return matrix3d;
        }

        //Создание табличных лэайутов для демонстрации массивов
        private void CreateFlowLayout(
            SplitContainer container,//Куда добавить созданный лэайут
            out List<DataGridView> grids,//Выходной список созданных таблиц 
            out List<Label> labels,//Выходной список созданных названий альтернатив
            int gridCount,
            int gridRowCount,//Число строк в таблицах
            int gridCollCount)//Число столбцов в таблицах
        {
            var flowLayout = new FlowLayoutPanel();

            flowLayout.AutoScroll = true;

            flowLayout.SuspendLayout();
            container.SuspendLayout();
            SuspendLayout();

            flowLayout.Anchor = ((((AnchorStyles.Top | AnchorStyles.Bottom)
                        | AnchorStyles.Left)
                        | AnchorStyles.Right));
            flowLayout.BorderStyle = BorderStyle.FixedSingle;
            flowLayout.Dock = DockStyle.Fill;
            flowLayout.AutoSize = true;

            grids = new List<DataGridView>();
            labels = new List<Label>();


            for (int i = 0; i < gridCount; i++)
            {
                var gridTable = CreateGridTable(gridCollCount, gridRowCount);//Создаём таблицу с матрицей

                grids.Add(gridTable);//Сохраняем таблицу для дальнейшего изменения

                var label = new Label();
                label.Text = "Матрица попарных сравнений\r\nдля " + $"Критерий {i + 1} = ";
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Dock = DockStyle.Fill;
                labels.Add(label);//Сохраняем название для дальнейшего изменения

                var table = new TableLayoutPanel();
                table.RowCount = 1;
                table.ColumnCount = 2;
                table.AutoSize = true;
                table.Controls.Add(label, 0, 0);
                table.Controls.Add(gridTable, 1, 0);
                table.BackColor = Color.DarkGray;

                gridTable.Size = gridTable.Parent.Size;

                flowLayout.Controls.Add(table);//Добавляем в лэйаут
            }

            container.Panel2.Controls.Clear();
            container.Panel2.Controls.Add(flowLayout);

            buttonFillData.Visible = true;
            buttonFillCrits.Visible = true;
            buttonFillVars.Visible = true;

            flowLayout.ResumeLayout(false);
            flowLayout.PerformLayout();

            container.ResumeLayout(false);
            container.PerformLayout();

            ResumeLayout(false);
        }

        private DataGridView CreateGridTable(int columnCount, int rowCount)
        {
            var gridTable = new DataGridView
            {
                AutoSize = true,
                AllowUserToAddRows = false,

                ColumnCount = columnCount,
                RowCount = rowCount,

                Dock = DockStyle.Fill,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single,
                CellBorderStyle = DataGridViewCellBorderStyle.Single,
                EditMode = DataGridViewEditMode.EditProgrammatically,
                GridColor = Color.Black,
                BackgroundColor = Color.DarkGray,
                ForeColor = Color.DarkGray,
            };
            return gridTable;
        }


        //Обработчик события выхода из приложения
        private void OnApplicationExit(object sender, EventArgs e)
        {
            if (matrixACreated)
            {
                if(MessageBox.Show("Модель будет утеряна, если её не сохранить.\r\nНе хотите её сохранить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    SaveItem_Clicked(this, new EventArgs());
                }
            }
        }
    }
}
