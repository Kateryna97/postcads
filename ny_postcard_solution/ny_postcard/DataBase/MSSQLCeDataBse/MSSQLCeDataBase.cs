using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;
//
//using Apteka_Utils = ClearingHouse.ClearingUtils;
//
//
using System.Drawing;
using System.Windows.Forms;

namespace ny_postcard
{
    public class MSSQLCeDatabase
    {
        //public OleDbConnection _ScroogeCon;
        //
        private SqlCeConnection _msSqlCeConnection;
        private SqlCeCommand Cmd { get; set; }
        private SqlCeDataReader Reader;
        private SqlCeDataAdapter dataAdapter;
        private DataSet Ds { get; set; }
        private string _strConn;
        //
        public MSSQLCeDatabase()
            : this(@"Data source = " + PostCardUtils.CurrenDataDirectory + "\\NY_PostCard.sdf;" +
		            "File Mode=Exclusive;"+
                    "Persist Security Info=False;"+
                    "Max Database Size=1000;" +
                    "Temp File Max Size=256;"+
                    "Default Lock Escalation=100;"+
                    "Default Lock Timeout=5000;"+
                    "Encrypt Database=False;Enlist=True;Mode=Read Write;Flush Interval=10;Max Buffer Size=4096")
        {
            _msSqlCeConnection = new SqlCeConnection(_strConn);
        }

        public MSSQLCeDatabase(string p_str_Connect)
        {
            _strConn = p_str_Connect;
            _msSqlCeConnection = new SqlCeConnection(_strConn);
        }

        public SqlCeConnection OpenConn()
        {
            if (_msSqlCeConnection.State == System.Data.ConnectionState.Closed || _msSqlCeConnection.State == System.Data.ConnectionState.Broken)
            {
                _msSqlCeConnection.Open();
            }
            return _msSqlCeConnection;
        }

        public SqlCeConnection CloseConn()
        {
            if (_msSqlCeConnection.State == System.Data.ConnectionState.Open)
            {
                _msSqlCeConnection.Close();
            }
            return _msSqlCeConnection;
        }


        public SqlCeConnection GetDbConnection()
        {
            return OpenConn();
        }

