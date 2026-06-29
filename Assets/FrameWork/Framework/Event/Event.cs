
using System;
using UnityEngine;

namespace FrameWork
{
    public class Event<T> where T : Event<T>
    {
        public static Action _OnEvent;

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="OnEvent"></param>
        public static void Register(Action OnEvent)
        {
            _OnEvent += OnEvent;
        }


        /// <summary>
        /// 取消注册事件
        /// </summary>
        /// <param name="OnEvent"></param>
        public static void Unregister(Action OnEvent)
        {
            _OnEvent -= OnEvent;
        }

        /// <summary>
        /// 触发事件
        /// </summary>
        public static void Trigger()
        {
            _OnEvent?.Invoke();
        }
    }
}