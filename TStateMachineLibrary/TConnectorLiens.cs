using System.Drawing;

namespace TStateMachineLibrary
{
    public class TConnectorLiens
    {
        private readonly Point[] _item;

        public TConnectorLiens()
        {
            _item = new Point[TDesignMove.Destination];
        }

        public Point this[int idx]
        {
            get { return _item[idx]; }
            set { _item[idx] = value; }
        }
    }
}