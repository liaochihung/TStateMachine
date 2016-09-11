namespace TStateMachineLibrary
{
    /// <summary>
    /// Run-time options:  soInteractive If set, the TStateMachine will be visible at
    /// run-time. The current state will be painted in red and bold.  soSingleStep If
    /// set, the execution will stop after each transition. Use the Execute method to
    /// resume execution.  soSynchronize If set, all events are fired in the context of
    /// the main thread via the TThread.Synchronize method. Otherwise, the events are
    /// fired in the context of the scheduler thread.
    /// </summary>
    public enum TStateMachineOptions
    {
        Interactive,
        SingleStep,
        Synchronize
    }//end TStateMachineOptions
}