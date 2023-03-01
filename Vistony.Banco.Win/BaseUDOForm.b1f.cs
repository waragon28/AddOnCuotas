using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Forxap.Banco.UI.Win
{
    [FormAttribute("Forxap.Demo.UI.Win.BaseUDOForm", "BaseUDOForm.b1f")]
    class BaseUDOForm : UserFormBase
    {
        public static SAPbouiCOM.Form oForm;
        public SAPbouiCOM.Form activeForm;

        public SAPbouiCOM.Button btnOK;

        public SAPbouiCOM.Button btnCancel;

        public SAPbouiCOM.Matrix oMatrix;

        public SAPbouiCOM.Folder fldContenido;
        public SAPbouiCOM.Folder fldInvisible;


        public BaseUDOForm()
        {
        }

        public static void ShowObject(string code)
        {

        }
        public virtual bool Validate()
        {
            return false;

        }
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }
    }
}
