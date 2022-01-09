using System.Collections.Generic;
using System.Linq;

public class DrawController
{
    private readonly List<IDrawer> _drawers;
    public DrawController(params IDrawer[] _drawers) { this._drawers = _drawers.ToList(); }
    public void Draw() => _drawers.ForEach(s => s.Draw.Invoke());
}
