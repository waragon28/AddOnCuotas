using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Forxap.Banco.UI.Win.Interfaz.Exportar
{
    [FormAttribute("AFPNet", "Asistentes/Exportar/wzdAFPNet.b1f")]
    class wzdAFPNet : UserFormBase
    {
        public wzdAFPNet()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("4").Specific));
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("5").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button2;
    }
}
