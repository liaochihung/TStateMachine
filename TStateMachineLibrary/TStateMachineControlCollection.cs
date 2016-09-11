using System;
using System.Windows.Forms;

namespace TStateMachineLibrary
{
    public class TStateMachineControlCollection : Control.ControlCollection
    {
        public TStateMachineControlCollection(Control owner)
            : base(owner)
        {}

        public override void Add(System.Windows.Forms.Control value)
        {
            if (value is TStateControl)
            {
                base.Add(value);
            }
            else
            {
                throw new NotSupportedException("Only TStateControl controls can be added to a TStateMachine control.");
            }
        }
    }
}