using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_BaiThi
{
    class MyPublics
    {
        public static SqlConnection conMyConnection;
        public static string strServer, strTenTK, strTrungTam, StrQuyenSD, strLop, strHK, strNK, strMK;
        public static void ConnectDatabase()
        {
            string strconn = "Server=" + strServer + ";Database=QL_BaiThi; integrated Security = false; UID = TN207User; PWD = TN207User";
            conMyConnection = new SqlConnection();
            conMyConnection.ConnectionString = strconn;
            try
            {
                conMyConnection.Open();
            }
            catch (Exception)
            {

            }
        }
        public static void OpenData(string strSelect, DataSet dsDatabase, string strTableName, SqlDataAdapter daDataApdapter)
        {
            try
            {
                if (conMyConnection.State == ConnectionState.Closed)
                    conMyConnection.Open();
                daDataApdapter.SelectCommand = new SqlCommand(strSelect, conMyConnection);
                SqlCommandBuilder cmbCommandBuilder = new SqlCommandBuilder(daDataApdapter);
                daDataApdapter.Fill(dsDatabase, strTableName);
                conMyConnection.Close();
            }
            catch (Exception)
            {

            }
        }
        public static void OpenData(string strSelect, DataSet dsDatabase, string strTableName)
        {
            SqlDataAdapter daDataApdapter = new SqlDataAdapter();
            try
            {
                if (conMyConnection.State == ConnectionState.Closed)
                    conMyConnection.Open();
                daDataApdapter.SelectCommand = new SqlCommand(strSelect, conMyConnection);
                daDataApdapter.Fill(dsDatabase, strTableName);
                conMyConnection.Close();
            }
            catch (Exception)
            {

            }
        }
        public static bool TonTaiKhoaChinh(string strGiaTri, string strTenTruong, string strTable)
        {
            bool blnResult = false;
            try
            {
                string sqlSelect = "Select 1 From " + strTable + " Where " + strTenTruong + "='" + strGiaTri + "'";
                if (conMyConnection.State == ConnectionState.Closed)
                    conMyConnection.Open();
                SqlCommand cmdCommand = new SqlCommand(sqlSelect, conMyConnection);
                SqlDataReader drReader = cmdCommand.ExecuteReader();
                if (drReader.HasRows)
                    blnResult = true;
                drReader.Close();
                conMyConnection.Close();

            }
            catch (Exception)
            {

            }
            return blnResult;
        }
        public static string MaHoaPassword(String strPassword)
        {
            string str1, str2;
            int i, n;
            str1 = "";
            str2 = "";
            n = strPassword.Length;
            for (i = 0; i < n; i = i + 2)
                str1 = str1 + strPassword[i];
            for (i = 1; i < n; i = i + 2)
                str2 = str2 + strPassword[i];
            strPassword = str1 + str2;
            return str1 + str2;
        }

    }
}
