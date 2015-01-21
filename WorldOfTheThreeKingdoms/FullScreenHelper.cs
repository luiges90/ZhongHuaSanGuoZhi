namespace WorldOfTheThreeKingdoms
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using WorldOfTheThreeKingdoms.GameProcesses;

    public class FullScreenHelper
    {
        public static void FullScreen()
        {
            Form frm = MainProcessManager.mainGame.GameForm;

            IntPtr hWnd = frm.Handle;
            int oldStyle = GetWindowLong(hWnd, GWL_STYLE);
            oldStyle &= (~WS_CAPTION);
            oldStyle &= (~WS_THICKFRAME);
            SetWindowLong(hWnd, GWL_STYLE, oldStyle);
            MoveWindow(hWnd, 0, 0, GetSystemMetrics(SM_CXSCREEN), GetSystemMetrics(SM_CYSCREEN), true);
            SendMessage(hWnd, WM_SYSCOMMAND, (IntPtr)SC_MAXIMIZE, IntPtr.Zero);
            UpdateWindow(hWnd);

        }
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool repaint);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetSystemMetrics(int smIndex);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int UpdateWindow(IntPtr hWnd);
        private const int GWL_STYLE = -16;
        private const int WS_CAPTION = 0x00C00000;
        private const int WS_THICKFRAME = 0x00040000;
        private const int SM_CXSCREEN = 0;
        private const int SM_CYSCREEN = 1;
        private const uint WM_SYSCOMMAND = 0x0112;
        private const int SC_MAXIMIZE = 0xF030;
    }
}