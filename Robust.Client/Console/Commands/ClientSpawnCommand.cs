using JetBrains.Annotations;
using Robust.Client.Player;
using Robust.Shared.Console;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;

namespace Robust.Client.Console.Commands
{
    [UsedImplicitly]
    internal sealed class ClientSpawnCommand : IConsoleCommand
    {
        public string Command => "cspawn";
        public string Description => "Spawns a client-side entity with specific type at your feet.";
        public string Help => "cspawn <entity type>";

        public void Execute(IConsoleShell shell, string argStr, string[] args)
        {
            var controlled = IoCManager.Resolve<IPlayerManager>().LocalPlayer?.ControlledEntity ?? EntityUid.Invalid;
            if (controlled == EntityUid.Invalid)
            {
                shell.WriteLine("You don't have an attached entity.");
                return;
            }

            var entityManager = IoCManager.Resolve<IEntityManager>();
            entityManager.SpawnEntity(args[0], entityManager.GetComponent<TransformComponent>(controlled).Coordinates);
        }
    }
}
