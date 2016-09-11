using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TStateMachineLibrary
{
    public class TStateMachineDesigner : ParentControlDesigner
    {
        public override bool CanParent(Control control)
        {			
            // Children can only be of type TStateControl. 
            return (control is TStateControl);
        }
    }
}