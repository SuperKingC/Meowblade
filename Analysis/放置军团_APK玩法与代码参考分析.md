# 《放置军团》APK 玩法与代码参考分析

> 分析对象：`C:\Users\admin\Downloads\com.gubulin.il.apk`  
> 分析日期：2026-08-05  
> 目标项目：《喵剑奇箱》  
> 分析方式：APK 静态解包、程序集识别、热更程序集反编译、资源目录与代码交叉核对。

## 一、先说结论

《放置军团》最值得《喵剑奇箱》学习的，不是“自动战斗”，也不是某个具体工坊界面，而是下面这条完整闭环：

```text
有限工人分配
    ↓
主城持续生产基础材料
    ↓
材料加工并补充兵员
    ↓
配置军团与阵型
    ↓
自动战斗产生兵员消耗
    ↓
首通永久提高生产收益
    ↓
回主城补员、改配置、继续推关
```

主城生产和战斗不是两个独立模块，而是双向驱动：

- 主城为战斗提供材料、装备和可消耗兵员；
- 战斗解锁新内容，并永久提高主城的单位时间收益；
- 兵员损耗让玩家每次战斗后都有回城处理生产的理由；
- 工人的路径、搬运、偷懒、缺料气泡把抽象数值变成可观察的场景故事。

因此，《喵剑奇箱》的 Demo 建议从原来的“自动推关—开箱—换装”改为：

> **猫宅可视化生产驱动的轻军团 Demo。**

一句话体验承诺：

> 我能看到猫猫在家里干活，重新分工会立刻改变产量；我用这些产物补充猫军团，通关后整个猫宅又明显变快、变热闹。

## 二、APK 与技术结构

APK 基本信息：

| 项目 | 结果 |
|---|---|
| 包名 | `com.gubulin.il` |
| 应用名 | 放置军团 |
| 版本 | `3.0.0` |
| versionCode | `79630` |
| APK 大小 | `841,702,016` bytes |
| SHA-256 | `1F876E1201362EB5DF24F670F5E7ECF7672672299C5E34B24FECD5D909C36589` |
| 引擎 | Unity，横屏 |
| 原生构建 | IL2CPP，ARM64 + ARMv7 |
| 资源管理 | Addressables |
| 热更新 | ILRuntime |

关键文件包括：

```text
lib/arm64-v8a/libil2cpp.so
assets/bin/Data/Managed/Metadata/global-metadata.dat
assets/AssetBundles/Addressables/catalog_1.json
assets/dlls/HotFix.dll.bin
```

其中 `HotFix.dll.bin` 实际是未额外加密的标准 .NET 程序集，文件头为 `MZ`，约 14.7 MB。大量玩法、UI、业务编排与协议调用都位于热更程序集内，已反编译为约 8,021 个源码文件：

- [HotFix.Decompiled](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled)

代码中还能看到 FairyGUI、DOTween、Spine、Entitas 风格的实体上下文，以及一个大型 `GameManagers` 全局管理入口。

### 分析限制

本次没有可用的 ADB 设备，因此没有完成运行时抓取与交互录屏。另有部分生产、离线、库存同步和战斗结算由服务器权威处理，所以静态客户端代码可以确认系统关系与客户端表现，但不能完整还原：

- 服务器的精确生产调度算法；
- 完整经济表与线上活动配置；
- 防作弊、库存校验和断线重连细节；
- 某些只由远端配置决定的数值与解锁节奏。

因此以下结论主要用于玩法拆解与 clean-room 架构设计，不应当被理解为对原游戏全部线上逻辑的完整复刻。

## 三、核心玩法是怎样运行的

### 1. 主城本身就是放置反馈

主城不是一个“领取离线收益”的静态菜单。代码和资源目录显示它拥有左右区域、多个建筑控制器、工位、路径节点和工人表现。

玩家会持续看到：

- 矿井、工坊、兵营和仓库；
- 工人从休息区出来；
- 工人走向工位；
- 获取或搬运原材料；
- 加工产品；
- 携带成品前往交付点；
- 缺少材料、仓库已满、工位闲置等状态气泡。

