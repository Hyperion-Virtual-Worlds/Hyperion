﻿/*
 * Hyperion Virtual Worlds is distributed under the terms of the
 * GNU Affero General Public License v3 with the following 
 * clarification and special exception.
 *
 * Linking this library statically or dynamically with other modules is
 * making a combined work based on this library. Thus, the terms and
 * conditions of the GNU Affero General Public License cover the whole
 * combination.
 *
 * As a special exception, the copyright holders of this library give you
 * permission to link this library with independent modules to produce an
 * executable, regardless of the license terms of these independent
 * modules, and to copy and distribute the resulting executable under
 * terms of your choice, provided that you also meet, for each linked
 * independent module, the terms and conditions of the license of that
 * module. An independent module is a module which is not derived from
 * or based on this library. If you modify this library, you may extend
 * this exception to your version of the library, but you are not
 * obligated to do so. If you do not wish to do so, delete this
 * exception statement from your version.
 */

using Hyperion.Common.Main;
using Hyperion.Scene.Management.Scene;
using Hyperion.Scene.Types.Agent;
using Hyperion.Scene.Types.Scene;
using Hyperion.ServiceInterfaces.Purge;
using Hyperion.Types;
using Hyperion.Types.Agent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.Asset.Purger
{
    [PluginName("BakeReferencer")]
    [Description("references avatar bakes")]
    public sealed class BakeReferences : IPlugin, IAssetReferenceInfoServiceInterface
    {
        private SceneList m_Scenes;

        public void Startup(ConfigurationLoader loader)
        {
            m_Scenes = loader.Scenes;
        }

        public void EnumerateUsedAssets(Action<UUID> action)
        {
            var refs = new List<UUID>();

            foreach (SceneInterface scene in m_Scenes.Values)
            {
                foreach (IAgent agent in scene.Agents)
                {
                    foreach (UUID id in agent.Appearance.AvatarTextures.All)
                    {
                        if (id != UUID.Zero && id != AppearanceInfo.AvatarTextureData.DefaultAvatarTextureID && !refs.Contains(id))
                        {
                            refs.Add(id);
                        }
                    }
                }
            }

            foreach (UUID id in refs)
            {
                action(id);
            }
        }
    }
}
