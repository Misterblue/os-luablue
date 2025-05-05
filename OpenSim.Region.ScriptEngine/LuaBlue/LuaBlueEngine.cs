// Copyright 2025 Robert Adams (misterblue@misterblue.com)
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// Structure patterned after OpenSimulator's YEngine which was
// based on XMREngine from Mike Rieker (DreamNation), Melanie Thielker and meta7.

using System;
using System.Collections.Generic;

using OpenSim.Framework;
using OpenSim.Region.Framework.Interfaces;
using OpenSim.Region.Framework.Scenes;
using OpenSim.Region.ScriptEngine.Interfaces;
using OpenSim.Region.ScriptEngine.Shared;
using OpenSim.Region.ScriptEngine.Shared.Api;

using OpenMetaverse;
using OpenMetaverse.StructuredData;

using log4net;
using Mono.Addins;
using Nini.Config;

namespace OpenSim.Region.ScriptEngine.LuaBlue
{
    [Mono.Addins.Extension(Path = "/OpenSim/RegionModules", NodeName = "RegionModule", Id = "LuaBlueEngine")]
    public class LuaBlueEngine : INonSharedRegionModule, IScriptEngine, IScriptModule
    {
        public static readonly ILog m_log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private bool m_Enabled = false;
        private IConfigSource m_ConfigSource;
        private IConfig m_Config;

    #region INonSharedRegionModule Members

        // INonSharedRegionModule.Name
        public string Name => "LuaBlue";
        // INonSharedRegionModule.ReplaceableInterface
        public Type ReplaceableInterface => null;

        // INonSharedRegionModule.Initialise
        public void Initialise(IConfigSource config)
        {
            m_ConfigSource = config;
            m_Config = config.Configs["LuaBlue"];
            if(m_Config == null)
            {
                m_log.Info("[LuaBlue]: no config, assuming disabled");
                return;
            }
            m_Enabled = m_Config.GetBoolean("Enabled", false);
            m_log.InfoFormat("[LuaBlue]: config enabled={0}", m_Enabled);
            if(!m_Enabled)
                return;

            MainConsole.Instance.Commands.AddCommand("luablue", false,
                    "luablue", "luablue [...|help|...] ...",
                    "Run LuaBlue script engine commands",
                    HandleConsoleCmds);


        }

        // INonSharedRegionModule.Close
        public void Close()
        {
            // Cleanup logic for LuaBlue engine
        }

        // INonSharedRegionModule.AddRegion
        public void AddRegion(Scene scene)
        {
            // Logic to add LuaBlue engine to a region
        }

        // INonSharedRegionModule.RemoveRegion
        public void RemoveRegion(Scene scene)
        {
            // Logic to remove LuaBlue engine from a region
        }

        // INonShareRegionModule.RegionLoaded
        public void RegionLoaded(Scene scene)
        {
            // Logic to handle when the region is loaded
        }
    #endregion

    #region IScriptEngine Members
        // IScriptEngine.Name
        public string Name => "LuaBlue";
        
        // IScriptEngine.OnScriptLoaded
        public void OnRezScript(uint localID, UUID itemID, string script, int startParam, bool postOnRez, string defEngine, int stateSource)
        {
            // Logic to handle script rezzing
        }

        public void QueueEventHandler(UUID itemID, string eventName, object[] parameters)
        {
            // Logic to queue event handlers for Lua scripts
        }
    #endregion

    #region IScriptModule Members

        // IScriptModule.ScriptEngineName
        public string ScriptEngineName => "LuaBlue";
        string GetXMLState(UUID itemID);
        bool SetXMLState(UUID itemID, string xml);

        bool PostScriptEvent(UUID itemID, string name, Object[] args);
        bool PostObjectEvent(UUID itemID, string name, Object[] args);
        bool SuspendScript(UUID itemID);
        bool ResumeScript(UUID itemID);
        ArrayList GetScriptErrors(UUID itemID);
        bool HasScript(UUID itemID, out bool running);
        bool GetScriptState(UUID itemID);
        void SaveAllState();
        void StartProcessing();
        float GetScriptExecutionTime(List<UUID> itemIDs);
        Dictionary<uint, float> GetObjectScriptsExecutionTimes();
        ICollection<ScriptTopStatsData> GetTopObjectStats(float mintime, int minmemory, out float totaltime, out float totalmemory);
        int GetScriptsMemory(List<UUID> itemIDs);
    #endregion
    }
}
