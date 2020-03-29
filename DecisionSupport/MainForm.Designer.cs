namespace DecisionSupport
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tableMain = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonFillCrits = new System.Windows.Forms.Button();
            this.buttonFillData = new System.Windows.Forms.Button();
            this.buttonCalc = new System.Windows.Forms.Button();
            this.buttonFillVars = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tableMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(889, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tableMain
            // 
            this.tableMain.AutoScroll = true;
            this.tableMain.BackColor = System.Drawing.Color.White;
            this.tableMain.CausesValidation = false;
            this.tableMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableMain.ColumnCount = 1;
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMain.Controls.Add(this.splitContainer1, 0, 0);
            this.tableMain.Controls.Add(this.splitContainer2, 0, 1);
            this.tableMain.Controls.Add(this.splitContainer3, 0, 2);
            this.tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMain.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableMain.Location = new System.Drawing.Point(0, 24);
            this.tableMain.Name = "tableMain";
            this.tableMain.RowCount = 3;
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableMain.Size = new System.Drawing.Size(889, 616);
            this.tableMain.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(881, 361);
            this.splitContainer1.SplitterDistance = 139;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.buttonFillCrits, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonFillData, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonCalc, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonFillVars, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(137, 359);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // buttonFillCrits
            // 
            this.buttonFillCrits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFillCrits.Location = new System.Drawing.Point(3, 3);
            this.buttonFillCrits.Name = "buttonFillCrits";
            this.buttonFillCrits.Size = new System.Drawing.Size(131, 83);
            this.buttonFillCrits.TabIndex = 2;
            this.buttonFillCrits.Text = "Ввести названия критериев";
            this.buttonFillCrits.UseVisualStyleBackColor = true;
            this.buttonFillCrits.Visible = false;
            this.buttonFillCrits.Click += new System.EventHandler(this.ButtonFillCrits_Click);
            // 
            // buttonFillData
            // 
            this.buttonFillData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFillData.Location = new System.Drawing.Point(3, 181);
            this.buttonFillData.Name = "buttonFillData";
            this.buttonFillData.Size = new System.Drawing.Size(131, 83);
            this.buttonFillData.TabIndex = 0;
            this.buttonFillData.Text = "Ввести данные";
            this.buttonFillData.UseVisualStyleBackColor = true;
            this.buttonFillData.Visible = false;
            this.buttonFillData.Click += new System.EventHandler(this.ButtonFill_Click);
            // 
            // buttonCalc
            // 
            this.buttonCalc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCalc.Location = new System.Drawing.Point(3, 270);
            this.buttonCalc.Name = "buttonCalc";
            this.buttonCalc.Size = new System.Drawing.Size(131, 86);
            this.buttonCalc.TabIndex = 1;
            this.buttonCalc.Text = "Рассчитать";
            this.buttonCalc.UseVisualStyleBackColor = true;
            this.buttonCalc.Visible = false;
            this.buttonCalc.Click += new System.EventHandler(this.buttonCalc_Click);
            // 
            // buttonFillVars
            // 
            this.buttonFillVars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFillVars.Location = new System.Drawing.Point(3, 92);
            this.buttonFillVars.Name = "buttonFillVars";
            this.buttonFillVars.Size = new System.Drawing.Size(131, 83);
            this.buttonFillVars.TabIndex = 3;
            this.buttonFillVars.Text = "Ввести названия альтернатив";
            this.buttonFillVars.UseVisualStyleBackColor = true;
            this.buttonFillVars.Visible = false;
            this.buttonFillVars.Click += new System.EventHandler(this.buttonFillVars_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Location = new System.Drawing.Point(4, 372);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Panel1Collapsed = true;
            this.splitContainer2.Panel1MinSize = 0;
            this.splitContainer2.Size = new System.Drawing.Size(881, 116);
            this.splitContainer2.SplitterDistance = 139;
            this.splitContainer2.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer3.Location = new System.Drawing.Point(4, 495);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Panel1Collapsed = true;
            this.splitContainer3.Panel1MinSize = 0;
            this.splitContainer3.Size = new System.Drawing.Size(881, 117);
            this.splitContainer3.SplitterDistance = 141;
            this.splitContainer3.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 640);
            this.Controls.Add(this.tableMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tableMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TableLayoutPanel tableMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button buttonCalc;
        private System.Windows.Forms.Button buttonFillData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonFillCrits;
        private System.Windows.Forms.Button buttonFillVars;
    }
}