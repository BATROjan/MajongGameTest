﻿using UnityEngine;


    public interface IUIRoot
    {
        Transform ActivateContainer { get; }
        Transform DeativateContainer { get; }
        Canvas RootCanvas { get; }
    }
