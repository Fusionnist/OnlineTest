using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Sprite
    {
        public Texture2D tex { get; set; }
        public Vector2 pos { get; set; }

        public Sprite(Texture2D a_tex, Vector2 a_pos)
        {
            tex = a_tex;
            pos = a_pos;
        }
        public void Move(Vector2 mov_)
        {
            pos += mov_;
        }
        public void Draw(SpriteBatch a_sb)
        {
            a_sb.Draw(tex, pos);
        }
    }
}
