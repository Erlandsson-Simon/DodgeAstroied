using System;

public class Asteroid
{
    public Vector2 Pos
    {
        get
        {
            return new Vector2(rect.x, rect.y);
        }
        set
        {
            rect.x = value.X;
            rect.y = value.Y;
        }
    }

    public Vector2 Direction { get; set; }

    public float Speed { get; set; }

    public int Width { get; set; } = 50;
    public int Height { get; set; } = 50;

    public static Random Rnd = new();
    Vector2 perFrameMovementChange;

    Rectangle rect = new();

    public Asteroid(Player p)
    {
        rect = new(0, 0, Width, Height);

        Pos = StartingPos();

        Direction = p.Pos - Pos;

        Direction = Vector2.Normalize(Direction);

        Speed = 3;
    }

    public void Update()
    {
        Movement();
        Draw();
        UpdateRect();
    }

    public void Draw()
    {
        R.DrawRectangleRec(rect, Color.BLACK);
    }

    public void UpdateRect()
    {
        rect = new(Pos.X, Pos.Y, Width, Height);
    }

    public void Movement()
    {
        Pos += Direction * Speed;
    }

    public Vector2 StartingPos()
    {
        Vector2 temp = new();

        int num = Rnd.Next(1, 5);

        switch (num)
        {
            case 1:
                //uppe
                temp = new(Rnd.Next(1, R.GetScreenWidth()), -100);
                break;
            case 2:
                //nere
                temp = new(Rnd.Next(1, R.GetScreenWidth()), R.GetScreenHeight() + 100);
                break;
            case 3:
                //vänster
                temp = new(-100, Rnd.Next(1, R.GetScreenHeight()));
                break;
            case 4:
                //höger
                temp = new(R.GetScreenWidth() + 100, Rnd.Next(1, R.GetScreenHeight()));
                break;
        }

        return temp;
    }

    public int RandomSpeed()
    {
        int temp = Rnd.Next(3, 5) * 2;

        return temp;
    }

    public bool ShouldAsteroidDie(Player p)
    {
        bool ret = false;

        if (Vector2.Distance(p.Pos, Pos) > 2500)
        {
            ret = true;
        }

        return ret;
    }

    public bool ShouldPlayerDie(Player p)
    {
        bool ret = false;

        if (R.CheckCollisionRecs(rect, p.rect))
        {
            ret = true;
        }

        return ret;
    }
}
