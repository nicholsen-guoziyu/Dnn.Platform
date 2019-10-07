﻿using Dnn.PersonaBar.Library.Prompt;
using Dnn.PersonaBar.Library.Prompt.Attributes;
using Dnn.PersonaBar.Library.Prompt.Models;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;

namespace Dnn.PersonaBar.Recyclebin.Components.Prompt.Commands
{
    [ConsoleCommand("restore-module", Constants.RecylcleBinCategory, "Prompt_RestoreModule_Description")]
    public class RestoreModule : ConsoleCommandBase
    {
        public override string LocalResourceFile => Constants.LocalResourcesFile;

        [FlagParameter("id", "Prompt_RestoreModule_FlagId", "Integer", true)]
        private const string FlagId = "id";

        [FlagParameter("pageid", "Prompt_RestoreModule_FlagPageId", "Integer", true)]
        private const string FlagPageId = "pageid";

        private int ModuleId { get; set; }
        private int PageId { get; set; }

        public override void Init(string[] args, PortalSettings portalSettings, UserInfo userInfo, int activeTabId)
        {
            
            ModuleId = GetFlagValue(FlagId, "Module Id", -1, true, true, true);
            PageId = GetFlagValue(FlagPageId, "Page Id", -1, true, false, true);
        }

        public override ConsoleResultModel Run()
        {
            string message;
            var restored = RecyclebinController.Instance.RestoreModule(ModuleId, PageId, out message);
            return !restored
                ? new ConsoleErrorResultModel(message)
                : new ConsoleResultModel(string.Format(LocalizeString("Prompt_ModuleRestoredSuccessfully"), ModuleId)) { Records = 1 };
        }
    }
}