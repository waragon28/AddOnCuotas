using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Drawing;
using SAPbobsCOM;
using Forxap.Framework.Extensions;



using Forxap.Banco.Win;


namespace Forxap.Banco.UI.Win
{
    public class Utils
    {







        ///// <summary>
        ///// Carga un combobox dentro de una grilla con los tipos de planillas
        ///// </summary>
        ///// <param name="oComboBox"></param>
        //public static void LoadTipoPlanilla(ref  SAPbouiCOM.Column oColumn)
        //{
        //    if (oColumn != null)
        //    {
        //        List<TipoPlanilla> listObject = new List<TipoPlanilla>();
        //        //TipoPlanillaBLL businessLogic = new TipoPlanillaBLL();

        //        //listObject = businessLogic.GetAll();
        //        //foreach (var item in listObject)
        //        //{
        //        //    oColumn.ValidValues.Add(item.Code, item.Name);
        //        //}

        //    }

        //}




        /// <summary>
        /// Carga un combobox con los vendedores
        /// </summary>
        /// <param name="oComboBox"></param>
        public static void LoadVendedor(ref SAPbouiCOM.ComboBox oComboBox)
        {
            Dictionary<string, string> listObject;
            if (oComboBox != null)
            {

                listObject = Framework.DI.Sb1Users.GetListFromSQL("CALL SP_VIS_ABNK_PERSON_POSITION ('1') ");
                foreach (var item in listObject)
                {
                    oComboBox.ValidValues.Add(item.Key, item.Value);
                }

                oComboBox.Item.DisplayDesc = true;
            }

        }

        /// <summary>
        /// Carga un combobox con los supervisores
        /// </summary>
        /// <param name="oComboBox"></param>
        public static void LoadUnidadNegocio(ref SAPbouiCOM.ComboBox oComboBox)
        {
            Dictionary<string, string> listObject;
            if (oComboBox != null)
            {

                listObject = Framework.DI.Sb1Users.GetListFromSQL("CALL SP_VIS_ABNK_BUSINNES_UNIT() ");
                foreach (var item in listObject)
                {
                    oComboBox.ValidValues.Add(item.Key, item.Value);
                }

                oComboBox.Item.DisplayDesc = true;
            }

        }


        /// <summary>
        /// Carga un combobox con los valores validos
        /// </summary>
        /// <param name="oComboBox"></param>
        /// <param name="tableID"></param> 
        public static void LoadTipoPago(ref SAPbouiCOM.ComboBox oComboBox)
        {
            Dictionary<string, string> listObject;
            if (oComboBox != null)
            {

                listObject = Framework.DI.ValidValues.GetValidValues("@VIST_DEPOSITO1", "VIS_IncomeType");
                foreach (var item in listObject)
                {
                    oComboBox.ValidValues.Add(item.Key, item.Value);
                }

                oComboBox.Item.DisplayDesc = true;
            }

        }


        /// <summary>
        /// Carga un combobox con los valores validos
        /// </summary>
        /// <param name="oComboBox"></param>
        /// <param name="tableID"></param> 
        public static void LoadEstado(ref SAPbouiCOM.ComboBox oComboBox)
        {
            Dictionary<string, string> listObject;
            if (oComboBox != null)
            {

                listObject = Framework.DI.ValidValues.GetValidValues("@VIST_DEPOSITO1", "VIS_Status");
                foreach (var item in listObject)
                {
                    oComboBox.ValidValues.Add(item.Key, item.Value);
                }

                oComboBox.Item.DisplayDesc = true;
            }

        }

        /// <summary>
        /// Carga un combobox con los bancos
        /// </summary>
        /// <param name="oComboBox"></param>
        /// <param name="tableID"></param> 
        public static void LoadBancos(ref SAPbouiCOM.ComboBox oComboBox)
        {

            Framework.DI.Bancos.Banks.GetBankList(ref oComboBox);
            
        }



