using System;
using System.Collections.Generic;

namespace TStateMachine
{
    internal class Disposer : IDisposable
    {
        private List<WeakReference> m_disposableList =
            new List<WeakReference>();

        private bool m_bDisposed = false;

        // default ctor
        public Disposer()
        {
        }

        public void Add(IDisposable disposable)
        {
            if (m_bDisposed)
            {
                // its not allowed to add additional items
                // to dispose if Dispose() already called
                throw new InvalidOperationException(
                    "Disposer: tried to add items after call to Disposer.Dispose()");
            }
            m_disposableList.Add(new WeakReference(disposable));
        }

        #region IDisposable members

        public void Dispose()
        {
            if (!m_bDisposed)
            {
                foreach (WeakReference weakRef in m_disposableList)
                {
                    try
                    {
                        if (weakRef.IsAlive)
                        {
                            // sadly there is no generic version of WeakReference
                            // WeakReference<IDisposable> would be nice...
                            IDisposable strongRef = (IDisposable) weakRef.Target;
                            // strongRef is null if weakRef.Target already disposed
                            if (strongRef != null)
                            {
                                strongRef.Dispose();
                            }
                        }
                    }
                    catch (System.InvalidOperationException ex)
                    {
                        // weakRef.Target already finalized
                    }
                }
            }
            m_disposableList.Clear();
            m_bDisposed = true;
        }

        #endregion
    }
}