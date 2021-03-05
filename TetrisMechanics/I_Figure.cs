namespace TetrisMechanics
{
    public class I_Figure : Figure
    {
        public I_Figure()
        {
            States = new Vector2[2, 4];
            States[0, 1] = new Vector2(0, -2);
            States[0, 2] = new Vector2(0, -1);
            States[0, 3] = new Vector2(0, 1);

            States[1, 1] = new Vector2(-2, 0);
            States[1, 2] = new Vector2(-1, 0);
            States[1, 3] = new Vector2(1, 0);

            InitializeParts(5, 2);
        }

        public override void Rotate()
        {
            if (state == 0)
            {
                if (MainPos.x == 1)
                    Righter();

                SetState(1);
            }
            else
            {
                SetState(0);
            }
        }
    }
}
