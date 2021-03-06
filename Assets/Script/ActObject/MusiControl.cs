﻿using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class MusiControl : HittableObject {

    public GameObject Destination { get { return destination; } }

    protected GameObject destination;

    public delegate void DestinationEvent(GameObject obj);
    public DestinationEvent OnChange;
}
