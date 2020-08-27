using System.Collections;
using System.Collections.ObjectModel;
namespace MyControls
{
    public class HtmlExtender : AjaxControlToolkit.HtmlEditor.Editor
    {
        protected override void FillBottomToolbar()
        {
            //BottomToolbar.Buttons.Add(new AjaxControlToolkit.HtmlEditor.ToolbarButtons.DesignMode());
            //BottomToolbar.Buttons.Add(new AjaxControlToolkit.HtmlEditor.ToolbarButtons.HtmlMode());
            //BottomToolbar.Buttons.Add(new AjaxControlToolkit.HtmlEditor.ToolbarButtons.PreviewMode());
        }

        protected override void FillTopToolbar()
        {
            Collection<AjaxControlToolkit.HtmlEditor.ToolbarButtons.SelectOption> options;
            AjaxControlToolkit.HtmlEditor.ToolbarButtons.SelectOption option;

            TopToolbar.Buttons.Add(new AjaxControlToolkit.HtmlEditor.ToolbarButtons.Bold());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HtmlEditor.ToolbarButtons.Italic());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HtmlEditor.ToolbarButtons.Underline());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HtmlEditor.ToolbarButtons.HorizontalSeparator());

            AjaxControlToolkit.HtmlEditor.ToolbarButtons.FixedForeColor FixedForeColor = new AjaxControlToolkit.HtmlEditor.ToolbarButtons.FixedForeColor();
            TopToolbar.Buttons.Add(FixedForeColor);
            AjaxControlToolkit.HtmlEditor.ToolbarButtons.ForeColorSelector ForeColorSelector = new AjaxControlToolkit.HtmlEditor.ToolbarButtons.ForeColorSelector();
            ForeColorSelector.FixedColorButtonId = FixedForeColor.ID = "FixedForeColor";
            TopToolbar.Buttons.Add(ForeColorSelector);
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HtmlEditor.ToolbarButtons.ForeColorClear());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HtmlEditor.ToolbarButtons.HorizontalSeparator());

            AjaxControlToolkit.HtmlEditor.ToolbarButtons.FontName fontName = new AjaxControlToolkit.HtmlEditor.ToolbarButtons.FontName();
            TopToolbar.Buttons.Add(fontName);

            options = fontName.Options;
            option = new AjaxControlToolkit.HtmlEditor.ToolbarButtons.SelectOption();
            option.Value = "fontasy_ himali_ tt";
            option.Text = "fontasy_ himali_ tt";
            options.Add(option); option = new AjaxControlToolkit.HtmlEditor.ToolbarButtons.SelectOption();
            option.Value = "mercantile";
            option.Text = "Mercantile";
            options.Add(option);
            option = new AjaxControlToolkit.HtmlEditor.ToolbarButtons.SelectOption();
            option.Value = "arial,helvetica,sans-serif";
            option.Text = "Arial";
            options.Add(option);
            option = new AjaxControlToolkit.HtmlEditor.ToolbarButtons.SelectOption();
            option.Value = "courier new,courier,monospace";
            option.Text = "Courier New";
            options.Add(option);
            option = new AjaxControlToolkit.HtmlEditor.ToolbarButtons.SelectOption();
            option.Value = "georgia,times new roman,times,serif";
            option.Text = "Georgia";
            options.Add(option);
            option = new AjaxControlToolkit.HtmlEditor.ToolbarButtons.SelectOption();
            option.Value = "tahoma,arial,helvetica,sans-serif";
            option.Text = "Tahoma";
            options.Add(option);
            option = new AjaxControlToolkit.HtmlEditor.ToolbarButtons.SelectOption();
            option.Value = "times new roman,times,serif";
            option.Text = "Times New Roman";
            options.Add(option);
            option = new AjaxControlToolkit.HtmlEditor.ToolbarButtons.SelectOption();
            option.Value = "verdana,arial,helvetica,sans-serif";
            option.Text = "Verdana";
            options.Add(option);
            option = new AjaxControlToolkit.HtmlEditor.ToolbarButtons.SelectOption();
            option.Value = "impact";
            option.Text = "Impact";
            options.Add(option);

            TopToolbar.Buttons.Add(new AjaxControlToolkit.HtmlEditor.ToolbarButtons.HorizontalSeparator());
            //AjaxControlToolkit.HtmlEditor.ToolbarButtons.FontSize fontSize = new AjaxControlToolkit.HtmlEditor.ToolbarButtons.FontSize();
            //TopToolbar.Buttons.Add(fontSize);

            //options = fontSize.Options;
            //option = new AjaxControlToolkit.HtmlEditor.ToolbarButtons.SelectOption();
            //option.Value = "8pt";
            //option.Text = "1 ( 8 pt)";
            //options.Add(option);
            //option = new AjaxControlToolkit.HtmlEditor.ToolbarButtons.SelectOption();
            //option.Value = "10pt";
            //option.Text = "2 (10 pt)";
            //options.Add(option);
            //option = new AjaxControlToolkit.HtmlEditor.ToolbarButtons.SelectOption();
            //option.Value = "12pt";
            //option.Text = "3 (12 pt)";
            //options.Add(option);
            //option = new AjaxControlToolkit.HtmlEditor.ToolbarButtons.SelectOption();
            //option.Value = "14pt";
            //option.Text = "4 (14 pt)";
            //options.Add(option);
            //option = new AjaxControlToolkit.HtmlEditor.ToolbarButtons.SelectOption();
            //option.Value = "18pt";
            //option.Text = "5 (18 pt)";
            //options.Add(option);
            //option = new AjaxControlToolkit.HtmlEditor.ToolbarButtons.SelectOption();
            //option.Value = "24pt";
            //option.Text = "6 (24 pt)";
            //options.Add(option);
            //option = new AjaxControlToolkit.HtmlEditor.ToolbarButtons.SelectOption();
            //option.Value = "36pt";
            //option.Text = "7 (36 pt)";
            //options.Add(option);

            TopToolbar.Buttons.Add(new AjaxControlToolkit.HtmlEditor.ToolbarButtons.HorizontalSeparator());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HtmlEditor.ToolbarButtons.RemoveStyles());
        }
    }

    public class HtmlExtenderNoBottom : HtmlExtender
    {
        protected override void FillBottomToolbar()
        {
        }
    }

    public class FullNoBottom : AjaxControlToolkit.HtmlEditor.Editor
    {
        protected override void FillBottomToolbar()
        {
        }
    }

    public class FullWithRightBottom : AjaxControlToolkit.HtmlEditor.Editor
    {
        protected override void FillBottomToolbar()
        {
            // reverse
            BottomToolbar.Buttons.Add(new AjaxControlToolkit.HtmlEditor.ToolbarButtons.PreviewMode());
            BottomToolbar.Buttons.Add(new AjaxControlToolkit.HtmlEditor.ToolbarButtons.HtmlMode());
            BottomToolbar.Buttons.Add(new AjaxControlToolkit.HtmlEditor.ToolbarButtons.DesignMode());
        }
    }

    public class EditorWithCustomButtons_1 : AjaxControlToolkit.HtmlEditor.Editor
    {
        protected override void FillTopToolbar()
        {
            base.FillTopToolbar();
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HtmlEditor.ToolbarButtons.HorizontalSeparator());
            //TopToolbar.Buttons.Add(new AjaxControlToolkit.HtmlEditor.CustomToolbarButtons.InsertDate());
            //TopToolbar.Buttons.Add(new AjaxControlToolkit.HtmlEditor.CustomToolbarButtons.InsertIcon());
        }

        public override string ButtonImagesFolder
        {
            get
            {
                return "~/App_Images/HtmlEditor.customButtons/";
            }
        }
    }
}