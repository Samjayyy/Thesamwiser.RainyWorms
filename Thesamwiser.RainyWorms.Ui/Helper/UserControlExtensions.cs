namespace Thesamwiser.RainyWorms.Ui.Helper
{
    public static class UserControlExtensions
    {
        /// <summary>
        /// Clears and displose a collection of controls
        /// </summary>
        /// <param name="collection"></param>
        public static void ClearAndDispose(this System.Windows.Forms.Control.ControlCollection collection)
        {
            while (collection.Count > 0) collection[0].Dispose();
        }
    }
}
