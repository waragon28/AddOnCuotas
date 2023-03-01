using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Vistony.Banco.UI.Win.Asistentes
{
    [FormAttribute("Vistony.Banco.UI.Win.Asistentes.frmGeneraPlantilla", "Asistentes/frmGeneraPlantilla.b1f")]
    public partial class frmGeneraPlantilla : UserFormBase
    {
        public frmGeneraPlantilla()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);

        }

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            throw new System.NotImplementedException();

        }

        private void OnCustomInitialize()
        {

        }
    }
}
