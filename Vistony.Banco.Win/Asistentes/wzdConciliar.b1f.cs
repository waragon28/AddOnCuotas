//#define AD_BO

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;
using Forxap.Banco.UI.Win.Asistentes;
using Forxap.Banco.UI.Constans;
using Forxap.Framework.UI;
using Vistony.Banco.BO;
using Newtonsoft.Json;
using RestSharp;
using Vistony.Banco.DAL;
using System.Windows.Forms;
using System.Threading;
using DLBancos;
using System.IO;
using System.Data;
using System.ComponentModel;

namespace Forxap.Banco.UI.Win.Interfaz
{
    [FormAttribute("Conciliar ", "Asistentes/wzdConciliar.b1f")]
    class wzdConciliar  : BaseWizard 
    {


        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.Grid oGridBancos;
        private SAPbouiCOM.Grid oGridConciliado;

        /*
        public wzdConciliar()
        {
        }
        */
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.btnCancel = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.btnPrior = ((SAPbouiCOM.Button)(this.GetItem("6").Specific));
            this.btnPrior.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.btnPrior_PressedAfter);
            this.btnNext = ((SAPbouiCOM.Button)(this.GetItem("7").Specific));
            this.btnNext.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.btnNext_PressedBefore);
            this.btnNext.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.btnNext_PressedAfter);
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.lblTitle = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.lblPageNumber = ((SAPbouiCOM.StaticText)(this.GetItem("142").Specific));
            //                                        this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_34").Specific));
            this.oGrid = ((SAPbouiCOM.Grid)(this.GetItem("Item_40").Specific));
            this.oGrid.ValidateBefore += new SAPbouiCOM._IGridEvents_ValidateBeforeEventHandler(this.oGrid_ValidateBefore);
            this.oGrid.ClickAfter += new SAPbouiCOM._IGridEvents_ClickAfterEventHandler(this.oGrid_ClickAfter);
            //                                                 this.btnCancelDoc.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.btnCancelDoc_PressedBefore);
            //                                                   this.chkSup = ((SAPbouiCOM.CheckBox)(this.GetItem("Item_7").Specific));
            //                                                   this.chkSup.PressedAfter += new SAPbouiCOM._ICheckBoxEvents_PressedAfterEventHandler(this.CheckBox1_PressedAfter);
            //                                                   this.cbxSup = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_8").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_20").Specific));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_29").Specific));
            //                                         this.ComboBox2.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.ComboBox2_ComboSelectAfter);
            //                                     this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_6").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("7").Specific));
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("Item_37").Specific));
            this.Button3.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button3_ClickBefore);
            this.Button4 = ((SAPbouiCOM.Button)(this.GetItem("Item_12").Specific));
            this.Button4.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button4_ClickBefore);
            this.Button4.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button2_ClickAfter);
            this.Button3.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button3_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("7").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("7").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("7").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("7").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("7").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("7").Specific));
            this.Grid1 = ((SAPbouiCOM.Grid)(this.GetItem("Item_40").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_31").Specific));
            this.EditText2.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText2_ClickAfter);
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_35").Specific));
            this.ComboBox2 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_11").Specific));
            this.ComboBox2.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.ComboBox2_ComboSelectAfter);
            this.ComboBox2.ClickAfter += new SAPbouiCOM._IComboBoxEvents_ClickAfterEventHandler(this.ComboBox2_ClickAfter);
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_15").Specific));
            //              this.Grid2 = ((SAPbouiCOM.Grid)(this.GetItem("Item_16").Specific));
            this.oGridConciliado = ((SAPbouiCOM.Grid)(this.GetItem("Item_16").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_17").Specific));
            this.Grid4 = ((SAPbouiCOM.Grid)(this.GetItem("Item_18").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_19").Specific));
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_21").Specific));
            this.Button5 = ((SAPbouiCOM.Button)(this.GetItem("6").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("7").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_0").Specific));
            this.ComboBox0.ClickAfter += new SAPbouiCOM._IComboBoxEvents_ClickAfterEventHandler(this.ComboBox0_ClickAfter);
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("7").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("7").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("7").Specific));
            this.Grid1 = ((SAPbouiCOM.Grid)(this.GetItem("Item_40").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("7").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("7").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("7").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);

        }



        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter(); // centro la pantalla
       
       
            //Utils.LoadBancos(ref ComboBox2);// carga los s bancos

            btnPrior.Item.Enabled = false;
            PaneLevel = 1;
            PaneMax = 5;
            lblTitle.SetBold();
            lblTitle.SetSize(12);
            lblPageNumber.Item.ToPane = PaneMax+1;
            lblPageNumber.SetBold();
            
        
            ComboBox2.ValidValues.Add("M", "Migrar Archivo Excel");
            ComboBox2.ValidValues.Add("A", "Migrar Mes Anterior");
            ComboBox2.Select("M");

            SAPbouiCOM.ComboBox cb2 = oForm.GetComboBox("Item_0");
 
            for (int i = 0; i <= 12; i++)
            {
                cb2.ValidValues.Add(DateTime.Now.AddMonths(-i).Date.ToString("yyyy-MM"), DateTime.Now.AddMonths(-i).Date.ToString("yyyy-MM"));
            }

            activarControlesPanel2(false);

            if (ComboBox2.Value == "A")
            {
                EditText2.Item.Enabled = false;
                Button4.Item.Enabled = false;
            }
            else
            {
                EditText2.Item.Enabled = true;
                Button4.Item.Enabled = true;
            }
        }




        private void PriorPane()
        {
            if (PaneLevel >= 2)
            {
                oForm.PaneLevel -= 1;
            }

            if (PaneLevel == 1)
            {
                btnPrior.Item.Enabled = false;
            }
            else
            {
                btnPrior.Item.Enabled = true;
                btnNext.Caption = AddonMessageInfo.Message122;
            }

            SetPageNumber();
        }

        private void LoadCuentas2 (string banco, string Currency)
        {

        }

        private void NextPane()
        {

            if (PaneLevel - 1 == 1)
            {
                SAPbouiCOM.EditText txturl = oForm.GetEditText("Item_31");
                string textoURL = txturl.Value.Trim();

                if (Grid1.Rows.Count == 0)
                {
                    Sb1Messages.ShowMessageBoxWarning("No realizó ningun proceso de importación (Externa/Mes Ant.");
                    return;

                }
                if (ComboBox2.GetSelectedValue().ToString() == "M")
                {
                    if (textoURL == "")
                    {
                        Sb1Messages.ShowMessageBoxWarning("Debe seleccionar un archivo para procesarlo");
                        return;
                    }
                }
                else
                {
                    if (ComboBox0.Value == "")
                    {
                        Sb1Messages.ShowMessageBoxWarning("Debe seleccionar un periodo para la búsqueda");
                        ComboBox0.SetFocus();
                        return;
                    }
                }

                bool consultar = false;
                //MessageBox.Show
                consultar = Sb1Messages.ShowQuestion("Desea procesar la información?");
                if (!consultar)
                {
                    return;
                }
                else
                {
                    SetPageNumber();
                    btnPrior.Item.Enabled = true;
                    btnNext.Caption = AddonMessageInfo.Message122;
                    Thread mythr = new Thread(LoadData);
                    mythr.Name = "MigraCuotas";
                    mythr.Start();
                    mythr.IsBackground = true;
                    return;

                }
            }

            if (PaneLevel - 1 == 2)
            {
               
               

   
            }

            if ((PaneLevel -1 ) < PaneMax)
            {
                
                oForm.PaneLevel += 1;
            }
            SetPageNumber();

           
            

            if ((PaneLevel -1 ) == 3)
            {
                btnNext.Caption = AddonMessageInfo.Message123;
               

            }
            else
            {
                btnPrior.Item.Enabled = true;
                btnNext.Caption = AddonMessageInfo.Message122;
            }
        }


 
        private void SetPageNumber()
        {
         
            lblPageNumber.Caption = string.Format("Paso  {0} de {1} ", (PaneLevel - 1), (PaneMax));
            Sb1Messages.ShowMessage ("");
        }

        private void btnPrior_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            PriorPane();
        }



        private void txtSN_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));

            
            if (chooseFromListEvent.SelectedObjects != null)
            {

                if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                {
                    oForm.SetUserDataSource("UD_SN", chooseFromListEvent.SelectedObjects.GetValue("CardCode", 0).ToString().Trim());
                    oForm.SetUserDataSource("UD_SNEx", chooseFromListEvent.SelectedObjects.GetValue("CardName", 0).ToString().Trim());
                   
                }
            }
            else
            {
                oForm.SetUserDataSource("UD_SN", string.Empty);
                oForm.SetUserDataSource("UD_SNEx", string.Empty);

            }

        }

        

        private void oGrid_ValidateBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            
          
        }

       
        private void ItemCode_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));


            if (chooseFromListEvent.SelectedObjects != null)
            {

                if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                {
                    oForm.SetUserDataSource("UD_ITM", chooseFromListEvent.SelectedObjects.GetValue("ItemCode", 0).ToString().Trim());
                    oForm.SetUserDataSource("UD_ITMEx", chooseFromListEvent.SelectedObjects.GetValue("ItemName", 0).ToString().Trim());

                }
            }
            else
            {
                oForm.SetUserDataSource("UD_ITM", string.Empty);
                oForm.SetUserDataSource("UD_ITMEx", string.Empty);

            }

        }


        private bool Validate()
        {

            bool ret = true;
            
            if (oForm.PaneLevel == 2)
            {

              
            }
         

            return ret;
        }

        
        private void btnNext_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            Sb1Messages.ShowMessage(oForm.PaneLevel.ToString());
          BubbleEvent = Validate();

        }
        private void btnNext_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (btnNext.Caption == AddonMessageInfo.Message122)
                NextPane();
            else
                btnCancel.Item.Click(SAPbouiCOM.BoCellClickType.ct_Regular);
        }

        private void chkItem_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

        }

        private void chkItem_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
          

        }



        private void LoadData()
        {
            try
            {
               // oForm.Freeze(true);
                SAPbouiCOM.EditTextColumn oEditCol;
                SAPbouiCOM.DataTable dataTable;
                string columna = string.Empty;
                // string strSQL = string.Empty;
                string qStrSQL = string.Empty;

                string day = string.Empty;
                string month = string.Empty;
                string year = string.Empty;

                string startDate;
                string endDate;
                string und = null;
                string sup = null;
                string slp = null;
                string tipo = null;
                string dp = null;
                string status = "P";
                int row = 0;
                Cuotas pyd = new Cuotas();

                string TipoConciliacion = "";
                TipoConciliacion = ComboBox2.GetSelectedValue();


                Sb1Messages.ShowMessage("Limpiando Información... espere por favor");

                string fecha = ComboBox0.GetSelectedValue().ToString() + "-01";
                qStrSQL = string.Format("CALL P_VIS_VEN_LIMPIACUOTAS_MESANT ('{0}') ", fecha);
                SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_1");
                oDT.ExecuteQuery(qStrSQL);


                string strSQL = string.Format("CALL P_VIS_VEN_LISTARCUOTAS_MESANT ('{0}') ", fecha);

                List<Cuotas> cuotas = new List<Cuotas>();
                List<Cuotas> cuotasOK = new List<Cuotas>();
                List<CuotasErrores> cuotasERR = new List<CuotasErrores>();
                oGridConciliado.RemoveRows();
                Grid4.RemoveRows();
                SAPbouiCOM.DataTable dt = Grid1.DataTable;
                DataTable dtNet = new DataTable();



                for (row = 0; row <= dt.Rows.Count-1 ; row++)
                {
                    Sb1Messages.ShowMessage("Trabajando registro: " + (row+1).ToString() + " de " + dt.Rows.Count);
                    
                    List<Cuotas> lp = new List<Cuotas>();
                        pyd.U_CIA_CODCIA = dt.GetString("CODCIA", row);
                        pyd.U_ANO_CODANO = dt.GetString("ANIO", row);
                        pyd.U_MES_CODMES = dt.GetString("MES", row);
                        pyd.U_VDE_CODVDE = dt.GetString("VENDEDOR", row);
                        pyd.U_PROY_VENTVDE = Convert.ToDecimal(dt.GetString("CUOTA", row));
                        pyd.U_VAR_CODVAR = dt.GetString("VARIABLE", row);
                        pyd.U_TMO_CODTMO = dt.GetString("TIPOVAR", row);
                        pyd.U_PESO = dt.GetString("PESO", row);
                        pyd.U_AVANCE_REAL = 0;
                        pyd.U_INACTIVO = "0";
  


                        dynamic response;
                        Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();
                        dynamic jsonData = JsonConvert.SerializeObject(pyd);
                        response = methods.POST("VIS_PROY_VENT_VDE", jsonData);
                        dynamic json2;
                        json2 = JsonConvert.DeserializeObject(response.Content.ToString());
                        if (response.StatusCode.ToString() == "Created")
                        {
                            
                            try
                            {
                                Cuotas rp = new Cuotas();

                                rp.U_CIA_CODCIA = json2["U_CIA_CODCIA"].ToString();
                                rp.U_ANO_CODANO = json2["U_ANO_CODANO"].ToString();
                                rp.U_MES_CODMES = json2["U_MES_CODMES"].ToString();
                                rp.U_VDE_CODVDE = json2["U_VDE_CODVDE"].ToString();
                                rp.U_PROY_VENTVDE = Convert.ToDecimal(json2["U_PROY_VENTVDE"].ToString());
                                rp.U_VAR_CODVAR = json2["U_VAR_CODVAR"].ToString();
                                rp.U_TMO_CODTMO = json2["U_TMO_CODTMO"].ToString();
                                rp.U_PESO = json2["U_PESO"].ToString();
                                rp.U_AVANCE_REAL = 0;
                                rp.U_INACTIVO = "0";
                                cuotasOK.Add(rp);
                            }
                            catch (Exception ERR)
                            {

                            }
                        }
                        else
                        {

                            try
                            {
                                CuotasErrores rpe = new CuotasErrores();

                                rpe.U_CIA_CODCIA = dt.GetString("CODCIA", row);
                                rpe.U_ANO_CODANO = dt.GetString("ANIO", row);
                                rpe.U_MES_CODMES = dt.GetString("MES", row);
                                rpe.U_VDE_CODVDE = dt.GetString("VENDEDOR", row);
                                rpe.U_PROY_VENTVDE = Convert.ToDecimal(dt.GetString("CUOTA", row));
                                rpe.U_VAR_CODVAR = dt.GetString("VARIABLE", row);
                                rpe.U_TMO_CODTMO = dt.GetString("TIPOVAR", row);
                                rpe.U_PESO = dt.GetString("PESO", row);
                                rpe.U_AVANCE_REAL = 0;
                                rpe.U_INACTIVO = "0";
                                rpe.ERROR = response.Content.ToString();
                                cuotasERR.Add(rpe);
                            }
                            catch (Exception err)

                            {

                            }
    
                       }                   
                    }
                    
                    Sb1Messages.ShowMessage("Generando Resumenes.. espere por favor");

                    SAPbouiCOM.DataTable dt2 = oForm.GetDataTable("DT_2");
                    dt2.Clear();
                    var columns = dt2.Columns;
                    columns.Add("CODCIA", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    columns.Add("ANIO", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    columns.Add("MES", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    columns.Add("VENDEDOR", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    columns.Add("VARIABLE", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    columns.Add("CUOTA", SAPbouiCOM.BoFieldsType.ft_Price);
                    columns.Add("TIPOVAR", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);

                    columns.Add("PESO", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    columns.Add("AVANCE", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    columns.Add("INACTIVO", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);

                    //columns.Add("Pago a Cuenta", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                     oForm.Freeze(true);

                    for (int i = 0; i <= cuotasOK.Count() - 1; i++)
                    {
                    Sb1Messages.ShowMessage("Generando Resumenes --- registro: " + (i + 1).ToString() + " de " + cuotasOK.Count());
                    dt2.Rows.Add();
                        dt2.SetValue("CODCIA", i, cuotasOK[i].U_CIA_CODCIA);
                        dt2.SetValue("ANIO", i, cuotasOK[i].U_ANO_CODANO);
                        dt2.SetValue("MES", i, cuotasOK[i].U_MES_CODMES);
                        dt2.SetValue("VENDEDOR", i, cuotasOK[i].U_VDE_CODVDE);
                        dt2.SetValue("TIPOVAR", i, cuotasOK[i].U_TMO_CODTMO);
                        dt2.SetValue("CUOTA", i, cuotasOK[i].U_PROY_VENTVDE.ToString());
                        dt2.SetValue("VARIABLE", i, cuotasOK[i].U_VAR_CODVAR);
                        
                        dt2.SetValue("PESO", i, cuotasOK[i].U_PESO);
                        dt2.SetValue("AVANCE", i, "0");
                        dt2.SetValue("INACTIVO", i, "0");
                    }
                Sb1Messages.ShowMessage("Asignando Líneas");
                //oGridConciliado.AssignLineNro();
                    oGridConciliado.ReadOnlyColumns();
                    //oGridConciliado.Columns.Item(1).LinkedObjectType(oGridConciliado, "DocEntry", "24");
                    oGridConciliado.AutoResizeColumns();
                    //oForm.Freeze(false);

                    //////////////////////////////////////////////

                    SAPbouiCOM.DataTable dt4 = oForm.GetDataTable("DT_5");
                    dt4.Clear();
                    var columnsERR = dt4.Columns;
                    columnsERR.Add("CODCIA", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    columnsERR.Add("ANIO", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    columnsERR.Add("MES", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    columnsERR.Add("VENDEDOR", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    columnsERR.Add("CUOTA", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    columnsERR.Add("VARIABLE", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    columnsERR.Add("TIPOVAR", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    
                    columnsERR.Add("PESO", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    columnsERR.Add("AVANCE", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    columnsERR.Add("INACTIVO", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    columnsERR.Add("ERROR", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);

                    //columns.Add("Pago a Cuenta", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);
                    //oForm.Freeze(true);

                    for (int i = 0; i <= cuotasERR.Count() - 1; i++)
                    {
                    Sb1Messages.ShowMessage("Validando Lista de erróneos: " + (i+1).ToString() + " de: " + cuotasERR.Count() );
                    dt4.Rows.Add();
                        dt4.SetValue("CODCIA", i, cuotasERR[i].U_CIA_CODCIA);
                        dt4.SetValue("ANIO", i, cuotasERR[i].U_ANO_CODANO);
                        dt4.SetValue("MES", i, cuotasERR[i].U_MES_CODMES);
                        dt4.SetValue("VENDEDOR", i, cuotasERR[i].U_VDE_CODVDE);
                        dt4.SetValue("TIPOVAR", i, cuotasERR[i].U_TMO_CODTMO);
                        dt4.SetValue("CUOTA", i, cuotasERR[i].U_PROY_VENTVDE.ToString());
                        dt4.SetValue("VARIABLE", i, cuotasERR[i].U_VAR_CODVAR);

                        dt4.SetValue("PESO", i, cuotasERR[i].U_PESO);
                        dt4.SetValue("AVANCE", i, "0");
                        dt4.SetValue("INACTIVO", i, "0");
                        dt4.SetValue("ERROR", i, cuotasERR[i].ERROR);
                    }
                Sb1Messages.ShowMessage("Culminando trabajos");
                //Grid4.AssignLineNro();
                    Grid4.ReadOnlyColumns();

                Grid4.AutoResizeColumns();
                oForm.PaneLevel += 1;
                SetPageNumber();
        }

            catch (Exception ex)
            {
                Sb1Messages.ShowMessage(ex.Message);
                
            }
            finally 
                {
                oForm.Freeze(false);
                Sb1Messages.ShowMessage("Trabajo culminado");
                Cursor.Current = Cursors.Default;
                Sb1Messages.ShowMessage("");
                btnNext.Item.Enabled = true;
                btnPrior.Item.Enabled = true;
                
            }
            

        }

        private void LoadDetalle(string deposito, string banco,string vendedor  )
        {
            oForm.Freeze(true);
          
            oForm.Freeze(false);
        }

     

        private SAPbouiCOM.CheckBox CheckBox0;


        private void oGrid_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            int row = 0;
            string banco = string.Empty;
            string vendedor = string.Empty;
            string deposito = string.Empty;
            SAPbouiCOM.DataTable oDatatable;


        }
        private SAPbouiCOM.CheckBox chkSup;
        private SAPbouiCOM.ComboBox cbxSup;

        private void CheckBox1_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (chkSup.Checked)
            {
                cbxSup.Item.Enabled = true;
                cbxSup.SetFocus();
            }
            else
            {
                cbxSup.Item.Enabled = false;
                cbxSup.Clear();


            }
        }

        private void chkVen_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            
        }

        private void chkTPa_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
         

        }

        private void chkTtr_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
          
        }

        private void chkEstado_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           

        }

        private SAPbouiCOM.Grid Grid3;

        private void _ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           
        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
         
         
        }


        private bool  AddUDO()
        {
            bool ret = true;


            return ret;
        }

        private bool AddPagoCuenta()
        {
            bool ret = true;


            return ret;
        }

        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.LinkedButton LinkedButton0;

        private void Grid2_LinkPressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            SAPbouiCOM.EditTextColumn col = null;
            BubbleEvent = true;

            if ( pVal.ColUID == "Documento")

            {
                

                EditText0.Value = Grid2.DataTable.GetValue("DocEntry", pVal.Row).ToString();
                oForm.Select();
                LinkedButton0.Item.Click(SAPbouiCOM.BoCellClickType.ct_Linked);

                col = ((SAPbouiCOM.EditTextColumn)(Grid2.Columns.Item(3)));
                col.LinkedObjectType = "";// muestra la ventana socio de negocio

            }
        }

        private void Grid2_LinkPressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.EditTextColumn col = null;



            col = ((SAPbouiCOM.EditTextColumn)(Grid2.Columns.Item(3)));
            col.LinkedObjectType = "13";// muestra la flecha amariilla        
        }

        private void ComboBox2_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (ComboBox2.Value == "A")
            {
                EditText2.Item.Enabled = false;
                Button4.Item.Enabled = false;
            }
            else
            {
                EditText2.Item.Enabled = true;
                Button4.Item.Enabled = true;
            }
        }

        private SAPbouiCOM.DataTable getDetalle(string deposito, string banco, string vendedor)
        {
            string qStrSQL = string.Empty;
            qStrSQL = string.Format("CALL SP_VIS_ABNK_SEARCH_RECEIPS ('{0}','{1}',{2}) ", deposito, banco, vendedor);
            SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_1");
            oDT.ExecuteQuery(qStrSQL);
            return oDT;
        }

        private void LoadMonedas()
        {

        }
        private void LoadBancos()
        {
        }


        private void LoadCuentas(string bankCode, string Currency)
        {

        }

        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.Button Button1;

        private void _ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            throw new System.NotImplementedException();

        }

        private void OptionBtn0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
          //  OptionBtn1.Selected = false;

        }
        private SAPbouiCOM.Button Button3;

        private void ComboBox0_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ComboBox Tipo = oForm.GetComboBox("Item_11");
            string tipo = string.Empty;
            tipo = Tipo.GetSelectedValue().ToString();
            if (tipo =="M")

            {
                activarControlesPanel2(true);

            }
            else
            {
                activarControlesPanel2(false);

            }
            //throw new System.NotImplementedException();

        }

        private void activarControlesPanel2( Boolean sw )
        {
            //ComboBox2.Item.Enabled = sw;

            Button4.Item.Enabled = sw;
            Grid1.Item.Enabled = sw;
            EditText2.Item.Enabled = sw;
            ComboBox0.Item.Enabled =  !sw;
        }

        private void Button2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {


            Thread t = new Thread(() =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Seleccione un archivo";
                openFileDialog.Filter = "Archivo de texto | *.txt | Archivo CSV | *.csv";

                DialogResult dr = openFileDialog.ShowDialog(new Form());
                if (dr == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    this.EditText2.Value = fileName;
                    //SAPbouiCOM.Framework.Application.SBO_Application.MessageBox(fileName);
                }
            });          // Kick off a new thread
            t.IsBackground = true;
            t.SetApartmentState(ApartmentState.STA);
            t.Start();


         

        }

        private void Button3_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {

            SAPbouiCOM.ComboBox Tipo = oForm.GetComboBox("Item_11");
            string tipo = string.Empty;
            tipo = Tipo.GetSelectedValue().ToString();
            try
            {
                if (tipo == "M")
                {
                    string archivo = this.EditText2.Value;
                    DL_ProcesoBancos.Fuente oFuente = new DL_ProcesoBancos.Fuente();
                    string BancoSeleccion = this.ComboBox2.Value;

                    oFuente = DL_ProcesoBancos.Fuente.CUOTA;


                    Cursor.Current = Cursors.WaitCursor;
                    if (archivo != string.Empty)
                    {
                        if (File.Exists(archivo))
                        {
                            Sb1Messages.ShowMessage("Archivo Validado, procediendo a cargarlo");
                            string respuestaProceso = string.Empty;
                            oForm.Freeze(true);
                            List<CA_ListaCampos> OBJ_Archivo = new List<CA_ListaCampos>();
                            OBJ_Archivo = DL_ProcesoBancos.RetornaDataArchivo(archivo, oFuente, out respuestaProceso);

                            SAPbouiCOM.DataTable data = oForm.GetDataTable("DT_Bancos");
                            data.Clear();
                            var columns = data.Columns;
                            columns.Add("CODCIA", SAPbouiCOM.BoFieldsType.ft_Text);
                            columns.Add("ANIO", SAPbouiCOM.BoFieldsType.ft_Text);
                            columns.Add("MES", SAPbouiCOM.BoFieldsType.ft_Text);
                            columns.Add("VENDEDOR", SAPbouiCOM.BoFieldsType.ft_Text);
                            columns.Add("VARIABLE", SAPbouiCOM.BoFieldsType.ft_Text);
                            columns.Add("CUOTA", SAPbouiCOM.BoFieldsType.ft_Text);
                            columns.Add("TIPOVAR", SAPbouiCOM.BoFieldsType.ft_Text);
                            columns.Add("PESO", SAPbouiCOM.BoFieldsType.ft_Text);


                            data.Rows.Clear();

                            for (int i = 0; i < OBJ_Archivo.Count; i++)
                            {
                                data.Rows.Add();
                                data.SetValue("CODCIA", i, OBJ_Archivo[i].CodCia);
                                data.SetValue("ANIO", i, OBJ_Archivo[i].Anio);
                                data.SetValue("MES", i, OBJ_Archivo[i].Mes);
                                data.SetValue("VENDEDOR", i, OBJ_Archivo[i].CodVendedor);
                                data.SetValue("VARIABLE", i, OBJ_Archivo[i].Variable);
                                data.SetValue("CUOTA", i, OBJ_Archivo[i].Cuota);
                                data.SetValue("TIPOVAR", i, OBJ_Archivo[i].TipoVar);
                                data.SetValue("PESO", i, OBJ_Archivo[i].Peso);
                                Sb1Messages.ShowMessage("Importando registros: " + i.ToString() + " de " + OBJ_Archivo.Count.ToString());
                            }

                            //Grid1.ReadOnlyColumns();
                            Grid1.Columns.Item(0).Editable = false;
                            Grid1.Columns.Item(1).Editable = false;
                            Grid1.Columns.Item(2).Editable = true;
                            Grid1.Columns.Item(3).Editable = false;
                            Grid1.Columns.Item(4).Editable = true;
                            Grid1.Columns.Item(5).Editable = true;
                            Grid1.Columns.Item(6).Editable = false;
                            Grid1.Columns.Item(7).Editable = true;

                            Grid1.AutoResizeColumns();
                            oForm.Freeze(false);
                            Sb1Messages.ShowMessage("Importación finalizada");
                            Sb1Messages.ShowMessageBoxWarning("Importación finalizada");
                        }
                        else
                        {
                            Sb1Messages.ShowMessageBoxWarning("No existe el archivo ingresado");
                            return;
                        }
                    }
                    else
                    {
                        Sb1Messages.ShowMessageBoxWarning("No selecciono ningun archivo para el proceso");
                        return;
                    }
                }
                else
                {
                    if (ComboBox0.Value == "")
                    {
                        Sb1Messages.ShowMessageBoxWarning("No selecciono ningun archivo para el proceso");
                        return;
                    }
                    string qStrSQL;

                    oForm.Freeze(true);
                    SAPbouiCOM.DataTable data = oForm.GetDataTable("DT_Bancos");
                    data.Clear();
                    var columns = data.Columns;
                    columns.Add("CODCIA", SAPbouiCOM.BoFieldsType.ft_Text);
                    columns.Add("ANIO", SAPbouiCOM.BoFieldsType.ft_Text);
                    columns.Add("MES", SAPbouiCOM.BoFieldsType.ft_Text);
                    columns.Add("VENDEDOR", SAPbouiCOM.BoFieldsType.ft_Text);
                    columns.Add("VARIABLE", SAPbouiCOM.BoFieldsType.ft_Text);
                    columns.Add("CUOTA", SAPbouiCOM.BoFieldsType.ft_Text);
                    columns.Add("TIPOVAR", SAPbouiCOM.BoFieldsType.ft_Text);

                    columns.Add("PESO", SAPbouiCOM.BoFieldsType.ft_Text);
                    data.Rows.Clear();

                    string fecha = ComboBox0.GetSelectedValue().ToString() + "-01";
                    qStrSQL = string.Format("CALL P_VIS_VEN_LISTARCUOTAS_MESANT ('{0}') ", fecha);


                    oGrid.DataTable.ExecuteQuery(qStrSQL);

                    oForm.Freeze(false);
                }
            }
            catch (Exception e)
            {
                
            }
          

        }

        private void _ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {

            if (oForm.PaneLevel == 2)
            {

                
            }

            BubbleEvent = true;
            throw new System.NotImplementedException();

        }

        private void ComboBox4_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.ComboBox Tipo = oForm.GetComboBox("Item_44");
            string banco = string.Empty;
            banco = Tipo.GetSelectedValue().ToString();

            SAPbouiCOM.ComboBox Moneda = oForm.GetComboBox("Item_42");
            string moneda = string.Empty;
            moneda = Moneda.GetSelectedValue().ToString();

            LoadCuentas2(banco,moneda);
            //ComboBox1.Select(ComboBox1.ValidValues.Item(0));


        }

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
          //  throw new System.NotImplementedException();

        }

        private void cbxUne_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           // throw new System.NotImplementedException();

        }

        private SAPbouiCOM.Grid Grid1;
        private SAPbouiCOM.Button Button4;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.ComboBox ComboBox2;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.Grid Grid2;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.Grid Grid4;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.Button Button5;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.StaticText StaticText1;

        private void Button3_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
          //  throw new System.NotImplementedException();

        }

        private void ComboBox2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {


        }

        private void EditText2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private void Button4_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            //throw new System.NotImplementedException();

        }

        private void ComboBox0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }
    }
}
