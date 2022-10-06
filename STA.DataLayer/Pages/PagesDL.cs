using STU.BaseLayer.Pages;
using STU.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA.DataLayer.Pages
{
    public class PagesDL
    {
        #region Declaration
        DataSet dsContainer;
        DataTable dtContainer;
        #endregion

        #region Pages_InsertUpdate
        public DataTable Pages_InsertUpdate(PagesBase pagesBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={        
                                            new MyParameter("@Id",pagesBase.Id),
                                            new MyParameter("@BookId",pagesBase.BookId),
                                            new MyParameter("@PageImage",pagesBase.PageImage),
                                            new MyParameter("@PageTitle",pagesBase.PageTitle),
                                            new MyParameter("@DisplayOrder",pagesBase.DisplayOrder),
                                            new MyParameter("@ChapterName",pagesBase.ChapterName)
                               };
                Common.Set_Procedures("USP_IU_Pages");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Pages_LoadBy_BookId
        public DataTable Pages_LoadBy_BookId(PagesBase pagesBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={        
                                            
                                            new MyParameter("@BookId",pagesBase.BookId)
                               };
                Common.Set_Procedures("USP_S_Pages_LoadBy_BookId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Pages_LoadBy_Id
        public DataTable Pages_LoadBy_Id(PagesBase pagesBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={        
                                            new MyParameter("@Id",pagesBase.Id)
                               };
                Common.Set_Procedures("USP_S_Pages_LoadBy_Id");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region RemovePageById
        public DataTable RemovePageById(PagesBase pageBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@pageId",pageBase.PageTitle)
                                        
                                        };
                Common.Set_Procedures("RemovePageById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch(Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Ad_LoadBy_BookId
        public DataTable Ad_LoadBy_BookId(PagesBase pagesBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={      
                                            
                                            ////new MyParameter("@BookId",pagesBase.BookId),
                                              new MyParameter("@UserId",pagesBase.UserId),
                                               new MyParameter("@City",pagesBase.CityName)
                                          
                               };
                Common.Set_Procedures("aduploaded_LoadImage");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion


        #region Ad_LoadBy_Id
        public DataTable Ad_LoadBy_Id(PagesBase pagesBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={        
                                            
                                            new MyParameter("@Id",pagesBase.Id)
                               };
                Common.Set_Procedures("Ad_LoadBy_Id");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
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
