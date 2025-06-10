namespace Expenser.Models
{
    public static class UserSession
    {
        public static User? CurrentUser { get; set; }

        public static void SaveCredentials(string username)
        {
            Properties.Settings.Default.SavedUsername = username;
            Properties.Settings.Default.RememberMe = true;
            Properties.Settings.Default.Save();
        }

        public static void ClearSavedCredentials()
        {
            Properties.Settings.Default.SavedUsername = string.Empty;
            Properties.Settings.Default.RememberMe = false;
            Properties.Settings.Default.Save();
        }
    }
}
