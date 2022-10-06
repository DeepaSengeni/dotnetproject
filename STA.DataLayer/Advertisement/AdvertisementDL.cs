using STU.BaseLayer.Advertisement;
using STU.BaseLayer.Book;
using STU.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA.DataLayer.Advertisement
{
    public class AdvertisementDL
    {
        #region Declaration
        DataSet dsContainer;
        DataTable dtContainer;

        #endregion

        #region Advertisement_Insert
        public DataTable Advertisement_Insert(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                          new MyParameter("@UploadAdv",advertisementbase.fileuploadTable),
                                          new MyParameter("@Type",advertisementbase.uploadtype),
                                          new MyParameter("@Headline",advertisementbase.headline),
                                          new MyParameter("@Description",advertisementbase.description),
                                          new MyParameter("@UrlAddress",advertisementbase.urladdress),
                                          new MyParameter("@Price",advertisementbase.price),
                                          new MyParameter("@StartDate",advertisementbase.startdate),
                                          new MyParameter("@EndDate",advertisementbase.enddate),
                                          new MyParameter("@UserId",advertisementbase.userId),
                                          new MyParameter("@EmailId",advertisementbase.EmailId),
                                          new MyParameter("@MobileNumber",advertisementbase.MobileNumber),
                                          new MyParameter("@CountryId",advertisementbase.CountryId),
                                          new MyParameter("@StateId",advertisementbase.StateId),
                                          new MyParameter("@CityId",advertisementbase.CityId),
                                          new MyParameter("@AmountToBePaid",advertisementbase.AmountToBePaid),
                                          new MyParameter("@CategoryIds",advertisementbase.CategoryIds),
                                          new MyParameter("@Features",advertisementbase.Features)

                                         };
                Common.Set_Procedures("AdvertisementInsert");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region CheckAvailability
        public DataTable CheckAvailability(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                          new MyParameter("@StartDate",advertisementbase.startdate),
                                          new MyParameter("@EndDate",advertisementbase.enddate),
                                          new MyParameter("@CategoryIds",advertisementbase.CategoryIds)
                                         };
                Common.Set_Procedures("CheckAvailability");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region CheckCityAd_Availability
        public DataTable CheckCityAd_Availability(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                          new MyParameter("@Start",advertisementbase.Checkstartdate),
                                          new MyParameter("@End",advertisementbase.Checkenddate),
                                          new MyParameter("@allCityId",advertisementbase.MultiplecityId)
                                         };
                Common.Set_Procedures("CheckSlot");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Advertisement_Update
        public DataTable Advertisement_Update(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                          new MyParameter("@UploadAdv",advertisementbase.fileuploadTable),
                                          new MyParameter("@Type",advertisementbase.uploadtype),
                                          new MyParameter("@Headline",advertisementbase.headline),
                                          new MyParameter("@Description",advertisementbase.description),
                                          new MyParameter("@UrlAddress",advertisementbase.urladdress),
                                          new MyParameter("@Price",advertisementbase.price),
                                          new MyParameter("@EmailId",advertisementbase.EmailId),
                                          new MyParameter("@MobileNumber",advertisementbase.MobileNumber),
                                          new MyParameter("@CountryId",advertisementbase.CountryId),
                                          new MyParameter("@StateId",advertisementbase.StateId),
                                          new MyParameter("@CityId",advertisementbase.CityId),
                                          new MyParameter("@AdId",advertisementbase.adId)
                                         };
                Common.Set_Procedures("AdvertisementUpdate");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        
        #region adcreation_LoadByAdId
        public DataTable adcreation_LoadByAdId(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@AdId",advertisementbase.adId),
                                         };
                Common.Set_Procedures("adcreation_LoadByAdId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Method Add_Transaction_Response
        public DataTable Add_Transaction_Response(checkoutbase check)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                          new MyParameter("@TransactionId",check.TransactionId),
                                           new MyParameter("@TransactionStatus",check.Status),
                                         new MyParameter("@Response",check.Response)

                                        };
                Common.Set_Procedures("Add_Transaction_Response");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Advertisement_Delete
        public DataTable Advertisement_Delete(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                          new MyParameter("@AdId",advertisementbase.adId)
                                         };
                Common.Set_Procedures("AdvertisementDelete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region PaymentRequest_IU
        public DataTable PaymentRequest_IU(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                          new MyParameter("@UserId",advertisementbase.userId),
                                          new MyParameter("@AccountNo",advertisementbase.AccountNumber),
                                            new MyParameter("@IFSCCode",advertisementbase.IFSCCode),
                                          new MyParameter("@AmountRequested",advertisementbase.AmountRequested),
                                           new MyParameter("@AccountHolderName",advertisementbase.AccountHolderName),
                                           new MyParameter("@EmailId",advertisementbase.EmailId),
                                           new MyParameter("@AmountCurrency",advertisementbase.Currency),
                                           new MyParameter("@ExchangeRate",advertisementbase.ExchangeRate)
                                         };
                Common.Set_Procedures("PaymentRequest_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region saveAd_Clicks
        public DataTable saveAd_Clicks(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@BookId",advertisementbase.BookId),
                                            new MyParameter("@AdId",advertisementbase.adId),
                                            new MyParameter("@UserId",advertisementbase.userId)
                                         };
                Common.Set_Procedures("Click_OnAd");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region GetClickCount_ByAdId
        public DataTable GetClickCount_ByAdId(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {


                                            new MyParameter("@AdId",advertisementbase.adId),


                                         };
                Common.Set_Procedures("GetClickCount_ByAdId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region getAccountDetails_ByUserId
        public DataTable getAccountDetails_ByUserId(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {


                                            new MyParameter("@Id",advertisementbase.userId),


                                         };
                Common.Set_Procedures("getAccountDetails_ByUserId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region PaymentRequest_LoadAll
        public DataTable PaymentRequest_LoadAll()
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         };
                Common.Set_Procedures("GetAllPaymentRequests");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region UpdatePaymentStatus_ByUserId
        public DataTable UpdatePaymentStatus_ByUserId(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                            new MyParameter("@id",advertisementbase.Id),
                                         new MyParameter("@Status",advertisementbase.response_Status),

                                         };
                Common.Set_Procedures("UpdatePaymentStatus_ByUserId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region PriceTable_S
        public DataTable PriceTable_S()
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         };
                Common.Set_Procedures("PriceTable_S");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region PriceTable_IU
        public DataTable PriceTable_IU(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                            new MyParameter("@Price",advertisementbase.AmountToBePaid)

                                         };
                Common.Set_Procedures("PriceTable_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region PaymentRequest_LoadByUserId
        public DataTable PaymentRequest_LoadByUserId(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                            new MyParameter("@UserId",advertisementbase.userId),
                                         };
                Common.Set_Procedures("PaymentRequests_ByUserId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region UpdateOtrdeId_ByAdId
        public DataTable UpdateOtrdeId_ByAdId(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                          new MyParameter("@AdId",advertisementbase.adId)  ,
                                          new MyParameter("@OrderId",advertisementbase.OrderId)
                                         };
                Common.Set_Procedures("UpdateOtrdeId_ByAdId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region GetAdList
        public DataTable GetAdList()
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         };
                Common.Set_Procedures("GetAdList");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region GetAdsList_ByUserId
        public DataSet GetAdsList_ByUserId(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                               new MyParameter("@UserId",advertisementbase.userId)
                                         };
                Common.Set_Procedures("GetAdsList_ByUserId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dsContainer;
        }
        #endregion

        #region GetPageList_ByUserId
        public DataSet GetPageList_ByUserId(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                               new MyParameter("@UserId",advertisementbase.userId)
                                         };
                Common.Set_Procedures("GetPgaeClicks_ByUserId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dsContainer;
        }
        #endregion

        #region PaymentDetails_Insert
        public DataTable PaymentDetails_Insert(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                          new MyParameter("@UserId",advertisementbase.userId),                                         
                                          new MyParameter("@CurrencyCode",advertisementbase.Currency),
                                          new MyParameter("@ExchangeRate",advertisementbase.ExchangeRate),
                                          new MyParameter("@paymentId",advertisementbase.paymentId),
                                          new MyParameter("@totalammount",advertisementbase.totalammount),
                                          new MyParameter("@Currency",advertisementbase.Currency),
                                          new MyParameter("@Payer_id",advertisementbase.Payer_id),
                                          new MyParameter("@intent",advertisementbase.intent),
                                          new MyParameter("@state",advertisementbase.state),
                                          new MyParameter("@AddId",advertisementbase.Add_Creation_ID),
                                          new MyParameter("@Response",advertisementbase.Response)
                                         };
                Common.Set_Procedures("PaymentDetails_Insert");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region getpaymentDetails_ByadID
        public DataTable getpaymentDetails_ByadID(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@AdId",advertisementbase.adId),
                                         };
                Common.Set_Procedures("getpaymentDetails_ByadID");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Paypaldetails_Insert_Update
        public DataTable Paypaldetails_Insert_Update(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                          new MyParameter("@UserId",advertisementbase.userId),
                                           new MyParameter("@Email",advertisementbase.EmailId)
                                         };
                Common.Set_Procedures("Paypaldetails_Insert_Update");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Change_Payment_Status
        public DataTable Change_Payment_Status(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                          new MyParameter("@UserId",advertisementbase.userId),
                                          new MyParameter("@Payer_id",advertisementbase.Payer_id),
                                          new MyParameter("@intent",advertisementbase.intent),
                                          new MyParameter("@state",advertisementbase.state),
                                           new MyParameter("@AddId",advertisementbase.Add_Creation_ID)
                                         };
                Common.Set_Procedures("Change_Payment_Status");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region UpdatePaymentBatch_ID
        public DataTable UpdatePaymentBatch_ID(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                           new MyParameter("@Id",advertisementbase.Id),
                                            new MyParameter("@payoutBatch_id",advertisementbase.payout_batch_id),
                                             new MyParameter("@SenderBatch_id",advertisementbase.sender_batch_id)

                                         };
                Common.Set_Procedures("UpdatePaymentBatch_ID");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region getID_PaymentRequest
        public DataTable getID_PaymentRequest(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@userId",advertisementbase.userId),
                                         };
                Common.Set_Procedures("getID_PaymentRequest");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region ForConvertCurrency_GetPrimaryRate
        public DataTable ForConvertCurrency_GetPrimaryRate(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                         };
                Common.Set_Procedures("ForConvertCurrency_GetPrimaryRate");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region FindusersDetailofCreatedForCity
        public DataTable FindusersDetailofCreatedForCity(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                          new MyParameter("@AdId",advertisementbase.Add_Creation_ID),
                                          new MyParameter("@Headline",advertisementbase.headline),
                                          new MyParameter("@UserId",advertisementbase.userId),
                                          new MyParameter("@CityId",advertisementbase.CityId),
                                   
                                         };
                Common.Set_Procedures("FindusersDetailofCreatedForCity");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region cityId_Insert
        public DataTable cityId_Insert(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                          new MyParameter("@adId",advertisementbase.adId),
                                          new MyParameter("@cityid",advertisementbase.CityId),
                                          new MyParameter("@StartDate",advertisementbase.startdate),
                                          new MyParameter("@EndDate",advertisementbase.enddate)
                                         
                                         };
                Common.Set_Procedures("cityId_Insert");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
                dtContainer = dsContainer.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region DeleteAddWhichIsnotPaid
        public DataSet DeleteAddWhichIsnotPaid(AdvertisementBase advertisementbase)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                             new MyParameter("@Adid",advertisementbase.adId),
                                             new  MyParameter("@res",advertisementbase.description)
                                          };
                Common.Set_Procedures("deleteaddwhichisnotpaidamount");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dsContainer;
        }
        #endregion

        #region SumofAllCityPricing
        public DataSet SumofAllCityPricing()
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                          };
                Common.Set_Procedures("SumofAllCityPricing");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dsContainer;
        }
        #endregion

   


    }
}
