namespace TetrisMechanics
{
    public class O_Figure : Figure
    {
        public O_Figure()
        {
            States = new Vector2[1, 4];
            States[0, 1] = new Vector2(1, 0);
            States[0, 2] = new Vector2(0, 1);
            States[0, 3] = new Vector2(1, 1);

            InitializeParts(4, 0);
        }
        public override void Rotate()
        {
        }
    }
}
