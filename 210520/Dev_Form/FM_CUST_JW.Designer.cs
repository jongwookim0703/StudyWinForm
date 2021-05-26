
namespace Dev_Form
{
    partial class FM_CUST_JW
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStartC = new System.Windows.Forms.DateTimePicker();
            this.dtpEndC = new System.Windows.Forms.DateTimePicker();
            this.btnSearchC = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkCustOnlyC = new System.Windows.Forms.CheckBox();
            this.rbo1C = new System.Windows.Forms.RadioButton();
            this.rbo2C = new System.Windows.Forms.RadioButton();
            this.rbo3C = new System.Windows.Forms.RadioButton();
            this.rbo4C = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtcustnameC = new System.Windows.Forms.TextBox();
            this.txtcustcodeC = new System.Windows.Forms.TextBox();
            this.dgvGridC = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGridC)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(824, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "거래일자";
            // 
            // dtpStartC
            // 
            this.dtpStartC.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartC.Location = new System.Drawing.Point(899, 36);
            this.dtpStartC.Name = "dtpStartC";
            this.dtpStartC.Size = new System.Drawing.Size(105, 27);
            this.dtpStartC.TabIndex = 1;
            this.dtpStartC.Value = new System.DateTime(2021, 5, 25, 0, 0, 0, 0);
            // 
            // dtpEndC
            // 
            this.dtpEndC.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndC.Location = new System.Drawing.Point(1036, 36);
            this.dtpEndC.Name = "dtpEndC";
            this.dtpEndC.Size = new System.Drawing.Size(105, 27);
            this.dtpEndC.TabIndex = 2;
            this.dtpEndC.Value = new System.DateTime(2021, 5, 25, 0, 0, 0, 0);
            // 
            // btnSearchC
            // 
            this.btnSearchC.BackColor = System.Drawing.SystemColors.Info;
            this.btnSearchC.Location = new System.Drawing.Point(834, 107);
            this.btnSearchC.Name = "btnSearchC";
            this.btnSearchC.Size = new System.Drawing.Size(169, 57);
            this.btnSearchC.TabIndex = 3;
            this.btnSearchC.Text = "조회";
            this.btnSearchC.UseVisualStyleBackColor = false;
            this.btnSearchC.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "거래처코드";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "거래처명";
            // 
            // chkCustOnlyC
            // 
            this.chkCustOnlyC.AutoSize = true;
            this.chkCustOnlyC.Location = new System.Drawing.Point(18, 112);
            this.chkCustOnlyC.Name = "chkCustOnlyC";
            this.chkCustOnlyC.Size = new System.Drawing.Size(126, 24);
            this.chkCustOnlyC.TabIndex = 6;
            this.chkCustOnlyC.Text = "고객사만 검색";
            this.chkCustOnlyC.UseVisualStyleBackColor = true;
            // 
            // rbo1C
            // 
            this.rbo1C.AutoSize = true;
            this.rbo1C.Checked = true;
            this.rbo1C.Location = new System.Drawing.Point(6, 37);
            this.rbo1C.Name = "rbo1C";
            this.rbo1C.Size = new System.Drawing.Size(110, 24);
            this.rbo1C.TabIndex = 7;
            this.rbo1C.TabStop = true;
            this.rbo1C.Text = "상용차 부품";
            this.rbo1C.UseVisualStyleBackColor = true;
            // 
            // rbo2C
            // 
            this.rbo2C.AutoSize = true;
            this.rbo2C.Location = new System.Drawing.Point(122, 37);
            this.rbo2C.Name = "rbo2C";
            this.rbo2C.Size = new System.Drawing.Size(105, 24);
            this.rbo2C.TabIndex = 8;
            this.rbo2C.Text = "자동차부품";
            this.rbo2C.UseVisualStyleBackColor = true;
            // 
            // rbo3C
            // 
            this.rbo3C.AutoSize = true;
            this.rbo3C.Location = new System.Drawing.Point(228, 37);
            this.rbo3C.Name = "rbo3C";
            this.rbo3C.Size = new System.Drawing.Size(90, 24);
            this.rbo3C.TabIndex = 9;
            this.rbo3C.Text = "절삭가공";
            this.rbo3C.UseVisualStyleBackColor = true;
            // 
            // rbo4C
            // 
            this.rbo4C.AutoSize = true;
            this.rbo4C.Location = new System.Drawing.Point(326, 37);
            this.rbo4C.Name = "rbo4C";
            this.rbo4C.Size = new System.Drawing.Size(105, 24);
            this.rbo4C.TabIndex = 10;
            this.rbo4C.Text = "펌프압축기";
            this.rbo4C.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtcustnameC);
            this.groupBox1.Controls.Add(this.txtcustcodeC);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkCustOnlyC);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpStartC);
            this.groupBox1.Controls.Add(this.dtpEndC);
            this.groupBox1.Controls.Add(this.btnSearchC);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1173, 176);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "거래처조회";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbo1C);
            this.groupBox2.Controls.Add(this.rbo2C);
            this.groupBox2.Controls.Add(this.rbo3C);
            this.groupBox2.Controls.Add(this.rbo4C);
            this.groupBox2.Location = new System.Drawing.Point(296, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(461, 79);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "종목";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1010, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "~";
            // 
            // txtcustnameC
            // 
            this.txtcustnameC.Location = new System.Drawing.Point(328, 33);
            this.txtcustnameC.Name = "txtcustnameC";
            this.txtcustnameC.Size = new System.Drawing.Size(125, 27);
            this.txtcustnameC.TabIndex = 12;
            // 
            // txtcustcodeC
            // 
            this.txtcustcodeC.Location = new System.Drawing.Point(108, 33);
            this.txtcustcodeC.Name = "txtcustcodeC";
            this.txtcustcodeC.Size = new System.Drawing.Size(125, 27);
            this.txtcustcodeC.TabIndex = 11;
            // 
            // dgvGridC
            // 
            this.dgvGridC.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvGridC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGridC.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvGridC.Location = new System.Drawing.Point(3, 58);
            this.dgvGridC.Name = "dgvGridC";
            this.dgvGridC.RowHeadersWidth = 51;
            this.dgvGridC.RowTemplate.Height = 29;
            this.dgvGridC.Size = new System.Drawing.Size(1167, 299);
            this.dgvGridC.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.dgvGridC);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 176);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1173, 360);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "거래처 정보";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(203, 23);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 29);
            this.button4.TabIndex = 14;
            this.button4.Text = "저장";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(103, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 29);
            this.button3.TabIndex = 13;
            this.button3.Text = "삭제";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 12;
            this.button2.Text = "추가";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FM_CUST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 536);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "FM_CUST";
            this.Text = "FM_CUST";
            this.Load += new System.EventHandler(this.FM_CUST_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGridC)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStartC;
        private System.Windows.Forms.DateTimePicker dtpEndC;
        private System.Windows.Forms.Button btnSearchC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkCustOnlyC;
        private System.Windows.Forms.RadioButton rbo1C;
        private System.Windows.Forms.RadioButton rbo2C;
        private System.Windows.Forms.RadioButton rbo3C;
        private System.Windows.Forms.RadioButton rbo4C;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtcustnameC;
        private System.Windows.Forms.TextBox txtcustcodeC;
        private System.Windows.Forms.DataGridView dgvGridC;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}