这里最重要的产品经验是：

> 放置反馈不只靠“每小时 +100”，而是让玩家一眼看出谁在工作、哪里卡住、为什么卡住，以及重新分配后哪里变快了。

### 2. 工人是全局有限资源

空闲工人数不是某个建筑内部的独立数字，而是从全局人力中扣除所有系统占用得到：

```text
空闲工人
= 总工人
- 所有矿井、工坊、熔炉等生产占用
- 所有建筑建造或升级占用
- 舰船等其他玩法占用
```

代码证据：

- [Dungeon.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/Shift/Legion/Common/Models/Dungeon.cs:36)

这使“把一个工人放在哪里”成为真实决策，而不是所有建筑都无条件自动增长。

对《喵剑奇箱》而言，第一版只需要 3 只工人猫，但要确保这 3 只猫确实稀缺：把一只猫调去收纸板，鱼干产量就必须下降。

### 3. 工位数据结构很简单

单个生产配置的核心字段只有：

```csharp
public class ProductionConfig
{
    public List<string> ProductList;
    public int Workers;
}
```

代码证据：

- [ProductionConfig.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/Shift/Legion/Common/Models/ProductionConfig.cs)
- [WorkShop.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/WorkShop.cs:100)

复杂感主要来自资源链、配置选择、场景动画和阻塞反馈，而不是底层数据模型本身。这一点非常适合 Demo：先把数据做小，把表现做清楚。

### 4. 工坊采用“临时预览—统一确认”

打开工坊面板后，正式配置会被克隆到 `NewProductConfig`：

- [UI_WorkShopPanel.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/UI/WorkShop/UI_WorkShopPanel.cs:303)

玩家在临时配置上：

- 增加工人；
- 减少工人；
- 清空配置；
- 查看当前与调整后的每小时产量；
- 查看剩余可用工人；
- 最后点击确认统一提交。

产量预览的主要公式近似为：

```text
每小时产量
= 3600 / 单次生产时间
× 分配工人数
×（1 + 生产效率加成）
```

代码证据：

- [UI_WorkShopPanel.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/UI/WorkShop/UI_WorkShopPanel.cs:709)
- [UI_WorkShopPanel.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/UI/WorkShop/UI_WorkShopPanel.cs:738)

确认后发送生产配置变更，并广播：

```text
PRODUCTION_CONFIG_CHANGED
WORKERS_ALLOCATION_DISPLAY_CHANGED
```

代码证据：

- [UI_WorkShopPanel.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/UI/WorkShop/UI_WorkShopPanel.cs:641)

这个交互方式值得保留。玩家可以自由试配并看到收益变化，只有确认后才真正改变状态，不会因为误点导致生产链反复抖动。

### 5. 工人是一套可观察的状态机

工人不是原地循环播放动画，而是沿路径完成一整套工作流程：

```text
休息区
→ 出门
→ 前往工位
→ 加工
→ 携带产品
→ 前往交付点
→ 入库
→ 返回工位或回休息区
```

关键方法包括：

```text
BedroomToStart
StartToWorkbench
StartProduce
WorkbenchToFinish
FinishToStart
StartToBedroom
```

代码证据：

- [WorkerController.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/WorkerController.cs:531)
- [WorkerController.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/WorkerController.cs:552)
- [WorkerController.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/WorkerController.cs:603)
- [WorkerController.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/WorkerController.cs:702)

工人还具有三种明确状态：

| 状态 | 代码效果 | 场景表现 |
|---|---:|---|
| Normal | 时间倍率 `1` | 正常工作 |
| Diligent | 时间倍率 `2` | 加速、火焰特效 |
| Lazy | 时间倍率 `0` | 停工、睡觉表现 |

代码证据：

- [WorkerController.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/WorkerController.cs:881)

《喵剑奇箱》可以把它改成更有猫味的短事件：

