using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;       // Marshal
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Diagnostics;

namespace HorzDeployNet
{
    public partial class Form1 : Form
    {
        //-------------------------------------------------------------------------------------
        System.Windows.Forms.Timer gInitialTimer = null;
        System.Windows.Forms.Timer gStatusTimer = null;
        System.Windows.Forms.Timer gWriteTimer = null;
        int gTimerType = 0;      // 0: nothing, 1: read, 2:write, 3:status clear

        int gCount = 0;
        List<object_excel> glstWorkSheet = new List<object_excel>();
        List<string> gFullList = new List<string>();
        Excel.Application excelApp = null;
        Excel.Worksheet MyWorkSheet = null;
        int gNumCols = 0;
        config_values gConfig = new config_values();  // Serialize & Unserialize
        Excel.Workbook workBook = null;

        //-------------------------------------------------------------------------------------
        //============================================================================================
        public Form1()
        {
            InitializeComponent();
            Initialize_Variables();
            this.FormClosed += Form_Closing;
            Enable_Buttons(false);
        }

        //============================================================================================
        private void Form1_Shown(object sender, EventArgs e)
        {
            string objName = Application.StartupPath + "\\last.lst";
            if (File.Exists(objName))
                Load_Clear_List_From_File(objName);

        }

        //============================================================================================
        public void Form_Closing(object sender, FormClosedEventArgs e)
        {
            CloseExcelFile();
        }

        //============================================================================================
        void timer_Handler(object sender, EventArgs e)
        {
            int ret = 0;

            gInitialTimer.Stop();

            switch (gTimerType)
            {
                case 1: // read
                    // get file name
                    string excelFile = textBoxFile.Text;

                    if (File.Exists(excelFile))
                    {
                        int iRet = 0;
                        gConfig.nthSheet = Convert.ToInt32(textSheetLoc.Text);
                        iRet = Read_Excel(excelFile, gConfig.nthSheet);
                        if (iRet >= 0)
                        {
                            gConfig.status = 1;
                            Enable_Buttons(true);
                            toolStripStatusLabel1.Text = "읽기 완료됨";
                        }
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "[### ERROR] 입력파일이 존재하지 않습니다.";
                    }
                    break;

                case 2: // write
                    ret = Write_Excel_Disorder(textNameOutputFile.Text);
                    if (ret < 0)
                    {
                        if (ret == -1)
                            toolStripStatusLabel1.Text = "활성화된 Worksheet가 없습니다";
                        else if (ret == -2)
                            toolStripStatusLabel1.Text = "선택된 항목(열)이 없습니다.";

                        break;
                    }

                    toolStripStatusLabel1.Text = "쓰기 완료됨";
                    string objName = Application.StartupPath + "\\last.lst";
                    Write_Clear_List_To_File(objName);
                    toolStripStatusLabel1.Text = "쓰기 완료됨. 새파일을 생성하려면 설치현황파일을 다시 읽으세요(읽어오기)";
                    break;

                case 3: // status clean
                    break;

                default:
                    break;
            }
        }

        //============================================================================================
        private void btnFile_Click(object sender, EventArgs e)
        {
            // Select Input File
            //파일오픈창 생성 및 설정
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "설치현황파일을 선택하십시오";
            ofd.FileName = "*.xlsx";
            ofd.Filter = "엑셀파일 (*.xlsx) | *.xlsx; | 모든 파일 (*.*) | *.*";

            //파일 오픈창 로드
            DialogResult dr = ofd.ShowDialog();

            //OK버튼 클릭시
            if (dr == DialogResult.OK)
            {
                //File명과 확장자를 가지고 온다.
                string fileName = ofd.SafeFileName;
                //File경로와 File명을 모두 가지고 온다.
                string fileFullName = ofd.FileName;
                //File경로만 가지고 온다.
                string filePath = fileFullName.Replace(fileName, "");

                //출력 예제용 로직
                textBoxFile.Text = fileFullName;
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            CloseExcelFile();

            SetInitialTimer(1);     // reading
            gFullList.Clear();
            checkedListBox1.Items.Clear();
            checkedListPart.Items.Clear();
            checkedListSite.Items.Clear();
            checkedListLine.Items.Clear();


        }

        //============================================================================================
        //============================================================================================
        //============================================================================================
        //============================================================================================
        //============================================================================================
        //============================================================================================
        //============================================================================================
        private void btnWrite_Click(object sender, EventArgs e)
        {
            // export Excel
            Serialize_Object();
            SetInitialTimer(2);     // writing
        }

        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            // Select All Items
            SelectDeselectAll(true);
        }

