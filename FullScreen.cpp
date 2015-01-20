#include <windows.h> 
#include <stdio.h>
#include <tlhelp32.h>
#define chZhsanMainTitle "中华三国志威力加强版"
DWORD GetZhsanPid(void)
{
	DWORD dwZhsanPid=0;
	PROCESSENTRY32 pEntry={sizeof(PROCESSENTRY32)};
    HANDLE hSnapshot=CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS,0);
    if(hSnapshot!=INVALID_HANDLE_VALUE)
    {
        if(Process32First(hSnapshot,&pEntry))
        {
            while (Process32Next(hSnapshot, &pEntry))
            {
                if(stricmp("WorldOfTheThreeKingdoms.exe", pEntry.szExeFile) == 0)
                {
                    dwZhsanPid=pEntry.th32ProcessID;
                    CloseHandle(hSnapshot);
                    break;
                }
            }
        }
    }
	return dwZhsanPid;
}
void SetWindowFullScreen(HWND hWnd)
{
	long MyStyle = GetWindowLong(hWnd, GWL_STYLE);
	MyStyle &= (~WS_CAPTION);
	MyStyle &= (~WS_THICKFRAME);
	SetWindowLong(hWnd, GWL_STYLE, MyStyle);
	MoveWindow(hWnd,0,0,GetSystemMetrics(SM_CXSCREEN),GetSystemMetrics(SM_CYSCREEN),true);//;;
	SendMessage(hWnd,WM_SYSCOMMAND,SC_MAXIMIZE,0);
	UpdateWindow(hWnd);
}
bool IsStrStartsWithStr(char* chStr1,char* chStr2)
{
	int cchStr1=strlen(chStr1);
	int cchStr2=strlen(chStr2);
	if(cchStr1<cchStr2)
	{
		return false;
	}
	bool bIsMatch=true;
	for(int i=0;i<cchStr2;i++)
	{
		if(chStr1[i]!=chStr2[i])
		{
			bIsMatch=false;
			break;
		}
	}
	return bIsMatch;
}
int main(int argc,char*argv)
{
	DWORD dwZhsanPid=GetZhsanPid();
	if(!dwZhsanPid)
	{
		MessageBoxA(0,"请先打开中三","",0);
	}
	HWND hZhsanHWND=GetTopWindow(NULL);
	while(hZhsanHWND)
    {
        DWORD dwTmpPid=0;
        GetWindowThreadProcessId(hZhsanHWND,&dwTmpPid);
        if(dwTmpPid==dwZhsanPid)
        {
			
			char chTmpStr[128];
			memset(chTmpStr,0,128);
			GetWindowText(hZhsanHWND,chTmpStr,128);
			if(IsStrStartsWithStr(chTmpStr,chZhsanMainTitle))
			{
				SetWindowFullScreen(hZhsanHWND);
				break;
			}
        }
        hZhsanHWND=GetNextWindow(hZhsanHWND,GW_HWNDNEXT);
    }
return 0;   
}   
