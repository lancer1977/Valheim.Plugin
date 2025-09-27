namespace PolyhydraGames.Valheim.Plugin.Extensions
{
    public enum RpcCommand
    {
        SetGuardianPower,
        UseGuardianPower,
        // Core networking / admin
        PeerInfo,              // (ZRpc rpc, ZPackage pkg)
        NetTime,               // (ZRpc rpc, ZPackage pkg)
        ServerHandshake,       // (ZRpc rpc, ZPackage pkg)
        ClientHandshake,       // (ZRpc rpc, ZPackage pkg)
        ServerSyncedPlayerData,// (ZRpc rpc, ZPackage pkg)
        Disconnect,            // (ZRpc rpc)
        Error,                 // (ZRpc rpc, int code)
        Kick,                  // (long uid)
        Kicked,                // ()
        Ban,                   // (string name, long uid)
        Unban,                 // (string name)
        AdminList,             // (ZPackage pkg)
        Save,                  // ()
        SavePlayerProfile,     // (ZDOID characterID, ZPackage pkg)
        PlayerList,            // (ZPackage pkg)
        PrintBanned,           // ()
        RemoteCommand,         // (string command)
        RemotePrint,           // (string message)

        // World & ZDO
        SpawnObject,           // (ZDOID objID, int prefab, Vector3 pos, Quaternion rot)
        DestroyZDO,            // (ZDOID id)
        RequestZDO,            // (ZDOID id)
        ZDOData,               // (ZDOID id, ZPackage pkg)
        RoutedRPC,             // (ZDOID target, int methodHash, ZPackage pkg)
        SetTrigger,            // (string triggerName)

        // Player
        Heal,                  // (float health, bool showText)
        Damage,                // (HitData hit)
        Stagger,               // ()
        UseStamina,            // (float v)
        OnDeath,               // ()
        OnTargeted,            // (bool enable)
        FlashShield,           // ()
        AddStatusEffect,       // (string name, bool add)
        Controls,              // (ZDOID controlledObject)
        ReleaseControl,        // ()
        RequestControl,        // (ZDOID id)
        RequestRespons,        // (ZDOID id, bool granted)

        // Chat / comms
        ChatMessage,           // (long senderID, Vector3 pos, int type, string text, string sender)
        TeleportPlayer,        // (Vector3 pos, Quaternion rot, bool distantTeleport)
        Say,                   // (string text)

        // Items / containers
        DropItem,              // (ZDOID item, Vector3 pos, int amount)
        DropItemByName,        // (string name, int amount)
        RequestOwn,            // (ZDOID id)
        SetPose,               // (int pose)
        SetVisualItem,         // (string name, int variant, int quality, int stack)
        OpenRespons,           // (bool granted)
        RequestStack,          // (ZDOID item)
        StackResponse,         // (bool ok)
        RequestOpen,           // (long playerID)
        RequestTakeAll,        // ()
        TakeAllRespons,        // (bool ok)
        AddFuel,               // (int amount)
        AddItem,               // (ZDOID item)
        RemoveDoneItem,        // (ZDOID item)
        SetSlotVisual,         // (int slot, string name)
        AddFuelAmount,         // (int amount)
        SetFuelAmount,         // (int amount)
        ToggleOn,              // (bool on)
        Pickup,                // (ZDOID id)
        RequestPickup,         // (ZDOID id)

        // Structures
        UseDoor,               // (bool open)
        Repair,                // ()
        Remove,                // ()
        HealthChanged,         // (float health)
        UpdateMaterial,        // (int index)
        SetAreaHealth,         // (float health)

        // Events / bosses
        SetEvent,              // (string name)
        BossSpawnInitiated,    // ()
        RemoveBossSpawnInventoryItems, // ()
        SpawnBoss,             // (Vector3 pos)

        // Creatures / AI
        SetTamed,              // (bool tamed)
        ResetCloth,            // ()
        FreezeFrame,           // ()
        OnHit,                 // (HitData hit)
        Attach,                // (ZDOID parent, Vector3 pos)
        TeleportTo,            // (Vector3 pos, Quaternion rot, bool distant)
        StaggerCreature,       // ()
        OnEat,                 // (string foodName)
        TryEat,                // (string foodName)
        EatConfirmation,       // (bool success)
        Nibble,                // ()
        Step,                  // ()
        Wakeup,                // ()
        Grow,                  // ()
        Shake,                 // ()
        Command,               // (string cmd)
        UnSummon,              // ()
        SetName,               // (string name)

        // Ships & saddles
        Forward,               // ()
        Backward,              // ()
        Rudder,                // (float value)
        Stop,                  // ()
        AddSaddle,             // (ZDOID saddle)
        RemoveSaddle,          // ()
        SetSaddle,             // (ZDOID saddle)
        RequestControlShip,    // (ZDOID shipID)
        ReleaseControlShip,    // (ZDOID shipID)

        // World keys / locations
        SetGlobalKey,          // (string key)
        RemoveGlobalKey,       // (string key)
        GlobalKeys,            // (ZPackage pkg)
        LocationIcons,         // (ZPackage pkg)
        AddNoise
    }
}