- 正常干活；
- 猫薄荷兴奋，短时间双倍生产；
- 原地睡觉；
- 玩纸团；
- 钻进待加工的纸箱；
- 偷吃鱼干；
- 把材料推到地上，再装作没看见。

这些事件不只是装饰，还应当成为生产状态的情绪化表达。

### 6. 生产会因为现实原因停止

生产流程会显式判断：

- 是否缺少上游材料；
- 目标库存是否已满；
- 是否有工人；
- 工位是否配置产品；
- 建筑或产品是否解锁。

工人控制器中能看到 `IsWaitingMaterial`、`IsWaitingStockSpace` 以及对应气泡：

- [WorkerController.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/WorkerController.cs:967)
- [WorkerController.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/WorkerController.cs:1140)

这个设计非常适合猫宅：

- 缺鱼干时，猫举着空碗；
- 纸板仓满时，纸箱堆到天花板；
- 没分配工人时，工位落灰；
- 补员队列卡住时，小猫从猫窝探头等待。

玩家不打开报表也能理解问题所在。

### 7. 兵营生产的是真实兵员库存

兵营最多维护 15 个生产槽位：

- [RecruitingCampDataManager.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/Shift/Legion/Common/Managers/RecruitingCampDataManager.cs:13)

槽位可能处于空闲、生产中、缺材料、库存已满等状态。兵种生产依赖材料、时间、槽位和兵种库存上限：

- [RecruitingCampDataManager.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/Shift/Legion/Common/Managers/RecruitingCampDataManager.cs:174)
- [RecruitingCampDataManager.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/Shift/Legion/Common/Managers/RecruitingCampDataManager.cs:342)

因此它的主要生产链可以概括为：

```text
矿井产基础材料
→ 工坊产武器或中间材料
→ 兵营消耗材料生产士兵
→ 士兵进入库存
→ 士兵被编入军团
```

### 8. 战斗结束会扣除死亡兵员

战斗结束方法接收各兵种死亡数量，并生成库存负向变更：

```text
Offset = -死亡数量
Context = 19
```

代码证据：

- [ClientBattleFieldLogic.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/ClientBattleFieldLogic.cs:130)

这让生产与战斗形成了反向压力：

```text
生产士兵 → 出战 → 伤亡 → 回城补员
```

《喵剑奇箱》不建议照搬“猫猫永久死亡”。更合适的包装是：

- 主将猫永远不会损失；
- 小猫兵战败后变为“疲劳”或“受伤”；
- 受伤小猫回猫窝恢复；
- 使用鱼干可以立即恢复；
- 新手关失败不额外扣除资源；
- 需要补充的是队伍可用人数，而不是角色所有权。

这样既保留经营压力，也不会产生明显的情感排斥。

### 9. 一个兵种在战场上表现为一个小军团

标准强力阵容辅助逻辑以 5 个兵种为常用编队数量：

- [LegionHelper.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/LegionHelper.cs:15)
- [LegionHelper.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/LegionHelper.cs:67)

每种兵并不只显示一个单位，而会形成具有多个实体的小军团。兵种等级、军团人数和单兵战力共同决定军团表现。

这与《喵剑奇箱》原文档中的“主将猫 + 小猫兵”高度契合：

- 玩家养成和配置的是主将猫；
- 每只主将带领一小队同主题猫兵；
- 主将决定技能、行为装备与流派；
- 小猫数量表现军团规模和当前完整度；
- 小猫疲劳产生补员需求。

### 10. 推关直接提高放置产量

每个关卡包含 `AutoProduceBonus`：

- [Level.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/Shift/Legion/Common/Models/Level.cs:322)
- [Level.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/Shift/Legion/Common/Models/Level.cs:425)

胜利界面会读取本关自动生产加成并展示：

- [UI_GameEndPanelVictory.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/UI/GameEndPanels/UI_GameEndPanelVictory.cs:448)

这是整个玩法中最应该借鉴的一刀：

> 战斗首通奖励不要只给一次性金币，而要永久改变主城的单位时间产量，并在回城后立刻让玩家看见变化。

