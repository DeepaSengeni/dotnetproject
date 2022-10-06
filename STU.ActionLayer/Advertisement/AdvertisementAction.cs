using STA.DataLayer.Advertisement;
using STU.BaseLayer;
using STU.BaseLayer.Advertisement;
using STU.BaseLayer.Book;
using STU.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STU.ActionLayer.Advertisement
{
    public class AdvertisementAction
    {
        AdvertisementDL advertisementdl;
        ActionResult actionResult;

        #region Advertisement_Insert
        public ActionResult Advertisement_Insert(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.Advertisement_Insert(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region CheckAvailability
        public ActionResult CheckAvailability(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.CheckAvailability(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region CheckCityAd_Availability
        public ActionResult CheckCityAd_Availability(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.CheckCityAd_Availability(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region Advertisement_Update
        public ActionResult Advertisement_Update(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.Advertisement_Update(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region Advertisement_Delete
        public ActionResult Advertisement_Delete(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.Advertisement_Delete(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region adcreation_LoadByAdId
        public ActionResult adcreation_LoadByAdId(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.adcreation_LoadByAdId(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion


        #region Mehod Add_Transaction_Response
        public ActionResult Add_Transaction_Response(checkoutbase check)
        {
            actionResult = new ActionResult();
            try
            {
                advertisementdl = new AdvertisementDL();
                actionResult.dtResult = advertisementdl.Add_Transaction_Response(check);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region PaymentRequest_UPI
        public ActionResult PaymentRequest_UPI(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.PaymentRequest_Bank(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion
        #region PaymentRequest_Bank
        public ActionResult PaymentRequest_Bank(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.PaymentRequest_Bank(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion


        #region saveAd_Clicks
        public ActionResult saveAd_Clicks(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.saveAd_Clicks(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region GetClickCount_ByAdId
        public ActionResult GetClickCount_ByAdId(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.GetClickCount_ByAdId(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region getAccountDetails_ByUserId
        public ActionResult getAccountDetails_ByUserId(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.getAccountDetails_ByUserId(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion


        #region PaymentRequest_LoadAll
        public ActionResult PaymentRequest_LoadAll()
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.PaymentRequest_LoadAll();
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion


        #region UpdatePaymentStatus_ByUserId
        public ActionResult UpdatePaymentStatus_ByUserId(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.UpdatePaymentStatus_ByUserId(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region PriceTable_S
        public ActionResult PriceTable_S()
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.PriceTable_S();
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion


        #region PriceTable_IU
        public ActionResult PriceTable_IU(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.PriceTable_IU(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region PaymentRequest_LoadByUserId
        public ActionResult PaymentRequest_LoadByUserId(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.PaymentRequest_LoadByUserId(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region UpdateOtrdeId_ByAdId
        public ActionResult UpdateOtrdeId_ByAdId(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.UpdateOtrdeId_ByAdId(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region GetAdList
        public ActionResult GetAdList()
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.GetAdList();
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion


        #region GetAdsList_ByUserId
        public ActionResult GetAdsList_ByUserId(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dsResult = advertisementdl.GetAdsList_ByUserId(advertisementbase);
                if (actionResult.dsResult != null)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region GetPageList_ByUserId
        public ActionResult GetPageList_ByUserId(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dsResult = advertisementdl.GetPageList_ByUserId(advertisementbase);
                if (actionResult.dsResult != null)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region PaymentDetails_Insert
        public ActionResult PaymentDetails_Insert(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.PaymentDetails_Insert(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region getpaymentDetails_ByadID
        public ActionResult getpaymentDetails_ByadID(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.getpaymentDetails_ByadID(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region Paypaldetails_Insert_Update
        public ActionResult Paypaldetails_Insert_Update(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.Paypaldetails_Insert_Update(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region UpdatePaymentBatch_ID
        public ActionResult UpdatePaymentBatch_ID(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.UpdatePaymentBatch_ID(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion


        #region getID_PaymentRequest
        public ActionResult getID_PaymentRequest(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.getID_PaymentRequest(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region ForConvertCurrency_GetPrimaryRate
        public ActionResult ForConvertCurrency_GetPrimaryRate(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.ForConvertCurrency_GetPrimaryRate(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region FindusersDetailofCreatedForCity
        public ActionResult FindusersDetailofCreatedForCity(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.FindusersDetailofCreatedForCity(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region cityId_Insert
        public ActionResult cityId_Insert(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.cityId_Insert(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region deleteaddwhichisnotpaidamount
        public ActionResult deleteaddwhichisnotpaidamount(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dsResult = advertisementdl.DeleteAddWhichIsnotPaid(advertisementbase);
                if (actionResult.dsResult != null && actionResult.dsResult.Tables.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region SumofAllCityPricing
        public ActionResult SumofAllCityPricing()
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dsResult = advertisementdl.SumofAllCityPricing();
                if (actionResult.dsResult != null && actionResult.dsResult.Tables.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region UPIdetails_Insert_Update
        public ActionResult UPIdetails_Insert_Update(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.UPIDetails_Insert_Update(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

        #region Bankdetails_Insert_Update
        public ActionResult Bankdetails_Insert_Update(AdvertisementBase advertisementbase)
        {
            advertisementdl = new AdvertisementDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = advertisementdl.BankDetails_Insert_Update(advertisementbase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                    actionResult.IsSuccess = true;
                else
                    actionResult.IsError = true;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return actionResult;
        }
        #endregion

    }
}