        private void btnDelectAll_Click(object sender, EventArgs e)
        {
            // Select All Items
            SelectDeselectAll(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //--- add to list (at the end of list)
            for (int i = 0; i < checkedListBox1.Items.Count; i++) // loop to set all items checked or unchecked
            {
                if (checkedListBox1.GetItemChecked(i) == true)
                {
                    listClearSite.Items.Add(checkedListBox1.Items[i].ToString());
                    checkedListBox1.Items.RemoveAt(i);
                    i--;
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int newIndex = listClearSite.SelectedIndex;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= listClearSite.Items.Count)
                return; // Index out of range - nothing to do

            //--- remove from list
            string strReturn = listClearSite.Items[newIndex].ToString();
            listClearSite.Items.RemoveAt(newIndex);

            //--- Update Full list
            checkedListBox1.Items.Clear();
            foreach (var item in gFullList)
            {
                if (!IsExistOnSelectedList(item))
                    checkedListBox1.Items.Add(item.ToString());
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            MoveItem(-1);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            MoveItem(1);
        }

        private void btnSClear_Click(object sender, EventArgs e)
        {
            listClearSite.Items.Clear();
            //--- Update Full list
            checkedListBox1.Items.Clear();
            foreach (var item in gFullList)
            {
                if (!IsExistOnSelectedList(item))
                    checkedListBox1.Items.Add(item.ToString());
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Read ColumnFile
            //      - read column list
            //      - display on list (compare with full list)
            //      - remove from full list & list adjust

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "항목설정 파일을 선택하십시오";
            ofd.FileName = "*.lst";
            ofd.Filter = "항목설정파일 (*.lst) | *.lst; | 모든 파일 (*.*) | *.*";

            //파일 오픈창 로드
            DialogResult dr = ofd.ShowDialog();

            //OK버튼 클릭시
            if (dr == DialogResult.OK)
            {
                //File명과 확장자를 가지고 온다.
                string fileName = ofd.SafeFileName;
                //File경로와 File명을 모두 가지고 온다.
                string fileFullName = ofd.FileName;
                //File경로만 가지고 온다.
                string filePath = fileFullName.Replace(fileName, "");

                Load_Clear_List_From_File(fileFullName);


                //--- Load Option
                int lastIndex = fileFullName.LastIndexOf('.');
                var name = fileFullName.Substring(0, lastIndex);
                string strSelectedFile = name + ".2nd";
                if (File.Exists(strSelectedFile))
                    Load_Options(strSelectedFile);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "항목리스트 파일 | *.lst";
            sfd.Title = "항목리스트 파일 저장";
            DialogResult dr = sfd.ShowDialog();

            // If the file name is not an  string open it for saving.
            //OK버튼 클릭시
            if (dr == DialogResult.OK && sfd.FileName != "")
            {
                Write_Clear_List_To_File(sfd.FileName);
            }
        }

        private void chkPart_CheckedChanged(object sender, EventArgs e)
        {
            checkedListPart.Enabled = chkPart.Checked;
        }

        private void chkSite_CheckedChanged(object sender, EventArgs e)
        {
            checkedListSite.Enabled = chkSite.Checked;
        }

        private void chkLine_CheckedChanged(object sender, EventArgs e)
        {
            checkedListLine.Enabled = chkLine.Checked;
        }

        private void textSheetLoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Serialize_Object();
        }
    }

    //============================================================================================
    [Serializable]
    class object_excel
    {
        public object[,] data;

        public string title;
    }

    //============================================================================================
    [Serializable]
    class config_values
    {
        public string name_sheet;
        public string name_input_file;
        public string name_output_file;
        public bool bSelect_Part;
        public bool bSelect_Site;
        public bool bSelect_Line;
        public string[] part_Names;
        public string[] site_Names;
        public string[] line_Names;
        public int nParts;
        public int nSites;
        public int nLines;
        public bool bUptoPump;
        public int nthSheet;
        public bool oneSheet;    // only one sheet or not (default: 0)
        //--- house keeping
        public int status;      // 0: before read, 1:read
    }

}
