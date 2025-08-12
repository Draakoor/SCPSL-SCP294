using Exiled.API.Enums;
using Exiled.API.Interfaces;
using SCP294.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace SCP294.Config
{
    public class Config : IConfig
    {

        // 必需配置
        /// <summary>
        /// 是否启用插件？
        /// </summary>
        [Description("是否启用插件？")]
        public bool IsEnabled { get; set; } = true;
        /// <summary>
        /// 是否打印调试文本？
        /// </summary>
        [Description("是否打印调试文本？")]
        public bool Debug { get; set; } = false;
        /// <summary>
        /// 配置SCP-294的生成位置
        /// </summary>
        [Description("配置SCP-294的生成位置")]
        public SpawningConfig SpawningLocations { get; set; } = new SpawningConfig() { 
            SpawnAmount = 1,
            SpawnRooms = new Dictionary<RoomType, List<SpawnTransform>>() {
                [RoomType.EzUpstairsPcs] = new List<SpawnTransform>(){
                    new SpawnTransform() {
                        Position = new Vector3(-5.15f, 0f, 2f),
                        Rotation = new Vector3(0f, -90f, 0f),
                        Scale = Vector3.one
                    } 
                },
                [RoomType.EzPcs] = new List<SpawnTransform>(){
                    new SpawnTransform() {
                        Position = new Vector3(-7f, 0f, -1.75f),
                        Rotation = new Vector3(0f, -90f, 0f),
                        Scale = Vector3.one
                    },
                    new SpawnTransform() {
                        Position = new Vector3(2.5f, 0f, 6.8f),
                        Rotation = new Vector3(0f, 0f, 0f),
                        Scale = Vector3.one
                    }
                },
                [RoomType.EzDownstairsPcs] = new List<SpawnTransform>(){
                    new SpawnTransform() {
                        Position = new Vector3(7f, -1.5f, -5.8f),
                        Rotation = new Vector3(0f, 90f, 0f),
                        Scale = Vector3.one
                    },
                    new SpawnTransform() {
                        Position = new Vector3(7f, -1.5f, 5.8f),
                        Rotation = new Vector3(0f, 90f, 0f),
                        Scale = Vector3.one
                    }
                }
            }
        };
        /// <summary>
        /// 是否启用语音效果？若性能不佳且每回合分发超过8杯饮料，请禁用此选项
        /// </summary>
        [Description("是否启用语音效果？若性能不佳且每回合分发超过8杯饮料，请禁用此选项")]
        public bool EnableVoiceEffects { get; set; } = true;
        /// <summary>
        /// 是否强制玩家获取随机饮料？（玩家血液饮料仍可请求）
        /// </summary>
        [Description("是否强制玩家获取随机饮料？（玩家血液饮料仍可请求）")]
        public bool ForceRandom { get; set; } = false;
        /// <summary>
        /// 玩家需距离机器多近才可以使用？
        /// </summary>
        [Description("玩家需距离机器多近才可以使用？")]
        public float UseDistance { get; set; } = 2.5f;
        /// <summary>
        /// 可乐是否应放入机器输出口？设为False则直接放入玩家物品栏
        /// </summary>
        [Description("可乐是否应放入机器输出口？设为False则直接放入玩家物品栏")]
        public bool SpawnInOutput { get; set; } = true;
        /// <summary>
        /// 从执行命令到分发饮料的延迟时间（秒）
        /// </summary>
        [Description("从执行命令到分发饮料的延迟时间（秒）")]
        public float DispenseDelay { get; set; } = 5.5f;
        /// <summary>
        /// 玩家使用机器后的冷却时间（从投入硬币时开始计算）
        /// </summary>
        [Description("玩家使用机器后的冷却时间（从投入硬币时开始计算）")]
        public float CooldownTime { get; set; } = 10f;
        /// <summary>
        /// 是否启用社区制作的饮料
        /// </summary>
        [Description("是否启用社区制作的饮料")]
        public bool EnableCommunityDrinks { get; set; } = true;
        /// <summary>
        /// SCP-294机器停用前的最大使用次数（设为-1表示无限使用）
        /// </summary>
        [Description("SCP-294机器停用前的最大使用次数（设为-1表示无限使用）")]
        public int MaxUsesPerMachine { get; set; } = 3;
        /// <summary>
        /// 饮用饮料后玩家可达到的最大体型
        /// </summary>
        [Description("饮用饮料后玩家可达到的最大体型")]
        public Vector3 MaxSizeFromDrink { get; set; } = new Vector3(1.3f,1.3f,1.3f);
        /// <summary>
        /// 饮用饮料后玩家可缩小的最小体型
        /// </summary>
        [Description("饮用饮料后玩家可缩小的最小体型")]
        public Vector3 MinSizeFromDrink { get; set; } = new Vector3(0.7f,0.7f,0.7f);
    }
}