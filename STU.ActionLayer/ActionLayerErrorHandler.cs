using STU.BaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace STU.ActionLayer
{
    public class ActionLayerErrorHandler
    {
        #region ReportException
        public static void ReportException(Exception ex, ActionResult ac)
        {
            ac.IsError = true;
            //GlobalErrorHandling.ActionLayerError(ex);
        }
        #endregion


    }
}
