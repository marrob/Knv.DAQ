namespace Knv.Fan.Events
{
    class UpdatingStateChangedAppEvent : IApplicationEvent
    {
        public bool IsRunning { get; set; }
        
        public UpdatingStateChangedAppEvent(bool isRunning)
        {
            IsRunning = isRunning;
        }
    }
}
