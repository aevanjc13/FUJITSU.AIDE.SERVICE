﻿using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    /// <summary>
    /// Data access layer class for clsStatus
    /// </summary>
    class clsResourcePlannerSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsResourcePlannerSql()
        {
            // Nothing for now.
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// insert new row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true of successfully insert</returns>
        /// 
        public bool InsertResourcePlanner(clsResourcePlanner businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertResourcePlanner]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@EMPLOYEE_NAME", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMPLOYEE_NAME));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE_ENTRY", SqlDbType.Date, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATE_ENTRY));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.Int, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATUS));


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::Insert::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        /// <summary>
        /// update row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true for successfully updated</returns>
        public bool UpdateResourcePlanner(clsResourcePlanner businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateResourcePlanner]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {               

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@from", SqlDbType.DateTime, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.from));
                sqlCommand.Parameters.Add(new SqlParameter("@to", SqlDbType.DateTime, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.to));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.Int, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATUS));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::UpdateResourcePlanner::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsResourcePlanner> ViewEmpResourcePlanner(string email)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetEmpResourcePlanner]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsRPFromReader(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::ViewEmpResourcePlanner::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsResourcePlanner> GetStatusResourcePlanner()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetStatusResourcePlanner]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;
            try
            {
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsRPFromReader2(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::GetStatusResourcePlanner::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        //not in use
        public List<clsResourcePlanner> GetResourcePlannerByEmpID(int EMP_ID, int DEPT_ID, int MONTH, int YEAR)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetResourcePlannerByEmpID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@DEPT_ID", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DEPT_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTH", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, MONTH));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, YEAR));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsRPFromReader3(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::GetResourcePlannerByEmpID::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsResourcePlanner> GetAllEmpResourcePlanner(string email, int MONTH, int YEAR)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllEmpResourcePlanner]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTH", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, MONTH));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, YEAR));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsRPFromReader4(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::GetAllEmpResourcePlanner::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsResourcePlanner> GetAllEmpResourcePlannerByStatus(string email, int MONTH, int YEAR, int STATUS)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllEmpResourcePlannerByStatus]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTH", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, MONTH));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, YEAR));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, STATUS));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsRPFromReader5(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::GetAllEmpResourcePlannerByStatus::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsResourcePlanner> GetAllStatusResourcePlanner()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllStatusResourcePlanner]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;
            try
            {
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsRPFromReader6(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::GetAllStatusResourcePlanner::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsResourcePlanner> GetResourcePlanner(string email, int STATUS, int ToDisplay)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetResourcePlanner]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, STATUS));
                sqlCommand.Parameters.Add(new SqlParameter("@ToDisplay", SqlDbType.Int, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ToDisplay));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsRPFromReader7(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::GetResourcePlanner::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectRPFromReader(clsResourcePlanner businessObject, IDataReader dataReader)
        {
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.EMP_ID.ToString()));
            businessObject.EMPLOYEE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.EMPLOYEE_NAME.ToString()));
            businessObject.IMAGE_PATH = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.IMAGE_PATH.ToString())); 
        }

        internal void PopulateBusinessObjectRPFromReader2(clsResourcePlanner businessObject, IDataReader dataReader)
        {
            businessObject.DESCR = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.DESCR.ToString()));
            businessObject.STATUS = (byte)dataReader.GetInt16(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.STATUS.ToString()));
        }

        internal void PopulateBusinessObjectRPFromReader3(clsResourcePlanner businessObject, IDataReader dataReader)
        {
            businessObject.DATE_ENTRY = dataReader.GetDateTime(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.DATE_ENTRY.ToString()));
            businessObject.STATUS = dataReader.GetInt32(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.STATUS.ToString()));
        }

        internal void PopulateBusinessObjectRPFromReader4(clsResourcePlanner businessObject, IDataReader dataReader)
        {
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.EMP_ID.ToString()));
            businessObject.EMPLOYEE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.EMPLOYEE_NAME.ToString()));
            businessObject.DATE_ENTRY = dataReader.GetDateTime(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.DATE_ENTRY.ToString()));
            businessObject.STATUS = dataReader.GetInt32(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.STATUS.ToString()));
        }

        internal void PopulateBusinessObjectRPFromReader5(clsResourcePlanner businessObject, IDataReader dataReader)
        {
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.EMP_ID.ToString()));
            businessObject.EMPLOYEE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.EMPLOYEE_NAME.ToString()));
            businessObject.DATE_ENTRY = dataReader.GetDateTime(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.DATE_ENTRY.ToString()));
            businessObject.STATUS = dataReader.GetInt32(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.STATUS.ToString()));
        }

        internal void PopulateBusinessObjectRPFromReader6(clsResourcePlanner businessObject, IDataReader dataReader)
        {
            businessObject.DESCR = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.DESCR.ToString()));
            businessObject.STATUS = (byte)dataReader.GetInt16(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.STATUS.ToString()));
        }

        internal void PopulateBusinessObjectRPFromReader7(clsResourcePlanner businessObject, IDataReader dataReader)
        {
            businessObject.EMPLOYEE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.EMPLOYEE_NAME.ToString()));
            businessObject.STATUS = dataReader.GetDouble(dataReader.GetOrdinal(clsResourcePlanner.clsResourcePlannerFields.STATUS.ToString()));
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsStatus</returns>
        internal List<clsResourcePlanner> PopulateObjectsRPFromReader(IDataReader dataReader)
        {

            List<clsResourcePlanner> list = new List<clsResourcePlanner>();

            while (dataReader.Read())
            {
                clsResourcePlanner businessObject = new clsResourcePlanner();
                PopulateBusinessObjectRPFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsResourcePlanner> PopulateObjectsRPFromReader2(IDataReader dataReader)
        {

            List<clsResourcePlanner> list = new List<clsResourcePlanner>();

            while (dataReader.Read())
            {
                clsResourcePlanner businessObject = new clsResourcePlanner();
                PopulateBusinessObjectRPFromReader2(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsResourcePlanner> PopulateObjectsRPFromReader3(IDataReader dataReader)
        {
            List<clsResourcePlanner> list = new List<clsResourcePlanner>();

            while (dataReader.Read())
            {
                clsResourcePlanner businessObject = new clsResourcePlanner();
                PopulateBusinessObjectRPFromReader3(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsResourcePlanner> PopulateObjectsRPFromReader4(IDataReader dataReader)
        {
            List<clsResourcePlanner> list = new List<clsResourcePlanner>();

            while (dataReader.Read())
            {
                clsResourcePlanner businessObject = new clsResourcePlanner();
                PopulateBusinessObjectRPFromReader4(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsResourcePlanner> PopulateObjectsRPFromReader5(IDataReader dataReader)
        {
            List<clsResourcePlanner> list = new List<clsResourcePlanner>();

            while (dataReader.Read())
            {
                clsResourcePlanner businessObject = new clsResourcePlanner();
                PopulateBusinessObjectRPFromReader5(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsResourcePlanner> PopulateObjectsRPFromReader6(IDataReader dataReader)
        {

            List<clsResourcePlanner> list = new List<clsResourcePlanner>();

            while (dataReader.Read())
            {
                clsResourcePlanner businessObject = new clsResourcePlanner();
                PopulateBusinessObjectRPFromReader6(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsResourcePlanner> PopulateObjectsRPFromReader7(IDataReader dataReader)
        {

            List<clsResourcePlanner> list = new List<clsResourcePlanner>();

            while (dataReader.Read())
            {
                clsResourcePlanner businessObject = new clsResourcePlanner();
                PopulateBusinessObjectRPFromReader7(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion
    }
}
