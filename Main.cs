using HarmonyLib;
using Verse;
using RimWorld;
using System.Reflection;

namespace KTNoPrisonBreaks
{
    [StaticConstructorOnStartup]
    public static class NoPrisonBreaks
    {
        static NoPrisonBreaks()
        {
            var harmony = new Harmony("com.noprisonbreaks.patch");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        [HarmonyPatch(typeof(PrisonBreakUtility), "StartPrisonBreak", new[] { typeof(Pawn), typeof(string), typeof(string), typeof(LetterDef) }, new ArgumentType[] { ArgumentType.Normal, ArgumentType.Out, ArgumentType.Out, ArgumentType.Out })]
        class PrisonBreakPatch
        {
            [HarmonyPrefix]
            static bool PrisonBreakPrefix()
            {
                Log.Message("Prison break suppressed by KasumiTakeshi's No Prison Breaks [1.1]");
                return false;
            }
        }
    }
}