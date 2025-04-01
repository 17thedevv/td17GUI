using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;

namespace td17GUI.UI
{
    public class TextBox : ComplexWidget
    {
        private string content = "";
        private uint maxLength = 255;
        private bool isFocused = false;
        private int cursorPos = 0;
        private RectangleShape caret = new RectangleShape(new SFML.System.Vector2f(2, 20)) { FillColor = Color.Black };
        private List<string> lines = new List<string>();

        public TextBox()
        {
            this.TeaRect.setFillColor(Color.White);
        }

        public TextBox(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.width = 200;
            this.height = 50;
            this.TeaRect.setFillColor(Color.White);
        }

        public TextBox(int x, int y, uint width, uint height) : base(x, y, width, height)
        {
            this.TeaRect.setFillColor(Color.White);
        }

        public uint GetMaxLength() => this.maxLength;
        public void SetMaxLength(uint maxLength) => this.maxLength = maxLength;

        private void UpdateLines()
        {
            lines.Clear();
            string currentLine = "";
            foreach (char c in content)
            {
                if (c == '\n')
                {
                    lines.Add(currentLine);
                    currentLine = "";
                    continue;
                }
                currentLine += c;
                if (MeasureTextWidth(currentLine) > getWidth())
                {
                    lines.Add(currentLine.Substring(0, currentLine.Length - 1));
                    currentLine = c.ToString();
                }
            }
            lines.Add(currentLine);
        }

        public override void HandleKeyPressed(KeyEventArgs e)
        {
            if (!isFocused) return;
            if (e.Code == Keyboard.Key.Enter && e.Shift)
            {
                content = content.Insert(cursorPos, "\n");
                cursorPos++;
                UpdateLines();
                return;
            }
            switch (e.Code)
            {
                case Keyboard.Key.Backspace:
                    if (cursorPos > 0 && cursorPos <= content.Length)
                    {
                        content = content.Remove(cursorPos - 1, 1);
                        cursorPos--;
                    }
                    break;
                case Keyboard.Key.Delete:
                    if (cursorPos >= 0 && cursorPos < content.Length)
                    {
                        content = content.Remove(cursorPos, 1);
                    }
                    break;
                case Keyboard.Key.Left:
                    if (cursorPos > 0) cursorPos--;
                    break;
                case Keyboard.Key.Right:
                    if (cursorPos < content.Length) cursorPos++;
                    break;
                default:
                    char inputChar = GetCharFromKey(e.Code, e.Shift);
                    if (inputChar != '\0' && content.Length < maxLength)
                    {
                        content = content.Insert(cursorPos, inputChar.ToString());
                        cursorPos++;
                    }
                    break;
            }
            cursorPos = Math.Clamp(cursorPos, 0, content.Length);
        }

        public override void HandleMouseButtonPressed(MouseButtonEventArgs e)
        {
            if (e.X >= getX() && e.X <= getX() + getWidth() &&
                e.Y >= getY() && e.Y <= getY() + getHeight())
            {
                isFocused = true;
                cursorPos = content.Length;
            }
            else
            {
                isFocused = false;
            }
        }

        private float CalculateCursorX()
        {
            if (lines.Count == 0 || cursorPos == 0) return 0;
            int currentLineIndex = GetCursorLineIndex();
            string currentLine = lines[currentLineIndex];
            int adjustedCursorPos = Math.Min(cursorPos - GetLineStartIndex(currentLineIndex), currentLine.Length);
            string visibleText = currentLine.Substring(0, adjustedCursorPos);
            return MeasureTextWidth(visibleText);
        }

        private int GetCursorLineIndex()
        {
            int lineStartIndex = 0;
            for (int i = 0; i < lines.Count; i++)
            {
                int lineEndIndex = lineStartIndex + lines[i].Length;
                if (cursorPos >= lineStartIndex && cursorPos < lineEndIndex)
                {
                    return i;
                }
                lineStartIndex = lineEndIndex;
            }
            return lines.Count - 1;
        }

        private int GetLineStartIndex(int lineIndex)
        {
            int lineStartIndex = 0;
            for (int i = 0; i < lineIndex; i++)
            {
                lineStartIndex += lines[i].Length;
            }
            return lineStartIndex;
        }

        public override void Draw(RenderWindow window)
        {
            base.Draw(window);
            UpdateLines();
            window.Draw(this.TeaRect.getRect());
            float lineHeight = 20;
            float yOffset = getY();
            foreach (string line in lines)
            {
                this.teaText.setContent(line);
                this.teaText.setPosition(new SFML.System.Vector2f(getX(), yOffset));
                window.Draw(teaText.getText());
                yOffset += lineHeight;
            }
            if (isFocused)
            {
                float cursorX = getX() + CalculateCursorX();
                float cursorY = getY() + GetCursorLineIndex() * lineHeight;
                caret.Position = new SFML.System.Vector2f(cursorX, cursorY);
                window.Draw(caret);
            }
        }

        private float MeasureTextWidth(string text)
        {
            Text sfmlText = new Text(text, this.teaText.getText().Font, this.teaText.getCharSize());
            return sfmlText.GetGlobalBounds().Width;
        }

        private char GetCharFromKey(Keyboard.Key key, bool shift)
        {
            if (key >= Keyboard.Key.A && key <= Keyboard.Key.Z)
                return (char)(key - Keyboard.Key.A + (shift ? 'A' : 'a'));
            if (key >= Keyboard.Key.Num0 && key <= Keyboard.Key.Num9)
                return (char)(key - Keyboard.Key.Num0 + '0');
            if (key == Keyboard.Key.Space)
                return ' ';
            return '\0';
        }

        public string getContent() => this.content;

        public override void setSize(uint width, uint height)
        {
            this.width = width;
            this.TeaRect.setSize(width, this.height);
        }
    }
}