using System.Collections.Generic;

[System.Serializable]
public class Stages
{
    public List<Stage> stages;

    public Stages()
    {
        stages = new List<Stage>();
    }
}

[System.Serializable]
public class Stage
{
    public int lvl;
    public bool unlock;
    public bool complete;
    public int stars;
    public int score;

    public Stage()
    {
        unlock = false;
        complete = false;
        stars = 0;
        score = 0;
    }
}