        public void CloseConnection()  //SqlCeConnection pConn
        {
            _msSqlCeConnection = CloseConn();
            _msSqlCeConnection.Dispose();
        }
        //
        public DataTable GetDataTable(string strQueryCommand)
        {
            Cmd = new SqlCeCommand();
            SqlCeDataAdapter adap;

            try
            {
                Cmd.Connection = OpenConn();
                Cmd.CommandText = strQueryCommand;
                adap = new SqlCeDataAdapter(Cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                return dt;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                Cmd = null;
            }
        }

        public DataSet GetDataSet(string strQueryCommand)
        {
            try
            {
                OpenConn();
                Cmd = _msSqlCeConnection.CreateCommand();
                dataAdapter = new SqlCeDataAdapter(strQueryCommand, _msSqlCeConnection);
                Ds = new DataSet();
                Ds.Reset();
                dataAdapter.Fill(Ds);

                return Ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Cmd = null;
                CloseConn();
            }
        }

        public void ExecuteQuery(string strQueryCommand)
        {
            try
            {
                Cmd.Connection = OpenConn();
                Cmd.CommandText = strQueryCommand;
                Cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                Cmd = null;
            }

        }

        public void ExecuteQueryTrans(string strQueryCommand, SqlCeTransaction p_trans)
        {
            try
            {
                Cmd.Connection = OpenConn();
                Cmd.CommandText = strQueryCommand;
                Cmd.Transaction = p_trans;
                Cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                Cmd = null;
            }

        }

        public SqlCeDataReader GetDataReader(string strQueryCommand)
        {
            try
            {
                Cmd = _msSqlCeConnection.CreateCommand();
                Cmd.CommandText = strQueryCommand;
                Reader = Cmd.ExecuteReader();
                return Reader;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Cmd = null;
            }
        }

        /// <summary>
        /// GetOneStringDataFromSql - get one string data using sql query 
        /// </summary>
        /// <param name="p_sql_query">Query data</param>
        /// <returns></returns>
        public string GetOneStringDataFromSql(string p_sql_query)
        {
            string _string_data = "";
            using (SqlCeCommand _com1 = new SqlCeCommand(p_sql_query, _msSqlCeConnection))
            {
				var s_data = _com1.ExecuteScalar();
				_string_data = (s_data == null ? "" : (string) s_data );
            }
            return _string_data.Trim();
        }

        public Int32 GetOneIntDataFromSql(string p_sql_query)
        {
            Int32 _int_data = 0;
            using (SqlCeCommand _com1 = new SqlCeCommand(p_sql_query, _msSqlCeConnection))
            {
				var i_data = _com1.ExecuteScalar();
				_int_data = (i_data == null ? 0 : (Int32) i_data );
            }
            return _int_data;
        }

        public UInt64 GetOneUInt64DataFromSql(string p_sql_query)
        {
            UInt64 u_int_data = 0;
            using (SqlCeCommand _com1 = new SqlCeCommand(p_sql_query, _msSqlCeConnection))
            {
                var i_data = _com1.ExecuteScalar();
                u_int_data = (i_data == null ? 0 : (UInt64)i_data);
            }
            return u_int_data;
        }


        public Double GetOneDoubleDataFromSql(string p_sql_query)
        {
            Double _dbl_data = 0;
            NumberFormatInfo _prov = AptekaUtils.GetWorkProvider();
            using (SqlCeCommand _com1 = new SqlCeCommand(p_sql_query, _msSqlCeConnection))
            {
                var _data = _com1.ExecuteScalar();
                //MessageBox.Show(_data.ToString());
                _dbl_data = (_data == null ? 0.00 : Convert.ToDouble(_data, _prov));
            }
            return _dbl_data;
        }

        public Decimal GetOneDecimalDataFromSql(string p_sql_query)
        {
            Decimal _dec_data = 0;
            using (SqlCeCommand _com1 = new SqlCeCommand(p_sql_query, _msSqlCeConnection))
            {
                var _data = _com1.ExecuteScalar();
                _dec_data = (_data == null ? 0 : (Decimal)_data);
            }
            return _dec_data;
        }

        public T GetOneNumberDataFromSql<T>(string p_sql_query)
        {
            T _ret_data;
            using (SqlCeCommand _com1 = new SqlCeCommand(p_sql_query, _msSqlCeConnection))
            {
                var _data = _com1.ExecuteScalar();
                _ret_data = (T)_data;
                //_ret_data = (_data == null ? (T)(0).GetType()  : (T)_data);
            }
            return _ret_data;
        }

        public DateTime GetOneDateTimeDataFromSql(string p_sql_query)
        {
            DateTime _dt_data;
            using (SqlCeCommand _com1 = new SqlCeCommand(p_sql_query, _msSqlCeConnection))
            {
                var _data = _com1.ExecuteScalar();
                _dt_data = (_data == null ? DateTime.MinValue : (DateTime)_data);
            }
            return _dt_data;
        }


        public void ExecuteQueryWithTrans(string p_strQueryCommand)
        {
            using (SqlCeTransaction trans = _msSqlCeConnection.BeginTransaction())
            {
                using (SqlCeCommand _command = new SqlCeCommand(p_strQueryCommand, _msSqlCeConnection))
                {
                    _command.Transaction = trans;
                    _command.ExecuteNonQuery();
                }
                trans.Commit();
            }
        }

        public void ExecuteQueryWithTrans2(string p_strQueryCommand)
        {
            using (SqlCeTransaction trans = _msSqlCeConnection.BeginTransaction())
            {
                this.ExecuteQueryTrans(p_strQueryCommand, trans);
                trans.Commit();
            }
        }

        public void DeleteAllRecord(string pNameTable, string pIdName,bool bIdentState)
        {
            // delete all records
            using (SqlCeTransaction trans = OpenConn().BeginTransaction())
            {
                using (SqlCeCommand _command = new SqlCeCommand("DELETE FROM " + pNameTable, OpenConn()))
                {
                    _command.Transaction = trans;
                    _command.ExecuteNonQuery();
                }
                trans.Commit();
            }

            //MessageBox.Show("Alter table");
            
            if (bIdentState)
            {
                // alter table IDENTITY (1,1)
                using (SqlCeTransaction trans = OpenConn().BeginTransaction())
                {
                    using (SqlCeCommand _command = new SqlCeCommand("ALTER TABLE " + pNameTable + " ALTER COLUMN " + pIdName + " IDENTITY (1,1)", OpenConn()))
                    {
                        _command.Transaction = trans;
                        _command.ExecuteNonQuery();
                    }
                    trans.Commit();
                }
            }
        }



    }


}