        /// <summary>
        /// Carga un combobox con las cuentas
        /// </summary>
        /// <param name="oComboBox"></param>
        /// <param name="tableID"></param> 
        public static void LoadCuentas(ref SAPbouiCOM.ComboBox oComboBox , string bankCode, string Currency)
        {

            Framework.DI.Bancos.Banks.GetAccountList(ref oComboBox, bankCode, Currency);

        }

        public static void LoadMonedas(ref SAPbouiCOM.ComboBox oComboBox)
        {

            Framework.DI.Bancos.Banks.GetMonedas(ref oComboBox);

        }

        /// <summary>
        /// Carga un combobox con los supervisores
        /// </summary>
        /// <param name="oComboBox"></param>
        public static void LoadEstadoo(ref SAPbouiCOM.ComboBox oComboBox)
        {
            Dictionary<string, string> listObject;
            if (oComboBox != null)
            {

                listObject = Framework.DI.Sb1Users.GetListFromSQL("CALL d() ");
                foreach (var item in listObject)
                {
                    oComboBox.ValidValues.Add(item.Key, item.Value);
                }

                oComboBox.Item.DisplayDesc = true;
            }

        }

        /// <summary>
        /// Carga un combobox con los supervisores
        /// </summary>
        /// <param name="oComboBox"></param>
        public static void LoadSupervisor(ref SAPbouiCOM.ComboBox oComboBox)
        {
            Dictionary<string, string> listObject;
            if (oComboBox != null)
            {

                listObject = Framework.DI.Sb1Users.GetListFromSQL("CALL SP_VIS_ABNK_PERSON_POSITION ('SUPERVISOR') ");
                foreach (var item in listObject)
                {
                    oComboBox.ValidValues.Add(item.Key, item.Value);
                }

                oComboBox.Item.DisplayDesc = true;
            }

        }


        /// <summary>
        /// Carga un combobox con los usuarios
        /// </summary>
        /// <param name="oComboBox"></param>
        public static void LoadUsers(ref  SAPbouiCOM.ComboBox oComboBox)
        {
            Dictionary<string, string> listObject;
            if (oComboBox != null)
            {

                listObject = Framework.DI.Sb1Users.GetListUser();
                foreach (var item in listObject)
                {
                    oComboBox.ValidValues.Add(item.Key,item.Value);
                }

                oComboBox.Item.DisplayDesc = true;
            }

        }

        /// <summary>
        /// Carga un combobox dentro de una grilla con los usuarios
        /// </summary>
        /// <param name="oComboBox"></param>
        public static void LoadUsers(ref  SAPbouiCOM.Column oColumn)
        {
            Dictionary<string, string> listObject;

            if (oColumn != null)
            {
                listObject = Framework.DI.Sb1Users.GetListUser();

               
                foreach (var item in listObject)
                {
                    oColumn.ValidValues.Add(item.Key, item.Value);
                }

            }

        }



        /// <summary>
        /// /
        /// </summary>
        /// <param name="oComboBox"></param>
        /// <param name="tableName"></param>
        public static void LoadMiscelaneo(ref  SAPbouiCOM.ComboBox oComboBox, string tableName)
        {
            
            Dictionary<string, string> listObject;
            if (oComboBox != null)
            {

                listObject = Framework.DI.Sb1Users.GetListFromUDT(tableName);
                foreach (var item in listObject)
                {
                    oComboBox.ValidValues.Add(item.Key, item.Value);
                }


            }
        }

        /// Carga un combobox dentro de una grilla 
        /// </summary>
        /// <param name="oComboBox"></param>
        public static void LoadMiscelaneo(ref  SAPbouiCOM.Column oColumn, string tableName)
        {
            Dictionary<string, string> listObject;
            if (oColumn != null)
            {
                if (oColumn.Type == SAPbouiCOM.BoFormItemTypes.it_COMBO_BOX)
                {

                  
                    listObject = Framework.DI.Sb1Users.GetListFromUDT(tableName);
                    foreach (var item in listObject)
                    {
                        oColumn.ValidValues.Add(item.Key, item.Value);
                    }
                }
            }

        }

    