### 11. 离线收益由服务器统一结算

登录主城时，客户端接收：

- 离线秒数；
- 离线奖励；
- 库存变更记录；
- 满仓资源；
- 其他跨系统离线信息。

代码证据：

- [SceneService.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/SceneService.cs:889)
- [SceneService.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/SceneService.cs:902)
- [SceneService.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/SceneService.cs:957)
- [CalcOfflineBonusCommandExecutor.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/CalcOfflineBonusCommandExecutor.cs)
- [UI_ShowOfflineEarnings.cs](/D:/UnityProject/Meowblade/Analysis/com.gubulin.il/HotFix.Decompiled/UI/Tips/UI_ShowOfflineEarnings.cs:261)

Demo 阶段无需服务器，但建议保留统一结果模型：

```text
OfflineResult
├─ ElapsedSeconds
├─ ResourceChanges
├─ UnitRecoveries
├─ CappedResources
└─ NewInventorySnapshot
```

## 四、代码层面哪些值得参考

这里只建议参考思想，重新实现，不复制源代码、资源、美术或具体数值。

### 值得借鉴的部分

1. **生产配置模型很小**  
   工位只保存产品与工人数，便于保存、网络传输和离线快照。

2. **工坊编辑使用临时副本**  
   玩家先试配、看预览，再确认提交，交互容错好。

3. **全局工人池**  
   工人不是每个建筑凭空拥有，而是跨建筑共享的战略资源。

4. **生产有明确阻塞原因**  
   缺料、满仓、未解锁、无人工作必须被建模，不只是在 UI 中写一句提示。

5. **库存变更带上下文**  
   生产、战斗损失、奖励等变更都应记录原因，方便回放、日志、统计和排错。

6. **通关数据直接携带生产加成**  
   关卡与放置经济在数据层明确连接，不靠 UI 临时拼接。

7. **离线结算输出统一结果**  
   UI 只展示结果，不负责自己推导经济过程。

8. **生产配置与场景显示通过事件同步**  
   数据确认后再通知场景和 UI 刷新，避免每个界面互相直接控制。

### 不建议照搬的技术债

1. **大量全局单例和 Service Locator**  
   `GameManagers.Instance`、`GameController.Contexts.Service<T>()` 使用范围很广，短期方便，长期会让依赖隐藏、单元测试困难。

2. **字符串事件名**  
   `"PRODUCTION_CONFIG_CHANGED"` 之类的消息缺乏编译期检查，重命名、参数变化和事件追踪容易出问题。

3. **超大型 UI 类**  
   工坊与胜利面板都有上千行代码，渲染、网络、状态、动效、埋点混在同一个类中，不适合新项目复制。

4. **生产流程与工人动画存在较强耦合**  
   工人到达工位后直接触发生产、生产结束再触发搬运。线上项目还可依赖服务器纠正，但本地 Demo 若这样写，切后台、倍速或动画中断时容易出逻辑错误。

5. **魔法数字和魔法字符串较多**  
   建筑类型如 `"12"`、库存上下文如 `19`，可读性和可维护性较弱。

6. **服务器协议调用混入 UI 编排**  
   面板直接组织网络请求和协议字典，会放大 UI 与后端结构之间的耦合。

《喵剑奇箱》应当保留其系统思想，但采用更小、更强类型、更可测试的架构。

## 五、《喵剑奇箱》Demo 的推荐玩法

### 产品定位

Demo 名称可暂定为：

> **猫宅军团：看得见的放置经营**

Demo 需要验证的不是长期数值，而是三个问题：

1. 看猫猫工作本身是否有趣；
2. 重新分配工人是否会产生明确、可理解的选择；
3. 战斗结束后，玩家是否自然愿意回猫宅处理生产和补员。

### Demo 的最小闭环

```text
观察猫宅
→ 收取资源
→ 调整 3 只工人猫的岗位
→ 补充小猫兵或制作行为装备
→ 配置 3 队军团
→ 自动战斗
→ 小猫疲劳/受伤
→ 回猫宅补员
→ 首通提高生产倍率并改变场景
```

