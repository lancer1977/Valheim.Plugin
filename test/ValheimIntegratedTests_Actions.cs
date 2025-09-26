using System.Diagnostics;
using NUnit.Framework;
using Polyhydra.Valheim.Api;
using Polyhydra.Valheim.Api.Models;

namespace PolyhydraGames.RCon.Test
{
    /// <summary>
    /// Player Targeted
    /// </summary>
    public partial class ValheimIntegratedTests
    {
        [Test] public async Task Smite()
        {
            var result = await _rcon.Smite(DreadId);
            ProcessResult(result, "Smite");
        }


        [Test] public async Task Whisper()
        {
            var result = await _rcon.Whisper(DreadId, " I am the whisper");
            ProcessResult(result, "Whisper");
        }


        [Test, Ignore("Dont kill me bro")]
        public async Task KillPlayerAsync_ShouldBeSuccessful()
        {
            var result = await _valheimServer.MurderPlayer(DreadId);
            ProcessResult(result, "KillPlayerAsync command should succeed.");
        }
        [Test, Ignore("Use rarely")]
        public async Task Teleport1To2()
        {
            var me = _valheimServer.Players[0];
            var target = _valheimServer.Players[1];
            var request = new TeleportRequest(me, target.Position);
            await _valheimServer.TeleportTo(request);
            //ProcessResult(result);
        }

        //AddStatus
        [Test] public async Task AddRested()
        {
            Assert.That(_valheimServer.Players.Count > 0);
            var me = _valheimServer.Players[0];
            var request = new AddEffectRequest(me.SteamId, "Rested");
            var result = await _valheimServer.Server.AddStatus(request);
            ProcessResult(result);
        }
        //AddStatus
        [Test]
        public async Task AddPower()
        {
            Assert.That(_valheimServer.Players.Count > 0);
            var me = _valheimServer.Players[0];
            var request = new AddEffectRequest(me.SteamId, "Eikthyr");
            var result = await _valheimServer.Server.AddPower(request);
            ProcessResult(result);
        }
        //AddStatus
        [Test]
        public async Task AddNoise()
        {
            Assert.That(_valheimServer.Players.Count > 0);
            var me = _valheimServer.Players[0];
            var result = await _valheimServer.Server.AddNoise(me.SteamId, 3.1f);
            ProcessResult(result);
        }


        [Test, Ignore("Save this")]
        public async Task KickAsync_ShouldBeSuccessful()
        {
            var result = await _rcon.KickAsync(DreadId.SteamId);
            ProcessResult(result, "Kick command should succeed.");
        }

        [Test] public async Task HealAsync_ShouldBeSuccessful()
        {
            var result = await _rcon.HealAsync(new(DreadId, 100));
            ProcessResult(result, "Heal command should succeed.");
        }

        [Test, Ignore("Save this")]
        public async Task DamageAsync_ShouldBeSuccessful()
        {
            var result = await _rcon.DamageAsync(new DamageRequest(DreadId, 5));
            ProcessResult(result, "Damage command should succeed.");
        }

        [Test] public async Task Stagger()
        {
            var result = await _rcon.DamageAsync(new DamageRequest(DreadId, 5));
            ProcessResult(result, "Damage command should succeed.");
        }

        [Test] public async Task GiveAsync_ShouldBeSuccessful()
        {
            var testItem = "Stone";
            var request = new GiveRequest(DreadId.SteamId, testItem)
            {
                Quality = 100,
                Count = 100
            };
            var result = await _rcon.GiveAsync(request);
            if (result.Successful == false)
            {
                Assert.Fail("Give command should succeed but was" + result.Response);
            }
            else
            {
                ProcessResult(result, "Give command should succeed.");
            }
            Console.WriteLine(result.OutgoingMessage);
            Console.WriteLine(result.Response);
        }

        //Clear, Twilight_Clear, Misty, Darklands_dark, Heath clear, DeepForest Mist, GDKing, Rain, LightRain, ThunderStorm, Eikthyr, GoblinKing, nofogts, SwampRain, Bonemass, Snow, Twilight_Snow, Twilight_SnowStorm, SnowStorm, Moder, Ashrain, Crypt, SunkenCrypt.


        [Test] public async Task TeleportAsync_ShouldBeSuccessful()
        {
            var dread = _valheimServer.Players.First(x => x.SteamId == DreadId.SteamId);
            var request = new TeleportRequest(AlecktoId, dread.Position);
            var result = await _rcon.TeleportAsync(request);
            ProcessResult(result);
        }

    }
    public partial class ValheimIntegratedTests
    {

        // === Commands with options/flags ===

        [Test]
        public async Task FindObjects_WithOptions_SendsExpected()
        {
            var opts = new ObjectQueryOptions(Id: DreadId.SteamId);

            var result = await _rcon.FindObjectsAsync(opts);

            Assert.That(result.Response, Is.EqualTo("ok"));
        }

