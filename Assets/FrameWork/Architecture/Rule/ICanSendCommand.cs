using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanSendCommand : IBelongArchitecture
{
}

public static class CanSendCommand
{
    public static void SendCommand<T>(this ICanSendCommand self) where T : ICommand, new()
    {
        self._GetArchitecture().SendCommand<T>();
    }

    public static void SendCommand<T>(this ICanSendCommand self, T command) where T : ICommand
    {
        self._GetArchitecture().SendCommand<T>(command);
    }
}