        ///// <summary>
        ///// Carga un combobox con los estados civiles
        ///// </summary>
        ///// <param name="oComboBox"></param>
        //public static void LoadEstadoCivil(ref  SAPbouiCOM.ComboBox oComboBox)
        //{
        //    if (oComboBox != null)
        //    {
        //        List<EstadoCivil> listObject = new List<EstadoCivil>();
        //        EstadoCivilBLL businessLogic = new EstadoCivilBLL();

        //        listObject = businessLogic.GetAll();
        //        foreach (var item in listObject)
        //        {
        //            oComboBox.ValidValues.Add(item.Code, item.Name);
        //        }

        //    }

        //}


        /// <summary>
        /// Carga un combobox dentro de una grilla con los estados civiles
        /// </summary>
        /// <param name="oComboBox"></param>
        //public static void LoadEstadoCivil(ref SAPbouiCOM.Column oColumn)
        //{
        //    if (oColumn != null)
        //    {
        //        List<EstadoCivil> listObject = new List<EstadoCivil>();
        //        EstadoCivilBLL businessLogic = new EstadoCivilBLL();

        //        listObject = businessLogic.GetAll();
        //        foreach (var item in listObject)
        //        {
        //            oColumn.ValidValues.Add(item.Code, item.Name);
        //        }

        //    }
        //}


        //public static void LoadEstadoCivil(ref SAPbouiCOM.ValidValues  oValidValues)
        //{
        //    if (oValidValues != null)
        //    {
        //        List<EstadoCivil> listObject = new List<EstadoCivil>();
        //        EstadoCivilBLL businessLogic = new EstadoCivilBLL();

        //        listObject = businessLogic.GetAll();
        //        foreach (var item in listObject)
        //        {
        //            oValidValues.Add(item.Code, item.Name);
        //        }

        //    }
        //}



        //public static void SetAprobacionGritFormat(ref SAPbouiCOM.Grid oGrid, SAPbouiCOM.Form oForm)
        //{


        //    oForm.Freeze(true);

        //    QuotationBLL quotationBLL = new QuotationBLL();


        //    SAPbouiCOM.DataTable dataTable = oForm.DataSources.DataTables.Item("DT_0");

        //    oGrid = ((SAPbouiCOM.Grid)oForm.Items.Item("Item_15").Specific);
        //    //oGrid = ((SAPbouiCOM.Grid)(this.GetItem("Item_19").Specific));
        //    dataTable.Clear();
        //    oGrid.DataTable = null;


        //    for (int i = 0; i < dataTable.Columns.Count; i++)
        //    {
        //        dataTable.Columns.Remove(i);
        //    }

        //    dataTable.Columns.Add("DocEntry", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //    dataTable.Columns.Add("Vend", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 190);
        //    dataTable.Columns.Add("Código", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //    dataTable.Columns.Add("Socio Negocio", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //    dataTable.Columns.Add("N° Pedido", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //    dataTable.Columns.Add("Lin", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 1);
        //    dataTable.Columns.Add("#", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 1);
        //    dataTable.Columns.Add("Estructura", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //    dataTable.Columns.Add("Item", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //    dataTable.Columns.Add("Descripción", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //    dataTable.Columns.Add("Precio Unitario Concreto", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //    dataTable.Columns.Add("Precio Unitario Bomba", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //    dataTable.Columns.Add("Precio Unitario Tubos", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //    dataTable.Columns.Add("Minimo Concreto", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //    dataTable.Columns.Add("Cantidad Programada", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //    dataTable.Columns.Add("Total Concreto", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //    dataTable.Columns.Add("Minimo Bomba", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);


        //    oGrid.DataTable = dataTable;
        //    oForm.Freeze(false);
        //}

        //public static void SetBaseGritFormat(ref SAPbouiCOM.Grid oGrid, SAPbouiCOM.Form oForm)
        //{


