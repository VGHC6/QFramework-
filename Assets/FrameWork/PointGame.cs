using Counter;
using FrameWork;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarameWork
{
    public class PointGame : Architecture<PointGame>
    {
        protected override void init()
        {
            Register(new GameModel());
        }
    }
}