        [Test]
        public async Task FindObjectsNear_WithOptions_SendsExpected()
        {
            var position = _valheimServer.Players[0].Position;
            var result = await _rcon.FindObjectsNearAsync(position, 1);

            Assert.That(result.Successful);
        }
        /*
     Deleting 2 objects:
       - Prefab: Fish8 Id: 4863 UserId: 1 Position: (-502.88, 41.92, -219.18)(-8,-3) Rotation: (23.11, 42.05, 265.38) Tag: Suck it Durability: 100 Stack: 1 Quality: 1 Variant: 0 Crafter:  (0) WorldLevel: 0 PickedUp: False [deleted]

       - Prefab: TrainingDummy Id: 4864 UserId: 1 Position: (-503.27, 42.48, -216.56)(-8,-3) Rotation: (0.00, 0.00, 10.00) Tag: Suck it Level: 1 Health: 38743.26/40000 Tamed: False [deleted]
       Deleting 2 objects:
       - Prefab: Fish8 Id: 4863 UserId: 1 Position: (-502.88, 41.92, -219.18)(-8,-3) Rotation: (23.11, 42.05, 265.38) Tag: Suck it Durability: 100 Stack: 1 Quality: 1 Variant: 0 Crafter:  (0) WorldLevel: 0 PickedUp: False [deleted]

       - Prefab: TrainingDummy Id: 4864 UserId: 1 Position: (-503.27, 42.48, -216.56)(-8,-3) Rotation: (0.00, 0.00, 10.00) Tag: Suck it Level: 1 Health: 38743.26/40000 Tamed: False [deleted]
     */
        [Test]
        public async Task DeleteObjects_WithOptions_SendsExpected()
        {
            //"TrainingDummy"//
            var s = _rcon;
            var opts = new DeleteObjectsOptions(Tag: "Suck it");

            var result = await s.DeleteObjectsAsync(opts);
            Console.WriteLine(result.Response);
            // Assert.That(result.OutgoingMessage, Is.EqualTo(expected));
            Assert.That(result.Response, Is.EqualTo("ok"));
        }

        [Test, Ignore("No more reginalds")]
        public async Task Spawn_WithOptions_SendsExpected()
        {
            var s = _rcon;
            var opts = new SpawnOptions(
                Count: 1,
                Radius: 10,
                Level: 200,
                Rotation: new(0, 90, 0),
                Tag: "Reginald",
                Tamed: true

            );
            var request = new SpawnRequest("Neck", _valheimServer.Players[0].Position, opts);
            var result = await s.SpawnAsync(request);

            Assert.That(result.Successful);


            /*
         Spawned 3 objects:
           - Prefab: Boar Id: 23879 UserId: 724413018 Position: (9.54, 5.00, 10.80)(0,0) Rotation: (0.00, 90.00, 0.00) Tag: tamedBoar Level: 2 Health: 20/20 Tamed: True
           - Prefab: Boar Id: 23880 UserId: 724413018 Position: (10.00, 5.00, 10.71)(0,0) Rotation: (0.00, 90.00, 0.00) Tag: tamedBoar Level: 2 Health: 20/20 Tamed: True
           - Prefab: Boar Id: 23881 UserId: 724413018 Position: (9.36, 5.00, 8.10)(0,0) Rotation: (0.00, 90.00, 0.00) Tag: tamedBoar Level: 2 Health: 20/20 Tamed: True
         */

        }

        [Test]
        public void DumpRPC()
        {

        }
        [Test]
        public async Task GetPlayersWorks()
        {
            var players = await _rcon.GetPlayersAsync();
            var dread = players.Result.FirstOrDefault(x => x.SteamId.Equals(DreadId.SteamId));
            Assert.That(dread != null);
            Assert.That(players.Successful);
            Assert.That(players.Result.Count > 0);
        }

        [Test]
        public async Task Players_ParsesList()
        {

            var players = await _rcon.GetPlayersAsync();
            var bob = players.Result[0];
            Console.WriteLine(players.Response);
            Assert.That(players.Result.Count, Is.GreaterThan(0));
            Assert.That(!string.IsNullOrEmpty(bob.Name));
            Assert.That(!string.IsNullOrEmpty(bob.SteamId));
        }


        [Test]
        public async Task BanList()
        {
            var players = await _rcon.GetBanListAsync();
            Console.WriteLine(players.Response);
            Assert.That(players.Successful);
            Assert.That(players.Result.Count == 0);
        }

        [Test]
        public async Task PermittedListAsync()
        {
            var players = await _rcon.GetPermittedListAsync();
            Console.WriteLine(players.Response);
            Assert.That(players.Successful);
            Assert.That(players.Result.Count == 0);
        }

        [Test]
        public async Task ServerStats_ParsesValues()
        {
            const string raw =
                "Players: 3 | FPS: 59.9 | Memory: 2048 MB | World: DedicatedWorld | Day: 12";

            var response = await _rcon.GetServerStatsAsync();
            Assert.That(response.Successful);
            Debug.WriteLine(response.Response);
            var stats = response.Result;



            Assert.That(stats, Is.Not.Null);
            Assert.That(stats!.Players >= 0);
            Assert.That(stats.Fps > 0);
            Assert.That(stats.MonoMemory > 0);
            Assert.That(stats.Objects > 0);
            Assert.That(stats.Day > 0);
        }

