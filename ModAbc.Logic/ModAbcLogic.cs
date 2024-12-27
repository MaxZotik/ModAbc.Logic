using Scada.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Server.Modules.ModAbc.Logic
{
    public class ModAbcLogic : ModuleLogic
    {
        public ModAbcLogic(IServerContext serverContext)
            : base(serverContext)
        {

        }

        public override string Code => "StartExternalApp";

        public override void OnServiceStart()
        {
            Log.WriteAction("Модуль StartExternalApp запущен");
        }

        public override void OnServiceStop()
        {
            Log.WriteAction("Модуль StartExternalApp остановлен");
        }

        public override async void OnIteration()
        {
            if (RepositoryAppObject.AppObjectsList.Count != 0)
            {
                foreach (AppObject appObj in RepositoryAppObject.AppObjectsList)
                {
                    await Task.Run(() => ProcessStart(appObj));
                }
            }
        }

        private void ProcessStart(AppObject appObject)
        {
            CnlData curData = ServerContext.GetCurrentData(appObject.InputChannel);

            if (curData.Val == 1)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = appObject.FileName,
                    WorkingDirectory = appObject.WorkingDirectory,
                    UseShellExecute = true
                });
            }
        }
    }
}
