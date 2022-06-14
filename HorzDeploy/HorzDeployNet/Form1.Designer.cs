namespace HorzDeployNet
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFile = new System.Windows.Forms.Button();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.textNameOutputFile = new System.Windows.Forms.TextBox();
            this.groupConfig = new System.Windows.Forms.GroupBox();
            this.checkedListLine = new System.Windows.Forms.CheckedListBox();
            this.chkLine = new System.Windows.Forms.CheckBox();
            this.textNameSheet = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListSite = new System.Windows.Forms.CheckedListBox();
            this.checkedListPart = new System.Windows.Forms.CheckedListBox();
            this.chkPump = new System.Windows.Forms.CheckBox();
            this.chkSite = new System.Windows.Forms.CheckBox();
            this.chkPart = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSClear = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.listClearSite = new System.Windows.Forms.ListBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelectAll = new System.Windows.Forms.Button();
            this.btnAllSelect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupConfig.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(14, 25);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(121, 31);
            this.btnFile.TabIndex = 0;
            this.btnFile.Text = "설치현황 파일...";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // textBoxFile
            // 
            this.textBoxFile.Location = new System.Drawing.Point(143, 31);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.Size = new System.Drawing.Size(307, 21);
            this.textBoxFile.TabIndex = 1;
            // 
            // btnRead
            // 
            this.btnRead.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnRead.Location = new System.Drawing.Point(14, 62);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(121, 31);
            this.btnRead.TabIndex = 2;
            this.btnRead.Text = "읽어오기";
            this.btnRead.UseVisualStyleBackColor = false;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnWrite.Location = new System.Drawing.Point(14, 487);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(121, 31);
            this.btnWrite.TabIndex = 3;
            this.btnWrite.Text = "새파일 만들기";
            this.btnWrite.UseVisualStyleBackColor = false;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // textNameOutputFile
            // 
            this.textNameOutputFile.Location = new System.Drawing.Point(142, 497);
            this.textNameOutputFile.Name = "textNameOutputFile";
            this.textNameOutputFile.Size = new System.Drawing.Size(308, 21);
            this.textNameOutputFile.TabIndex = 4;
            // 
            // groupConfig
            // 
            this.groupConfig.Controls.Add(this.checkedListLine);
            this.groupConfig.Controls.Add(this.chkLine);
            this.groupConfig.Controls.Add(this.textNameSheet);
            this.groupConfig.Controls.Add(this.label1);
            this.groupConfig.Controls.Add(this.checkedListSite);
            this.groupConfig.Controls.Add(this.checkedListPart);
            this.groupConfig.Controls.Add(this.chkPump);
            this.groupConfig.Controls.Add(this.chkSite);
            this.groupConfig.Controls.Add(this.chkPart);
            this.groupConfig.Location = new System.Drawing.Point(15, 110);
            this.groupConfig.Name = "groupConfig";
            this.groupConfig.Size = new System.Drawing.Size(435, 350);
            this.groupConfig.TabIndex = 5;
            this.groupConfig.TabStop = false;
            this.groupConfig.Text = "옵션설정";
            // 
            // checkedListLine
            // 
            this.checkedListLine.CheckOnClick = true;
            this.checkedListLine.FormattingEnabled = true;
            this.checkedListLine.Location = new System.Drawing.Point(298, 50);
            this.checkedListLine.Name = "checkedListLine";
            this.checkedListLine.Size = new System.Drawing.Size(131, 228);
            this.checkedListLine.TabIndex = 8;
            // 
            // chkLine
            // 
            this.chkLine.AutoSize = true;
            this.chkLine.Location = new System.Drawing.Point(298, 27);
            this.chkLine.Name = "chkLine";
            this.chkLine.Size = new System.Drawing.Size(99, 16);
            this.chkLine.TabIndex = 7;
            this.chkLine.Text = "<라인> 선택";
            this.chkLine.UseVisualStyleBackColor = true;
            this.chkLine.CheckedChanged += new System.EventHandler(this.chkLine_CheckedChanged);
            // 
            // textNameSheet
            // 
            this.textNameSheet.Location = new System.Drawing.Point(167, 322);
            this.textNameSheet.Name = "textNameSheet";
            this.textNameSheet.Size = new System.Drawing.Size(231, 21);
            this.textNameSheet.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sheet 이름:";
            // 
            // checkedListSite
            // 
            this.checkedListSite.CheckOnClick = true;
            this.checkedListSite.FormattingEnabled = true;
            this.checkedListSite.Location = new System.Drawing.Point(151, 50);
            this.checkedListSite.Name = "checkedListSite";
            this.checkedListSite.Size = new System.Drawing.Size(131, 228);
            this.checkedListSite.TabIndex = 4;
            // 
            // checkedListPart
            // 
            this.checkedListPart.CheckOnClick = true;
            this.checkedListPart.FormattingEnabled = true;
            this.checkedListPart.Location = new System.Drawing.Point(7, 50);
            this.checkedListPart.Name = "checkedListPart";
            this.checkedListPart.Size = new System.Drawing.Size(130, 228);
            this.checkedListPart.TabIndex = 3;
            // 
            // chkPump
            // 
            this.chkPump.AutoSize = true;
            this.chkPump.Location = new System.Drawing.Point(9, 299);
            this.chkPump.Name = "chkPump";
            this.chkPump.Size = new System.Drawing.Size(107, 16);
            this.chkPump.TabIndex = 2;
            this.chkPump.Text = "PUMP 까지만";
            this.chkPump.UseVisualStyleBackColor = true;
            // 
            // chkSite
            // 
            this.chkSite.AutoSize = true;
            this.chkSite.Location = new System.Drawing.Point(151, 27);
            this.chkSite.Name = "chkSite";
            this.chkSite.Size = new System.Drawing.Size(98, 16);
            this.chkSite.TabIndex = 1;
            this.chkSite.Text = "<Site> 선택";
            this.chkSite.UseVisualStyleBackColor = true;
            this.chkSite.CheckedChanged += new System.EventHandler(this.chkSite_CheckedChanged);
            // 
            // chkPart
            // 
            this.chkPart.AutoSize = true;
            this.chkPart.Location = new System.Drawing.Point(7, 27);
            this.chkPart.Name = "chkPart";
            this.chkPart.Size = new System.Drawing.Size(112, 16);
            this.chkPart.TabIndex = 0;
            this.chkPart.Text = "<사업부> 선택";
            this.chkPart.UseVisualStyleBackColor = true;
            this.chkPart.CheckedChanged += new System.EventHandler(this.chkPart_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 482);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "출력파일 이름:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnLoad);
            this.groupBox2.Controls.Add(this.btnSClear);
            this.groupBox2.Controls.Add(this.btnDown);
            this.groupBox2.Controls.Add(this.btnUp);
            this.groupBox2.Controls.Add(this.listClearSite);
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnDelectAll);
            this.groupBox2.Controls.Add(this.btnAllSelect);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.checkedListBox1);
            this.groupBox2.Location = new System.Drawing.Point(487, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(803, 493);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "항목 선택";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(415, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "출력항목 및 순서:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(707, 445);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "저장하기...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(707, 407);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(86, 23);
            this.btnLoad.TabIndex = 15;
            this.btnLoad.Text = "불러오기...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSClear
            // 
            this.btnSClear.Location = new System.Drawing.Point(707, 187);
            this.btnSClear.Name = "btnSClear";
            this.btnSClear.Size = new System.Drawing.Size(86, 23);
            this.btnSClear.TabIndex = 14;
            this.btnSClear.Text = "전부제거";
            this.btnSClear.UseVisualStyleBackColor = true;
            this.btnSClear.Click += new System.EventHandler(this.btnSClear_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(707, 105);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(86, 23);
            this.btnDown.TabIndex = 13;
            this.btnDown.Text = "아래 이동";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(707, 72);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(86, 23);
            this.btnUp.TabIndex = 12;
            this.btnUp.Text = "위로 이동";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // listClearSite
            // 
            this.listClearSite.FormattingEnabled = true;
            this.listClearSite.ItemHeight = 12;
            this.listClearSite.Location = new System.Drawing.Point(417, 50);
            this.listClearSite.Name = "listClearSite";
            this.listClearSite.Size = new System.Drawing.Size(282, 436);
            this.listClearSite.TabIndex = 11;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(325, 115);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(86, 23);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "<==";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(325, 85);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "==>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelectAll
            // 
            this.btnDelectAll.Location = new System.Drawing.Point(231, 21);
            this.btnDelectAll.Name = "btnDelectAll";
            this.btnDelectAll.Size = new System.Drawing.Size(86, 23);
            this.btnDelectAll.TabIndex = 8;
            this.btnDelectAll.Text = "전부해제";
            this.btnDelectAll.UseVisualStyleBackColor = true;
            this.btnDelectAll.Click += new System.EventHandler(this.btnDelectAll_Click);
            // 
            // btnAllSelect
            // 
            this.btnAllSelect.Location = new System.Drawing.Point(139, 21);
            this.btnAllSelect.Name = "btnAllSelect";
            this.btnAllSelect.Size = new System.Drawing.Size(86, 23);
            this.btnAllSelect.TabIndex = 7;
            this.btnAllSelect.Text = "전부선택";
            this.btnAllSelect.UseVisualStyleBackColor = true;
            this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "항목리스트:";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(7, 50);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(309, 436);
            this.checkedListBox1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 527);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1304, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(203, 17);
            this.toolStripStatusLabel1.Text = "설치현황파일을 읽으세요 (읽어오기)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 549);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupConfig);
            this.Controls.Add(this.textNameOutputFile);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.textBoxFile);
            this.Controls.Add(this.btnFile);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "항목편집 프로그램 (v1.0.1)";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupConfig.ResumeLayout(false);
            this.groupConfig.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.TextBox textNameOutputFile;
        private System.Windows.Forms.GroupBox groupConfig;
        private System.Windows.Forms.TextBox textNameSheet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListSite;
        private System.Windows.Forms.CheckedListBox checkedListPart;
        private System.Windows.Forms.CheckBox chkPump;
        private System.Windows.Forms.CheckBox chkSite;
        private System.Windows.Forms.CheckBox chkPart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSClear;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.ListBox listClearSite;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelectAll;
        private System.Windows.Forms.Button btnAllSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.CheckedListBox checkedListLine;
        private System.Windows.Forms.CheckBox chkLine;
    }
}

