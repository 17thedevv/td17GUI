using SFML.Graphics;
using SFML.System;
using td17GUI.Utilities;

namespace td17GUI.Graphics
{
    public class TeaText
    {
        private Text text = new Text();
        private TextAlign textAlign = TextAlign.LeftTop;
        private uint width;
        private uint height;

        public TeaText() { }

        public TeaText(string content)
        {
            setContent(content);
        }

        public void Init(Vector2f position, uint width, uint height)
        {
            text.Font = TeaFont.ArialFont;
            text.CharacterSize = 14;
            text.FillColor = Color.Black;
            text.Position = position;
            this.width = width;
            this.height = height;
            this.setPosition(this.CaculateTextPosition());
        }

        public void setPosition(Vector2f pos) => this.text.Position = pos;

        public Vector2f CaculateTextPosition()
        {
            FloatRect textBounds = this.text.GetLocalBounds();
            float posX = text.Position.X;
            float posY = text.Position.Y;

            switch (this.textAlign)
            {
                case TextAlign.CenterTop:
                    posX += (width - textBounds.Width) / 2 - textBounds.Left;
                    posY -= textBounds.Top;
                    break;

                case TextAlign.CenterMiddle:
                    posX += (width - textBounds.Width) / 2 - textBounds.Left;
                    posY += (height - textBounds.Height) / 2 - textBounds.Top;
                    break;

                case TextAlign.CenterBottom:
                    posX += (width - textBounds.Width) / 2 - textBounds.Left;
                    posY += height - textBounds.Height - textBounds.Top;
                    break;

                case TextAlign.RightTop:
                    posX += width - textBounds.Width - textBounds.Left;
                    posY -= textBounds.Top;
                    break;

                case TextAlign.RightMiddle:
                    posX += width - textBounds.Width - textBounds.Left;
                    posY += (height - textBounds.Height) / 2 - textBounds.Top;
                    break;

                case TextAlign.RightBottom:
                    posX += width - textBounds.Width - textBounds.Left;
                    posY += height - textBounds.Height - textBounds.Top;
                    break;

                case TextAlign.LeftTop:
                    posX -= textBounds.Left;
                    posY -= textBounds.Top;
                    break;

                case TextAlign.LeftMiddle:
                    posX -= textBounds.Left;
                    posY += (height - textBounds.Height) / 2 - textBounds.Top;
                    break;

                case TextAlign.LeftBottom:
                    posX -= textBounds.Left;
                    posY += height - textBounds.Height - textBounds.Top;
                    break;
            }

            return new Vector2f(posX, posY);
        }

        public void setContent(string content)
        {
            text.DisplayedString = content;
        }

        public void AppendContent(string content)
        {
            text.DisplayedString += content;
        }

        public string getContent()
        {
            return text.DisplayedString;
        }

        public void setTextAlign(TextAlign align)
        {
            this.textAlign = align;
            this.setPosition(this.CaculateTextPosition());
        }

        public TextAlign getTextAlign()
        {
            return textAlign;
        }

        public void setCharSize(uint charSize)
        {
            text.CharacterSize = charSize;
        }

        public uint getCharSize()
        {
            return text.CharacterSize;
        }

        public Text getText()
        {
            return this.text;
        }
    }
}