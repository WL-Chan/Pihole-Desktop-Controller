using System;

namespace PiholeController.Public
{
    /// <summary>
    /// Example Pi-hole command wrapper.
    /// This class demonstrates how SSH commands can be sent to Pi-hole.
    /// It is intentionally minimal and does NOT represent the full app logic.
    /// </summary>
    public class SshCommands
    {
        private readonly SshConnectionManager _ssh;

        public SshCommands(SshConnectionManager ssh)
        {
            _ssh = ssh ?? throw new ArgumentNullException(nameof(ssh));
        }
        public string GetStatus()
        {
            return _ssh.RunCommand("pihole status");
        }
        public void Enable()
        {
            _ssh.RunCommand("sudo pihole enable");
        }

        public void Disable()
        {
            _ssh.RunCommand("sudo pihole disable");
        }
        public void ReloadDns()
        {
            _ssh.RunCommand("sudo pihole reloaddns");
        }
        public string RunRaw(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                throw new ArgumentException("Command cannot be empty.");

            return _ssh.RunCommand(command);
        }
    }
}
