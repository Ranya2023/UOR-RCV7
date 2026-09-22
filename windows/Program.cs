namespace Remco;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        using var single = new Mutex(true, "UOR-RC.SingleInstance", out bool first);
        if (!first)
        {
            MessageBox.Show("UOR-RC is already running (look in the system tray).",
                "UOR-RC", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        // Per-monitor DPI awareness: cursor positions and window rectangles are real pixels,
        // so the laser / pen lands exactly where you touch on the phone.
        Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm(Settings.Load()));
    }
}
