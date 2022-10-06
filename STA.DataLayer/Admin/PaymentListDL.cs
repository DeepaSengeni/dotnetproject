using STU.BaseLayer.Advertisement;
using STU.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA.DataLayer.Admin
{
    public class PaymentListDL
    {
        #region Declaration
        DataSet dsContainer;
        DataTable dtContainer;

        #endregion
        #region PaymentRequest_Bank
        public DataTable GetPaymentListforMonth(string Month,string Year)
        {
            dsContainer = new DataSet();
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                          new MyParameter("@Month",Month),
                                          new MyParameter("@Year",Year),
                                         };
                Common.Set_Procedures("GetPaymentListforMonth");
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
    }
}
