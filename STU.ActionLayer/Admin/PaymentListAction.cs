using STA.DataLayer.Advertisement;
using STU.BaseLayer.Advertisement;
using STU.BaseLayer;
using STU.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STA.DataLayer.Admin;

namespace STU.ActionLayer.Admin
{
    public class PaymentListAction
    {

        PaymentListDL paymentlistdl;
        ActionResult actionResult;
        #region GetPaymentListbyMonth
        public ActionResult GetPaymentListforMonth(string Month, string Year)
        {
            paymentlistdl = new PaymentListDL();
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = paymentlistdl.GetPaymentListforMonth(Month,Year);
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
