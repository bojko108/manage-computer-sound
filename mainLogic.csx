using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

public class Startup
{
    public async Task<object> Invoke(object taskType)
    {
        int v = (int)taskType;
        Helper h = new Helper();
        return h.Process(v);
    }
}

public partial class Helper : Form
{
    private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
    private const int APPCOMMAND_VOLUME_UP = 0xA0000;
    private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
    private const int WM_APPCOMMAND = 0x319;

    [DllImport("user32.dll")]
    public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

    public Helper() { }

    public string Process(int taskType) 
    {
        switch(taskType) {
            case 0:
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_MUTE);
                return "MUTED";
            case 2:
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_UP);
                return "VOLUME UP";
            case 1:
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_DOWN);
                return "VOLUME DOWN";
            default:
                return taskType.ToString();
        }
    }
}