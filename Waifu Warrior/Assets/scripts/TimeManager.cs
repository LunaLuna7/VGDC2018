using UnityEngine;

public class TimeManager : MonoBehaviour {

    public float slowdown = 0.05f;
    public float slowdowntime = 6f;
    
    

    void Update()
    {
        if (!Pause.GamePaused)
        {
            Time.timeScale += (1f / slowdowntime) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }
    }

    public void SlowMotion()
    {
        Time.timeScale = slowdown;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}