        //        oForm.Freeze(true);

        //            QuotationBLL quotationBLL = new QuotationBLL();


        //            SAPbouiCOM.DataTable dataTable = oForm.DataSources.DataTables.Item("DT_0");

        //            oGrid = ((SAPbouiCOM.Grid)oForm.Items.Item("Item_15").Specific);
        //            //oGrid = ((SAPbouiCOM.Grid)(this.GetItem("Item_19").Specific));
        //            dataTable.Clear();
        //            oGrid.DataTable = null;


        //            for (int i = 0; i < dataTable.Columns.Count; i++)
        //            {
        //                dataTable.Columns.Remove(i);
        //            }

        //            dataTable.Columns.Add("DocEntry", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //            dataTable.Columns.Add("Código", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //            dataTable.Columns.Add("Socio Negocio", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //            dataTable.Columns.Add("N° Pedido", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //            dataTable.Columns.Add("Lin", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 1);
        //            dataTable.Columns.Add("#", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 1);
        //            dataTable.Columns.Add("Vend", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 190);
        //            dataTable.Columns.Add("Item", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //            dataTable.Columns.Add("Descripción", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //            dataTable.Columns.Add("Total Pedido", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //            dataTable.Columns.Add("Total Prog.", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //            dataTable.Columns.Add("% Prog.", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //            dataTable.Columns.Add("Program. Anterior", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);
        //            dataTable.Columns.Add("Program. Actual", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 254);


        //            oGrid.DataTable = dataTable;
        //        oForm.Freeze(false);
        //}

        public static bool  findDataTable (SAPbouiCOM.DataTable datatable, string numeroPedido,  string lineaPedido)
        {
            bool ret = false;

            string nroPedido = string.Empty;
            string linea = string.Empty;

            for (int i = 0; i < datatable.Rows.Count; i++)
			{
                nroPedido = datatable.GetValue("DocEntry", i).ToString();
                linea =  datatable.GetValue("Lin", i).ToString();
			 
                if ( (numeroPedido == nroPedido ) && (lineaPedido== linea ))
                {
                    ret = true;
                }
			}
             

            return ret;
        }

        

            
        public static bool   InitConfig ()
        {
            SAPbobsCOM.Recordset recordSet = null;
            string code = string.Empty;
            bool ret = false;
       

            recordSet = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            if (recordSet == null)
                throw new NullReferenceException("No se pudo obtener el objeto Recordset");

            try
            {
              
                string strSQL = "''";

                strSQL = string.Format("Select  \"Code\" From \"@FXP_DEMO_OADM\" where \"Code\" = 'CONFIG'  ");

                recordSet.DoQuery(strSQL);


                code = recordSet.Fields.Item("Code").Value.ToString();
               
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (recordSet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(recordSet);
                    recordSet = null;
                    GC.Collect();
                }
            }

            // si no existe el registro de la configuración lo debo agregar
            if (code.Length == 0)
            {

                SAPbobsCOM.GeneralService oGeneralService = null;
                SAPbobsCOM.GeneralData oGeneralData = null;
                SAPbobsCOM.GeneralData oChild = null;
                SAPbobsCOM.GeneralDataCollection oChildren = null;
                SAPbobsCOM.GeneralDataParams oGeneralParams = null;


                oGeneralService = Sb1Globals.oCompanyService.GetGeneralService("FXP_DEMO_OADM");


                oGeneralParams = ((SAPbobsCOM.GeneralDataParams)(oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralDataParams)));


                oGeneralData = (SAPbobsCOM.GeneralData)oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralData);

                //     oGeneralData = oGeneralService.GetByParams(oGeneralParams);
                oGeneralData.SetProperty("Code", "CONFIG");



                oGeneralService.Add(oGeneralData);




                //Specify data for main UDO






                //

            }
            else
            {
                ret = true;
            }

            return ret;
        }
     
      

    }// fin de la clase

}// fin del namespace
