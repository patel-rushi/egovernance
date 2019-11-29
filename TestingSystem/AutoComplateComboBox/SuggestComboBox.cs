using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace AutoCompleteComboBox
{
    public class SuggestComboBox : ComboBox
    {
        #region fields and properties


        // private readonly ListBox _suggLv = new ListBox { Visible = false, TabStop = false };

        //private readonly BindingList<string> _suggBindingList = new BindingList<string>();
        private readonly BindingList<ComboBoxItem> _suggBindingList = new BindingList<ComboBoxItem>();

        private Expression<Func<ObjectCollection, IEnumerable<string>>> _propertySelector;
        private Func<ObjectCollection, IEnumerable<string>> _propertySelectorCompiled;
        private Expression<Func<string, string, bool>> _filterRule;
        private Func<string, bool> _filterRuleCompiled;
        private Expression<Func<string, string>> _suggestListOrderRule;
        private ListBox _suggLb;
        private ToolTip toolTip1;
        private IContainer components;
        private Func<string, string> _suggestListOrderRuleCompiled;

        public int SuggestBoxHeight
        {

            get { return _suggLb.Height; }
            set { if (value > 0) _suggLb.Height = value; }
        }

        /// <summary>
        /// If the item-type of the ComboBox is not string,
        /// you can set here which property should be used
        /// </summary>
        public Expression<Func<ObjectCollection, IEnumerable<string>>> PropertySelector
        {
            get { return _propertySelector; }
            set
            {
                if (value == null) return;
                _propertySelector = value;
                _propertySelectorCompiled = value.Compile();
            }
        }

        ///<summary>
        /// Lambda-Expression to determine the suggested items
        /// (as Expression here because simple lamda (func) is not serializable)
        /// <para>default: case-insensitive contains search</para>
        /// <para>1st string: list item</para>
        /// <para>2nd string: typed text</para>
        ///</summary>
        public Expression<Func<string, string, bool>> FilterRule
        {
            get { return _filterRule; }
            set
            {
                if (value == null) return;
                _filterRule = value;
                _filterRuleCompiled = item => value.Compile()(item, Text);
            }
        }

        ///<summary>
        /// Lambda-Expression to order the suggested items
        /// (as Expression here because simple lamda (func) is not serializable)
        /// <para>default: alphabetic ordering</para>
        ///</summary>
        public Expression<Func<string, string>> SuggestListOrderRule
        {
            get { return _suggestListOrderRule; }
            set
            {
                if (value == null) return;
                _suggestListOrderRule = value;
                _suggestListOrderRuleCompiled = value.Compile();
            }
        }

        #endregion

        /// <summary>
        /// ctor
        /// </summary>
        public SuggestComboBox()
        {
            // set the standard rules:
            try
            {
                if (!DesignMode)
                {
                    DateTime StartDate = DateTime.Now;
                 
                    InitializeComponent();
                    var EndDate = DateTime.Now;
                    var a = (EndDate - StartDate).TotalMilliseconds;
                    a++;
                    StartDate = DateTime.Now;
                    _filterRuleCompiled = s => s.ToLower().Contains(Text.Trim().ToLower());
                    _suggestListOrderRuleCompiled = s => s;
                    _propertySelectorCompiled = collection => collection.Cast<string>();
                    EndDate = DateTime.Now;
                     a = (EndDate - StartDate).TotalMilliseconds;
                    a++;
                    StartDate = DateTime.Now;
                    _suggLb.DataSource = _suggBindingList;
                    EndDate = DateTime.Now;
                    a = (EndDate - StartDate).TotalMilliseconds;
                    a++;
                    StartDate = DateTime.Now;
                    _suggLb.DisplayMember = "DisplayMember";
                    _suggLb.ValueMember = "ValueMember";
                    EndDate = DateTime.Now;
                    a = (EndDate - StartDate).TotalMilliseconds;
                    a++;
                    StartDate = DateTime.Now;
                    _suggLb.Click += SuggLbOnClick;
                    EndDate = DateTime.Now;
                    a = (EndDate - StartDate).TotalMilliseconds;
                    a++;
                    StartDate = DateTime.Now;
                    //_suggLb.Height = base.DropDownHeight;
                    ParentChanged += OnParentChanged;
                    _suggLb.MouseMove += OnListBoxMouseMove;
                    _suggLb.PreviewKeyDown += OnListBoxPreviewKeyDown;
                    _suggLb.BringToFront();
                    EndDate = DateTime.Now;
                    a = (EndDate - StartDate).TotalMilliseconds;
                    a++;

                    //_suggLb.MouseClick += OnMouseClickSuggestionBox;
                }
            }
            catch
            {

            }
        }
        private void OnListBoxMouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (!DesignMode)
                {
                    string strTip = "";

                    //Get the item
                    int nIdx = _suggLb.IndexFromPoint(e.Location);
                    if ((nIdx >= 0) && (nIdx < _suggLb.Items.Count))
                        if (toolTip1.GetToolTip(_suggLb) != ((ComboBoxItem)_suggLb.Items[nIdx]).DisplayMember)
                        {
                            strTip = ((ComboBoxItem)_suggLb.Items[nIdx]).DisplayMember;
                            toolTip1.SetToolTip(_suggLb, strTip);
                        }
                }
            }
            catch
            {

            }
        }
        private void OnListBoxPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (!DesignMode)
                {
                    if (e.KeyData == Keys.Enter)
                    {
                        OnPreviewKeyDown(new PreviewKeyDownEventArgs(Keys.Tab));
                    }
                }
            }
            catch
            {

            }
        }

        //protected override void OnDropDown()
        //{
        //    DroppedDown = false;
        //    _suggLb.Visible = true;
        //}
        /// <summary>
        /// the magic happens here ;-)
        /// </summary>
        /// <param name="e"></param>
        //private void MouseClick(object sender, EventArgs e)
        //{
        //    SelectedValue = _suggLb.SelectedValue;
        //    Select(0, Text.Length);
        //    _suggLb.Visible = false;
        //    base.OnMouseClick(new MouseEventArgs(MouseButtons.Left,1));
        //}
        protected override void OnTextChanged(EventArgs e)
        {
            try
            {
                if (!DesignMode)
                {
                    base.OnTextChanged(e);

                    if (!Focused) return;

                    _suggBindingList.Clear();
                    _suggBindingList.RaiseListChangedEvents = false;
                    _filterRuleCompiled = s => s.ToLower().Contains(Text.Trim().ToLower());

                    if (DataSource != null)
                    {
                        //System.Collections.Generic.IEnumerable<string> List = ((DataTable)DataSource).AsEnumerable().Select(r => r.Field<string>(DisplayMember)).ToArray<string>();

                        //System.Collections.Generic.IEnumerable<ComboBoxItem> List = ((DataTable)DataSource).AsEnumerable().Select
                        //(
                        //    r => r.Field<ComboBoxItem>
                        //    (
                        //        DisplayMember
                        //    )

                        //).ToArray<ComboBoxItem>();

                        //List<ComboBoxItem> list = new List<ComboBoxItem>();
                        //DataTable Ds = ((DataTable)DataSource);
                        ////SizeF Size = new SizeF();
                        ////System.Drawing.Font font = _suggLb.Font;
                        ////Graphics g = _suggLb.CreateGraphics();
                        //foreach (DataRow row in Ds.Rows)
                        //{
                        //    if (row[DisplayMember].ToString()=="--SELECT--")
                        //    {
                        //        continue;
                        //    }
                        //    list.Add
                        //    (
                        //        new ComboBoxItem()
                        //        {
                        //            DisplayMember = row[DisplayMember].ToString(),
                        //            ValueMember = row[ValueMember].ToString()
                        //        }
                        //    );
                        //    //SizeF newSize = g.MeasureString(row[DisplayMember].ToString(), font);
                        //    //if (Size.Width < newSize.Width)
                        //    //    Size = newSize;

                        //}
                        //_suggLb.Width = Convert.ToInt32(Math.Ceiling(Size.Width));
                        //.Where(_filterRuleCompiled)
                        //.OrderBy(_suggestListOrderRuleCompiled)
                        List<ComboBoxItem> list = new List<ComboBoxItem>();

                        BindDataSourse(list);


                        _suggLb.Visible = _suggBindingList.Any();
                        _suggLb.BringToFront();

                        if
                        (
                            _suggBindingList.Count == 1 &&
                            _suggBindingList.Single().DisplayMember.Length == Text.Trim().Length
                        )
                        {
                            Text = _suggBindingList.Single().DisplayMember;
                            Select(0, Text.Length);
                            _suggLb.Visible = false;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        //protected override void OnDataSourceChanged(EventArgs e)
        //{
        //    BindDataSourse(list);
        //    base.OnDataSourceChanged(e);
        //}
        //protected override void OnDisplayMemberChanged(EventArgs e)
        //{
        //    BindDataSourse(list);
        //    base.OnDataSourceChanged(e);

        //}
        //protected override void OnValueMemberChanged(EventArgs e)
        //{
        //    BindDataSourse( list);
        //    base.OnDataSourceChanged(e);

        //}
        private void BindDataSourse(List<ComboBoxItem> list)
        {
            //SizeF Size = new SizeF();
            //System.Drawing.Font font = _suggLb.Font;
            //Graphics g = _suggLb.CreateGraphics();
            try
            {
                if (!DesignMode)
                {
                    if (DataSource != null && ValueMember != "" && DisplayMember != "")
                    {
                        String Filter = "[" + DisplayMember + "] like '%" + EscapeLikeValue(Text) + "%' and [" + DisplayMember + "]<>'--SELECT--'";
                        String SortOrder = "[" + DisplayMember + "] ASC";
                        DataTable dt = ((DataTable)DataSource);
                        dt.CaseSensitive = false;
                        DataRow[] dr = dt.Select(Filter, SortOrder);
                        if (dr.Length > 0)
                        {
                            DataTable Ds = dr.CopyToDataTable();
                            foreach (DataRow row in Ds.Rows)
                            {
                                list.Add
                                (
                                    new ComboBoxItem()
                                    {
                                        DisplayMember = row[DisplayMember].ToString(),
                                        ValueMember = row[ValueMember].ToString()
                                    }
                                );
                                //SizeF newSize = g.MeasureString(row[DisplayMember].ToString(), font);
                                //if (Size.Width < newSize.Width)
                                //    Size = newSize;

                            }
                        }
                    }
                    AssignListBox(list);
                }
            }
            catch
            {

            }
        }
        public static string EscapeLikeValue(string valueWithoutWildcards)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < valueWithoutWildcards.Length; i++)
            {
                char c = valueWithoutWildcards[i];
                if (c == '*' || c == '%' || c == '[' || c == ']')
                    sb.Append("[").Append(c).Append("]");
                else if (c == '\'')
                    sb.Append("''");
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {

            try
            {
                if (!DesignMode)
                {
                    if (e.Index == -1) { return; }

                    Point p = new Point(Location.X + 120, Location.Y + Height + (25 + e.Index * 10));



                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    {

                        toolTip1.Show(Items[e.Index].ToString(), this, p);

                    }



                    e.DrawBackground();

                    e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, Brushes.Black, new Point(e.Bounds.X, e.Bounds.Y));
                }
            }
            catch
            {

            }
        }
        private void AssignListBox(List<ComboBoxItem> list)
        {
            try
            {
                if (!DesignMode)
                {
                    list.ForEach(_suggBindingList.Add);

                    _suggBindingList.RaiseListChangedEvents = true;
                    _suggBindingList.ResetBindings();
                    // SuggestBoxHeight = DropDownHeight;
                }
            }
            catch
            {

            }
        }
        #region size and position of suggest box

        /// <summary>
        /// suggest-ListBox is added to parent control
        /// (in ctor parent isn't already assigned)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnParentChanged(object sender, EventArgs e)
        {
            try
            {
                if (!DesignMode)
                {
                    Parent.Controls.Add(_suggLb);
                    Parent.Controls.SetChildIndex(_suggLb,1000);
                    _suggLb.Top = Top + Height - 3;
                    _suggLb.Left = Left;
                    _suggLb.Width = Width;
                    _suggLb.Font = new Font("Segoe UI", 9);
                }
            }
            catch
            {

            }
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            try
            {
                if (!DesignMode)
                {
                    base.OnLocationChanged(e);
                    _suggLb.Top = Top + Height - 3;
                    _suggLb.Left = Left;
                }
            }
            catch
            {

            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            try
            {
                if (!DesignMode)
                {
                    base.OnSizeChanged(e);
                    _suggLb.Width = Width;
                }
            }
            catch
            {

            }
        }

        #endregion

        #region visibility of suggest box

        //protected void OnMouseClickSuggestionBox(object sender, MouseEventArgs e)
        //{
        //    if (_suggLb.SelectedValue != null)
        //    {
        //        SelectedValue = _suggLb.SelectedValue;
        //        Select(0, Text.Length);
        //        _suggLb.Visible = false;
        //    }
        //    base.OnPreviewKeyDown(new PreviewKeyDownEventArgs(Keys.Tab));
        //}
        //protected override void OnMouseClick(MouseEventArgs e)
        //{
        //    // _suggLb can only getting focused by clicking (because TabStop is off)
        //    // --> click-eventhandler 'SuggLbOnClick' is called
        //    //if (!_suggLb.Focused)
        //    //    HideSuggBox();
        //    //base.OnLostFocus(e);
        //    base.SelectionChangeCommitted(EventArgs.Empty);
        //}

        protected override void OnLostFocus(EventArgs e)
        {
            // _suggLb can only getting focused by clicking (because TabStop is off)
            // --> click-eventhandler 'SuggLbOnClick' is called
            try
            {
                if (!DesignMode)
                {
                    if (!_suggLb.Visible)
                    {
                        if ((Text == "") || SelectedValue == null)
                        {
                            Text = "--SELECT--";
                        }
                        //    base.OnPreviewKeyDown(new PreviewKeyDownEventArgs(Keys.Tab));
                    }
                    else
                    {
                        if ((Text.Trim() == "" || (_suggLb.Items.Count == 0)))
                        {
                            Text = "--SELECT--";
                            //s base.OnPreviewKeyDown(new PreviewKeyDownEventArgs(Keys.Tab));
                        }
                    }
                    if (!_suggLb.Focused)
                        HideSuggBox();
                    // base.OnLostFocus(e);
                }
            }
            catch
            {

            }
        }

        private void SuggLbOnClick(object sender, EventArgs eventArgs)
        {
            try
            {
                if (!DesignMode)
                {
                    SelectedValue = _suggLb.SelectedValue;
                    Focus();
                    base.OnPreviewKeyDown(new PreviewKeyDownEventArgs(Keys.Tab));
                }
            }
            catch
            {

            }
        }

        public void HideSuggBox()
        {
            try
            { _suggLb.Visible = false; }
            catch
            {

            }
        }

        protected override void OnDropDown(EventArgs e)
        {
            try
            {
                if (!DesignMode)
                {
                    HideSuggBox();
                    base.OnDropDown(e);
                }
            }
            catch
            {

            }
        }

        #endregion

        #region keystroke events

        /// <summary>
        /// if the suggest-ListBox is visible some keystrokes
        /// should behave in a custom way
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            try
            {
                if (!DesignMode)
                {
                    DroppedDown = false;
                    if (!_suggLb.Visible)
                    {
                        //if ((e.KeyData == Keys.Tab) && (Text == ""))
                        //{
                        //    Text = "--SELECT--";
                        //}
                        base.OnPreviewKeyDown(e);
                        goto End;
                    }
                    else
                    {
                        if ((e.KeyData == Keys.Tab) && (Text.Trim() == "" || (_suggLb.Items.Count == 0)))
                        {
                            Text = "--SELECT--";
                            base.OnPreviewKeyDown(new PreviewKeyDownEventArgs(Keys.Tab));
                        }
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            if (_suggLb.SelectedIndex < _suggBindingList.Count - 1)
                                _suggLb.SelectedIndex++;
                            break;
                        case Keys.Up:
                            if (_suggLb.SelectedIndex > 0)
                                _suggLb.SelectedIndex--;
                            break;
                        case Keys.Enter:
                            if (_suggLb.SelectedValue != null)
                            {
                                SelectedValue = _suggLb.SelectedValue;
                                Select(0, Text.Length);
                                _suggLb.Visible = false;
                            }
                            return;
                        case Keys.Escape:
                            HideSuggBox();
                            return;
                        case Keys.Tab:
                            if (_suggLb.SelectedValue != null)
                            {
                                SelectedValue = _suggLb.SelectedValue;
                                Select(0, Text.Length);
                                _suggLb.Visible = false;
                            }
                            break;
                        //    default: Text = _suggLb.Text;
                        //        Select(0, Text.Length);
                        //        _suggLb.Visible = false;
                        //base.OnPreviewKeyDown(e);
                        //        return;
                    }

                    base.OnPreviewKeyDown(e);
                End: { }

                    //
                }
            }
            catch
            {

            }
        }

        private static readonly Keys[] KeysToHandle = new[] { Keys.Down, Keys.Up, Keys.Enter, Keys.Escape };
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // the keysstrokes of our interest should not be processed be base class:
            try
            {
                if (!DesignMode)
                {
                    if (_suggLb.Visible && (KeysToHandle.Contains(keyData) || keyData == Keys.Enter))
                        return true;
                }
            }
            catch
            {

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            try
            {
                if (!DesignMode)
                {
                    if (!_suggLb.Visible && !DroppedDown)
                        DroppedDown = true;
                }
            }
            catch
            {

            }
        }
        #endregion

        private void InitializeComponent()
        {

            this.components = new System.ComponentModel.Container();
            this._suggLb = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // _suggLb
            // 
            this._suggLb.FormattingEnabled = true;
            this._suggLb.Location = new System.Drawing.Point(0, 0);
            this._suggLb.Name = "_suggLb";
            this._suggLb.Size = new System.Drawing.Size(120, 95);
            this._suggLb.TabIndex = 0;
            this._suggLb.TabStop = false;
            this._suggLb.Visible = false;
            this.ResumeLayout(false);
        }
    }
    public class ComboBoxItem
    {
        public string DisplayMember { get; set; }

        public string ValueMember { get; set; }
    }
}