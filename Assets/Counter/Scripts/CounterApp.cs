using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Counter
{
    public class CounterApp : Architecture<CounterApp>
    {
        protected override void init()
        {
            Register(new CounterModel());
        }
    }
}