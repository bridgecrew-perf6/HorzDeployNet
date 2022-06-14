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
        //============================================================================================
        static class Constants
        {
            public const int MAX_SHEET = 11;
        }

        //============================================================================================
        private void CloseExcelFile()
        {
            object missing = Type.Missing;
            object noSave = false;
            if (workBook != null)
                workBook.Close(noSave, missing, missing);
            workBook = null;

            ReleaseObject(workBook);
            ReleaseObject(excelApp);
            Enable_Buttons(false);
            toolStripStatusLabel1.Text = "설치현황파일을 읽으세요(읽어오기)";
        }

        //============================================================================================
        void Deserialize_Object()
        {
            string objName = Application.StartupPath + "\\cs_config.bin";
            if (!File.Exists(objName))
            {
                gConfig.name_input_file = "c:\\temp\\test2.xlsx";
                gConfig.name_output_file = "c:\\temp\\output_2.xlsx";
                gConfig.name_sheet = "항목편집";
                gConfig.bUptoPump = false;
                gConfig.nParts = 0;
                gConfig.nSites = 0;
                gConfig.nLines = 0;
                gConfig.bSelect_Part = false;
                gConfig.bSelect_Site = false;
                gConfig.bSelect_Line = false;
                return;
            }

            //deserialize
            string serializationFile = Path.Combine(Application.StartupPath, "cs_config.bin");
            using (Stream stream = File.Open(serializationFile, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                glstWorkSheet.Clear();
                gConfig = (config_values)bformatter.Deserialize(stream);
            }

        }

        //============================================================================================
        //--- 입력 파일 Read후
        //    설정 그룹, 버튼들 (Write, Load, Save)
        private void Enable_Buttons(bool bEnable)
        {
            groupConfig.Enabled = bEnable;
            btnWrite.Enabled = bEnable;
            btnLoad.Enabled = bEnable;
            btnSave.Enabled = bEnable;
        }

        //=========================================================================================
        /// <summary>
        /// 해당 WorkSheet의 전체 데이터를 가져온다.
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        // 출처: https://ehdrn.tistory.com/431 [동구의 블로그]
        private object[,] GetTotalValue(Excel.Worksheet sheet)
        {

            //사용중인 범위(한번도 사용하지 않은 범위는 포함되지 않음)
            Excel.Range usedRange = sheet.UsedRange;

            //마지막 Cell
            Excel.Range lastCell = usedRange.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);

            //전체 범위 (왼쪽 상단의 Cell부터 사용한 맨마지막 범위까지)
            Excel.Range totalRange = sheet.get_Range(sheet.get_Range("A1"), lastCell);

            return (object[,])totalRange.get_Value();

        }

        //============================================================================================
        //============================================================================================
        //============================================================================================
        //============================================================================================
        private void Initialize_Variables()
        {
            gConfig.part_Names = new string[20];
            gConfig.site_Names = new string[20];
            gConfig.line_Names = new string[20];
            Deserialize_Object();
            textBoxFile.Text = gConfig.name_input_file; // "c:\\temp\\test2.xlsx";
            textNameSheet.Text = gConfig.name_sheet;
            textNameOutputFile.Text = gConfig.name_output_file;
            chkPart.Checked = gConfig.bSelect_Part;
            chkSite.Checked = gConfig.bSelect_Site;
            chkLine.Checked = gConfig.bSelect_Line;
            chkPump.Checked = gConfig.bUptoPump;

            return;
        }

        //============================================================================================
        private bool IsExsitInList(List<string> list1, string str)
        {
            foreach (string item in list1)
            {
                if (item == str)
                    return true;
            }

            return false;
        }

        //============================================================================================
        private bool IsExistOnSelectedList(string item)
        {
            foreach (var iTarget in listClearSite.Items)
            {
                string str = iTarget.ToString();
                if (item == str)
                    return true;
            }

            return false;
        }

        //============================================================================================
        // 사업부와 Site체크여부 
        private bool IsIncludeInTheList(bool bPart, CheckedListBox lstPart, string valuePart, bool bSite, CheckedListBox lstSite, string valueSite, bool bLine, CheckedListBox lstLine, string valueLine)
        {
            bool OkPart = false;    // 모두 true여야 출력에 포함된다.
            bool OkSite = false;
            bool OkLine = false;

            //--- check Part
            if (bPart)
            {


                for (int i = 0; i < lstPart.Items.Count; i++) // loop to set all items checked or unchecked
                {
                    if (lstPart.GetItemChecked(i) == true && valuePart == lstPart.Items[i].ToString())
                    {
                        OkPart = true;
                        break;
                    }
                }
            }
            else
            {
                OkPart = true; 
            }

            //--- check Site
            if (bSite)
            {


                for (int i = 0; i < lstSite.Items.Count; i++) // loop to set all items checked or unchecked
                {
                    if (lstSite.GetItemChecked(i) == true && valueSite == lstSite.Items[i].ToString())
                    {
                        OkSite = true;
                        break;
                    }
                }
            }
            else
            {
                OkSite = true;
            }

            //--- check Part
            if (bLine)
            {


                for (int i = 0; i < lstLine.Items.Count; i++) // loop to set all items checked or unchecked
                {
                    if (lstLine.GetItemChecked(i) == true && valueLine == lstLine.Items[i].ToString())
                    {
                        OkLine = true;
                        break;
                    }
                }
            }
            else
            {
                OkLine = true;
            }

            if (OkPart && OkSite && OkLine)
                return true;

            return false;

            /************************************************************
            if (bPart)
            {
                for (int i = 0; i < lstPart.Items.Count; i++) // loop to set all items checked or unchecked
                {
                    if (lstPart.GetItemChecked(i) == true && valuePart == lstPart.Items[i].ToString())
                    {
                        if (bSite)
                        {
                            for (int k = 0; k < lstSite.Items.Count; k++) // loop to set all items checked or unchecked
                            {
                                if (lstSite.GetItemChecked(k) == true && valueSite == lstSite.Items[k].ToString())
                                {
                                    return true;
                                }
                            }

                            return false;

                        }
                        else   // Only Part
                            return true;
                    }
                }
            }
            else if (bSite)
            {
                for (int i = 0; i < lstSite.Items.Count; i++) // loop to set all items checked or unchecked
                {
                    if (lstSite.GetItemChecked(i) == true && valueSite == lstSite.Items[i].ToString())
                    {
                        return true;
                    }
                }
            }
            return false;
            ************************************************/
        }

        //============================================================================================
        private void Load_Clear_List_From_File(string filename)
        {
            listClearSite.Items.Clear();


            // Read the file and display it line by line.  
            foreach (string line in System.IO.File.ReadLines(filename))
            {
                listClearSite.Items.Add(line);
                Remove_From_FullList(line);
            }
        }
        private void Load_Options(string filename)
        {
            int [] iValue = { 0, 0, 0, 0, 0, 0 };
            string[] strValue = { "0", "0", "0", "0", "0", "0" };
            int iTest = 0;

            strValue = System.IO.File.ReadAllLines(filename);

            for (int i = 0; i < 6; i++)
            {
                iValue[i] = Convert.ToInt32(strValue[i]);
            }

            chkPart.Checked = iValue[0] != 0 ? true : false;
            for (int i = 0; i < gConfig.nParts; i++)
            {
                iTest =  (iValue[1] >> i ) & 0x01;
                checkedListPart.SetItemChecked(i, iTest == 0 ? false : true);    
                
            }

            chkSite.Checked = iValue[2] != 0 ? true : false;
            for (int i = 0; i < gConfig.nSites; i++)
            {
                iTest = (iValue[3] >> i) & 0x01;
                checkedListSite.SetItemChecked(i, iTest == 0 ? false : true);
            }

            chkLine.Checked = iValue[4] != 0 ? true : false;
            for (int i = 0; i < gConfig.nLines; i++)
            {
                iTest = (iValue[5] >> i) & 0x01;
                checkedListLine.SetItemChecked(i, iTest == 0 ? false : true);
            }
        }

        //============================================================================================
        // Move Up & Down
        public void MoveItem(int direction)
        {
            // Checking selected item
            if (listClearSite.SelectedItem == null || listClearSite.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = listClearSite.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= listClearSite.Items.Count)
                return; // Index out of range - nothing to do

            object selected = listClearSite.SelectedItem;

            // Removing removable element
            listClearSite.Items.Remove(selected);
            // Insert it in new position
            listClearSite.Items.Insert(newIndex, selected);
            // Restore selection
            listClearSite.SetSelected(newIndex, true);
        }

        //============================================================================================
        //---- Extract BusiPart, objName
        private void Process_WorkSheet(object_excel sheet)
        {
            string[] stritems = new string[4];
            string rowString = "";
            object[,] data = sheet.data;
            string strPart = "";
            string strSite = "";
            string strLine = "";

            strPart = data[6, 4].ToString();
            strSite = data[6, 5].ToString();
            strLine = data[6, 7].ToString();
            if (strPart != "사업부" || strSite != "Site" || strLine !="라인")
            {
                // Something Wrong
                return;
            }

            List<string> lpart = new List<string>();
            List<string> lsite = new List<string>();
            List<string> lline = new List<string>();

            //--- Add Part
            gConfig.nParts = 0;
            gConfig.nLines = 0;
            gConfig.nSites = 0;

            //--- Add Site
            for (int r = 7; r <= data.GetLength(0); r++)        // row
            {
                if (data[r, 4] != null)
                {
                    rowString = data[r, 4].ToString();
                    if (!IsExsitInList(lpart, rowString))
                    {
                        checkedListPart.Items.Add(rowString);
                        lpart.Add(rowString);
                        gConfig.nParts++;
                    }
                }
                if (data[r, 5] != null)
                {
                    rowString = data[r, 5].ToString();
                    if (!IsExsitInList(lsite, rowString))
                    {
                        checkedListSite.Items.Add(rowString);
                        lsite.Add(rowString);
                        gConfig.nSites++;
                    }
                }

                if (data[r, 7] != null)
                {
                    rowString = data[r, 7].ToString();
                    if (!IsExsitInList(lline, rowString))
                    {
                        checkedListLine.Items.Add(rowString);
                        lline.Add(rowString);
                        gConfig.nLines++;
                    }
                }
            }

            //---- check/uncheck part, site, line
            //     Read from ./last.lst.2nd
            //     
            string objName = Application.StartupPath + "\\last.lst.2nd";
            if (File.Exists(objName))
                Load_Options(objName);

        }

        //============================================================================================
        // sheetNum: 0=all, 1=1stWorksheet
        private int Read_Excel(string strFilename, int sheetNum)
        {
            if (File.Exists(strFilename) == false)
            {
                return - 1;
            }

            try
            {
                excelApp = new Excel.Application();
                workBook = excelApp.Workbooks.Open(strFilename,
                    0,
                    true,
                    5,
                    "",
                    "",
                    true,
                    Excel.XlPlatform.xlWindows,
                    "\t",
                    false,
                    false,
                    0,
                    true,
                    1,
                    0);

                gCount = 0;
                int index = 0;
                foreach (Excel.Worksheet workSheet in workBook.Worksheets)
                {

                    index++;
                    if (sheetNum != 0 && index != sheetNum)
                        continue;

                    object_excel obj = new object_excel();
                    obj.data = GetTotalValue(workSheet);
                    obj.title = workSheet.Name;
                    glstWorkSheet.Add(obj);

                    gCount++;
                    if (gCount >= Constants.MAX_SHEET)
                        break;

                    if (sheetNum == 3)
                    {
                        MyWorkSheet = workSheet;
                        workSheet.Name = textNameSheet.Text;

                        //--- if 완료수량 --> 완료일자
                        for (int k = 0; k < obj.data.GetLength(1); k++)
                        {
                            string text1 = obj.data[6, k + 1] != null ? obj.data[6, k + 1].ToString() : "---";
                            if (text1 == "완료수량")
                            {
                                workSheet.Cells[6, k + 1].Value = "완료일자";
                            }
                        }

                        for (int j = 1; j < obj.data.GetLength(1); j++)
                        {
                            if (obj.data[6, j] == null)
                            {
                                toolStripStatusLabel1.Text = "[### ERROR] " + j.ToString() + "번째 열의 이름이 없습니다.";
                                return -2;  // 항목 이름이 없음.
                            }
                            string rowString = obj.data[6, j] != null ? obj.data[6, j].ToString() : "###";
                            if (rowString == "대상수량")
                            {
                                gNumCols = j - 1;
                                break;
                            }
                            rowString = rowString.Replace("\n", " ");
                            checkedListBox1.Items.Add(rowString, CheckState.Checked);
                            gFullList.Add(rowString);       // Read Only. Original Full
                        }
                    }
                }

                int iCol = 0, iRow = 0;
                iRow = glstWorkSheet[0].data.GetLength(0);
                iCol = glstWorkSheet[0].data.GetLength(1);
                Process_WorkSheet(glstWorkSheet[0]);
                RemoveColumnFromFullList();
            }
            finally
            {
            }

            return 0;
        }

        //============================================================================================
        void ReleaseObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }

        //============================================================================================
        //---- remove all lists
        private void RemoveColumnFromFullList()
        {
            if (listClearSite.Items.Count <= 0)
                return;

            foreach (string line in listClearSite.Items)
            {
                Remove_From_FullList(line);
            }


        }

        //============================================================================================
        private void Remove_From_FullList(string line)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++) // loop to set all items checked or unchecked
            {
                if (line == checkedListBox1.Items[i].ToString())
                {
                    checkedListBox1.Items.RemoveAt(i);
                    i--;
                }
            }

        }

        //============================================================================================
        void SelectDeselectAll(bool Selected)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++) // loop to set all items checked or unchecked
            {
                checkedListBox1.SetItemChecked(i, Selected);
            }
        }

        //============================================================================================
        void Serialize_Object()
        {

            gConfig.bSelect_Site = chkSite.Checked;
            gConfig.bSelect_Part = chkPart.Checked;
            gConfig.bSelect_Line = chkLine.Checked;
            gConfig.bUptoPump = chkPump.Checked;
            gConfig.name_input_file = textBoxFile.Text;
            gConfig.name_output_file = textNameOutputFile.Text;
            gConfig.name_sheet = textNameSheet.Text;

            //serialize
            string serializationFile = Path.Combine(Application.StartupPath, "cs_config.bin");
            using (Stream stream = File.Open(serializationFile, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, gConfig);
            }

        }

        private void SetInitialTimer(int iTimerType)
        {
            gTimerType = iTimerType;
            gInitialTimer = new System.Windows.Forms.Timer();
            gInitialTimer.Interval = 1;
            gInitialTimer.Tick += new EventHandler(timer_Handler);
            gInitialTimer.Start();

            if (gTimerType == 1)
            {
                toolStripStatusLabel1.Text = "파일 읽는 중..., 잠시 기다리세요";
            } else if (gTimerType == 2)
            {
                toolStripStatusLabel1.Text = "파일 생성중..., 잠시 기다리세요";
            }
        }

        //============================================================================================
        private void Write_Clear_List_To_File(string filename)
        {
            using (TextWriter tw = new StreamWriter(filename))
            {
                foreach (var item in listClearSite.Items)
                {
                    tw.WriteLine(item.ToString());
                }
            }

            int i = 0;
            UInt32 uChecked = 0;
            string strSelectedFile = filename + ".2nd";
            using (TextWriter tw = new StreamWriter(strSelectedFile))
            {
                uChecked = 0;
                tw.WriteLine(chkPart.Checked ? "1" : "0");
                for (i = 0; i < checkedListPart.Items.Count; i++)
                {
                    if (checkedListPart.GetItemChecked(i) == true)
                        uChecked |= (UInt32)(1 << i);
                }
                tw.WriteLine(uChecked.ToString());

                uChecked = 0;
                tw.WriteLine(chkSite.Checked ? "1" : "0");
                for (i = 0; i < checkedListSite.Items.Count; i++)
                {
                    if (checkedListSite.GetItemChecked(i) == true)
                        uChecked |= (UInt32)(1 << i);
                }
                tw.WriteLine(uChecked.ToString());

                uChecked = 0;
                tw.WriteLine(chkLine.Checked ? "1" : "0");
                for (i = 0; i < checkedListLine.Items.Count; i++)
                {
                    if (checkedListLine.GetItemChecked(i) == true)
                        uChecked |= (UInt32)(1 << i);
                }
                tw.WriteLine(uChecked.ToString());

            }
        }

        //============================================================================================
        // return error code : >=0 : OK
        // 설정에 맞춰 엑셀파일 생성하기
        // (순서)
        //          1. pump가 체크되어 있으면 pump 이후 열은 삭제
        //          2. 사업부나 Site가 선택되어 있으면 해당 사항이 없는 행은 삭제
        //          3. list에 없는 열은 삭제
        //          
        private int Write_Excel_Disorder(string strFile)
        {
            if (MyWorkSheet == null)
                return -1;      // no active worksheet

            int iNumInsert = listClearSite.Items.Count;

            if (iNumInsert <= 0)
                return -2;      // no column selected;

            // input parameter : column name list, pump까지, Site선택, 사업부 선택

            /* if (pump) delete the columns after pump
             * if (site or 사업부) delete Rows
             * remove no selected columns
             * move columns 
             * Save workbook */

            //----------------------------------------------------------------------------------------
            // if (pump) delete the columns after pump
            string str = "";
            if (chkPump.Checked == true)
            {
                if (MyWorkSheet != null)
                {
                    // delete in reverse order if not checked
                    int iTotalCols = glstWorkSheet[0].data.GetLength(1);
                    for (int i = iTotalCols - 1; i >= 0; i--)
                    {
                        string text1 = glstWorkSheet[0].data[6, i + 1] != null ? glstWorkSheet[0].data[6, i + 1].ToString() : "---";
                        if (text1 == "PUMP")
                        {
                            //Excel.Range range = MyWorkSheet.get_Range(MyWorkSheet.Cells[6, i + 2], MyWorkSheet.Cells[6, iTotalCols]);
                            Excel.Range range = MyWorkSheet.Range[MyWorkSheet.Cells[6, i + 2], MyWorkSheet.Cells[6, iTotalCols]];
                            range.EntireColumn.Delete();
                            //range.Delete();
                            break;
                        }
                        // MyWorkSheet.Columns[i + 1].Delete();
                    }
                }
            }

            //----------------------------------------------------------------------------------------
            // 2. 사업부/Site/Line 이 선택되어 있으면 해당 사항이 없는 행은 삭제
            if (chkPart.Checked == true || chkSite.Checked == true || chkLine.Checked == true)     // column4, column5, colimn7
            {
                if (MyWorkSheet != null)
                {
                    int iStart = 0; // 삭제할 row 시작점 선택됨
                    int ixStart = 0, ixEnd = 0; // 삭제할 row 시작과 끝
                    int i = 0;
                    string strPart = "";
                    string strSite = "";
                    string strLine = "";
                    for (i = glstWorkSheet[0].data.GetLength(0); i >= 7; i--)
                    {

                        if (i == 9)
                            i = i;

                        strPart = glstWorkSheet[0].data[i, 4] != null ? glstWorkSheet[0].data[i, 4].ToString() : "YUYU";
                        strSite = glstWorkSheet[0].data[i, 5] != null ? glstWorkSheet[0].data[i, 5].ToString() : "YUYU";
                        strLine = glstWorkSheet[0].data[i, 7] != null ? glstWorkSheet[0].data[i, 7].ToString() : "YUYU";
                        if (IsIncludeInTheList(chkPart.Checked, checkedListPart, strPart,
                                               chkSite.Checked, checkedListSite, strSite, 
                                               chkLine.Checked, checkedListLine, strLine))
                        {
                            if (iStart == 0)
                                continue;

                            ixEnd = i;
                            iStart = 0;

                            Excel.Range range = MyWorkSheet.Range[MyWorkSheet.Cells[ixEnd + 1, 4], MyWorkSheet.Cells[ixStart, 4]];
                            range.EntireRow.Delete();
                        }
                        else
                        {
                            if (iStart == 1)
                                continue;

                            ixStart = i;
                            iStart = 1;

                        }
                    }

                    //--- last rows
                    if (iStart == 1)
                    {
                        Excel.Range range = MyWorkSheet.Range[MyWorkSheet.Cells[i + 1, 4], MyWorkSheet.Cells[ixStart, 4]];
                        range.EntireRow.Delete();
                    }
                }
            }

            //----------------------------------------------------------------------------------------
            //--- move & remove columns

            //--- 유효한 컬럼 수 계산 : 공백이나 "대상수량" 나올때까지.
            int iValidNumCol = 0;
            for (int j = 1; j < 200; j++)
            {
                if (MyWorkSheet.Cells[6, j].Value == null)
                    break;
                string colName = MyWorkSheet.Cells[6, j].Value.ToString();

                if (colName == "대상수량")
                    break;

                iValidNumCol++;
            }


            //--- list에 있는 item만큼 열 추가
            Excel.Range rCols = (Excel.Range)MyWorkSheet.Columns[1];
            for (int i = 0; i < iNumInsert; i++)
                rCols.Insert();

            //--- list에 있는 열을 찾아서 삽입한 열에 차례대로 복사
            for (int i = 0; i < listClearSite.Items.Count; i++) // loop to set all items checked or unchecked
            {
                string nameCol = listClearSite.Items[i].ToString();

                for (int j = iNumInsert + 1; j <= (iValidNumCol + iNumInsert); j++)
                {
                    string rowString = MyWorkSheet.Cells[6, j].Value.ToString();
                    rowString = rowString.Replace("\n", " ");
                    if (rowString == "대상수량")
                    {
                        break;
                    }

                    if (nameCol == rowString)
                    {
                        // j-th column to i-th column

                        Excel.Range rangeSource = MyWorkSheet.Columns[j];         // 
                        Excel.Range rangeTarget = MyWorkSheet.Columns[i + 1];         // Inserted Columns
                        rangeSource.Copy(rangeTarget);
                        break;
                    }
                }
            }

            //--- list에 있는 열수 이후의 열은 삭제 (대상수량 이후는 삭제하지 않음)
            //을 찾아서 삽입한 열에 차례대로 복사
            Excel.Range rangeX = MyWorkSheet.Range[MyWorkSheet.Cells[6, iNumInsert + 1], MyWorkSheet.Cells[6, iNumInsert + iValidNumCol]];
            rangeX.EntireColumn.Delete();

            if (workBook != null)
                workBook.SaveAs(strFile);
            CloseExcelFile();

            return 1;

        }
    }
}
