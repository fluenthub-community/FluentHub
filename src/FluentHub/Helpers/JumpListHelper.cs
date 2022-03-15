﻿using FluentHub.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.StartScreen;

namespace FluentHub.Helpers
{
    public static class JumpListHelper
    {
        public static JumpListItem CreateJumpListItem(string args!!, string displayName!!, string logo!!, string description = "", string groupName = "")
        {
            var item = JumpListItem.CreateWithArguments(args.ToString(), displayName);
            item.Description = description;
            item.GroupName = groupName;
            item.Logo = new Uri(logo);
            return item;
        }

        public static async Task<bool> RemoveFromJumpListAsync(string args)
        {
            if (JumpList.IsSupported())
            {
                var jumpList = await JumpList.LoadCurrentAsync();
                var jumpListItem = jumpList.Items.FirstOrDefault(x => x.Arguments == args);
                if (jumpListItem != null)
                {
                    jumpList.Items.Remove(jumpListItem);
                    await jumpList.SaveAsync();
                    return true;
                }
            }
            return false;
        }

        public static async Task ClearJumpListAsync()
        {
            if (JumpList.IsSupported())
            {
                var jumpList = await JumpList.LoadCurrentAsync();
                jumpList.Items.Clear();
                await jumpList.SaveAsync();
            }
        }

        public static async Task ConfigureDefaultJumpListAsync()
        {
            if (JumpList.IsSupported())
            {                
                var jumpList = await JumpList.LoadCurrentAsync();

                jumpList.Items[0] = CreateJumpListItem("Profile", "Profile", "ms-appx:///Assets/AppTiles/StoreLogo.png", "", "Profile");
                jumpList.Items[1] = CreateJumpListItem("Notifications", "Notifications", "ms-appx:///Assets/AppTiles/StoreLogo.png", "", "Profile");
                jumpList.Items[2] = CreateJumpListItem("Activities", "Activities", "ms-appx:///Assets/AppTiles/StoreLogo.png", "", "Profile");                
                jumpList.Items[3] = CreateJumpListItem("Issues", "Issues", "ms-appx:///Assets/AppTiles/StoreLogo.png", "", "My Work");                                               
                jumpList.Items[4] = CreateJumpListItem("Pull Requests", "Pull Requests", "ms-appx:///Assets/AppTiles/StoreLogo.png", "", "My Work");
                jumpList.Items[5] = CreateJumpListItem("Discussions", "Discussions", "ms-appx:///Assets/AppTiles/StoreLogo.png", "", "My Work");
                jumpList.Items[6] = CreateJumpListItem("Repositories", "Repositories", "ms-appx:///Assets/AppTiles/StoreLogo.png", "", "My Work");
                jumpList.Items[7] = CreateJumpListItem("Organizations", "Organizations", "ms-appx:///Assets/AppTiles/StoreLogo.png", "", "My Work");                
                jumpList.Items[8] = CreateJumpListItem("Starred", "Starred", "ms-appx:///Assets/AppTiles/StoreLogo.png", "", "My Work");
                await jumpList.SaveAsync();
            }
        }

        private static void AddOrUpdate(JumpList jumpList, JumpListItem item)
        {
            var index = jumpList
                            .Items
                            .IndexOf(x => x.Arguments == item.Arguments);

            if (index >= 0)
            {
                jumpList.Items[index] = item;
            }
            else
            {
                jumpList.Items.Add(item);
            }
        }
    }
}