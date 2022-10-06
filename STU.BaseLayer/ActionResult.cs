using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace STU.BaseLayer
{
    public class ActionResult
    {

        #region Declarations
        private string returnMessage = "";
        private int rowsAffected;
        private bool isError;
        private bool isSuccess;
        private DataSet _dsResult;
        private DataTable _dtResult;
        private List<string> _ltResult;

        #endregion

        #region Properties
        public string ReturnMessage
        {
            get { return returnMessage; }
            set { returnMessage = value; }
        }

        public int RowsAffected
        {
            get { return rowsAffected; }
            set { rowsAffected = value; }
        }

        public bool IsError
        {
            get { return isError; }
            set { isError = value; }
        }

        public DataSet dsResult
        {
            get { return _dsResult; }
            set { _dsResult = value; }
        }

        public DataTable dtResult
        {
            get { return _dtResult; }
            set { _dtResult = value; }
        }
        public List<string> ltResult
        {
            get { return _ltResult; }
            set { _ltResult = value; }
        }
        public bool IsSuccess
        {
            get { return isSuccess; }
            set { isSuccess = value; }
        }
        #endregion
    }
}
