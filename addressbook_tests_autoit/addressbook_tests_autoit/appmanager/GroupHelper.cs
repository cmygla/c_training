using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DLTWINTITLE = "Delete group";

        public GroupHelper(ApplicationManager manager):base (manager)
        {
        }

        public List<GroupData> CheckGroupDialog()
        {
            OpenGroupDialog();
            List<GroupData> list = GetGroupList();
            CloseGroupDialog();
            return list;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.3dd72c21",
                "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.3dd72c21",
                "GetText", "#0|#" + i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            }
            return list;
        }

        public void AddGroup(GroupData newGroup)
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.3dd72c23");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
        }

        public void RemoveGroup(int num)
        {
            aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.3dd72c21",
    "Select", "#0|#" + num, "");
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.3dd72c21");
            ConfirmDelete();
        }

        public void AddGroupDialog(GroupData newGroup)
        {
            OpenGroupDialog();
            AddGroup(newGroup);
            CloseGroupDialog();
        }

        public void RemoveGroupDialog(int num)
        {
            OpenGroupDialog();
            RemoveGroup(num);
            CloseGroupDialog();
        }

        private void ConfirmDelete()
        {
            aux.WinWait(DLTWINTITLE);
            aux.ControlClick(DLTWINTITLE, "", "WindowsForms10.BUTTON.app.0.3dd72c21");
            aux.ControlClick(DLTWINTITLE, "", "WindowsForms10.BUTTON.app.0.3dd72c23");
        }

        private void CloseGroupDialog()
        {
            aux.WinWait(GROUPWINTITLE);
            aux.WinActivate(GROUPWINTITLE);
            aux.WinWaitActive(GROUPWINTITLE);
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.3dd72c24");
        }

        private void OpenGroupDialog()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.3dd72c212");
            aux.WinWait(GROUPWINTITLE);
            aux.WinActivate(GROUPWINTITLE);
            aux.WinWaitActive(GROUPWINTITLE);
        }
    }
}