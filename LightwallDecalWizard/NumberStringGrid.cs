using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightwallDecalWizard
{
    public partial class NumberStringGrid : Control
    {
        //=========================================
        // Constants
        //=========================================
        const int kMinCellSize = 4, kMinCellAmount = 1, kMinIndices = 2, kPaletteHieght = 14;
        const char kDefaultCharIndex = '0';
        const int kInit_X = 8, kInit_Y = 7, kInit_indices = 3;

        //=========================================
        // public variables and properties
        //=========================================
        public EventHandler OnDataDirty, OnMouseCellChanged, OnReinitialasation, OnPreTableEdit;

        [Description("Set the size of the cells and the palette height."),
        Category("Appearance")]
        public int cellSize 
        {
            get 
            { 
                return m_cellSize; 
            } 
            set 
            {
                if (m_cellSize == value)
                    return;
                m_cellSize = value >= kMinCellSize ? value : kMinCellSize;
                Invalidate();
            } 
        }

        [Description("Sets the number of rows in the grid"),
        Category("Appearance")]
        public int columns 
        { 
            get
            { 
                return m_xCells; 
            } 
            set
            {
                if (value == m_xCells)
                    return;
                m_xCells = value >= kMinCellAmount ? value : kMinCellAmount;
                OnGridDimensionChanged(null);
            } 
        }

        [Description("Sets the number of Columns in the grid"),
        Category("Appearance")]
        public int rows 
        { 
            get 
            { 
                return m_yCells; 
            } 
            set 
            {
                if (value == m_yCells)
                    return;
                m_yCells = value >= kMinCellAmount ? value : kMinCellAmount;
                OnGridDimensionChanged(null);
            } 
        }

        [Description("Sets the total number of values in the palette"),
        Category("Appearance")]
        public int indices 
        {
            get 
            {
                return m_indices;
            }
            set
            {
                if (value == m_indices)
                    return;
                int lastIndices = m_indices;
                m_indices = value >= kMinIndices ? value : kMinIndices;
                OnNumberOfIndicesChanged(null,lastIndices);
            }
        }

        [Description("The colour of the border around the selected Paint index."),
        Category("Appearance")]
        public Color paintColour
        {
            get
            {
                return m_paintColour;
            }
            set
            {
                m_paintColour = value;
            }
        }
       
        [Description("The colour of the border around the selected erase index."),
        Category("Appearance")]
        public Color eraseColour
        {
            get
            {
                return m_eraseColour;
            }
            set
            {
                m_eraseColour = value;
            }
        }

        //=========================================
        // private members
        //=========================================
        private int m_cellSize = 14, m_xCells = 1, m_yCells = 1;
        
        private int m_indices = 1, m_paintIndex = 0, m_eraseIndex = 0, m_mouseCell = 0;

        private int m_init_x, m_init_y, m_init_size, m_init_indices;

        private Point m_mouseCellPoint;

        private bool bMouseOnGridCell, bMouseOverPalette, bMouseDown;

        private Color m_paintColour = Color.Orange, m_eraseColour = Color.Blue;

        Dictionary<char, string> CharToStringIntLUT = new Dictionary<char, string>();

        string m_numberString;
        
        Rectangle[] indicePaletteRect;

        int keysDown;

        //=========================================
        // Constructor
        //=========================================
        public NumberStringGrid()
        {
            InitializeComponent();
            OnGridDimensionChanged(null);
            base.DoubleBuffered = true;
            m_init_x = kInit_X;
            m_init_y = kInit_Y;
            m_init_size = kInit_X * kInit_Y;

            m_init_indices = kInit_indices;
        }

        //=========================================
        // Destructor
        //=========================================
        ~NumberStringGrid()
        {
            OnDataDirty = null;
            OnMouseCellChanged = null;
            OnReinitialasation = null;
        }

        //=========================================
        // Public methods
        //=========================================
        public void Initialise()
        {
            char[] numberStringBuffer = new char[m_init_size];
            int iterator = 0;
            while (iterator < m_init_size)
            {
                numberStringBuffer[iterator] = kDefaultCharIndex;
                iterator++;
            }
           
            m_xCells = m_init_x;
            m_yCells = m_init_y;
            m_indices = m_init_indices;
            m_numberString = new string(numberStringBuffer);
            
            if (OnReinitialasation != null)
                OnReinitialasation.Invoke(this, new EventArgs());
            InvokeOnDataDirty();
            Invalidate();
        }

        public void GetSelectionPosition(out int x, out int y, out int oneD)
        {
            x = m_mouseCellPoint.X;
            y = m_mouseCellPoint.Y;
            oneD = To1DArray(x, y);
        }

        public void SwitchIndices()
        {
            int oldPaintIndex = m_paintIndex;
            m_paintIndex = m_eraseIndex;
            m_eraseIndex = m_paintIndex;
        }

        public string GetString()
        {
            return m_numberString;
        }

        public void SetString(string str)
        {
            if (str.Length != m_xCells * m_yCells)
                return;
            if (m_numberString.Equals(str))
                return;
            m_numberString = str;
            InvokeOnDataDirty();
            Invalidate();
        }

        public void RequestSerialisableData(out int x, out int y, out int size, out int indices, out string data)
        {
            x = m_xCells;
            y = m_yCells;
            size = m_xCells * m_yCells;
            indices = this.m_indices;
            data = m_numberString;
        }

        public void Deserialise(int _x, int _y, int _indices, string _data)
        {
            m_xCells = _x;
            m_yCells = _y;
            m_indices = _indices;
            m_numberString = _data;
            Invalidate();
        }

        public void PaintAll()
        {
            m_numberString = String.Empty;
            for (int i = 0; i < m_xCells * m_yCells; i++)
            {
                m_numberString += (char)(m_paintIndex + kDefaultCharIndex);
            }
            Invalidate();
        }

        public void EraseAll()
        {
            m_numberString = String.Empty;
            for (int i = 0; i < m_xCells * m_yCells; i++)
            {
                m_numberString += (char)(m_eraseIndex + kDefaultCharIndex);
            }
            Invalidate();
        }

        public void SaveMembersToInitVariables()
        {
            m_init_x = m_xCells;
            m_init_y = m_yCells;
            m_init_size = m_xCells * m_yCells;
            m_init_indices = m_indices;
        }

        public void SetPaintIndex(int index)
        {
            if (index < m_indices)
            {
                m_paintIndex = index;
                Refresh();
            }
        }

        //=========================================
        // Protected methods
        //=========================================
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            
            if (base.Font == null)
                return;

            //Prepare variables
            Graphics gfx = pe.Graphics;
            Rectangle rect = ClientRectangle, palette = new Rectangle(0,0,ClientRectangle.Width,m_cellSize), cell = new Rectangle(0,cellSize,cellSize,cellSize);
            rect.Width -= 1;
            rect.Height -= 1;
            gfx.FillRectangle(new SolidBrush(Color.White),rect);
            Brush brush = Brushes.Black;
            Pen pen = Pens.Black;
            Point A, B, cellCenter;
            string drawString = String.Empty;

            int maxX = m_cellSize * m_xCells > rect.Width ? rect.Width : m_cellSize * m_xCells;
            int maxY = m_cellSize * m_yCells > rect.Width ? rect.Width : m_cellSize * m_yCells;
            int ix = 0, iy = 0, x = 0, y = m_cellSize * 2;

            //Paint the cell the mouse is currently over green;
            if(bMouseOnGridCell)
            {
                cell.X += m_mouseCellPoint.X * cellSize;
                cell.Y += m_mouseCellPoint.Y * cellSize;
                gfx.FillRectangle(new SolidBrush(Color.Green),cell);
            }

            //Paint the cells with their contents and borders;
            for (iy = 0; iy < m_yCells; iy++)
            {
                x = 0;
                for (ix = 0; ix < m_xCells; ix++)
                {
                    A = new Point(x, 0);
                    B = new Point(x, rect.Height);
                    gfx.DrawLine(pen, A, B);
                    x += cellSize;

                    if (String.IsNullOrEmpty(m_numberString))
                        continue;

                    char c = m_numberString[To1DArray(ix, iy)];
                    CharToStringIntLUT.TryGetValue(c, out drawString);
                    int centerOffset = (int)((base.Font.Size * 0.5f) * (drawString.Length - 1));
                    cellCenter = new Point(0, 0);
                    cellCenter.X += ((int)(base.Font.Size * 0.5f - centerOffset)) + (x - cellSize);
                    cellCenter.Y += ((int)(base.Font.Size * 0.5f)) + (y - cellSize);
                    gfx.DrawString(drawString, base.Font, brush, cellCenter);
                    drawString = String.Empty;
                }
                A = new Point(0, y);
                B = new Point(rect.Width, y);
                gfx.DrawLine(pen, A, B);
                y += cellSize;
            }
            
            //Cap Grid X
            A = new Point(x, 0);
            B = new Point(x, rect.Height);
            gfx.DrawLine(pen, A, B);

            //Draw palette
            gfx.FillRectangle(new SolidBrush(Color.White), palette);
            Point paletteLineStart = new Point(0,palette.Height), paletteLineEnd = new Point(palette.Width,palette.Height);
            
            A = new Point();
            B = new Point();

            float fontYDifference = m_cellSize - base.Font.Size;
            int tx = 0;

            //Draw Indices
            gfx.DrawLine(pen,paletteLineStart,paletteLineEnd);
            for (int i = 0; i < m_indices; i++)
            {
                drawString = i.ToString();
                gfx.DrawString(drawString, base.Font, brush, new Point(tx, (int)fontYDifference / 2));
                IncrementPalettePropertyX(ref tx, ref A, ref B, (int)(base.Font.Size) * drawString.Length);
                gfx.DrawLine(pen, A, B);
            }

            //Draw Indice Borders
            Pen borderPen = new Pen(m_eraseColour);
            gfx.DrawRectangle(borderPen, indicePaletteRect[m_eraseIndex]);
            borderPen.Color = m_paintColour;
            gfx.DrawRectangle(borderPen, indicePaletteRect[m_paintIndex]);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            bool lastOverPalette = bMouseOverPalette;
            bMouseOverPalette = e.Y <= cellSize;
            if (bMouseOverPalette)
            {
                if (bMouseOnGridCell)
                    Invalidate();
                bMouseOnGridCell = false;
                return;
            }

            int lastMouseCell = m_mouseCell;
            int x, y, mouseX = e.X, mouseY = e.Y - cellSize;
            double dx, dy;
            dx = Math.Floor((double)mouseX/ cellSize);
            dy = Math.Floor((double)mouseY / cellSize);
            x = (int)dx;
            y = (int)dy;
            m_mouseCell = To1DArray(x,y);
            m_mouseCellPoint = new Point(x,y);
            bool xInRange = x >= 0 && x < m_xCells, yInRange = y >= 0 && y < m_yCells;
            bMouseOnGridCell = xInRange && yInRange;
            if (m_mouseCell != lastMouseCell || (lastOverPalette && !bMouseOverPalette))
            {
                if (OnMouseCellChanged != null)
                    OnMouseCellChanged.Invoke(this, new EventArgs());
                if (bMouseDown && bMouseOnGridCell)
                    MouseClickGrid(e);
                Invalidate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            bMouseDown = true;
            if (bMouseOnGridCell)
                MouseClickGrid(e);
        }
       
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            bMouseDown = false;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (bMouseOverPalette)
            {
                MouseClickPalette(e);
                return;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                SetPaintIndex((e.KeyChar - '0'));
                return;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyValue == (int)Keys.ControlKey)
                keysDown |= (int)Keys.ControlKey;
            if (e.KeyValue == (int)Keys.ShiftKey)
                keysDown |= (int)Keys.ShiftKey;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            bool ctrlDown = (keysDown & (int)Keys.ControlKey) == (int)Keys.ControlKey;
            bool shiftDown = (keysDown & (int)Keys.ShiftKey) == (int)Keys.ShiftKey;

            if (e.Control && ctrlDown)
                keysDown ^= (int)Keys.Control;
            if (e.Shift && shiftDown)
                keysDown ^= (int)Keys.Shift;
        }

        //=========================================
        // Private methods
        //=========================================

        int To1DArray(int x, int y)
        {
            return y * m_xCells + x; // Remember it's the row Position x number of cells in an column + the current column.
        }

        void BuildNumberString()
        {
            if (String.IsNullOrEmpty(m_numberString))
                m_numberString = String.Empty;

            int iterator = 0, oldLength = m_numberString.Length;
            string oldStringBuffer = String.Copy(m_numberString);
            m_numberString = String.Empty;

            while (iterator < m_xCells * m_yCells)
            {
                if (iterator < oldLength) { m_numberString += oldStringBuffer[iterator]; }
                else { m_numberString += kDefaultCharIndex; }
                iterator++;
            }
            oldStringBuffer = null;
        }

        void OnGridDimensionChanged(EventArgs args)
        {
            BuildNumberString();
            UpdatePaletteRects();
            Invalidate();
        }

        void OnNumberOfIndicesChanged(EventArgs args, int lastIndices)
        {
            if (lastIndices > m_indices)
            {
                m_paintIndex = m_paintIndex >= m_indices ? m_indices - 1 : m_paintIndex;
                m_eraseIndex = m_eraseIndex >= m_indices ? m_indices - 1 : m_eraseIndex; 
                char maxCharacter = (char)(kDefaultCharIndex + (m_indices-1));
                char[] stringBuffer = m_numberString.ToArray();
                for (int i = 0; i < stringBuffer.Length; i++)
                {
                    if(stringBuffer[i] >= maxCharacter)
                    {
                        stringBuffer[i] = maxCharacter;
                    }
                }
                m_numberString = new string(stringBuffer);
            }
            UpdatePaletteRects();
            UpdateCharLUT();
            Invalidate();
        }

        void IncrementPalettePropertyX(ref int x, ref Point A, ref Point B, int by)
        {
            x += by;
            A = new Point(x, 0);
            B = new Point(x, m_cellSize);
        }

        void MouseClickPalette(MouseEventArgs args)
        {
            int clickedOn = -1;
            LoopThroughIndexRects(ref clickedOn, args.X);
            if (clickedOn == -1)
                return;
            switch (args.Button)
            {
                case System.Windows.Forms.MouseButtons.Left:
                    m_paintIndex = clickedOn;
                    break;
                case System.Windows.Forms.MouseButtons.Right:
                    m_eraseIndex = clickedOn;
                    break;
                default:
                    break;
            }
            Invalidate();
        }

        void MouseClickGrid(MouseEventArgs args)
        {
            switch (args.Button)
            {
                case System.Windows.Forms.MouseButtons.Left:
                    PaintCell(m_mouseCell);
                    break;
                case System.Windows.Forms.MouseButtons.Right:
                    EraseCell(m_mouseCell);
                    break;
                default:
                    break;
            }
            Invalidate();
        }

        void LoopThroughIndexRects(ref int clickedOn, int mouseX)
        {
            int iterator = 0, A,B;
            while (iterator < indices)
            {
                A = indicePaletteRect[iterator].X;
                B = indicePaletteRect[iterator].X + indicePaletteRect[iterator].Width;
                if(mouseX >= indicePaletteRect[iterator].X && mouseX < B)
                {
                    clickedOn = iterator;
                    return;
                }
                iterator++;
            }
        }

        void UpdatePaletteRects()
        {
            indicePaletteRect = new Rectangle[indices];
            int fontSize = (int)base.Font.Size, ix = 0;
            string digits = null;
            for (int i = 0; i < indices; i++)
            {
                digits = i.ToString();
                indicePaletteRect[i] = new Rectangle(ix, 0, fontSize * digits.Length, cellSize);
                ix += fontSize * digits.Length;
            }
        }

        void UpdateCharLUT()
        {
            CharToStringIntLUT.Clear();
            char c = kDefaultCharIndex;
            for (int i = 0; i < indices; i++)
            {
                CharToStringIntLUT.Add(c, i.ToString());
                c++;
            }
        }

        void PaintCell(int index)
        {
            if (m_numberString[index] == (char)((int)kDefaultCharIndex + m_paintIndex))
                return;
            char[] array = m_numberString.ToArray();
            array[index] = (char)((int)kDefaultCharIndex + m_paintIndex);
            m_numberString = new string(array);
            InvokeOnDataDirty();
        }

        void EraseCell(int index)
        {
            if (m_numberString[index] == (char)((int)kDefaultCharIndex + m_eraseIndex))
                return;
            char[] array = m_numberString.ToArray();
            array[index] = (char)((int)kDefaultCharIndex + m_eraseIndex);
            m_numberString = new string(array);
            InvokeOnDataDirty();
        }

        void InvokeOnDataDirty()
        {
            if (OnDataDirty != null)
                OnDataDirty.Invoke(this,new EventArgs());
        }
    }
}
