[![Github 所有版本下载量](https://img.shields.io/github/downloads/creepycats/Ultimate294/total.svg)](https://github.com/creepycats/Ultimate294/releases) [![维护状态](https://img.shields.io/badge/%E7%BB%B4%E6%8A%A4%E4%B8%AD%EF%BC%9F-%E6%98%AF-green.svg)](https://github.com/creepycats/Ultimate294/graphs/commit-activity) [![GitHub 许可证](https://img.shields.io/github/license/Naereen/StrapDown.js.svg)](https://github.com/creepycats/Ultimate294/blob/main/LICENSE)
<a href="https://github.com/creepycats/Ultimate294/releases"><img src="https://img.shields.io/github/v/release/creepycats/Ultimate294?include_prereleases&label=%E7%89%88%E6%9C%AC" alt="版本"></a>
<a href="https://discord.gg/PyUkWTg"><img src="https://img.shields.io/discord/656673194693885975?color=%23aa0000&label=EXILED" alt="支持"></a>

# Ultimate294 - 真正的 SCP-294 体验
Ultimate294 是一个为《SCP: 秘密实验室》(SCP: Secret Laboratory) 添加随机生成异常饮料贩卖机的插件。

**此版本包含：**
- 重新制作的 SCP-294 模型
- 可控制的生成位置
- 使用次数限制控制
- 倒出饮料时的*音效和动画*
- [**100多种独特饮料（不同名称的饮料数量翻倍），移植自《收容失效》(Containment Breach)，包括来自 Banana's Bungalow 社区的自定义饮料**](https://github.com/creepycats/Ultimate294/blob/main/Types/Config/DrinkList.cs)
- 有趣的秘密命令 :3

由 creepycats 制作，适用于 `v13.3.1` 版本的 SCP:SL 及 `v8.4.2` 版本及更高版本的 Exiled。

## 工作原理
在回合开始时，SCP-294 贩卖机会随机在地图周围生成，默认生成在入口区 (Entrance Zone) 的特定房间中。

当玩家靠近贩卖机时，会看到一个弹出提示 (Hint)，告知他们手持硬币并运行 `.scp294` 命令。

如果玩家手持硬币靠近 SCP-294，他们将能够运行命令 `.scp294 <饮料名称>`，这将导致贩卖机倒出所点的饮料。`<饮料名称>` 替换为玩家想要点的饮料名称。

输入独特的饮料名称会产生各种效果、事件和状态修改。

饮料有设定的概率会“反噬”，导致玩家倒出的饮料变成自己的血液，使其陷入几秒钟的心脏骤停 (Cardiac Arrest)。这通常不致命，但非常痛苦。越好的饮料越容易导致反噬。

玩家也可以通过命令 `.scp294 player <玩家名称>` 获取其他玩家的血液杯，将 `<玩家名称>` 替换为对应玩家的名字。如果找不到玩家或无法接近他们，但玩家找到了硬币并知道目标玩家的名字，这可以用来击杀蹲点的玩家。

与《收容失效》中的对应物相比，一些饮料在 SCP:SL 中进行了独特的改动。例如，点一些恶心的东西可能会导致你把饮料倒在地上（产生一坨“花生的屎”(Tantrum puddle)）。

## 管理员命令
拥有 `SCP294.admin` 权限的管理员可以使用 RA 命令 `scp294`：

*   `scp294 create/spawn` > 在玩家所在坐标生成一个新的 SCP-294 贩卖机。
*   `scp294 remove/delete` > 删除离玩家最近的 SCP-294 贩卖机。
*   `scp294 setuses <次数>` > 设置离玩家最近的 SCP-294 贩卖机实例的剩余使用次数。设置为 `-1` 表示无限次使用，设置为 `0` 表示禁用。
*   `scp294 givedrink <饮料名称>` > 免费将玩家点单后本应从 SCP-294 获得的饮料直接放入玩家的物品栏中。

## 安装
**此插件需要 MapEditorReborn，[你可以在这里下载](https://github.com/Michal78900/MapEditorReborn/releases/)**

**此插件需要 SCPSLAudioApi，[你可以在这里下载](https://github.com/CedModV2/SCPSLAudioApi/releases)**

安装好 MapEditorReborn 和 SCPSLAudioApi 后，前往 [发布页面](https://github.com/creepycats/Ultimate294/releases) 下载最新的 ZIP 文件。

解压 ZIP 文件，将 `Ultimate294.dll` 放入你的 `Plugins` 文件夹，并将 `Config` 文件夹粘贴到你的 `EXILED` 文件夹中（这会安装自定义的 Schematic 地图文件和音效文件）。

## 权限
`SCP294.admin`

## 中文汉化说明
汉化内容由DeepSeek-R1汉化并人工核对修改