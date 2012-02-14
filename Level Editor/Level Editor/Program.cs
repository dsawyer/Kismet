using System;

namespace LevelEditor
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            ObjectEditor form = new ObjectEditor();
            form.Show();
            form.game = new Game1(form.pctSurface.Handle, form, form.pctSurface);
            form.game.Run();
        }
    }
#endif
}

