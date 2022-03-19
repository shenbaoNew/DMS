using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DMS.DataClass.Pub;

namespace DMS
{
    public delegate void AfterMenuTreeClickEventHandler(object sender, string FullClassName, int FormModule, string FormText);
    public delegate void AfterSelectFinishedItemEventHandler(object sender, bool isSave, string date,bool isExcute);
    public delegate void AfterConfirmEventHandler(object serder, bool flag);
    public delegate void AfterSaveDataEventHandler(object sender, bool isSave);
    public delegate void AfterConfirmUnMatchEventHandler(object sender, bool isSave, List<MenuData> table);
    public delegate void AfterContentMenuClickJumpToEventHandler(object sender, int ClickID);
    public delegate void AfterContentMenuClickEventHandler(object sender, int ClickID, string MenuCode, string FullClassName, int FormModule, string FormText);
}
