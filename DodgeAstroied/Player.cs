public class Player
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

    public int Speed { get; set; } = 7;

    public int Width { get; set; } = 50;
    public int Height { get; set; } = 50;

    public Rectangle rect;

    public Player()
    {
        rect = new(800, 400, Width, Height);
    }

    public void Update()
    {
        Pos += Movement();
        Draw();
        Speed = Sprint();
    }

    public void Draw()
    {
        R.DrawRectangleRec(rect, Color.LIME);
    }

    public int Sprint()
    {
        if (R.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT)) {
            return 7;
        }
        return 4;
    }

    public Vector2 Movement()
    {
        Vector2 movement = new(0, 0);

        if (R.IsKeyDown(KeyboardKey.KEY_D))
        {
            movement.X = Speed;
        }
        else if (R.IsKeyDown(KeyboardKey.KEY_A))
        {
            movement.X = -Speed;
        }

        if (R.IsKeyDown(KeyboardKey.KEY_W))
        {
            movement.Y = -Speed;
        }
        else if (R.IsKeyDown(KeyboardKey.KEY_S))
        {
            movement.Y = Speed;
        }
        return movement;
    }
}
