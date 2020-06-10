using System.Diagnostics;
using System.Windows.Forms;
using EasyTabs;

namespace TestApp
{
	public partial class TestApp : TitleBarTabs
    {
        public TestApp()
        {
            InitializeComponent();

            ClientSize      = new System.Drawing.Size(700, 550);
            MinimumSize     = new System.Drawing.Size(450, 300);
            Name            = "Chrome test";
            WindowState     = FormWindowState.Normal;
            
            AeroPeekEnabled = true;
            TabRenderer     = new ModernChromeTabRenderer(this)  // new ClassicChromeTabRenderer(this);
            { AutoMinimumWidth = false}; 
            Icon            = Resources.DefaultIcon;

            // Automatically creating & closing tabs. 
            // If disabled, use the TabClosed & TabCreated event to do it manually
            AutoCloseTab    = true;
            AutoCreateTab   = true;

            TabClosed      += OnTabClosed;
            TabCreated     += OnTabCreated;
        }

        private void OnTabCreated(object sender, TitleBarTabEventArgs e)
        {
            Debug.WriteLine("TabCreated");
        }

        private void OnTabClosed(object sender, TitleBarTabEventArgs e)
        {
            Debug.WriteLine("TabClosed");
        }

        // CreateTab is called when automatically creating a tab
        public override TitleBarTab CreateTab()
        {
            return new TitleBarTab(this)
            {
                Content = new TabWindow
                {
                    Text = "New Tab"
                }
            };
        }
    }
}