### 主界面只做一间猫宅

横屏主场景只保留三个生产点：

| 生产点 | 基础产出 | 猫行为 |
|---|---|---|
| 纸箱回收角 | 纸板 | 抓纸箱、撕胶带、钻箱子 |
| 小鱼干厨房 | 鱼干 | 推碗、偷吃、踩奶 |
| 奇箱拆解台 | 奇箱零件 | 拍按钮、拨齿轮、追弹簧 |

玩家总共只有 3 只工人猫。三个生产点都允许放 0～3 只，但总数不能超过 3。

生产点之外，再提供两个不占工人的消费入口：

- 猫窝：用纸板和鱼干恢复小猫兵；
- 奇箱工坊：用纸板和零件制作一件行为装备。

这样既有调度，又不会在 Demo 中做出多层生产队列。

### 最小资源集合

只保留三种资源：

| 资源 | 主要用途 | 来源 |
|---|---|---|
| 纸板 | 补员、纸箱装备 | 纸箱回收角 |
| 鱼干 | 补员、快速恢复 | 小鱼干厨房 |
| 奇箱零件 | 行为装备 | 奇箱拆解台、关卡首通 |

建议初始每只工人猫的基础速度：

| 岗位 | 单猫基础产量 |
|---|---:|
| 纸板 | 12/分钟 |
| 鱼干 | 10/分钟 |
| 奇箱零件 | 6/分钟 |

建议库存上限：

| 资源 | 初始上限 |
|---|---:|
| 纸板 | 60 |
| 鱼干 | 50 |
| 奇箱零件 | 30 |

这些数字是为了让 Demo 在几十秒内产生反馈，不是正式上线经济。

### 最小配方

只做两个配方：

```text
补充 1 只小猫兵
= 4 纸板 + 6 鱼干
```

```text
制作“纸箱侠披风”
= 8 纸板 + 3 奇箱零件
效果：前排小队受到伤害 -20%
```

Demo 中配方建议即时完成或只播放 2～3 秒表现，不做数分钟的等待队列。

### 军团规模

只做 3 只主将猫：

| 主将猫 | 定位 | 小队特征 |
|---|---|---|
| 纸箱侠 | 前排防御 | 3 只纸箱小猫，吸收伤害 |
| 小鱼干 | 中排输出 | 3 只投掷鱼干的小猫，单体伤害 |
| 毛线球 | 后排控制 | 2 只毛线小猫，减速或缠绕 |

阵型只做 `3×2` 中实际使用的 3 个槽位，先不要做 12 格复杂阵型。

主将猫永久存在；小猫兵只有三种状态：

```text
Ready     可出战
Injured   受伤，占编制但不可出战
Recovering 正在猫窝恢复
```

战斗中的“死亡”统一包装为受伤。

### 两关即可

第一关用于证明“军团会消耗、回城要补员”：

- 玩家大概率获胜；
- 产生 1～2 只受伤小猫；
- 首通奖励 3 个奇箱零件；
- 解锁纸箱侠披风配方。

第二关用于证明“生产与配置能解决战斗问题”：

- Boss 有明显的前排范围攻击；
- 直接挑战会很难，但不应强制脚本失败；
- 玩家可以通过补满小猫、给纸箱侠装备披风、把纸箱侠放前排来明显改善结果；
- 首通后所有基础生产速度永久 `+30%`；
- 回城时生产数字、工人速度和场景装饰同时升级。

## 六、推荐的 6～8 分钟体验流程

