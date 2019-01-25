using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace EXPToolkit
{
    public interface iInteractionBehavior
    {
        void BeginHover();
        event EventHandler OnBeginHover;
        void StayHovered();
        event EventHandler OnStayHovered;
        void EndHover();
        event EventHandler OnEndHover;

        void BeginGrasp();
        event EventHandler OnBegingGrasp;
        void StayGrasped();
        event EventHandler OnStayGrasped;
        void EndGrasped();
        event EventHandler OnEndGrasp;
    }
}
