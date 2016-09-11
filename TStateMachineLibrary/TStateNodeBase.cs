using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TStateMachineLibrary
{
    [ToolboxItem(false)]
    public class TStateNodeBase:TStateControl
    {
        public TStateNodeBase()
        {
            
        }

        public void SetParent(Control AParent)
        {
        }
    }// end TStateNodeBase
}
