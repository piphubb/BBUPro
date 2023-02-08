using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBUPro.models
{
    class clsCategory
    {
        public int CATEGORYID { get; set; }
        public string CATEGORYNAME { get; set; }
        public string CATEGORYDESC { get; set; }

        //Select
        public DataTable GetDate()
        {
            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter("select * from category_tbl",clsGlobal.con);

            try
            {
                da.Fill(dt);
            }
            catch(Exception ex)
            {
                dt = null;
            }

            return dt;
        }
        //Search
        public DataTable GetDate(string q)
        {
            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter("select * from category_tbl where lower(categoryname) like '%' || lower( :q) || '%'", clsGlobal.con);
            da.SelectCommand.Parameters.Add(":q", q);
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = null;
            }

            return dt;
        }
        //Insert
        public bool Insert()
        {
            bool check = false;
            OracleCommand cmd = new OracleCommand("CATEGORY_TBL_tapi.ins", clsGlobal.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("p_CATEGORYDESC",CATEGORYDESC);
            cmd.Parameters.Add("p_CATEGORYID", CATEGORYID);
            cmd.Parameters.Add("p_CATEGORYNAME", CATEGORYNAME);

            try
            {
                cmd.ExecuteNonQuery();
                check = true;
            }
            catch (Exception ex)
            {
                check = true;
            }

            return check;
        }
        //Update
        public bool Update()
        {
            bool check = false;
            OracleCommand cmd = new OracleCommand("CATEGORY_TBL_tapi.upd", clsGlobal.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("p_CATEGORYDESC", CATEGORYDESC);
            cmd.Parameters.Add("p_CATEGORYID", CATEGORYID);
            cmd.Parameters.Add("p_CATEGORYNAME", CATEGORYNAME);

            try
            {
                cmd.ExecuteNonQuery();
                check = true;
            }
            catch (Exception ex)
            {
                check = true;
            }

            return check;
        }

        //Delete
        public bool Delete()
        {
            bool check = false;
            OracleCommand cmd = new OracleCommand("CATEGORY_TBL_tapi.del", clsGlobal.con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("p_CATEGORYID", CATEGORYID);

            try
            {
                cmd.ExecuteNonQuery();
                check = true;
            }
            catch (Exception ex)
            {
                check = true;
            }

            return check;
        }
    }
}
