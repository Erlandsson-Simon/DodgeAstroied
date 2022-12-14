using System;

public class Game
{
    float screenWidth;
    float screenHeight;

    Player p = new Player();
    List<Asteroid> asteroids = new();

    static double milliSecondsBetweenTimedEvents = 1000;
    double playedTime = 0;

    public static bool asteroidLock = false;

    System.Timers.Timer asteroidTimer = new(milliSecondsBetweenTimedEvents);

    public Game()
    {
        milliSecondsBetweenTimedEvents = 1000;
        screenHeight = R.GetScreenHeight();
        screenWidth = R.GetScreenWidth();

        asteroidTimer.AutoReset = true;
        asteroidTimer.Elapsed += SpawnAsteroid;
        asteroidTimer.Enabled = true;
        asteroidTimer.Start();
    }

    public int Run()
    {
        while (true)
        {
            while (Game.asteroidLock) ;
            Game.asteroidLock = true;
            foreach (var v in asteroids)
            {
                if (v.ShouldPlayerDie(p))
                {
                    asteroidLock = false;
                    return (int)playedTime;
                }

                if (v.ShouldAsteroidDie(p))
                {
                    asteroids.Remove(v);
                    break;
                }

            }

            foreach (var v in asteroids)
            {
                v.Update();
            }
            asteroidLock = false;

            R.BeginDrawing();
            R.ClearBackground(Color.WHITE);


            R.EndDrawing();

            p.Update();
        }
    }

    private void SpawnAsteroid(Object source, ElapsedEventArgs e)
    {
        while (Game.asteroidLock) ;
        Game.asteroidLock = true;
        asteroids.Add(new(p));
        Game.asteroidLock = false;

        AddToTime();
    }

    private void AddToTime()
    {
        playedTime += milliSecondsBetweenTimedEvents;

        milliSecondsBetweenTimedEvents *= 0.985;
        asteroidTimer.Interval = milliSecondsBetweenTimedEvents;
    }
}
