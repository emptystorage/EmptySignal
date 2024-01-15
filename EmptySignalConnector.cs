using System;

namespace EmptySignal
{
    public static class EmptySignalConnector 
    {
        public static void RegistrationSignal<T>(Action<T> callback)
            where T : struct, ISignal
        {
            SignalContext<T>.OnExecute += callback;
        }

        public static void UnregistrationSignal<T>(Action<T> callback)
            where T : struct, ISignal
        {
            SignalContext<T>.OnExecute -= callback;
        }

        public static void ExecuteSignal<T>(T signal)
            where T: struct, ISignal
        {
            SignalContext<T>.Execute(signal);
        }

        private static class SignalContext<T>
            where T : struct, ISignal
        {
            public static event Action<T> OnExecute;
            public static void Execute(T signal)
            {
                OnExecute?.Invoke(signal);
            }
        }
    }
}
