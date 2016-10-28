using System;
using System.Threading;

namespace TStateMachineLibrary
{
	public class TStateThread :BaseThread
	{
	    public TStateControl NewState { get; set; }
        public TStateControl OldState { get; set; }

	    private IntPtr FStartEvent;
	    private TStateControl _state;

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
	                Terminate();
	            }
	            else
	            {
	                if (_state == null)
	                {
                        // todo: check how this should work.
	                    //SetEvent(FStartEvent);
	                    _eventWait.Set();
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
	        if (Terminated)
	            return;

	        //if (StateMachine.HandlesTransitionEvent())
	            StateMachine.DoTransition();
	    }
	
        private EventWaitHandle _eventWait = new AutoResetEvent(false);

	    protected void Execute()
	    {
            StateMachine.ThreadStart();

	        try
	        {
                DoStart();

	            _state = NewState;

                // Execute state transitions
                while(!Terminated && _state!=null)
	            {
	                // do
	                DoEnterState(_state);

                    Thread.Sleep(500);
	                if (Terminated)
	                    break;

	                // Get next default state unless state was explicitly changed
	                if (NewState == _state)
	                {
	                    NewState = _state.Default();
	                    OldState = _state;
	                }
	                _state = null;

	                DoExitState(OldState);

	                if (Terminated)
	                    break;

	                _state = NewState;
	                DoTransition();
	            }

                DoStop();
	        }
	        finally
	        {
	            StateMachine.ThreadStop();
	        }
	    }

	    public bool Terminated { get; set; }

	    public void Terminate()
	    {
	    }

        protected override void DoTask()
        {
            Execute();
        }

        protected override void OnCompleted()
        {
            if (OnCompletedEventHandler != null)
                OnCompletedEventHandler(this, EventArgs.Empty);
        }
    }//end TStateThread
}