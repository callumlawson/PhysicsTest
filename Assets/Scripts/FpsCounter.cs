using System;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts
{
    public class FpsCounter : MonoBehaviour
    {
        public float PhysicsFramesPerSecond;

        private const int NumFramesSampled = 10;
        private const int NumFramesBetweenDebugPrints = 30;
        private int frameCount = 1;
        private Stopwatch stopwatch;
        private TimeSpan lastTime;
        private Queue<double> frameTimes;

        // Use this for initialization
        [UsedImplicitly]
        private void Start()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            frameTimes = new Queue<double>(NumFramesSampled);
        }

        [UsedImplicitly]
        private void FixedUpdate()
        {
            var latest = stopwatch.Elapsed;
            var difference = latest - lastTime;

            frameTimes.Enqueue(difference.TotalMilliseconds);
            if (frameTimes.Count > NumFramesSampled)
            {
                frameTimes.Dequeue();
            }

            var sumTime = 0.0;
            foreach (var time in frameTimes)
            {
                sumTime += time;
            }
            var averageDifference = (float) sumTime / NumFramesSampled;

            PhysicsFramesPerSecond = 1.0f / (averageDifference / 1000.0f);
            lastTime = latest;

            frameCount++;
            if (frameCount % NumFramesBetweenDebugPrints == 0)
            {
                frameCount = 1;
                Debug.Log("PhysicsFramesPerSecond: " + PhysicsFramesPerSecond);
            }
        }
    }
}
