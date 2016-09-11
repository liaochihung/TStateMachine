using System;
using System.Threading;

namespace TStateMachineLibrary
{
    public abstract class BaseThread
    {
        protected Thread _thread;

        public enum StatusState
        {
            Unstarted,
            InProgress,
            Completed
        };

        public StatusState Status { get; private set; }

        protected BaseThread()
        {
            Id = Guid.NewGuid();
            Status = StatusState.Unstarted;

            //_thread = new Thread(new ThreadStart(this.Execute));
            _thread = new Thread(DoTask);
        }

        public Guid Id { get; private set; }

        // Thread methods / properties
        public void Start()
        {
            if (Status == StatusState.InProgress)
            {
                throw new InvalidOperationException("Already in progress.");
            }
            else
            {
                // Initialize the new task.
                Status = StatusState.InProgress;
                // Create the thread and run it in the background,
                // so it will terminate automatically if the application ends.
                _thread = new Thread(StartTaskAsync);
                _thread.IsBackground = true;
                // Start the thread.
                _thread.Start();
            }
        }

        private void StartTaskAsync()
        {
            DoTask();
            Status = StatusState.Completed;
            OnCompleted();
        }
        public void Join()
        {
            _thread.Join();
        }

        public void RequestStop()
        {
            while (!IsAlive)
            {
            }

            Thread.Sleep(10);

            _shouldStop = true;
            _thread.Join();
        }

        protected volatile bool _shouldStop = false;

        public bool IsAlive
        {
            get { return _thread.IsAlive; }
        }

        /// <summary>
        /// Override this class to supply the task logic.
        /// </summary>
        protected abstract void DoTask();

        /// <summary>
        /// Override this class to supply the callback logic.
        /// </summary>
        protected abstract void OnCompleted();
    }
}