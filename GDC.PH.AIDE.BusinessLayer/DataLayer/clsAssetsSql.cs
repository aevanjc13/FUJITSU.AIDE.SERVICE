using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    /// <summary>
    /// Data access layer class for clsContacts
    /// </summary>
    class clsAssetsSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </clsCommendationsSql>
        public clsAssetsSql()
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
        public bool InsertAssets(clsAssets businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertAssets]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@ASSET_DESC", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ASSET_DESC));
                sqlCommand.Parameters.Add(new SqlParameter("@MANUFACTURER", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MANUFACTURER));
                sqlCommand.Parameters.Add(new SqlParameter("@MODEL_NO", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MODEL_NO));
                sqlCommand.Parameters.Add(new SqlParameter("@SERIAL_NO", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SERIAL_NO));
                sqlCommand.Parameters.Add(new SqlParameter("@ASSET_TAG", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ASSET_TAG));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE_PURHCASED", SqlDbType.DateTime, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATE_PURCHASED));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATUS));
                sqlCommand.Parameters.Add(new SqlParameter("@OTHER_INFO", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OTHER_INFO));
                sqlCommand.Parameters.Add(new SqlParameter("@ASSIGNEDTO", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ASSIGNED_TO));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsAssets:sp_InsertAssests:Error occured.", ex);
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
        public bool UpdateAssets(clsAssets businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateAssets]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ASSET_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ASSET_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@ASSET_DESC", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ASSET_DESC));
                sqlCommand.Parameters.Add(new SqlParameter("@MANUFACTURER", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MANUFACTURER));
                sqlCommand.Parameters.Add(new SqlParameter("@MODEL_NO", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MODEL_NO));
                sqlCommand.Parameters.Add(new SqlParameter("@SERIAL_NO", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SERIAL_NO));
                sqlCommand.Parameters.Add(new SqlParameter("@ASSET_TAG", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ASSET_TAG));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE_PURHCASED", SqlDbType.DateTime, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATE_PURCHASED));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATUS));
                sqlCommand.Parameters.Add(new SqlParameter("@OTHER_INFO", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OTHER_INFO));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsAssets::Update::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }


        /// <summary>
        /// Select all records
        /// </summary>
        /// <returns>list of clsAssets</returns>
        public List<clsAssets> GetAllAssetsByEmpID(int empID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllAssetsByEmpID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsAssets::sp_GetAllAssetsByEmpID::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }


        /// <summary>
        /// Select My Assets
        /// </summary>
        /// <returns>list of clsAssets</returns>
        public List<clsAssets> GetMyAssets(int empID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetMyAssets]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader3(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsAssets::sp_GetMyAssets::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// Select all rescords by keyword
        /// </summary>
        /// <returns>list of clsAssets</returns>
        public List<clsAssets> GetAllAssetsBySearch(int empID, string input)
       {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[sp_GetAllAssetsBySearch]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@INPUT", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, input));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsAssets::sp_GetAllAssetsBySearch::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// Select all rescords
        /// </summary>
        /// <returns>list of clsAssets</returns>
        public List<clsAssets> GetAllAssetsInventoryByEmpID(int empID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllAssetsInventoryByEmpID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader2(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsAssets::sp_GetAllAssetsInventoryByEmpID::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// insert new row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true of successfully insert</returns>
        public bool InsertAssetsInventory(clsAssets businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertAssetsInventory]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@ASSET_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ASSET_ID));
                 sqlCommand.Parameters.Add(new SqlParameter("@DATE_ASSIGNED", SqlDbType.DateTime, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATE_ASSIGNED));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATUS));
                sqlCommand.Parameters.Add(new SqlParameter("@COMMENTS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.COMMENTS));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsAssets:sp_InsertAssests:Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public bool UpdateAssetsInventory(clsAssets businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateAssetsInventory]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ASSET_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ASSET_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE_ASSIGNED", SqlDbType.DateTime, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATE_ASSIGNED));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATUS));
                sqlCommand.Parameters.Add(new SqlParameter("@COMMENTS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.COMMENTS));
                sqlCommand.Parameters.Add(new SqlParameter("@APPROVAL", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.APPROVAL));
                
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsAssets::Update::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public bool UpdateAssetsInventoryApproval(clsAssets businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateAssetsInventoryApproval]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ASSET_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ASSET_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATUS));
                sqlCommand.Parameters.Add(new SqlParameter("@APPROVAL", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.APPROVAL));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsAssets::sp_UpdateAssetsInventoryApproval::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public bool UpdateAssetsInventoryCancel(clsAssets businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateAssetsInventoryCancel]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ASSET_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ASSET_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE_ASSIGNED", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATE_ASSIGNED));
                sqlCommand.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATUS));
                sqlCommand.Parameters.Add(new SqlParameter("@COMMENTS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.COMMENTS));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsAssets::sp_UpdateAssetsInventoryCancel::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }
        /// <summary>
        /// Select all rescords
        /// </summary>
        /// <returns>list of clsAssets</returns>
        public List<clsAssets> GetAllAssetsUnAssigned(int empID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllAssetsUnAssigned]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsAssets::sp_GetAllAssetsByEmpID::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public List<clsNickname> GetAllManagers(int empID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[sp_GetAllManagers]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;


            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderForNickname(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsSuccessRegister::getNicknameByEmpID::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public List<clsAssets> GetAllAssetsInventoryUnApproved(int empID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllAssetsInventoryUnApproved]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader2(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsAssets::sp_GetAllAssetsInventoryUnApproved::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public List<clsAssets> GetAllAssetsHistory(int empID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[sp_GetAllAssetsHistory]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                
                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader4(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsAssets::sp_GetAllAssetsHistory::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public List<clsAssets> GetAllAssetsHistoryBySearch(int empID, string input)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[sp_GetAllAssetsHistoryBySearch]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@INPUT", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, input));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader4(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsAssets::sp_GetAllAssetsHistoryBySearch::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsAssets businessObject, IDataReader dataReader)
        {
            businessObject.ASSET_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsAssets.clsAssetsFields.ASSET_ID.ToString()));
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsAssets.clsAssetsFields.EMP_ID.ToString()));
            businessObject.ASSET_DESC = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.ASSET_DESC.ToString()));
            businessObject.MANUFACTURER = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.MANUFACTURER.ToString()));
            businessObject.MODEL_NO = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.MODEL_NO.ToString()));
            businessObject.SERIAL_NO = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.SERIAL_NO.ToString()));
            businessObject.ASSET_TAG = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.ASSET_TAG.ToString()));
            businessObject.DATE_PURCHASED = dataReader.GetDateTime(dataReader.GetOrdinal(clsAssets.clsAssetsFields.DATE_PURCHASED.ToString()));
            businessObject.STATUS = dataReader.GetInt32(dataReader.GetOrdinal(clsAssets.clsAssetsFields.STATUS.ToString()));
            businessObject.FULL_NAME = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.FULL_NAME.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAssets.clsAssetsFields.OTHER_INFO.ToString())))
            {
                businessObject.OTHER_INFO = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.OTHER_INFO.ToString()));
            }
            else
            {
                businessObject.OTHER_INFO = String.Empty;
            }            
        }

        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReader2(clsAssets businessObject, IDataReader dataReader)
        {
            businessObject.ASSET_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsAssets.clsAssetsFields.ASSET_ID.ToString()));
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsAssets.clsAssetsFields.EMP_ID.ToString()));
            businessObject.ASSET_DESC = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.ASSET_DESC.ToString()));
            businessObject.MANUFACTURER = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.MANUFACTURER.ToString()));
            businessObject.MODEL_NO = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.MODEL_NO.ToString()));
            businessObject.SERIAL_NO = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.SERIAL_NO.ToString()));
            businessObject.ASSET_TAG = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.ASSET_TAG.ToString()));
            businessObject.DATE_ASSIGNED = dataReader.GetDateTime(dataReader.GetOrdinal(clsAssets.clsAssetsFields.DATE_ASSIGNED.ToString()));
            businessObject.STATUS = dataReader.GetInt32(dataReader.GetOrdinal(clsAssets.clsAssetsFields.STATUS.ToString()));
            businessObject.FULL_NAME = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.FULL_NAME.ToString()));
            
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAssets.clsAssetsFields.COMMENTS.ToString())))
            {
                businessObject.COMMENTS = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.COMMENTS.ToString()));
            }
            else
            {
                businessObject.COMMENTS = String.Empty;
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAssets.clsAssetsFields.DEPARTMENT.ToString())))
            {
                businessObject.DEPARTMENT = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.DEPARTMENT.ToString()));
            }
            else
            {
                businessObject.DEPARTMENT = String.Empty;
            }
        }

        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReader3(clsAssets businessObject, IDataReader dataReader)
        {
            businessObject.ASSET_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsAssets.clsAssetsFields.ASSET_ID.ToString()));
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsAssets.clsAssetsFields.EMP_ID.ToString()));
            businessObject.ASSET_DESC = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.ASSET_DESC.ToString()));
            businessObject.MANUFACTURER = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.MANUFACTURER.ToString()));
            businessObject.MODEL_NO = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.MODEL_NO.ToString()));
            businessObject.SERIAL_NO = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.SERIAL_NO.ToString()));
            businessObject.ASSET_TAG = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.ASSET_TAG.ToString()));
            businessObject.DATE_ASSIGNED = dataReader.GetDateTime(dataReader.GetOrdinal(clsAssets.clsAssetsFields.DATE_ASSIGNED.ToString()));
            businessObject.STATUS = dataReader.GetInt32(dataReader.GetOrdinal(clsAssets.clsAssetsFields.STATUS.ToString()));
            businessObject.FULL_NAME = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.FULL_NAME.ToString()));
            businessObject.APPROVAL = dataReader.GetInt32(dataReader.GetOrdinal(clsAssets.clsAssetsFields.APPROVAL.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAssets.clsAssetsFields.COMMENTS.ToString())))
            {
                businessObject.COMMENTS = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.COMMENTS.ToString()));
            }
            else
            {
                businessObject.COMMENTS = String.Empty;
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsAssets.clsAssetsFields.DEPARTMENT.ToString())))
            {
                businessObject.DEPARTMENT = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.DEPARTMENT.ToString()));
            }
            else
            {
                businessObject.DEPARTMENT = String.Empty;
            }
        }

        internal void PopulateBusinessObjectFromReaderForNickname(clsNickname businessObject, IDataReader dataReader)
        {
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsNickname.clsNicknameFields.EMP_ID.ToString()));
            businessObject.NICK_NAME = dataReader.GetString(dataReader.GetOrdinal(clsNickname.clsNicknameFields.NICK_NAME.ToString()));

        }

        internal void PopulateBusinessObjectFromReader4(clsAssets businessObject, IDataReader dataReader)
        {
            businessObject.ASSET_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsAssets.clsAssetsFields.ASSET_ID.ToString()));
            businessObject.FULL_NAME = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.FULL_NAME.ToString()));
            businessObject.TABLE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.TABLE_NAME.ToString()));
            businessObject.STATUS_DESCR = dataReader.GetString(dataReader.GetOrdinal(clsAssets.clsAssetsFields.STATUS_DESCR.ToString()));
            businessObject.DATE_ASSIGNED = dataReader.GetDateTime(dataReader.GetOrdinal(clsAssets.clsAssetsFields.DATE_ASSIGNED.ToString()));
        }
        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsContacts</returns>
        internal List<clsAssets> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<clsAssets> list = new List<clsAssets>();

            while (dataReader.Read())
            {
                clsAssets businessObject = new clsAssets();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsContacts</returns>
        internal List<clsAssets> PopulateObjectsFromReader2(IDataReader dataReader)
        {
            List<clsAssets> list = new List<clsAssets>();

            while (dataReader.Read())
            {
                clsAssets businessObject = new clsAssets();
                PopulateBusinessObjectFromReader2(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }
        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsContacts</returns>
        internal List<clsAssets> PopulateObjectsFromReader3(IDataReader dataReader)
        {
            List<clsAssets> list = new List<clsAssets>();

            while (dataReader.Read())
            {
                clsAssets businessObject = new clsAssets();
                PopulateBusinessObjectFromReader3(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsAssets> PopulateObjectsFromReader4(IDataReader dataReader)
        {
            List<clsAssets> list = new List<clsAssets>();

            while (dataReader.Read())
            {
                clsAssets businessObject = new clsAssets();
                PopulateBusinessObjectFromReader4(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsNickname> PopulateObjectsFromReaderForNickname(IDataReader dataReader)
        {
            List<clsNickname> list = new List<clsNickname>();

            while (dataReader.Read())
            {
                clsNickname businessObject = new clsNickname();
                PopulateBusinessObjectFromReaderForNickname(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }
        #endregion

    }
}
///////////////////////////////////
//   AEVAN CAMILLE BATONGBACAL   //
///////////////////////////////////
