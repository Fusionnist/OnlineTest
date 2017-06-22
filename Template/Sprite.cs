using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Sprite
    {
        Texture2D tex;
        Vector2 pos;

        public Sprite(Texture2D a_tex, Vector2 a_pos)
        {
            tex = a_tex;
            pos = a_pos;
        }

        public void Draw(SpriteBatch a_sb)
        {
            a_sb.Draw(tex, pos);
        }
    }
}