        [Test]
        public async Task Admins_ParseList()
        {
            var players = await _rcon.GetAdminListAsync();
            var bob = players.Result[0];
            Console.WriteLine(players.Response);
            Assert.That(players.Result.Count, Is.GreaterThan(0));
        }


        [Test]
        public async Task ShowMessageAsync_ShouldBeSuccessful()
        {
            var result = await _rcon.ShowMessageAsync("Eat my poop!");
            ProcessResult(result);
        }

        [Test]
        public async Task SayAsync_ShouldBeSuccessful()
        {
            var result = await _rcon.SayAsync("Broadcast Test");
            ProcessResult(result, "Say command should succeed.");
        }
        [TestCase("Bob", "I am bob! fear me!")]
        [TestCase("Zeb", "I am zeb! No, fear me!")]
        public async Task Impersonate(string name, string message)
        {
            var result = await _rcon.Impersonate(name, message);
            ProcessResult(result);
        }

        [Test]
        public async Task PingAsync_ShouldBeSuccessful()
        {
            var result = await _rcon.PingAsync(new(10f, 20f, 30f));
            ProcessResult(result);
        }

        [Test]
        public async Task FindPlayerRawAsync_ShouldBeSuccessful()
        {
            var result = await _rcon.FindPlayerRawAsync(DreadId.SteamId);
            ProcessResult(result);
        }

        [Test, Ignore("Dont kill me bro")]
        public async Task KillPlayerRawAsync_ShouldBeSuccessful()
        {
            var result = await _rcon.DamageAsync(new(LockId, 1000));
            ProcessResult(result);
        }
        [Test]
        public async Task GetTimeRawAsync_ShouldBeSuccessful()
        {
            var result = await _rcon.GetTimeAsync();
            ProcessResult(result, "FindPlayerRaw command should succeed.");
            Assert.That(result.Result.Day > 0);
        }

        [Test]
        public async Task Save_ShouldBeSuccessful()
        {
            var result = await _rcon.SaveAsync();

            ProcessResult(result, "Save command should succeed.");
        }
        [Test]
        public async Task ListCommandsAsync_ShouldBeSuccessful()
        {
            var result = await _rcon.ListCommandsAsync();
            ProcessResult(result, "ListCommandsAsync command should succeed.");
        }

        [Test]
        public async Task GetEvent()
        {
            var result = await _rcon.GetEvent();

            ProcessResult(result, "Save command should succeed.");
        }
        [Test]
        public async Task RaidBread()
        {
            var result = await _rcon.SendRaid(DreadId, ValheimEvent.ArmyTheElder);
            ProcessResult(result, "Save command should succeed.");
        }
        [Test]
        public async Task SetWind()
        {
            var request = new SetWindRequest(.5f, 5f);
            var result = await _rcon.SetWind(request);
            ProcessResult(result, "ResetWind command should succeed.");
        }
        [Test]
        public async Task ResetWind()
        {
            var result = await _rcon.ResetWind();
            ProcessResult(result, "ResetWind command should succeed.");
        }
        [TestCase(.5)]
        [TestCase(.9)]
        [TestCase(.3)]
        public async Task SetTime(double time)
        {
            var result = await _rcon.SetTime(time);
            ProcessResult(result, "SetTime command should succeed.");
            await Task.Delay(5000);
        }

        [Test]
        public async Task SetWeather()
        {
            var result = await _rcon.SetWeather("SwampRain");
            ProcessResult(result, "SetWeather command should succeed.");
        }
        [Test]
        public async Task SkipMorning()
        {
            var result = await _rcon.SkipMorning();
            ProcessResult(result, "SkipMorning command should succeed.");
        }

        [Test]
        public async Task StartRandomRaid()
        {
            var result = await _rcon.StartRandomRaid();
            ProcessResult(result, "StartRandomRaid");
        }


        [Test]
        public async Task StopRaid()
        {
            var result = await _rcon.StopRaid();
            ProcessResult(result, "StopRaid");
        }


        [Test, Ignore("Ruins the server dont do this")]
        public async Task SpawnEmAll()
        {
            foreach (var item in Strings.Spawns)
            {
                var result = await _valheimServer.SpawnOnPlayer(DreadId.SteamId, item);
                ProcessResult(result);
                await Task.Delay(1000);
            }

        }

        [Test, Ignore("reset wtf")]
        public async Task ResetWorld()
        {

            ProcessResult(await _valheimServer.Server.ConsoleCommandAsync("resetworld"));
        }

        [Test]
        public async Task Exploremap()
        {
            await _valheimServer.Server.ConsoleCommandAsync($"exploremap {DreadId}");
        }
        //
        //GetLogsAsync
    }
}