```text
0:00
进入猫宅，看到三只猫分别工作，资源以小包装被搬进仓库。

0:30
玩家点击收取纸板与鱼干，看到仓库数值和场景堆料同时变化。

0:50
教程要求把一只奇箱拆解猫调到纸板区。
纸板/分钟立刻上升，零件/分钟立刻下降。

1:20
使用纸板和鱼干补充一只小猫兵。
小猫从猫窝跑到纸箱侠身后，阵容人数在场景中可见。

1:50
配置三队军团并挑战第一关。

2:40
第一关获胜，但有 1～2 只小猫受伤；获得 3 个奇箱零件。

3:00
回猫宅。受伤小猫躺在猫窝，玩家用鱼干恢复；解锁纸箱侠披风。

3:40
玩家制作披风，装备给纸箱侠；必要时再次调整工人，补满前排。

4:20
挑战第二关 Boss。Boss 的前排范围攻击被披风和阵型明显克制。

5:30
Boss 首通，结算明确显示：所有生产速度 +30%。

5:50
返回猫宅。工人动作加快、产量数字跳升、纸箱堆变大、新装饰亮起。

6:30～8:00
允许玩家自由调整岗位，展示下一种行为装备或第四只工人猫的预告。
```

## 七、Demo 实现架构建议

当前 Unity 工程版本为 `2022.3.62f3`，`Assets` 基本为空，适合从小型领域模型开始，不需要继承复杂旧架构。

### 1. 逻辑层使用纯 C#，不要依赖场景动画

建议模块：

```text
GameDomain
├─ InventoryService
├─ WorkerPoolService
├─ ProductionService
├─ CraftingService
├─ ArmyService
├─ BattleResultService
├─ ProgressionService
├─ OfflineProductionService
└─ SaveService
```

职责建议：

```text
InventoryService
├─ 增减资源
├─ 库存上限
├─ 原子消耗
└─ 记录变更原因

WorkerPoolService
├─ 总工人数
├─ 岗位分配
├─ 空闲工人数
└─ 校验分配合法性

ProductionService
├─ 按时间推进产量
├─ 应用关卡倍率
├─ 处理满仓
└─ 输出生产状态

ArmyService
├─ 主将猫
├─ 小猫编制
├─ 受伤与恢复
├─ 装备
└─ 阵型

ProgressionService
├─ 当前关卡
├─ 首通状态
├─ 永久生产倍率
└─ 配方与工位解锁
```

工人表现层单独监听逻辑状态：

```text
WorkerVisualController
├─ Sleeping
├─ WalkingToInput
├─ CarryingMaterial
├─ Working
├─ CarryingProduct
├─ Delivering
├─ WaitingResource
└─ WaitingStorage
```

关键原则：

> 生产结算不能依赖工人动画是否走到终点。动画只把生产状态演出来，不能成为经济系统的时钟。

这样才能安全支持倍速、暂停、切后台和离线结算。

### 2. 使用强类型事件

不要复制字符串消息总线。建议使用强类型事件或一个很小的事件流：

```csharp
public readonly record struct WorkerAllocationChanged(
    JobId Job,
    int OldCount,
    int NewCount);

public readonly record struct InventoryChanged(
    ResourceId Resource,
    int Delta,
    ChangeReason Reason);

public readonly record struct ProductionMultiplierChanged(
    float OldValue,
    float NewValue);
```

### 3. 配置使用 ScriptableObject，运行状态使用普通数据对象

配置：

```text
ResourceDefinition
JobDefinition
RecipeDefinition
HeroCatDefinition
SquadDefinition
StageDefinition
```

运行时保存：

```text
GameSaveData
├─ Inventory
├─ WorkerAllocations
├─ ProductionProgress
├─ ArmyState
├─ EquippedBehaviorItems
├─ ClearedStages
├─ GlobalProductionMultiplier
└─ LastSaveUnixTime
```

### 4. Demo 生产公式

每帧或每个固定逻辑 Tick：

```text
生产进度增加量
= DeltaTime
× 岗位工人数
× 单猫每秒产量
× 全局生产倍率
```

当进度达到 `1` 时，尝试把整数产物写入库存；超过上限的部分不写入，并把岗位状态改为 `WaitingStorage`。

不要每一帧直接修改 UI。逻辑可以 5～10 次/秒 Tick，UI 数字再平滑插值。

