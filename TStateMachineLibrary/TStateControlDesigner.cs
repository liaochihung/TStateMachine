using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace TStateMachineLibrary
{
    public class TStateControlDesigner : ControlDesigner
    {
        public override bool CanBeParentedTo(IDesigner parentDesigner)
        {
            // Control can only be parented by TStateMachine. 
            return (parentDesigner is TStateMachineDesigner);
        }
    }
}