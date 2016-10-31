using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace TStateMachineLibrary
{
	public class TStateThread //:BaseThread
	{
	    public TStateControl NewState { get; set; }
        public TStateControl OldState { get; set; }

	    private IntPtr FStartEvent;
	    private TStateControl _state;

	    private Thread _thread;

	    public TStateControl State
	    {
	        get
	        {
	            if (NewState != null)
	            {
	                return NewState;
	            }
	            else
	            {
	                return _state;
	            }
	        }
	        set
	        {
	            OldState = _state;
	            NewState = value;
	            if (value == null)
	            {
	                //Terminate();
	            }
	            else
	            {
	                if (_state == null)
	                {
                        // todo: check how this should work.
	                    //SetEvent(FStartEvent);
	                    //_eventWait.Set();
	                }
	            }
	        }
	    }

	    public TStateMachine StateMachine { get; set; }

        public EventHandler OnCompletedEventHandler { get; set; }

	    ~TStateThread()
	    {
	
	    }

	    public TStateThread(TStateMachine aStateMachine)
	    {
	        StateMachine = aStateMachine;
	        //_eventWait = eventWait;
	    }

	
	    private void DoEnterState(TStateControl State)
	    {
            State.DoEnter();
	    }
	
	    private void DoExitState(TStateControl State)
	    {
            State.DoExit();
	    }
	
	    private void DoStart()
	    {
            StateMachine.DoStart();
	    }
	
	    private void DoStop()
	    {
            StateMachine.DoStop();
	    }
	
	    private void DoTransition()
	    {
           //if (StateMachine.HandlesTransitionEvent())
	            StateMachine.DoTransition();
	    }
	
        private ManualResetEvent _pauseEvent = new ManualResetEvent(true);
        private ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
        
	    protected void Execute()
	    {
            StateMachine.ThreadStart();

	        try
	        {
                DoStart();

	            _state = NewState;

                // Execute state transitions
                while(_state!=null)
	            {
	                // do
	                DoEnterState(_state);

	                _pauseEvent.WaitOne(Timeout.Infinite);

                    if (_shutdownEvent.WaitOne(0))
                        break;

                    Thread.Sleep(100);

	                // Get next default state unless state was explicitly changed
	                if (NewState == _state)
	                {
	                    NewState = _state.Default();
	                    OldState = _state;
	                }
	                _state = null;

	                DoExitState(OldState);

	                _pauseEvent.WaitOne(Timeout.Infinite);

	                _state = NewState;

                    if (_shutdownEvent.WaitOne(0))
                        break;

	                DoTransition();
	            }

                DoStop();
	        }
	        finally
	        {
	            StateMachine.ThreadStop();
	        }
	    }


	    public void Pause()
	    {
	        _pauseEvent.Reset();
	    }

	    public void Resume()
	    {
	        _pauseEvent.Set();
	    }

	    public void Start()
	    {
	        _shutdownEvent.Reset();

            _thread = new Thread(StartTaskAsync);
            _thread.Start();
	    }

	    public void StartTaskAsync()
	    {
	        Execute();
	    }

	    public void Stop()
	    {
	        _shutdownEvent.Set();

	        _pauseEvent.Set();

	        _thread.Join();
	    }

        protected void DoTask()
        {
            Execute();
        }

        //protected override void OnCompleted()
        //{
        //    if (OnCompletedEventHandler != null)
        //        OnCompletedEventHandler(this, EventArgs.Empty);
        //}
    }//end TStateThread
}