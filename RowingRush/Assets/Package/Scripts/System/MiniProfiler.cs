using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Profiling;

public class MiniProfiler : MonoBehaviour {

    public bool m_Enable = false;

    private int frameCount = 0;
    private const int kAverageFrameCount = 64;
    private float m_AccDeltaTime;
    private float m_AvgDeltaTime;

    internal class RecorderEntry
    {
        public string name;
        public float time;
        public int count;
        public float avgTime;
        public float avgCount;
        public float accTime;
        public int accCount;
        public Recorder recorder;
    };

    RecorderEntry[] recordersList =
    {
        new RecorderEntry() { name="RenderLoop.Draw" },
        new RecorderEntry() { name="CullScriptable" },
        new RecorderEntry() { name="Gfx.WaitForPresent" }
	};

    void Awake()
    {
        for (int i=0;i<recordersList.Length;i++)
        {
            var sampler = Sampler.Get(recordersList[i].name);
            if ( sampler != null )
            {
                recordersList[i].recorder = sampler.GetRecorder();
            }
        }
    }


    void Update()
    {

        if (m_Enable)
        {

            // get timing & update average accumulators
            for (int i = 0; i < recordersList.Length; i++)
            {
                recordersList[i].time = recordersList[i].recorder.elapsedNanoseconds / 1000000.0f;
                recordersList[i].count = recordersList[i].recorder.sampleBlockCount;
                recordersList[i].accTime += recordersList[i].time;
                recordersList[i].accCount += recordersList[i].count;
            }

            m_AccDeltaTime += Time.deltaTime;

            frameCount++;
            // time to time, update average values & reset accumulators
            if (frameCount >= kAverageFrameCount)
            {
                for (int i = 0; i < recordersList.Length; i++)
                {
                    recordersList[i].avgTime = recordersList[i].accTime * (1.0f / kAverageFrameCount);
                    recordersList[i].avgCount = recordersList[i].accCount * (1.0f / kAverageFrameCount);
                    recordersList[i].accTime = 0.0f;
                    recordersList[i].accCount = 0;

                }

                m_AvgDeltaTime = m_AccDeltaTime / kAverageFrameCount;
                m_AccDeltaTime = 0.0f;
                frameCount = 0;
            }
        }

    }

    void OnGUI()
    {

        if (m_Enable)
        {
            GUI.color = new Color(0, 0.54f, 1, 0.8f);
            float w = 500, h = 140;

            GUILayout.BeginArea(new Rect(10, 10, w, h), "Mini Profiler", GUI.skin.window);
            GUI.color = new Color(1, 0.9f, 0.3f, 1f);

            float avgMs = m_AvgDeltaTime * 1000.0f;
            float avgWait = recordersList[2].avgTime;

            string sLabel = System.String.Format("<b>Total {0:F2} FPS ({1:F2}ms)</b>\n", 1.0f / m_AvgDeltaTime, avgMs);
            sLabel += System.String.Format("<b>CPU {0:F2}ms</b>\n", avgMs - avgWait);
            sLabel += System.String.Format("<b>GPU(guess) {0:F2}ms</b>\n", avgWait);
            for (int i = 0; i < recordersList.Length; i++)
            {
                sLabel += string.Format("{0:F2}ms (*{1:F2})\t({2:F2}ms *{3:F2})\t<b>{4}</b>\n", recordersList[i].avgTime, recordersList[i].avgCount, recordersList[i].time, recordersList[i].count, recordersList[i].name);
            }
            GUILayout.Label(sLabel);
            GUILayout.EndArea();
        }
    }

}
