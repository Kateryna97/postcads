using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Security.Cryptography;
using System.Globalization;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
//
using System.Drawing;
using System.Windows.Forms;

namespace ny_postcard
{
    public static class PostCardUtils
    {
        // Config data
        private static string _inDir;
        private static string _outDir;
        //
        // Directory data
        private static string _applicationDir;
        private static string _currenTempDirectory;
        private static string _currenOutDirectory;
        private static string _currenInDirectory;
        private static string _currenReportDirectory;
        private static string _currenDataDirectory;
        private static string _baseArcDirectory;
        //private static string _currenArcDirectory;

        //
        private static string _runProgramState;
        //
        public static string RunProgramState
        {
            get { return _runProgramState; }
            set { _runProgramState = value; }
        }

        //
        public static string OutDir
        {
            get { return _outDir; }
            set { _outDir = value; }
        }

        public static string InDir
        {
            get { return _inDir; }
            set { _inDir = value; }
        }

        //
        public static string ApplicationDir
        {
            get { return _applicationDir; }
            set { _applicationDir = value; }
        }

        public static string CurrenTempDirectory
        {
            get { return _currenTempDirectory; }
            set { _currenTempDirectory = value; }
        }

        public static string CurrenOutDirectory
        {
            get { return _currenOutDirectory; }
            set { _currenOutDirectory = value; }
        }

        public static string CurrenInDirectory
        {
            get { return _currenInDirectory; }
            set { _currenInDirectory = value; }
        }

        public static string CurrenReportDirectory
        {
            get { return _currenReportDirectory; }
            set { _currenReportDirectory = value; }
        }

        public static string CurrenDataDirectory
        {
            get { return _currenDataDirectory; }
            set { _currenDataDirectory = value; }
        }

        //
        static PostCardUtils()
        {
            MessageBox.Show("test");
            _applicationDir = AppDomain.CurrentDomain.BaseDirectory;
			//
            _inDir = System.Configuration.ConfigurationManager.AppSettings["InDir"];
            _outDir = System.Configuration.ConfigurationManager.AppSettings["OutDir"];
            //
            // Config Email Data
            //_runProgramState = System.Configuration.ConfigurationSettings.AppSettings["RunProgramState"];
            // directory create
            CheckDirectories();
        }

        public static void CheckDirectories()
        {
            _currenTempDirectory = _applicationDir + "TEMP";
            _currenOutDirectory = _applicationDir + "OUT";
            _currenInDirectory = _applicationDir + "IN";
            _currenReportDirectory = _applicationDir + "REPORT";
            _currenDataDirectory = _applicationDir + "DATA";
            //
            _baseArcDirectory = _applicationDir + "ARCHIVE";
	    //	
            if (!Directory.Exists(_currenTempDirectory))
                Directory.CreateDirectory(_currenTempDirectory);
            if (!Directory.Exists(_currenInDirectory))
                Directory.CreateDirectory(_currenInDirectory);
            if (!Directory.Exists(_currenOutDirectory))
                Directory.CreateDirectory(_currenOutDirectory);
            if (!Directory.Exists(_currenReportDirectory))
                Directory.CreateDirectory(_currenReportDirectory);
            if (!Directory.Exists(_currenDataDirectory))
            {
                Directory.CreateDirectory(_currenDataDirectory);
                // Create Empty Database
                //
            }
            if (!Directory.Exists(_baseArcDirectory))
                Directory.CreateDirectory(_baseArcDirectory);
            //
            //_currenArcDirectory = _baseArcDirectory + "\\" + DateTime.Today.ToString("ddMMyyyy");
            //if (!Directory.Exists(_currenArcDirectory))
            //{
            //    Directory.CreateDirectory(_currenArcDirectory);
            //}

        }

        public static string TestOrAddSleshToString(string pstrPathData)
        {
            return pstrPathData.EndsWith(@"\") ? pstrPathData : pstrPathData + @"\";
            //return pathWithTrailingSlah = Path.EndsWith(Path.DirectorySeparatorChar) ? pstrPathData : pstrPathData + Path.DirectorySeparatorChar;
            
        }

        /// <summary>
        ///  Method for analize start or end symbol string data 
        /// </summary>
        /// <param name="pstrData"></param>
        /// <param name="pStrAnalize"></param>
        /// <param name="bStartFlag">True - start position; False - end position</param>
        /// <returns></returns>
        public static string TestOrAddStringDataToEndOrStart(string pstrData, string pStrAnalize,bool bStartFlag)
        {
            if (bStartFlag)
                return  pstrData.StartsWith(pStrAnalize) ? pstrData : pStrAnalize + pstrData;
            else
                return  pstrData.EndsWith(pStrAnalize) ? pstrData : pstrData + pStrAnalize;
        }


        public static NumberFormatInfo GetWorkProvider()
        {
            NumberFormatInfo _provider = new NumberFormatInfo();
            if (NumberFormatInfo.CurrentInfo.NumberDecimalSeparator == ".")
            {
                _provider.NumberDecimalDigits = 3;
                _provider.NumberDecimalSeparator = ",";
                _provider.NumberGroupSeparator = ".";
                //_provider.NumberGroupSizes = new int[] { 3 };
            }
            else
                _provider = NumberFormatInfo.CurrentInfo;

            return _provider;
        }

        public static void WaitWindowErrorMessage(string _errormessage, Int32 _stateMessage)
        {
            Int32 _timeDelay = 0;

            WaitWindowMessage _waitErrorWindow = new WaitWindowMessage();
            _waitErrorWindow.TopMost = true;
            _waitErrorWindow.StartPosition = FormStartPosition.CenterScreen;
            _waitErrorWindow.Show();
            if (_stateMessage == 0) // Error message
            {
                _waitErrorWindow.SetErrorMessage(_errormessage);
                _timeDelay = 2 * 1000;
            }
            else
            {
                _waitErrorWindow.SetInfoMessage(_errormessage);
                _timeDelay = 1 * 1000;
            }
            _waitErrorWindow.Refresh();
            Thread.Sleep(_timeDelay);
            _waitErrorWindow.Close();
        }

        public static WaitWindowMessage WaitWindowNowait(string _errormessage, Int32 _stateMessage)
        {
            WaitWindowMessage _waitErrorWindow = new WaitWindowMessage();
            _waitErrorWindow.TopMost = true;
            _waitErrorWindow.StartPosition = FormStartPosition.CenterScreen;
            _waitErrorWindow.Show();
            if (_stateMessage == 0) // Error message
                _waitErrorWindow.SetErrorMessage(_errormessage);
            else
                _waitErrorWindow.SetInfoMessage(_errormessage);

            _waitErrorWindow.Refresh();
            return _waitErrorWindow;
        }

        public static void WaitWindowNowaitClose(WaitWindowMessage _waitwindow)
        {
            _waitwindow.Close();
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "Затвердити";
            buttonCancel.Text = "Вихід";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        public static DateTime GetCurrentWorkDate()
        {
            return DateTime.Today;
        }
		
        public static void FileCopyMove(string ps_From, string ps_To, bool pb_DelFlag)
        {
            File.Copy(ps_From, ps_To, true);
            if (pb_DelFlag)
                File.Delete(ps_From);

        }

        public static void SaveStringDataToFile(string ps_DataToSave, string ps_FileName, bool pb_Append)
        {
            using (var _wr = new StreamWriter(ps_FileName, pb_Append, System.Text.Encoding.GetEncoding(1251)))
            {
                _wr.WriteLine(ps_DataToSave);
                _wr.Close();
            }
        }
    }
}