### 5. Demo 离线结算

第一版只计算三种独立基础资源，不离线模拟复杂制作队列：

```text
有效离线时间
= min(当前时间 - 上次保存时间, 30 分钟)
```

对每个岗位：

```text
离线产量
= 有效离线秒数
× 工人数
× 单猫每秒产量
× 保存时的全局倍率
```

最后统一应用库存上限，并返回哪些资源因满仓被截断。

### 6. 本地保存

Demo 使用一个版本化 JSON 即可：

```text
SaveVersion
LastSaveUnixTime
Inventory
WorkerAllocations
ArmyState
Progression
```

保存时机：

- 调整工人确认后；
- 制作或补员后；
- 战斗结算后；
- 应用暂停或退出时；
- 每 30 秒自动保存一次。

## 八、开发顺序与预估

以一名开发者、占位美术、现有空工程为前提，建议用 8～12 个工作日完成可玩的垂直切片：

| 阶段 | 内容 | 预计 |
|---|---|---:|
| 1 | 资源、工人、生产、存档纯逻辑 | 1.5 天 |
| 2 | 猫宅场景与三个工位占位表现 | 1.5 天 |
| 3 | 工人分配面板、产量预览、满仓反馈 | 1 天 |
| 4 | 三主将、三小队、简化阵型 | 1.5 天 |
| 5 | 两关自动战斗与受伤结算 | 2 天 |
| 6 | 补员、行为装备与克制关系 | 1 天 |
| 7 | 通关反哺生产、回城升级表现 | 1 天 |
| 8 | 教程、数值调优、存档与构建检查 | 1.5～2.5 天 |

若加入正式猫动画、完整音效、UI 动效和可对外展示的美术，建议再预留 2～3 周。

## 九、验收标准

Demo 完成不以“功能都能点”为标准，而以玩家是否读懂闭环为标准。

必须满足：

- 玩家进入后 10 秒内能看出三只猫正在做不同工作；
- 60 秒内完成一次工人重新分配；
- 分配前就能看到三个岗位产量的增减预览；
- 确认后 3 秒内，数字和场景动作都反映变化；
- 第一场战斗后必然产生一个回城动作：恢复、补员或制作；
- 玩家能说清第二关失败或险胜的原因；
- 装备、补员或阵型调整能明显改变第二次战斗结果；
- Boss 首通后 3 秒内能看到猫宅生产永久加快；
- 完整闭环控制在 6～8 分钟；
- 流程中不出现超过 15 秒且没有观察价值或决策的纯等待。

建议记录以下本地调试事件：

```text
demo_started
worker_allocation_changed
resource_capped
squad_recovered
behavior_item_crafted
battle_started
battle_finished
stage_first_cleared
production_multiplier_changed
demo_loop_completed
```

## 十、Demo 暂时不要做

- 复杂开箱概率；
- 24 件装备；
- 十几个生产建筑；
- 多层中间材料；
- 永久猫猫死亡；
- 好友工人和工人租赁；
- 月卡、广告与付费加速；
- 数小时建筑升级队列；
- 15 个兵营槽位；
- 12 格阵型；
- 完整服务器生产同步；
- 超过 30 分钟的长期离线经济；
- 大量稀有度与升星系统。

这些系统都可能成为后续扩展，但现在会掩盖真正需要验证的核心问题：

> “看得见的猫宅生产”和“轻军团战斗”之间，是否能形成一条让玩家愿意反复走的短循环。

## 十一、最终建议

第一版 Demo 应当把开发资源优先放在四件事上：

1. 三只工人猫的工作、搬运、偷懒和缺料表现；
2. 一次工人调度立刻改变产量的反馈；
3. 小猫受伤后回猫宅恢复的可视化；
4. Boss 首通后猫宅产量和外观同时升级。

如果这四件事做出来仍不好玩，再增加开箱、装备数量或长期养成也很难救；如果这四件事成立，后续的行为装备、猫品种、建筑升级和更大军团都可以自然接上。

